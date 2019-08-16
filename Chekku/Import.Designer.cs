namespace Chekku
{
    partial class Import
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Import));
            this.txtFilename = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnImport = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblImport = new System.Windows.Forms.Label();
            this.lblQues = new System.Windows.Forms.Label();
            this.btnUploadReport = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFilename
            // 
            this.txtFilename.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.txtFilename.ReadOnly= false;
            this.txtFilename.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilename.Location = new System.Drawing.Point(104, 86);
            this.txtFilename.MaxLength = 7;
            this.txtFilename.Multiline = true;
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(208, 23);
            this.txtFilename.TabIndex = 60;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 86);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 21);
            this.label4.TabIndex = 59;
            this.label4.Text = "Filename:";
            // 
            // btnCancel
            // 
            this.btnCancel.ActiveBorderThickness = 1;
            this.btnCancel.ActiveCornerRadius = 20;
            this.btnCancel.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnCancel.ActiveForecolor = System.Drawing.Color.White;
            this.btnCancel.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.ButtonText = "Cancel";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IdleBorderThickness = 1;
            this.btnCancel.IdleCornerRadius = 20;
            this.btnCancel.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnCancel.IdleForecolor = System.Drawing.Color.White;
            this.btnCancel.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnCancel.Location = new System.Drawing.Point(27, 131);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 59);
            this.btnCancel.TabIndex = 64;
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnImport
            // 
            this.btnImport.ActiveBorderThickness = 1;
            this.btnImport.ActiveCornerRadius = 20;
            this.btnImport.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnImport.ActiveForecolor = System.Drawing.Color.White;
            this.btnImport.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnImport.BackColor = System.Drawing.SystemColors.Control;
            this.btnImport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImport.BackgroundImage")));
            this.btnImport.ButtonText = "Upload File";
            this.btnImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImport.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.IdleBorderThickness = 1;
            this.btnImport.IdleCornerRadius = 20;
            this.btnImport.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnImport.IdleForecolor = System.Drawing.Color.White;
            this.btnImport.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnImport.Location = new System.Drawing.Point(212, 131);
            this.btnImport.Margin = new System.Windows.Forms.Padding(5);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(100, 59);
            this.btnImport.TabIndex = 63;
            this.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnImport.Visible = false;
            this.btnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.panel1.Controls.Add(this.lblImport);
            this.panel1.Controls.Add(this.lblQues);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 46);
            this.panel1.TabIndex = 65;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            this.lblImport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImport.ForeColor = System.Drawing.Color.White;
            this.lblImport.Location = new System.Drawing.Point(92, 13);
            this.lblImport.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(158, 21);
            this.lblImport.TabIndex = 67;
            this.lblImport.Text = "IMPORT REPORT FILE";
            this.lblImport.Visible = false;
            // 
            // lblQues
            // 
            this.lblQues.AutoSize = true;
            this.lblQues.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQues.ForeColor = System.Drawing.Color.White;
            this.lblQues.Location = new System.Drawing.Point(94, 13);
            this.lblQues.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQues.Name = "lblQues";
            this.lblQues.Size = new System.Drawing.Size(155, 21);
            this.lblQues.TabIndex = 52;
            this.lblQues.Text = "IMPORT QUESTIONS";
            // 
            // btnUploadReport
            // 
            this.btnUploadReport.ActiveBorderThickness = 1;
            this.btnUploadReport.ActiveCornerRadius = 20;
            this.btnUploadReport.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnUploadReport.ActiveForecolor = System.Drawing.Color.White;
            this.btnUploadReport.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnUploadReport.BackColor = System.Drawing.SystemColors.Control;
            this.btnUploadReport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUploadReport.BackgroundImage")));
            this.btnUploadReport.ButtonText = "Upload File";
            this.btnUploadReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUploadReport.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadReport.ForeColor = System.Drawing.Color.White;
            this.btnUploadReport.IdleBorderThickness = 1;
            this.btnUploadReport.IdleCornerRadius = 20;
            this.btnUploadReport.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnUploadReport.IdleForecolor = System.Drawing.Color.White;
            this.btnUploadReport.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnUploadReport.Location = new System.Drawing.Point(212, 131);
            this.btnUploadReport.Margin = new System.Windows.Forms.Padding(5);
            this.btnUploadReport.Name = "btnUploadReport";
            this.btnUploadReport.Size = new System.Drawing.Size(100, 59);
            this.btnUploadReport.TabIndex = 66;
            this.btnUploadReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnUploadReport.Visible = false;
            this.btnUploadReport.Click += new System.EventHandler(this.BtnUploadReport_Click);
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 218);
            this.Controls.Add(this.btnUploadReport);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Import";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import_QuestionBank";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowsFormsControlLibrary1.BunifuCustomTextbox txtFilename;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuThinButton2 btnCancel;
        private Bunifu.Framework.UI.BunifuThinButton2 btnImport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblQues;
        private System.Windows.Forms.Label lblImport;
        private Bunifu.Framework.UI.BunifuThinButton2 btnUploadReport;
    }
}