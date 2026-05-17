namespace KartingClubApp
{
    partial class FinishSessionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlInfo = new Panel();
            lblStatus = new Label();
            lblDate = new Label();
            lblTrack = new Label();
            pnlBottom = new Panel();
            btnClose = new Button();
            btnFinish = new Button();
            lblError = new Label();
            dgvResults = new DataGridView();
            pnlInfo.SuspendLayout();
            pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // pnlInfo
            // 
            pnlInfo.BorderStyle = BorderStyle.FixedSingle;
            pnlInfo.Controls.Add(lblStatus);
            pnlInfo.Controls.Add(lblDate);
            pnlInfo.Controls.Add(lblTrack);
            pnlInfo.Dock = DockStyle.Top;
            pnlInfo.Location = new Point(0, 0);
            pnlInfo.Name = "pnlInfo";
            pnlInfo.Size = new Size(544, 85);
            pnlInfo.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(15, 56);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(57, 19);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Статус: ";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(15, 33);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(46, 19);
            lblDate.TabIndex = 1;
            lblDate.Text = "Дата: ";
            // 
            // lblTrack
            // 
            lblTrack.AutoSize = true;
            lblTrack.Location = new Point(15, 10);
            lblTrack.Name = "lblTrack";
            lblTrack.Size = new Size(51, 19);
            lblTrack.TabIndex = 0;
            lblTrack.Text = "Траса: ";
            // 
            // pnlBottom
            // 
            pnlBottom.Controls.Add(btnClose);
            pnlBottom.Controls.Add(btnFinish);
            pnlBottom.Controls.Add(lblError);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 401);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(544, 120);
            pnlBottom.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(380, 70);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 35);
            btnClose.TabIndex = 2;
            btnClose.Text = "Закрити";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnFinish
            // 
            btnFinish.Location = new Point(380, 70);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new Size(150, 35);
            btnFinish.TabIndex = 1;
            btnFinish.Text = "Завершити заїзд";
            btnFinish.UseVisualStyleBackColor = true;
            btnFinish.Click += btnFinish_Click;
            // 
            // lblError
            // 
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(15, 6);
            lblError.Name = "lblError";
            lblError.Size = new Size(510, 110);
            lblError.TabIndex = 0;
            // 
            // dgvResults
            // 
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Dock = DockStyle.Fill;
            dgvResults.Location = new Point(0, 85);
            dgvResults.Name = "dgvResults";
            dgvResults.Size = new Size(544, 316);
            dgvResults.TabIndex = 2;
            dgvResults.KeyDown += dgvResults_KeyDown;
            // 
            // FinishSessionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(544, 521);
            Controls.Add(dgvResults);
            Controls.Add(pnlBottom);
            Controls.Add(pnlInfo);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FinishSessionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Фіксація результатів заїзду";
            pnlInfo.ResumeLayout(false);
            pnlInfo.PerformLayout();
            pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlInfo;
        private Label lblTrack;
        private Label lblStatus;
        private Label lblDate;
        private Panel pnlBottom;
        private Button btnFinish;
        private Label lblError;
        private Button btnClose;
        private DataGridView dgvResults;
    }
}