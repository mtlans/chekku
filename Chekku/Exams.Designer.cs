namespace Chekku
{
    partial class Exams
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Exams));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSections = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.txtSearchSection = new Bunifu.Framework.UI.BunifuTextbox();
            this.txtSearch = new Bunifu.Framework.UI.BunifuTextbox();
            this.dgvSubjects = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.cmbSearchYear = new Bunifu.Framework.UI.BunifuDropdown();
            this.cmbSearchTerm = new Bunifu.Framework.UI.BunifuDropdown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExams = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSection = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.txtCode = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new Bunifu.Framework.UI.BunifuFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSections
            // 
            this.dgvSections.AllowUserToAddRows = false;
            this.dgvSections.AllowUserToDeleteRows = false;
            this.dgvSections.AllowUserToResizeColumns = false;
            this.dgvSections.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvSections.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSections.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvSections.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSections.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSections.DoubleBuffered = true;
            this.dgvSections.EnableHeadersVisualStyles = false;
            this.dgvSections.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.dgvSections.HeaderForeColor = System.Drawing.Color.White;
            this.dgvSections.Location = new System.Drawing.Point(427, 120);
            this.dgvSections.MultiSelect = false;
            this.dgvSections.Name = "dgvSections";
            this.dgvSections.ReadOnly = true;
            this.dgvSections.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSections.RowHeadersWidth = 51;
            this.dgvSections.Size = new System.Drawing.Size(154, 242);
            this.dgvSections.TabIndex = 95;
            this.dgvSections.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSections_CellClick);
            // 
            // txtSearchSection
            // 
            this.txtSearchSection.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearchSection.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtSearchSection.BackgroundImage")));
            this.txtSearchSection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtSearchSection.ForeColor = System.Drawing.Color.Black;
            this.txtSearchSection.Icon = ((System.Drawing.Image)(resources.GetObject("txtSearchSection.Icon")));
            this.txtSearchSection.Location = new System.Drawing.Point(427, 84);
            this.txtSearchSection.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchSection.Name = "txtSearchSection";
            this.txtSearchSection.Size = new System.Drawing.Size(154, 24);
            this.txtSearchSection.TabIndex = 94;
            this.txtSearchSection.text = "";
            this.txtSearchSection.OnTextChange += new System.EventHandler(this.TxtSearchSection_TextChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtSearch.BackgroundImage")));
            this.txtSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Icon = ((System.Drawing.Image)(resources.GetObject("txtSearch.Icon")));
            this.txtSearch.Location = new System.Drawing.Point(224, 84);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(197, 24);
            this.txtSearch.TabIndex = 93;
            this.txtSearch.text = "";
            this.txtSearch.OnTextChange += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // dgvSubjects
            // 
            this.dgvSubjects.AllowUserToAddRows = false;
            this.dgvSubjects.AllowUserToDeleteRows = false;
            this.dgvSubjects.AllowUserToResizeColumns = false;
            this.dgvSubjects.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvSubjects.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSubjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubjects.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvSubjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSubjects.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubjects.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubjects.DoubleBuffered = true;
            this.dgvSubjects.EnableHeadersVisualStyles = false;
            this.dgvSubjects.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.dgvSubjects.HeaderForeColor = System.Drawing.Color.White;
            this.dgvSubjects.Location = new System.Drawing.Point(224, 120);
            this.dgvSubjects.MultiSelect = false;
            this.dgvSubjects.Name = "dgvSubjects";
            this.dgvSubjects.ReadOnly = true;
            this.dgvSubjects.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSubjects.RowHeadersWidth = 51;
            this.dgvSubjects.Size = new System.Drawing.Size(197, 242);
            this.dgvSubjects.TabIndex = 92;
            this.dgvSubjects.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSubjects_CellClick);
            // 
            // cmbSearchYear
            // 
            this.cmbSearchYear.BackColor = System.Drawing.Color.Transparent;
            this.cmbSearchYear.BorderRadius = 3;
            this.cmbSearchYear.DisabledColor = System.Drawing.Color.Gray;
            this.cmbSearchYear.ForeColor = System.Drawing.Color.White;
            this.cmbSearchYear.Items = new string[] {
        "2019 - 2020",
        "2020 - 2021"};
            this.cmbSearchYear.Location = new System.Drawing.Point(290, 54);
            this.cmbSearchYear.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSearchYear.Name = "cmbSearchYear";
            this.cmbSearchYear.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.cmbSearchYear.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.cmbSearchYear.selectedIndex = 0;
            this.cmbSearchYear.Size = new System.Drawing.Size(131, 24);
            this.cmbSearchYear.TabIndex = 91;
            this.cmbSearchYear.onItemSelected += new System.EventHandler(this.CmbSearchTerm_SelectedIndexChanged);
            this.cmbSearchYear.TabIndexChanged += new System.EventHandler(this.CmbSearchTerm_SelectedIndexChanged);
            // 
            // cmbSearchTerm
            // 
            this.cmbSearchTerm.BackColor = System.Drawing.Color.Transparent;
            this.cmbSearchTerm.BorderRadius = 3;
            this.cmbSearchTerm.DisabledColor = System.Drawing.Color.Gray;
            this.cmbSearchTerm.ForeColor = System.Drawing.Color.White;
            this.cmbSearchTerm.Items = new string[] {
        "1",
        "2",
        "3"};
            this.cmbSearchTerm.Location = new System.Drawing.Point(224, 54);
            this.cmbSearchTerm.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSearchTerm.Name = "cmbSearchTerm";
            this.cmbSearchTerm.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.cmbSearchTerm.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.cmbSearchTerm.selectedIndex = 0;
            this.cmbSearchTerm.Size = new System.Drawing.Size(60, 24);
            this.cmbSearchTerm.TabIndex = 90;
            this.cmbSearchTerm.onItemSelected += new System.EventHandler(this.CmbSearchTerm_SelectedIndexChanged);
            this.cmbSearchTerm.TabIndexChanged += new System.EventHandler(this.CmbSearchTerm_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.btnExams);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtSection);
            this.panel2.Controls.Add(this.txtCode);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(607, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(324, 434);
            this.panel2.TabIndex = 89;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Exams_MouseDown);
            // 
            // btnExams
            // 
            this.btnExams.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnExams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnExams.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExams.BorderRadius = 0;
            this.btnExams.ButtonText = "View Exams";
            this.btnExams.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExams.DisabledColor = System.Drawing.Color.Gray;
            this.btnExams.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExams.Iconcolor = System.Drawing.Color.Transparent;
            this.btnExams.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnExams.Iconimage")));
            this.btnExams.Iconimage_right = null;
            this.btnExams.Iconimage_right_Selected = null;
            this.btnExams.Iconimage_Selected = null;
            this.btnExams.IconMarginLeft = 10;
            this.btnExams.IconMarginRight = 0;
            this.btnExams.IconRightVisible = true;
            this.btnExams.IconRightZoom = 0D;
            this.btnExams.IconVisible = true;
            this.btnExams.IconZoom = 40D;
            this.btnExams.IsTab = false;
            this.btnExams.Location = new System.Drawing.Point(122, 314);
            this.btnExams.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExams.Name = "btnExams";
            this.btnExams.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnExams.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnExams.OnHoverTextColor = System.Drawing.Color.White;
            this.btnExams.selected = false;
            this.btnExams.Size = new System.Drawing.Size(189, 47);
            this.btnExams.TabIndex = 74;
            this.btnExams.Text = "View Exams";
            this.btnExams.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExams.Textcolor = System.Drawing.Color.White;
            this.btnExams.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExams.Click += new System.EventHandler(this.BtnExams_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 147);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 39;
            this.label2.Text = "Section Code";
            // 
            // txtSection
            // 
            this.txtSection.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.txtSection.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSection.Location = new System.Drawing.Point(122, 144);
            this.txtSection.Multiline = true;
            this.txtSection.Name = "txtSection";
            this.txtSection.ReadOnly = true;
            this.txtSection.Size = new System.Drawing.Size(179, 23);
            this.txtSection.TabIndex = 38;
            // 
            // txtCode
            // 
            this.txtCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.txtCode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(122, 85);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(179, 23);
            this.txtCode.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 85);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "Subject Code";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Location = new System.Drawing.Point(1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 435);
            this.panel1.TabIndex = 96;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Exams_MouseDown);
            // 
            // btnBack
            // 
            this.btnBack.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.BorderRadius = 0;
            this.btnBack.ButtonText = "Back to Menu";
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.DisabledColor = System.Drawing.Color.Gray;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Iconcolor = System.Drawing.Color.Transparent;
            this.btnBack.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnBack.Iconimage")));
            this.btnBack.Iconimage_right = null;
            this.btnBack.Iconimage_right_Selected = null;
            this.btnBack.Iconimage_Selected = null;
            this.btnBack.IconMarginLeft = 10;
            this.btnBack.IconMarginRight = 0;
            this.btnBack.IconRightVisible = true;
            this.btnBack.IconRightZoom = 0D;
            this.btnBack.IconVisible = true;
            this.btnBack.IconZoom = 40D;
            this.btnBack.IsTab = false;
            this.btnBack.Location = new System.Drawing.Point(0, 315);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnBack.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnBack.OnHoverTextColor = System.Drawing.Color.White;
            this.btnBack.selected = false;
            this.btnBack.Size = new System.Drawing.Size(196, 47);
            this.btnBack.TabIndex = 29;
            this.btnBack.Text = "Back to Menu";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBack.Textcolor = System.Drawing.Color.White;
            this.btnBack.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // Exams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 420);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvSections);
            this.Controls.Add(this.txtSearchSection);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvSubjects);
            this.Controls.Add(this.cmbSearchYear);
            this.Controls.Add(this.cmbSearchTerm);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Exams";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exams";
            this.Load += new System.EventHandler(this.Exams_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Exams_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvSections;
        private Bunifu.Framework.UI.BunifuTextbox txtSearchSection;
        private Bunifu.Framework.UI.BunifuTextbox txtSearch;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvSubjects;
        internal Bunifu.Framework.UI.BunifuDropdown cmbSearchYear;
        internal Bunifu.Framework.UI.BunifuDropdown cmbSearchTerm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txtSection;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txtCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuFlatButton btnBack;
        private Bunifu.Framework.UI.BunifuFlatButton btnExams;
    }
}