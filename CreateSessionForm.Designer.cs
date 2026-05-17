namespace KartingClubApp
{
    partial class CreateSessionForm
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
            label1 = new Label();
            dtpSessionDate = new DateTimePicker();
            label2 = new Label();
            txtTrackName = new TextBox();
            label3 = new Label();
            nudDuration = new NumericUpDown();
            label4 = new Label();
            clbRacers = new CheckedListBox();
            lblError = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)nudDuration).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(180, 19);
            label1.TabIndex = 0;
            label1.Text = "Дата та час початку заїзду:";
            // 
            // dtpSessionDate
            // 
            dtpSessionDate.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpSessionDate.Format = DateTimePickerFormat.Custom;
            dtpSessionDate.Location = new Point(20, 42);
            dtpSessionDate.Name = "dtpSessionDate";
            dtpSessionDate.Size = new Size(420, 25);
            dtpSessionDate.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 77);
            label2.Name = "label2";
            label2.Size = new Size(88, 19);
            label2.TabIndex = 2;
            label2.Text = "Назва траси:";
            // 
            // txtTrackName
            // 
            txtTrackName.Location = new Point(20, 99);
            txtTrackName.MaxLength = 100;
            txtTrackName.Name = "txtTrackName";
            txtTrackName.Size = new Size(420, 25);
            txtTrackName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 134);
            label3.Name = "label3";
            label3.Size = new Size(144, 19);
            label3.TabIndex = 4;
            label3.Text = "Тривалість заїзду (хв):";
            // 
            // nudDuration
            // 
            nudDuration.Location = new Point(20, 156);
            nudDuration.Maximum = new decimal(new int[] { 480, 0, 0, 0 });
            nudDuration.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDuration.Name = "nudDuration";
            nudDuration.Size = new Size(120, 25);
            nudDuration.TabIndex = 5;
            nudDuration.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 191);
            label4.Name = "label4";
            label4.Size = new Size(245, 19);
            label4.TabIndex = 6;
            label4.Text = "Оберіть гонщиків (поставте галочки):";
            // 
            // clbRacers
            // 
            clbRacers.CheckOnClick = true;
            clbRacers.FormattingEnabled = true;
            clbRacers.Location = new Point(20, 213);
            clbRacers.Name = "clbRacers";
            clbRacers.Size = new Size(420, 164);
            clbRacers.TabIndex = 7;
            // 
            // lblError
            // 
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(20, 405);
            lblError.Name = "lblError";
            lblError.Size = new Size(420, 35);
            lblError.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(230, 455);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 9;
            btnSave.Text = "Зберегти";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(340, 455);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Скасувати";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // CreateSessionForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(464, 511);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblError);
            Controls.Add(clbRacers);
            Controls.Add(label4);
            Controls.Add(nudDuration);
            Controls.Add(label3);
            Controls.Add(txtTrackName);
            Controls.Add(label2);
            Controls.Add(dtpSessionDate);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateSessionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Формування нового заїзду";
            ((System.ComponentModel.ISupportInitialize)nudDuration).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpSessionDate;
        private Label label2;
        private TextBox txtTrackName;
        private Label label3;
        private NumericUpDown nudDuration;
        private Label label4;
        private CheckedListBox clbRacers;
        private Label lblError;
        private Button btnSave;
        private Button btnCancel;
    }
}