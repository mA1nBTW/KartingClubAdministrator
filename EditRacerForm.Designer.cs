namespace KartingClubApp
{
    partial class EditRacerForm
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
            btnCancel = new Button();
            btnSave = new Button();
            lblError = new Label();
            cmbCategory = new ComboBox();
            label4 = new Label();
            txtLicense = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(312, 283);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 21;
            btnCancel.Text = "Скасувати";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(202, 283);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 20;
            btnSave.Text = "Зберегти";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblError
            // 
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(22, 243);
            lblError.Name = "lblError";
            lblError.Size = new Size(390, 35);
            lblError.TabIndex = 19;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(22, 206);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(390, 25);
            cmbCategory.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 184);
            label4.Name = "label4";
            label4.Size = new Size(130, 19);
            label4.TabIndex = 17;
            label4.Text = "Категорія гонщика:";
            // 
            // txtLicense
            // 
            txtLicense.Location = new Point(22, 149);
            txtLicense.Name = "txtLicense";
            txtLicense.Size = new Size(390, 25);
            txtLicense.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 127);
            label3.Name = "label3";
            label3.Size = new Size(159, 19);
            label3.TabIndex = 15;
            label3.Text = "Номер ліцензії (картки):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 70);
            label2.Name = "label2";
            label2.Size = new Size(73, 19);
            label2.TabIndex = 14;
            label2.Text = "Прізвище:";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(22, 92);
            txtLastName.MaxLength = 50;
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(390, 25);
            txtLastName.TabIndex = 13;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(22, 35);
            txtFirstName.MaxLength = 50;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(390, 25);
            txtFirstName.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 13);
            label1.Name = "label1";
            label1.Size = new Size(36, 19);
            label1.TabIndex = 11;
            label1.Text = "Ім'я:";
            // 
            // EditRacerForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(434, 331);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblError);
            Controls.Add(cmbCategory);
            Controls.Add(label4);
            Controls.Add(txtLicense);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditRacerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Редагування даних гонщика";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Button btnSave;
        private Label lblError;
        private ComboBox cmbCategory;
        private Label label4;
        private TextBox txtLicense;
        private Label label3;
        private Label label2;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Label label1;
    }
}