namespace KartingClubApp
{
    partial class MainForm
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
            groupBoxRacers = new GroupBox();
            btnDeleteRacer = new Button();
            btnAddRacer = new Button();
            dgvRacers = new DataGridView();
            groupBoxSessions = new GroupBox();
            btnOpenSession = new Button();
            btnCreateSession = new Button();
            dgvSessions = new DataGridView();
            groupBoxRacers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRacers).BeginInit();
            groupBoxSessions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSessions).BeginInit();
            SuspendLayout();
            // 
            // groupBoxRacers
            // 
            groupBoxRacers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxRacers.Controls.Add(btnDeleteRacer);
            groupBoxRacers.Controls.Add(btnAddRacer);
            groupBoxRacers.Controls.Add(dgvRacers);
            groupBoxRacers.Location = new Point(12, 12);
            groupBoxRacers.Name = "groupBoxRacers";
            groupBoxRacers.Size = new Size(960, 300);
            groupBoxRacers.TabIndex = 0;
            groupBoxRacers.TabStop = false;
            groupBoxRacers.Text = "Гонщики";
            // 
            // btnDeleteRacer
            // 
            btnDeleteRacer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteRacer.Location = new Point(800, 75);
            btnDeleteRacer.Name = "btnDeleteRacer";
            btnDeleteRacer.Size = new Size(150, 40);
            btnDeleteRacer.TabIndex = 2;
            btnDeleteRacer.Text = "Видалити гонщика";
            btnDeleteRacer.UseVisualStyleBackColor = true;
            // 
            // btnAddRacer
            // 
            btnAddRacer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddRacer.Location = new Point(800, 25);
            btnAddRacer.Name = "btnAddRacer";
            btnAddRacer.Size = new Size(150, 40);
            btnAddRacer.TabIndex = 1;
            btnAddRacer.Text = "Додати гонщика";
            btnAddRacer.UseVisualStyleBackColor = true;
            // 
            // dgvRacers
            // 
            dgvRacers.AllowUserToAddRows = false;
            dgvRacers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRacers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRacers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRacers.Location = new Point(10, 25);
            dgvRacers.Name = "dgvRacers";
            dgvRacers.ReadOnly = true;
            dgvRacers.RowHeadersVisible = false;
            dgvRacers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRacers.Size = new Size(780, 260);
            dgvRacers.TabIndex = 0;
            // 
            // groupBoxSessions
            // 
            groupBoxSessions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxSessions.Controls.Add(btnOpenSession);
            groupBoxSessions.Controls.Add(btnCreateSession);
            groupBoxSessions.Controls.Add(dgvSessions);
            groupBoxSessions.Location = new Point(12, 320);
            groupBoxSessions.Name = "groupBoxSessions";
            groupBoxSessions.Size = new Size(960, 330);
            groupBoxSessions.TabIndex = 1;
            groupBoxSessions.TabStop = false;
            groupBoxSessions.Text = "Заїзди";
            // 
            // btnOpenSession
            // 
            btnOpenSession.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenSession.Location = new Point(800, 75);
            btnOpenSession.Name = "btnOpenSession";
            btnOpenSession.Size = new Size(150, 40);
            btnOpenSession.TabIndex = 2;
            btnOpenSession.Text = "Відкрити заїзд";
            btnOpenSession.UseVisualStyleBackColor = true;
            // 
            // btnCreateSession
            // 
            btnCreateSession.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreateSession.Location = new Point(800, 25);
            btnCreateSession.Name = "btnCreateSession";
            btnCreateSession.Size = new Size(150, 40);
            btnCreateSession.TabIndex = 1;
            btnCreateSession.Text = "Створити заїзд";
            btnCreateSession.UseVisualStyleBackColor = true;
            // 
            // dgvSessions
            // 
            dgvSessions.AllowUserToAddRows = false;
            dgvSessions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSessions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSessions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSessions.Location = new Point(10, 25);
            dgvSessions.Name = "dgvSessions";
            dgvSessions.ReadOnly = true;
            dgvSessions.RowHeadersVisible = false;
            dgvSessions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSessions.Size = new Size(780, 290);
            dgvSessions.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 749);
            Controls.Add(groupBoxSessions);
            Controls.Add(groupBoxRacers);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Адміністратор картинг-клубу";
            groupBoxRacers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRacers).EndInit();
            groupBoxSessions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSessions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxRacers;
        private DataGridView dgvRacers;
        private Button btnDeleteRacer;
        private Button btnAddRacer;
        private GroupBox groupBoxSessions;
        private Button btnOpenSession;
        private Button btnCreateSession;
        private DataGridView dgvSessions;
    }
}
