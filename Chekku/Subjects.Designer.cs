namespace Chekku
{
    partial class Subjects
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
            this.btnAddSubjects = new System.Windows.Forms.Button();
            this.btnEditSubjects = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvViewSubjects = new System.Windows.Forms.DataGridView();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTerm = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.txtTerm = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbSearchTerm = new System.Windows.Forms.ComboBox();
            this.cmbSearchYear = new System.Windows.Forms.ComboBox();
            this.lblCHOICE = new System.Windows.Forms.Label();
            this.lblindex1 = new System.Windows.Forms.Label();
            this.lblindex2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewSubjects)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddSubjects
            // 
            this.btnAddSubjects.Location = new System.Drawing.Point(63, 117);
            this.btnAddSubjects.Name = "btnAddSubjects";
            this.btnAddSubjects.Size = new System.Drawing.Size(143, 39);
            this.btnAddSubjects.TabIndex = 0;
            this.btnAddSubjects.Text = "Add Subjects";
            this.btnAddSubjects.UseVisualStyleBackColor = true;
            this.btnAddSubjects.Click += new System.EventHandler(this.BtnAddSubjects_Click);
            // 
            // btnEditSubjects
            // 
            this.btnEditSubjects.Location = new System.Drawing.Point(63, 183);
            this.btnEditSubjects.Name = "btnEditSubjects";
            this.btnEditSubjects.Size = new System.Drawing.Size(143, 39);
            this.btnEditSubjects.TabIndex = 1;
            this.btnEditSubjects.Text = "Edit Subjects";
            this.btnEditSubjects.UseVisualStyleBackColor = true;
            this.btnEditSubjects.Click += new System.EventHandler(this.BtnEditSubjects_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(63, 254);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(143, 39);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete Subjects";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(63, 333);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(143, 39);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back to Menu";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // dgvViewSubjects
            // 
            this.dgvViewSubjects.AllowUserToAddRows = false;
            this.dgvViewSubjects.AllowUserToDeleteRows = false;
            this.dgvViewSubjects.AllowUserToResizeColumns = false;
            this.dgvViewSubjects.AllowUserToResizeRows = false;
            this.dgvViewSubjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvViewSubjects.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvViewSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewSubjects.Location = new System.Drawing.Point(230, 117);
            this.dgvViewSubjects.MultiSelect = false;
            this.dgvViewSubjects.Name = "dgvViewSubjects";
            this.dgvViewSubjects.ReadOnly = true;
            this.dgvViewSubjects.RowHeadersWidth = 51;
            this.dgvViewSubjects.RowTemplate.Height = 24;
            this.dgvViewSubjects.Size = new System.Drawing.Size(536, 276);
            this.dgvViewSubjects.TabIndex = 4;
            this.dgvViewSubjects.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvViewSubjects_CellClick);
            this.dgvViewSubjects.SelectionChanged += new System.EventHandler(this.DgvViewSubjects_Selectionhanged);
            // 
            // txtCode
            // 
            this.txtCode.Enabled = false;
            this.txtCode.Location = new System.Drawing.Point(954, 91);
            this.txtCode.MaxLength = 7;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(237, 22);
            this.txtCode.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(954, 140);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(237, 110);
            this.txtName.TabIndex = 6;
            this.txtName.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(826, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Subject Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(826, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Subject Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(826, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Term";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(826, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "School Year";
            // 
            // cmbTerm
            // 
            this.cmbTerm.Enabled = false;
            this.cmbTerm.FormattingEnabled = true;
            this.cmbTerm.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbTerm.Location = new System.Drawing.Point(954, 269);
            this.cmbTerm.Name = "cmbTerm";
            this.cmbTerm.Size = new System.Drawing.Size(121, 24);
            this.cmbTerm.TabIndex = 13;
            this.cmbTerm.Visible = false;
            // 
            // cmbYear
            // 
            this.cmbYear.Enabled = false;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Items.AddRange(new object[] {
            "2019 - 2020",
            "2020 - 2021"});
            this.cmbYear.Location = new System.Drawing.Point(954, 309);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(237, 24);
            this.cmbYear.TabIndex = 14;
            this.cmbYear.Visible = false;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(1048, 397);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(143, 39);
            this.btnSaveChanges.TabIndex = 15;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Visible = false;
            this.btnSaveChanges.Click += new System.EventHandler(this.BtnSaveChanges_Click);
            // 
            // txtTerm
            // 
            this.txtTerm.Enabled = false;
            this.txtTerm.Location = new System.Drawing.Point(954, 269);
            this.txtTerm.Name = "txtTerm";
            this.txtTerm.Size = new System.Drawing.Size(237, 22);
            this.txtTerm.TabIndex = 16;
            // 
            // txtYear
            // 
            this.txtYear.Enabled = false;
            this.txtYear.Location = new System.Drawing.Point(954, 309);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(237, 22);
            this.txtYear.TabIndex = 17;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(826, 376);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(46, 17);
            this.lblID.TabIndex = 18;
            this.lblID.Text = "label5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Subject Code:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(332, 71);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 22);
            this.txtSearch.TabIndex = 19;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // cmbSearchTerm
            // 
            this.cmbSearchTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchTerm.FormattingEnabled = true;
            this.cmbSearchTerm.Items.AddRange(new object[] {
            " ",
            "1",
            "2",
            "3"});
            this.cmbSearchTerm.Location = new System.Drawing.Point(557, 71);
            this.cmbSearchTerm.Name = "cmbSearchTerm";
            this.cmbSearchTerm.Size = new System.Drawing.Size(59, 24);
            this.cmbSearchTerm.TabIndex = 21;
            this.cmbSearchTerm.SelectedIndexChanged += new System.EventHandler(this.CmbSearchTerm_SelectedIndexChanged);
            this.cmbSearchTerm.SelectionChangeCommitted += new System.EventHandler(this.CmbSearchTerm_SelectedIndexChanged);
            // 
            // cmbSearchYear
            // 
            this.cmbSearchYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchYear.FormattingEnabled = true;
            this.cmbSearchYear.Items.AddRange(new object[] {
            " ",
            "2019 - 2020",
            "2020 - 2021"});
            this.cmbSearchYear.Location = new System.Drawing.Point(630, 71);
            this.cmbSearchYear.Name = "cmbSearchYear";
            this.cmbSearchYear.Size = new System.Drawing.Size(136, 24);
            this.cmbSearchYear.TabIndex = 22;
            this.cmbSearchYear.SelectedIndexChanged += new System.EventHandler(this.CmbSearchTerm_SelectedIndexChanged);
            this.cmbSearchYear.SelectionChangeCommitted += new System.EventHandler(this.CmbSearchTerm_SelectedIndexChanged);
            // 
            // lblCHOICE
            // 
            this.lblCHOICE.AutoSize = true;
            this.lblCHOICE.Location = new System.Drawing.Point(462, 28);
            this.lblCHOICE.Name = "lblCHOICE";
            this.lblCHOICE.Size = new System.Drawing.Size(46, 17);
            this.lblCHOICE.TabIndex = 23;
            this.lblCHOICE.Text = "label6";
            this.lblCHOICE.Visible = false;
            // 
            // lblindex1
            // 
            this.lblindex1.AutoSize = true;
            this.lblindex1.Location = new System.Drawing.Point(554, 28);
            this.lblindex1.Name = "lblindex1";
            this.lblindex1.Size = new System.Drawing.Size(46, 17);
            this.lblindex1.TabIndex = 24;
            this.lblindex1.Text = "label6";
            this.lblindex1.Visible = false;
            // 
            // lblindex2
            // 
            this.lblindex2.AutoSize = true;
            this.lblindex2.Location = new System.Drawing.Point(657, 28);
            this.lblindex2.Name = "lblindex2";
            this.lblindex2.Size = new System.Drawing.Size(46, 17);
            this.lblindex2.TabIndex = 25;
            this.lblindex2.Text = "label6";
            this.lblindex2.Visible = false;
            // 
            // Subjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 530);
            this.Controls.Add(this.lblindex2);
            this.Controls.Add(this.lblindex1);
            this.Controls.Add(this.lblCHOICE);
            this.Controls.Add(this.cmbSearchYear);
            this.Controls.Add(this.cmbSearchTerm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtTerm);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.cmbTerm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.dgvViewSubjects);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEditSubjects);
            this.Controls.Add(this.btnAddSubjects);
            this.Name = "Subjects";
            this.Text = "Subjects";
            this.Load += new System.EventHandler(this.Subjects_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewSubjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddSubjects;
        private System.Windows.Forms.Button btnEditSubjects;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvViewSubjects;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.RichTextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTerm;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.TextBox txtTerm;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbSearchTerm;
        private System.Windows.Forms.ComboBox cmbSearchYear;
        private System.Windows.Forms.Label lblCHOICE;
        private System.Windows.Forms.Label lblindex1;
        private System.Windows.Forms.Label lblindex2;
    }
}