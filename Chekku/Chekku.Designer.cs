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
            this.btnSubjects = new System.Windows.Forms.Button();
            this.btnExam = new System.Windows.Forms.Button();
            this.btnStudents = new System.Windows.Forms.Button();
            this.btnSection = new System.Windows.Forms.Button();
            this.btnQuestions = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSubjects
            // 
            this.btnSubjects.Location = new System.Drawing.Point(289, 163);
            this.btnSubjects.Name = "btnSubjects";
            this.btnSubjects.Size = new System.Drawing.Size(124, 68);
            this.btnSubjects.TabIndex = 0;
            this.btnSubjects.Text = "Subjects";
            this.btnSubjects.UseVisualStyleBackColor = true;
            this.btnSubjects.Click += new System.EventHandler(this.BtnSubjects_Click);
            // 
            // btnExam
            // 
            this.btnExam.Location = new System.Drawing.Point(140, 163);
            this.btnExam.Name = "btnExam";
            this.btnExam.Size = new System.Drawing.Size(124, 68);
            this.btnExam.TabIndex = 1;
            this.btnExam.Text = "Exams";
            this.btnExam.UseVisualStyleBackColor = true;
            this.btnExam.Click += new System.EventHandler(this.BtnExams_Click);
            // 
            // btnStudents
            // 
            this.btnStudents.Location = new System.Drawing.Point(441, 163);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Size = new System.Drawing.Size(124, 68);
            this.btnStudents.TabIndex = 2;
            this.btnStudents.Text = "Students";
            this.btnStudents.UseVisualStyleBackColor = true;
            this.btnStudents.Click += new System.EventHandler(this.BtnStudents_Click);
            // 
            // btnSection
            // 
            this.btnSection.Location = new System.Drawing.Point(289, 250);
            this.btnSection.Name = "btnSection";
            this.btnSection.Size = new System.Drawing.Size(124, 68);
            this.btnSection.TabIndex = 3;
            this.btnSection.Text = "Sections";
            this.btnSection.UseVisualStyleBackColor = true;
            this.btnSection.Click += new System.EventHandler(this.BtnSection_Click);
            // 
            // btnQuestions
            // 
            this.btnQuestions.Location = new System.Drawing.Point(140, 250);
            this.btnQuestions.Name = "btnQuestions";
            this.btnQuestions.Size = new System.Drawing.Size(124, 68);
            this.btnQuestions.TabIndex = 4;
            this.btnQuestions.Text = "Questions";
            this.btnQuestions.UseVisualStyleBackColor = true;
            this.btnQuestions.Click += new System.EventHandler(this.BtnQuestions_Click);
            // 
            // Chekku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1050, 508);
            this.Controls.Add(this.btnQuestions);
            this.Controls.Add(this.btnSection);
            this.Controls.Add(this.btnStudents);
            this.Controls.Add(this.btnExam);
            this.Controls.Add(this.btnSubjects);
            this.Name = "Chekku";
            this.Text = "Chekku";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSubjects;
        private System.Windows.Forms.Button btnExam;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnSection;
        private System.Windows.Forms.Button btnQuestions;
    }
}

