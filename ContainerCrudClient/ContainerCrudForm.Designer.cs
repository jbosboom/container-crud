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
            dataGridView1 = new DataGridView();
            urlBox = new TextBox();
            label1 = new Label();
            connectBtn = new Button();
            saveBtn = new Button();
            discardBtn = new Button();
            newBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(776, 397);
            dataGridView1.TabIndex = 0;
            // 
            // urlBox
            // 
            urlBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            urlBox.Location = new Point(94, 415);
            urlBox.Name = "urlBox";
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
            // 
            // saveBtn
            // 
            saveBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveBtn.Location = new Point(700, 415);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(88, 23);
            saveBtn.TabIndex = 4;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            // 
            // discardBtn
            // 
            discardBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            discardBtn.Location = new Point(606, 415);
            discardBtn.Name = "discardBtn";
            discardBtn.Size = new Size(88, 23);
            discardBtn.TabIndex = 5;
            discardBtn.Text = "Discard";
            discardBtn.UseVisualStyleBackColor = true;
            // 
            // newBtn
            // 
            newBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            newBtn.Location = new Point(512, 415);
            newBtn.Name = "newBtn";
            newBtn.Size = new Size(88, 23);
            newBtn.TabIndex = 6;
            newBtn.Text = "New Item";
            newBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(newBtn);
            Controls.Add(discardBtn);
            Controls.Add(saveBtn);
            Controls.Add(connectBtn);
            Controls.Add(label1);
            Controls.Add(urlBox);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox urlBox;
        private Label label1;
        private Button connectBtn;
        private Button saveBtn;
        private Button discardBtn;
        private Button newBtn;
    }
}