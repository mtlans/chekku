namespace Chekku
{
    partial class Students
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Students));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEdit = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnAdd = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnBack = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnDelete = new Bunifu.Framework.UI.BunifuFlatButton();
            this.dgvViewStudents = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.btnSave = new Bunifu.Framework.UI.BunifuFlatButton();
            this.txtID = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSearch = new Bunifu.Framework.UI.BunifuTextbox();
            this.cmbSelect = new Bunifu.Framework.UI.BunifuDropdown();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewStudents)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Location = new System.Drawing.Point(0, -6);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 535);
            this.panel1.TabIndex = 74;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel2_MouseDown);
            // 
            // btnEdit
            // 
            this.btnEdit.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEdit.BorderRadius = 0;
            this.btnEdit.ButtonText = "Edit Student Details";
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.DisabledColor = System.Drawing.Color.Gray;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Iconcolor = System.Drawing.Color.Transparent;
            this.btnEdit.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnEdit.Iconimage")));
            this.btnEdit.Iconimage_right = null;
            this.btnEdit.Iconimage_right_Selected = null;
            this.btnEdit.Iconimage_Selected = null;
            this.btnEdit.IconMarginLeft = 10;
            this.btnEdit.IconMarginRight = 0;
            this.btnEdit.IconRightVisible = true;
            this.btnEdit.IconRightZoom = 0D;
            this.btnEdit.IconVisible = true;
            this.btnEdit.IconZoom = 40D;
            this.btnEdit.IsTab = false;
            this.btnEdit.Location = new System.Drawing.Point(0, 212);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnEdit.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnEdit.OnHoverTextColor = System.Drawing.Color.White;
            this.btnEdit.selected = false;
            this.btnEdit.Size = new System.Drawing.Size(261, 58);
            this.btnEdit.TabIndex = 27;
            this.btnEdit.Text = "Edit Student Details";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEdit.Textcolor = System.Drawing.Color.White;
            this.btnEdit.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.BorderRadius = 0;
            this.btnAdd.ButtonText = "Add Student";
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.DisabledColor = System.Drawing.Color.Gray;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAdd.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnAdd.Iconimage")));
            this.btnAdd.Iconimage_right = null;
            this.btnAdd.Iconimage_right_Selected = null;
            this.btnAdd.Iconimage_Selected = null;
            this.btnAdd.IconMarginLeft = 10;
            this.btnAdd.IconMarginRight = 0;
            this.btnAdd.IconRightVisible = true;
            this.btnAdd.IconRightZoom = 0D;
            this.btnAdd.IconVisible = true;
            this.btnAdd.IconZoom = 40D;
            this.btnAdd.IsTab = false;
            this.btnAdd.Location = new System.Drawing.Point(0, 149);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnAdd.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnAdd.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAdd.selected = false;
            this.btnAdd.Size = new System.Drawing.Size(261, 58);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "Add Student";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.Textcolor = System.Drawing.Color.White;
            this.btnAdd.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.btnBack.Location = new System.Drawing.Point(0, 388);
            this.btnBack.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnBack.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnBack.OnHoverTextColor = System.Drawing.Color.White;
            this.btnBack.selected = false;
            this.btnBack.Size = new System.Drawing.Size(261, 58);
            this.btnBack.TabIndex = 29;
            this.btnBack.Text = "Back to Menu";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBack.Textcolor = System.Drawing.Color.White;
            this.btnBack.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.BorderRadius = 0;
            this.btnDelete.ButtonText = "Delete Student";
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.DisabledColor = System.Drawing.Color.Gray;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDelete.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnDelete.Iconimage")));
            this.btnDelete.Iconimage_right = null;
            this.btnDelete.Iconimage_right_Selected = null;
            this.btnDelete.Iconimage_Selected = null;
            this.btnDelete.IconMarginLeft = 10;
            this.btnDelete.IconMarginRight = 0;
            this.btnDelete.IconRightVisible = true;
            this.btnDelete.IconRightZoom = 0D;
            this.btnDelete.IconVisible = true;
            this.btnDelete.IconZoom = 40D;
            this.btnDelete.IsTab = false;
            this.btnDelete.Location = new System.Drawing.Point(0, 274);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnDelete.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnDelete.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDelete.selected = false;
            this.btnDelete.Size = new System.Drawing.Size(261, 58);
            this.btnDelete.TabIndex = 28;
            this.btnDelete.Text = "Delete Student";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.Textcolor = System.Drawing.Color.White;
            this.btnDelete.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // dgvViewStudents
            // 
            this.dgvViewStudents.AllowUserToAddRows = false;
            this.dgvViewStudents.AllowUserToDeleteRows = false;
            this.dgvViewStudents.AllowUserToResizeColumns = false;
            this.dgvViewStudents.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvViewStudents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvViewStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvViewStudents.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvViewStudents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvViewStudents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvViewStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewStudents.DoubleBuffered = true;
            this.dgvViewStudents.EnableHeadersVisualStyles = false;
            this.dgvViewStudents.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.dgvViewStudents.HeaderForeColor = System.Drawing.Color.White;
            this.dgvViewStudents.Location = new System.Drawing.Point(319, 146);
            this.dgvViewStudents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvViewStudents.MultiSelect = false;
            this.dgvViewStudents.Name = "dgvViewStudents";
            this.dgvViewStudents.ReadOnly = true;
            this.dgvViewStudents.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvViewStudents.RowHeadersWidth = 51;
            this.dgvViewStudents.Size = new System.Drawing.Size(321, 297);
            this.dgvViewStudents.TabIndex = 78;
            this.dgvViewStudents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvViewStudents_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.txtID);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(687, -5);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(449, 534);
            this.panel2.TabIndex = 79;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel2_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 23);
            this.label3.TabIndex = 39;
            this.label3.Text = "Student Name";
            // 
            // txtName
            // 
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(177, 186);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(237, 27);
            this.txtName.TabIndex = 38;
            // 
            // btnSave
            // 
            this.btnSave.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.BorderRadius = 0;
            this.btnSave.ButtonText = "Save Changes";
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DisabledColor = System.Drawing.Color.Gray;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSave.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnSave.Iconimage")));
            this.btnSave.Iconimage_right = null;
            this.btnSave.Iconimage_right_Selected = null;
            this.btnSave.Iconimage_Selected = null;
            this.btnSave.IconMarginLeft = 10;
            this.btnSave.IconMarginRight = 0;
            this.btnSave.IconRightVisible = true;
            this.btnSave.IconRightZoom = 0D;
            this.btnSave.IconVisible = true;
            this.btnSave.IconZoom = 40D;
            this.btnSave.IsTab = false;
            this.btnSave.Location = new System.Drawing.Point(177, 386);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnSave.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnSave.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSave.selected = false;
            this.btnSave.Size = new System.Drawing.Size(239, 58);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "Save Changes";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.Textcolor = System.Drawing.Color.White;
            this.btnSave.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // txtID
            // 
            this.txtID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(177, 148);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtID.Multiline = true;
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(237, 27);
            this.txtID.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(43, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 23);
            this.label8.TabIndex = 9;
            this.label8.Text = "Student No.";
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtSearch.BackgroundImage")));
            this.txtSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Icon = ((System.Drawing.Image)(resources.GetObject("txtSearch.Icon")));
            this.txtSearch.Location = new System.Drawing.Point(319, 106);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(321, 30);
            this.txtSearch.TabIndex = 80;
            this.txtSearch.text = "";
            this.txtSearch.OnTextChange += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // cmbSelect
            // 
            this.cmbSelect.BackColor = System.Drawing.Color.Transparent;
            this.cmbSelect.BorderRadius = 3;
            this.cmbSelect.DisabledColor = System.Drawing.Color.Gray;
            this.cmbSelect.ForeColor = System.Drawing.Color.White;
            this.cmbSelect.Items = new string[] {
        "Student No.",
        "Student Name"};
            this.cmbSelect.Location = new System.Drawing.Point(319, 68);
            this.cmbSelect.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cmbSelect.Name = "cmbSelect";
            this.cmbSelect.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.cmbSelect.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.cmbSelect.selectedIndex = 0;
            this.cmbSelect.Size = new System.Drawing.Size(321, 30);
            this.cmbSelect.TabIndex = 81;
            this.cmbSelect.onItemSelected += new System.EventHandler(this.CmbSelect_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(313, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 28);
            this.label5.TabIndex = 82;
            this.label5.Text = "STUDENTS";
            // 
            // Students
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 507);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSelect);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvViewStudents);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Students";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Students";
            this.Load += new System.EventHandler(this.Students_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel2_MouseDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewStudents)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuFlatButton btnEdit;
        private Bunifu.Framework.UI.BunifuFlatButton btnAdd;
        private Bunifu.Framework.UI.BunifuFlatButton btnBack;
        private Bunifu.Framework.UI.BunifuFlatButton btnDelete;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvViewStudents;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txtName;
        private Bunifu.Framework.UI.BunifuFlatButton btnSave;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txtID;
        private System.Windows.Forms.Label label8;
        private Bunifu.Framework.UI.BunifuTextbox txtSearch;
        internal Bunifu.Framework.UI.BunifuDropdown cmbSelect;
        private System.Windows.Forms.Label label5;
    }
}