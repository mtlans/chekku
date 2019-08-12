namespace Chekku
{
    partial class Chekku
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chekku));
            this.btnClose = new System.Windows.Forms.Button();
            this.Reports = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnQuestions = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnSections = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnStudents = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnSubjects = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnExam = new Bunifu.Framework.UI.BunifuTileButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(902, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(26, 27);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // Reports
            // 
            this.Reports.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Reports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.Reports.color = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.Reports.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.Reports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Reports.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reports.ForeColor = System.Drawing.Color.White;
            this.Reports.Image = ((System.Drawing.Image)(resources.GetObject("Reports.Image")));
            this.Reports.ImagePosition = 17;
            this.Reports.ImageZoom = 50;
            this.Reports.LabelPosition = 37;
            this.Reports.LabelText = "REPORTS";
            this.Reports.Location = new System.Drawing.Point(701, 333);
            this.Reports.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Reports.Name = "Reports";
            this.Reports.Size = new System.Drawing.Size(121, 161);
            this.Reports.TabIndex = 12;
            this.Reports.Click += new System.EventHandler(this.Reports_Click);
            // 
            // btnQuestions
            // 
            this.btnQuestions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnQuestions.color = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnQuestions.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnQuestions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuestions.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuestions.ForeColor = System.Drawing.Color.White;
            this.btnQuestions.Image = ((System.Drawing.Image)(resources.GetObject("btnQuestions.Image")));
            this.btnQuestions.ImagePosition = 17;
            this.btnQuestions.ImageZoom = 50;
            this.btnQuestions.LabelPosition = 37;
            this.btnQuestions.LabelText = "QUESTIONS";
            this.btnQuestions.Location = new System.Drawing.Point(574, 333);
            this.btnQuestions.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnQuestions.Name = "btnQuestions";
            this.btnQuestions.Size = new System.Drawing.Size(121, 161);
            this.btnQuestions.TabIndex = 11;
            this.btnQuestions.Click += new System.EventHandler(this.BtnQuestions_Click);
            // 
            // btnSections
            // 
            this.btnSections.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnSections.color = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnSections.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnSections.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSections.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSections.ForeColor = System.Drawing.Color.White;
            this.btnSections.Image = ((System.Drawing.Image)(resources.GetObject("btnSections.Image")));
            this.btnSections.ImagePosition = 17;
            this.btnSections.ImageZoom = 50;
            this.btnSections.LabelPosition = 37;
            this.btnSections.LabelText = "SECTIONS";
            this.btnSections.Location = new System.Drawing.Point(450, 333);
            this.btnSections.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnSections.Name = "btnSections";
            this.btnSections.Size = new System.Drawing.Size(121, 161);
            this.btnSections.TabIndex = 10;
            this.btnSections.Click += new System.EventHandler(this.BtnSection_Click);
            // 
            // btnStudents
            // 
            this.btnStudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnStudents.color = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnStudents.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnStudents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStudents.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudents.ForeColor = System.Drawing.Color.White;
            this.btnStudents.Image = ((System.Drawing.Image)(resources.GetObject("btnStudents.Image")));
            this.btnStudents.ImagePosition = 17;
            this.btnStudents.ImageZoom = 50;
            this.btnStudents.LabelPosition = 37;
            this.btnStudents.LabelText = "STUDENTS";
            this.btnStudents.Location = new System.Drawing.Point(326, 333);
            this.btnStudents.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Size = new System.Drawing.Size(121, 161);
            this.btnStudents.TabIndex = 9;
            this.btnStudents.Click += new System.EventHandler(this.BtnStudents_Click);
            // 
            // btnSubjects
            // 
            this.btnSubjects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnSubjects.color = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnSubjects.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnSubjects.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubjects.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubjects.ForeColor = System.Drawing.Color.White;
            this.btnSubjects.Image = ((System.Drawing.Image)(resources.GetObject("btnSubjects.Image")));
            this.btnSubjects.ImagePosition = 17;
            this.btnSubjects.ImageZoom = 50;
            this.btnSubjects.LabelPosition = 37;
            this.btnSubjects.LabelText = "SUBJECTS";
            this.btnSubjects.Location = new System.Drawing.Point(202, 333);
            this.btnSubjects.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnSubjects.Name = "btnSubjects";
            this.btnSubjects.Size = new System.Drawing.Size(121, 161);
            this.btnSubjects.TabIndex = 8;
            this.btnSubjects.Click += new System.EventHandler(this.BtnSubjects_Click);
            // 
            // btnExam
            // 
            this.btnExam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnExam.color = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnExam.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnExam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExam.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExam.ForeColor = System.Drawing.Color.White;
            this.btnExam.Image = ((System.Drawing.Image)(resources.GetObject("btnExam.Image")));
            this.btnExam.ImagePosition = 17;
            this.btnExam.ImageZoom = 50;
            this.btnExam.LabelPosition = 37;
            this.btnExam.LabelText = "EXAMS";
            this.btnExam.Location = new System.Drawing.Point(78, 333);
            this.btnExam.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExam.Name = "btnExam";
            this.btnExam.Size = new System.Drawing.Size(121, 161);
            this.btnExam.TabIndex = 7;
            this.btnExam.Click += new System.EventHandler(this.BtnExams_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-17, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(975, 261);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            // 
            // Chekku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(940, 580);
            this.Controls.Add(this.Reports);
            this.Controls.Add(this.btnQuestions);
            this.Controls.Add(this.btnSections);
            this.Controls.Add(this.btnStudents);
            this.Controls.Add(this.btnSubjects);
            this.Controls.Add(this.btnExam);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Chekku";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chekku";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Chekku_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClose;
        private Bunifu.Framework.UI.BunifuTileButton btnExam;
        private Bunifu.Framework.UI.BunifuTileButton btnSubjects;
        private Bunifu.Framework.UI.BunifuTileButton btnStudents;
        private Bunifu.Framework.UI.BunifuTileButton btnSections;
        private Bunifu.Framework.UI.BunifuTileButton btnQuestions;
        private Bunifu.Framework.UI.BunifuTileButton Reports;
    }
}

