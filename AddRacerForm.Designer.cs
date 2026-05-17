namespace KartingClubApp
{
    partial class AddRacerForm
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
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtLicense = new TextBox();
            label4 = new Label();
            cmbCategory = new ComboBox();
            lblError = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(36, 19);
            label1.TabIndex = 0;
            label1.Text = "Ім'я:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(20, 42);
            txtFirstName.MaxLength = 50;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(390, 25);
            txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(20, 99);
            txtLastName.MaxLength = 50;
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(390, 25);
            txtLastName.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 77);
            label2.Name = "label2";
            label2.Size = new Size(73, 19);
            label2.TabIndex = 3;
            label2.Text = "Прізвище:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 134);
            label3.Name = "label3";
            label3.Size = new Size(159, 19);
            label3.TabIndex = 4;
            label3.Text = "Номер ліцензії (картки):";
            // 
            // txtLicense
            // 
            txtLicense.Location = new Point(20, 156);
            txtLicense.Name = "txtLicense";
            txtLicense.Size = new Size(390, 25);
            txtLicense.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 191);
            label4.Name = "label4";
            label4.Size = new Size(130, 19);
            label4.TabIndex = 6;
            label4.Text = "Категорія гонщика:";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(20, 213);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(390, 25);
            cmbCategory.TabIndex = 7;
            // 
            // lblError
            // 
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(20, 250);
            lblError.Name = "lblError";
            lblError.Size = new Size(390, 35);
            lblError.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(200, 290);
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
            btnCancel.Location = new Point(310, 290);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Скасувати";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddRacerForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(434, 375);
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
            Name = "AddRacerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Реєстрація нового гонщика";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private Label label2;
        private Label label3;
        private TextBox txtLicense;
        private Label label4;
        private ComboBox cmbCategory;
        private Label lblError;
        private Button btnSave;
        private Button btnCancel;
    }
}