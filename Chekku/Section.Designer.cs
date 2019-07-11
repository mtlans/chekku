namespace Chekku
{
    partial class Section
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
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.txtSection = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchSection = new System.Windows.Forms.TextBox();
            this.dgvSections = new System.Windows.Forms.DataGridView();
            this.cmbSearchYear = new System.Windows.Forms.ComboBox();
            this.cmbSearchTerm = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.dgvSubjects = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEnroll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(351, 138);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(51, 20);
            this.lbl2.TabIndex = 71;
            this.lbl2.Text = "label6";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(231, 139);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(51, 20);
            this.lbl1.TabIndex = 70;
            this.lbl1.Text = "label4";
            // 
            // txtSection
            // 
            this.txtSection.Enabled = false;
            this.txtSection.Location = new System.Drawing.Point(932, 230);
            this.txtSection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSection.Name = "txtSection";
            this.txtSection.Size = new System.Drawing.Size(266, 26);
            this.txtSection.TabIndex = 69;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(511, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 68;
            this.label3.Text = "Section Code:";
            // 
            // txtSearchSection
            // 
            this.txtSearchSection.Location = new System.Drawing.Point(626, 99);
            this.txtSearchSection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchSection.Name = "txtSearchSection";
            this.txtSearchSection.Size = new System.Drawing.Size(124, 26);
            this.txtSearchSection.TabIndex = 67;
            this.txtSearchSection.TextChanged += new System.EventHandler(this.TxtSearchSection_TextChanged);
            // 
            // dgvSections
            // 
            this.dgvSections.AllowUserToAddRows = false;
            this.dgvSections.AllowUserToDeleteRows = false;
            this.dgvSections.AllowUserToResizeColumns = false;
            this.dgvSections.AllowUserToResizeRows = false;
            this.dgvSections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSections.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSections.Location = new System.Drawing.Point(519, 168);
            this.dgvSections.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSections.MultiSelect = false;
            this.dgvSections.Name = "dgvSections";
            this.dgvSections.ReadOnly = true;
            this.dgvSections.RowHeadersWidth = 51;
            this.dgvSections.RowTemplate.Height = 24;
            this.dgvSections.Size = new System.Drawing.Size(232, 345);
            this.dgvSections.TabIndex = 66;
            this.dgvSections.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSections_CellClick);
            this.dgvSections.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSections_CellClick);
            // 
            // cmbSearchYear
            // 
            this.cmbSearchYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchYear.FormattingEnabled = true;
            this.cmbSearchYear.Items.AddRange(new object[] {
            "2019 - 2020",
            "2020 - 2021"});
            this.cmbSearchYear.Location = new System.Drawing.Point(309, 99);
            this.cmbSearchYear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbSearchYear.Name = "cmbSearchYear";
            this.cmbSearchYear.Size = new System.Drawing.Size(152, 28);
            this.cmbSearchYear.TabIndex = 65;
            this.cmbSearchYear.SelectedIndexChanged += new System.EventHandler(this.CmbSearchYear_SelectedIndexChanged);
            // 
            // cmbSearchTerm
            // 
            this.cmbSearchTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchTerm.FormattingEnabled = true;
            this.cmbSearchTerm.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbSearchTerm.Location = new System.Drawing.Point(227, 99);
            this.cmbSearchTerm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbSearchTerm.Name = "cmbSearchTerm";
            this.cmbSearchTerm.Size = new System.Drawing.Size(66, 28);
            this.cmbSearchTerm.TabIndex = 64;
            this.cmbSearchTerm.SelectedIndexChanged += new System.EventHandler(this.CmbSearchYear_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 63;
            this.label5.Text = "Subject Code:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(338, 45);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(124, 26);
            this.txtSearch.TabIndex = 62;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(1037, 464);
            this.btnSaveChanges.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(161, 49);
            this.btnSaveChanges.TabIndex = 61;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Visible = false;
            this.btnSaveChanges.Click += new System.EventHandler(this.BtnSaveChanges_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(788, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 60;
            this.label2.Text = "Section Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(788, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 59;
            this.label1.Text = "Subject Code";
            // 
            // txtCode
            // 
            this.txtCode.Enabled = false;
            this.txtCode.Location = new System.Drawing.Point(932, 159);
            this.txtCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(266, 26);
            this.txtCode.TabIndex = 58;
            // 
            // dgvSubjects
            // 
            this.dgvSubjects.AllowUserToAddRows = false;
            this.dgvSubjects.AllowUserToDeleteRows = false;
            this.dgvSubjects.AllowUserToResizeColumns = false;
            this.dgvSubjects.AllowUserToResizeRows = false;
            this.dgvSubjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSubjects.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubjects.Location = new System.Drawing.Point(231, 168);
            this.dgvSubjects.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSubjects.MultiSelect = false;
            this.dgvSubjects.Name = "dgvSubjects";
            this.dgvSubjects.ReadOnly = true;
            this.dgvSubjects.RowHeadersWidth = 51;
            this.dgvSubjects.RowTemplate.Height = 24;
            this.dgvSubjects.Size = new System.Drawing.Size(232, 345);
            this.dgvSubjects.TabIndex = 57;
            this.dgvSubjects.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSubjects_CellClick);
            this.dgvSubjects.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSubjects_CellClick);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(43, 438);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(161, 49);
            this.btnBack.TabIndex = 56;
            this.btnBack.Text = "Back to Menu";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(43, 339);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(161, 49);
            this.btnDelete.TabIndex = 55;
            this.btnDelete.Text = "Delete Section";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(43, 250);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(161, 49);
            this.btnEdit.TabIndex = 54;
            this.btnEdit.Text = "Edit Section";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(43, 168);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(161, 49);
            this.btnAdd.TabIndex = 53;
            this.btnAdd.Text = "Add Section";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnEnroll
            // 
            this.btnEnroll.Location = new System.Drawing.Point(1021, 432);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(177, 81);
            this.btnEnroll.TabIndex = 72;
            this.btnEnroll.Text = "Check Enrolled Students";
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.BtnEnroll_Click);
            // 
            // Section
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 601);
            this.Controls.Add(this.btnEnroll);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txtSection);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSearchSection);
            this.Controls.Add(this.dgvSections);
            this.Controls.Add(this.cmbSearchYear);
            this.Controls.Add(this.cmbSearchTerm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.dgvSubjects);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Section";
            this.Text = "Section";
            this.Load += new System.EventHandler(this.Section_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox txtSection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearchSection;
        private System.Windows.Forms.DataGridView dgvSections;
        private System.Windows.Forms.ComboBox cmbSearchYear;
        private System.Windows.Forms.ComboBox cmbSearchTerm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.DataGridView dgvSubjects;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEnroll;
    }
}