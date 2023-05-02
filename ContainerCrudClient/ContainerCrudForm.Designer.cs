namespace ContainerCrudClient
{
    partial class ContainerCrudForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gridCtrl = new DataGridView();
            urlBox = new TextBox();
            label1 = new Label();
            connectBtn = new Button();
            saveBtn = new Button();
            refreshBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)gridCtrl).BeginInit();
            SuspendLayout();
            // 
            // gridCtrl
            // 
            gridCtrl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridCtrl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            gridCtrl.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridCtrl.Enabled = false;
            gridCtrl.Location = new Point(12, 12);
            gridCtrl.Name = "gridCtrl";
            gridCtrl.RowTemplate.Height = 25;
            gridCtrl.Size = new Size(776, 397);
            gridCtrl.TabIndex = 0;
            gridCtrl.CellValidated += gridCtrl_CellValidated;
            gridCtrl.CellValueChanged += gridCtrl_CellValueChanged;
            gridCtrl.DataError += gridCtrl_DataError;
            gridCtrl.DefaultValuesNeeded += gridCtrl_DefaultValuesNeeded;
            gridCtrl.RowValidated += gridCtrl_RowValidated;
            gridCtrl.UserDeletingRow += gridCtrl_UserDeletingRow;
            // 
            // urlBox
            // 
            urlBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            urlBox.Location = new Point(94, 415);
            urlBox.Name = "urlBox";
            urlBox.PlaceholderText = "http://localhost:5289";
            urlBox.Size = new Size(310, 23);
            urlBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(12, 419);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 2;
            label1.Text = "API Base URL";
            // 
            // connectBtn
            // 
            connectBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            connectBtn.Location = new Point(410, 415);
            connectBtn.Name = "connectBtn";
            connectBtn.Size = new Size(75, 23);
            connectBtn.TabIndex = 3;
            connectBtn.Text = "Connect";
            connectBtn.UseVisualStyleBackColor = true;
            connectBtn.Click += connectBtn_Click;
            // 
            // saveBtn
            // 
            saveBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveBtn.Enabled = false;
            saveBtn.Location = new Point(700, 415);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(88, 23);
            saveBtn.TabIndex = 4;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // refreshBtn
            // 
            refreshBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            refreshBtn.Enabled = false;
            refreshBtn.Location = new Point(606, 415);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(88, 23);
            refreshBtn.TabIndex = 5;
            refreshBtn.Text = "Refresh";
            refreshBtn.UseVisualStyleBackColor = true;
            refreshBtn.Click += refreshBtn_Click;
            // 
            // ContainerCrudForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(refreshBtn);
            Controls.Add(saveBtn);
            Controls.Add(connectBtn);
            Controls.Add(label1);
            Controls.Add(urlBox);
            Controls.Add(gridCtrl);
            Name = "ContainerCrudForm";
            Text = "Container CRUD Client";
            ((System.ComponentModel.ISupportInitialize)gridCtrl).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gridCtrl;
        private TextBox urlBox;
        private Label label1;
        private Button connectBtn;
        private Button saveBtn;
        private Button refreshBtn;
    }
}