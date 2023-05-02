using System.Net.Http.Json;

namespace ContainerCrudClient
{
    public partial class ContainerCrudForm : Form
    {
        private HttpClient? _httpClient;
        private List<Container> _modifiedRows = new();
        private List<long> _deletedRows = new();
        // Rows not yet saved to the database are assigned negative IDs.
        private long _newRowContainerKey = -1;

        public ContainerCrudForm()
        {
            InitializeComponent();

            var binding = new BindingSource();
            binding.DataSource = new List<Container>();
            gridCtrl.DataSource = binding;

            gridCtrl.Columns["ContainerKey"].ReadOnly = true;
        }

        private async void connectBtn_Click(object sender, EventArgs e)
        {
            Uri url;
            if (!Uri.TryCreate(urlBox.Text, UriKind.Absolute, out url))
            {
                MessageBox.Show("The connection URL is invalid.");
                return;
            }

            connectBtn.Enabled = false;

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = url;
            if (!await LoadFromDatabase())
            {
                MessageBox.Show("Failed to connect to the database.");
                _httpClient.Dispose();
                _httpClient = null;
                connectBtn.Enabled = true;
            }
            else
            {
                saveBtn.Enabled = true;
                refreshBtn.Enabled = true;
            }
        }

        private async Task<bool> LoadFromDatabase()
        {
            var binding = (BindingSource)gridCtrl.DataSource;
            List<Container>? containers;
            try
            {
                containers = await _httpClient.GetFromJsonAsync<List<Container>>("/api/Container");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while connecting to the database:\n" + ex.ToString(), "Connection error");
                binding.DataSource = new List<Container>();
                gridCtrl.Enabled = false;
                return false;
            }
            binding.DataSource = containers!;
            gridCtrl.Enabled = true;
            return true;
        }

        private void gridCtrl_DefaultValuesNeeded(object? sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["ContainerKey"].Value = _newRowContainerKey;
            --_newRowContainerKey;
            e.Row.Cells["CreateTime"].Value = e.Row.Cells["UpdateTime"].Value = DateTime.Now;
        }

        private void gridCtrl_UserDeletingRow(object? sender, DataGridViewRowCancelEventArgs e)
        {
            Container c = (Container)e.Row.DataBoundItem;
            if (c.ContainerKey >= 0)
            {
                _modifiedRows.Remove(c); //may or may not be modified
                _deletedRows.Add(c.ContainerKey);
            }
        }

        private void gridCtrl_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == gridCtrl.NewRowIndex)
                return;
            Container c = (Container)gridCtrl.Rows[e.RowIndex].DataBoundItem;
            if (c.ContainerKey >= 0)
                _modifiedRows.Add(c);
        }

        private void gridCtrl_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gridCtrl.RowCount)
            {
                gridCtrl.Rows[e.RowIndex].ErrorText = "data validation error";
                if (e.ColumnIndex >= 0 && e.ColumnIndex < gridCtrl.ColumnCount)
                    gridCtrl.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "data validation error";
            }
            e.ThrowException = false;
        }

        private void gridCtrl_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            gridCtrl.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;
        }

        private void gridCtrl_RowValidated(object? sender, DataGridViewCellEventArgs e)
        {
            gridCtrl.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        private async void saveBtn_Click(object sender, EventArgs e)
        {
            saveBtn.Enabled = false;
            refreshBtn.Enabled = false;

            List<string> errors = new();
            // RemoveAll can't be called with an async lambda.
            List<Container> remainingModifiedRows = new();
            foreach (Container c in _modifiedRows)
            {
                using var resp = await _httpClient.PutAsJsonAsync($"/api/Container/{c.ContainerKey}", c);
                if (!resp.IsSuccessStatusCode)
                {
                    remainingModifiedRows.Add(c);
                    errors.Add($"PUT of container {c.ContainerKey} returned {resp.StatusCode}");
                }
            }
            _modifiedRows = remainingModifiedRows;

            List<long> remainingDeletedRows = new();
            foreach (long id in _deletedRows)
            {
                using var resp = await _httpClient.DeleteAsync($"/api/Container/{id}");
                if (!resp.IsSuccessStatusCode)
                {
                    remainingDeletedRows.Add(id);
                    errors.Add($"DELETE of container {id} returned {resp.StatusCode}");
                }
            }
            _deletedRows = remainingDeletedRows;

            BindingSource binding = (BindingSource)gridCtrl.DataSource;
            bool redrawGrid = false;
            foreach (Container c in binding)
            {
                if (c.ContainerKey >= 0)
                    continue;
                var placeholderId = c.ContainerKey;
                c.ContainerKey = 0;
                using var resp = await _httpClient.PostAsJsonAsync($"/api/Container", c);
                if (!resp.IsSuccessStatusCode)
                {
                    c.ContainerKey = placeholderId;
                    errors.Add($"POST of new container {c.ContainerKey} returned {resp.StatusCode}");
                }
                else
                {
                    c.ContainerKey = (await resp.Content.ReadFromJsonAsync<Container>()).ContainerKey;
                    redrawGrid = true;
                }
            }

            if (errors.Count > 0)
            {
                string message = "Errors occurred while saving changes to the database." +
                        "You may try saving again, or refresh to discard the unsaved changes.\n";
                message += string.Join("\n", errors);
                MessageBox.Show(message, "Errors occurred while saving");
            }

            saveBtn.Enabled = true;
            refreshBtn.Enabled = true;

            if (redrawGrid)
                binding.ResetBindings(false);
        }

        private async void refreshBtn_Click(object sender, EventArgs e)
        {
            List<Container> containers = (List<Container>)((BindingSource)gridCtrl.DataSource).List;
            bool hasNewRows = !containers.All(c => c.ContainerKey >= 0);
            if (_modifiedRows.Any() || _deletedRows.Any() || hasNewRows)
                if (MessageBox.Show("Refreshing will discard unsaved changes.  Refresh anyway?",
                        "Discarding changes", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

            _modifiedRows.Clear();
            _deletedRows.Clear();
            if (hasNewRows)
                containers.RemoveAll(c => c.ContainerKey < 0);

            saveBtn.Enabled = false;
            refreshBtn.Enabled = false;
            if (!await LoadFromDatabase())
                MessageBox.Show("An error occurred while refreshing.");
            saveBtn.Enabled = true;
            refreshBtn.Enabled = true;
        }
    }
}