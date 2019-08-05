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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Section));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEdit = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnAdd = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnBack = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnDelete = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEnroll = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSection = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.btnSaveChanges = new Bunifu.Framework.UI.BunifuFlatButton();
            this.txtCode = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbSearchYear = new Bunifu.Framework.UI.BunifuDropdown();
            this.cmbSearchTerm = new Bunifu.Framework.UI.BunifuDropdown();
            this.dgvSubjects = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.txtSearchSection = new Bunifu.Framework.UI.BunifuTextbox();
            this.dgvSections = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.txtSearch = new Bunifu.Framework.UI.BunifuTextbox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSections)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Location = new System.Drawing.Point(1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 435);
            this.panel1.TabIndex = 73;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            // 
            // btnEdit
            // 
            this.btnEdit.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEdit.BorderRadius = 0;
            this.btnEdit.ButtonText = "Edit Section";
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
            this.btnEdit.Location = new System.Drawing.Point(0, 172);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnEdit.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnEdit.OnHoverTextColor = System.Drawing.Color.White;
            this.btnEdit.selected = false;
            this.btnEdit.Size = new System.Drawing.Size(196, 47);
            this.btnEdit.TabIndex = 27;
            this.btnEdit.Text = "Edit Section";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnAdd.ButtonText = "Add Section";
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
            this.btnAdd.Location = new System.Drawing.Point(0, 121);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnAdd.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnAdd.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAdd.selected = false;
            this.btnAdd.Size = new System.Drawing.Size(196, 47);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "Add Section";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Textcolor = System.Drawing.Color.White;
            this.btnAdd.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
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
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnDelete.ButtonText = "Delete Section";
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
            this.btnDelete.Location = new System.Drawing.Point(0, 223);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnDelete.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnDelete.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDelete.selected = false;
            this.btnDelete.Size = new System.Drawing.Size(196, 47);
            this.btnDelete.TabIndex = 28;
            this.btnDelete.Text = "Delete Section";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Textcolor = System.Drawing.Color.White;
            this.btnDelete.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.btnEnroll);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtSection);
            this.panel2.Controls.Add(this.btnSaveChanges);
            this.panel2.Controls.Add(this.txtCode);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(607, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(324, 434);
            this.panel2.TabIndex = 74;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            // 
            // btnEnroll
            // 
            this.btnEnroll.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnEnroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnEnroll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEnroll.BorderRadius = 0;
            this.btnEnroll.ButtonText = "Check Enrolled Students";
            this.btnEnroll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnroll.DisabledColor = System.Drawing.Color.Gray;
            this.btnEnroll.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnroll.Iconcolor = System.Drawing.Color.Transparent;
            this.btnEnroll.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnEnroll.Iconimage")));
            this.btnEnroll.Iconimage_right = null;
            this.btnEnroll.Iconimage_right_Selected = null;
            this.btnEnroll.Iconimage_Selected = null;
            this.btnEnroll.IconMarginLeft = 10;
            this.btnEnroll.IconMarginRight = 0;
            this.btnEnroll.IconRightVisible = true;
            this.btnEnroll.IconRightZoom = 0D;
            this.btnEnroll.IconVisible = true;
            this.btnEnroll.IconZoom = 40D;
            this.btnEnroll.IsTab = false;
            this.btnEnroll.Location = new System.Drawing.Point(89, 314);
            this.btnEnroll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnEnroll.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnEnroll.OnHoverTextColor = System.Drawing.Color.White;
            this.btnEnroll.selected = false;
            this.btnEnroll.Size = new System.Drawing.Size(212, 47);
            this.btnEnroll.TabIndex = 73;
            this.btnEnroll.Text = "Check Enrolled Students";
            this.btnEnroll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnroll.Textcolor = System.Drawing.Color.White;
            this.btnEnroll.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnroll.Click += new System.EventHandler(this.BtnEnroll_Click);
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
            this.txtSection.Enabled = false;
            this.txtSection.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSection.Location = new System.Drawing.Point(122, 144);
            this.txtSection.Multiline = true;
            this.txtSection.Name = "txtSection";
            this.txtSection.Size = new System.Drawing.Size(179, 23);
            this.txtSection.TabIndex = 38;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnSaveChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnSaveChanges.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveChanges.BorderRadius = 0;
            this.btnSaveChanges.ButtonText = "Save Changes";
            this.btnSaveChanges.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveChanges.DisabledColor = System.Drawing.Color.Gray;
            this.btnSaveChanges.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanges.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSaveChanges.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnSaveChanges.Iconimage")));
            this.btnSaveChanges.Iconimage_right = null;
            this.btnSaveChanges.Iconimage_right_Selected = null;
            this.btnSaveChanges.Iconimage_Selected = null;
            this.btnSaveChanges.IconMarginLeft = 10;
            this.btnSaveChanges.IconMarginRight = 0;
            this.btnSaveChanges.IconRightVisible = true;
            this.btnSaveChanges.IconRightZoom = 0D;
            this.btnSaveChanges.IconVisible = true;
            this.btnSaveChanges.IconZoom = 40D;
            this.btnSaveChanges.IsTab = false;
            this.btnSaveChanges.Location = new System.Drawing.Point(89, 315);
            this.btnSaveChanges.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnSaveChanges.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnSaveChanges.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSaveChanges.selected = false;
            this.btnSaveChanges.Size = new System.Drawing.Size(212, 47);
            this.btnSaveChanges.TabIndex = 30;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveChanges.Textcolor = System.Drawing.Color.White;
            this.btnSaveChanges.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanges.Visible = false;
            this.btnSaveChanges.Click += new System.EventHandler(this.BtnSaveChanges_Click);
            // 
            // txtCode
            // 
            this.txtCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.txtCode.Enabled = false;
            this.txtCode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(122, 85);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
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
            // cmbSearchYear
            // 
            this.cmbSearchYear.BackColor = System.Drawing.Color.Transparent;
            this.cmbSearchYear.BorderRadius = 3;
            this.cmbSearchYear.DisabledColor = System.Drawing.Color.Gray;
            this.cmbSearchYear.ForeColor = System.Drawing.Color.White;
            this.cmbSearchYear.Items = new string[] {
        "2018- 2019",
        "2019 - 2020"};
            this.cmbSearchYear.Location = new System.Drawing.Point(290, 53);
            this.cmbSearchYear.Name = "cmbSearchYear";
            this.cmbSearchYear.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.cmbSearchYear.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.cmbSearchYear.selectedIndex = -1;
            this.cmbSearchYear.Size = new System.Drawing.Size(131, 24);
            this.cmbSearchYear.TabIndex = 76;
            this.cmbSearchYear.onItemSelected += new System.EventHandler(this.CmbSearchYear_selectedIndexChanged);
            this.cmbSearchYear.TabIndexChanged += new System.EventHandler(this.CmbSearchYear_selectedIndexChanged);
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
            this.cmbSearchTerm.Location = new System.Drawing.Point(224, 53);
            this.cmbSearchTerm.Name = "cmbSearchTerm";
            this.cmbSearchTerm.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.cmbSearchTerm.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.cmbSearchTerm.selectedIndex = -1;
            this.cmbSearchTerm.Size = new System.Drawing.Size(60, 24);
            this.cmbSearchTerm.TabIndex = 75;
            this.cmbSearchTerm.onItemSelected += new System.EventHandler(this.CmbSearchYear_selectedIndexChanged);
            this.cmbSearchTerm.TabIndexChanged += new System.EventHandler(this.CmbSearchYear_selectedIndexChanged);
            // 
            // dgvSubjects
            // 
            this.dgvSubjects.AllowUserToAddRows = false;
            this.dgvSubjects.AllowUserToDeleteRows = false;
            this.dgvSubjects.AllowUserToResizeColumns = false;
            this.dgvSubjects.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvSubjects.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvSubjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubjects.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvSubjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSubjects.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubjects.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubjects.DoubleBuffered = true;
            this.dgvSubjects.EnableHeadersVisualStyles = false;
            this.dgvSubjects.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.dgvSubjects.HeaderForeColor = System.Drawing.Color.White;
            this.dgvSubjects.Location = new System.Drawing.Point(224, 119);
            this.dgvSubjects.Name = "dgvSubjects";
            this.dgvSubjects.ReadOnly = true;
            this.dgvSubjects.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSubjects.Size = new System.Drawing.Size(197, 242);
            this.dgvSubjects.TabIndex = 77;
            this.dgvSubjects.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSubjects_CellClick);
            // 
            // txtSearchSection
            // 
            this.txtSearchSection.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearchSection.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtSearchSection.BackgroundImage")));
            this.txtSearchSection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtSearchSection.ForeColor = System.Drawing.Color.Black;
            this.txtSearchSection.Icon = ((System.Drawing.Image)(resources.GetObject("txtSearchSection.Icon")));
            this.txtSearchSection.Location = new System.Drawing.Point(427, 83);
            this.txtSearchSection.Name = "txtSearchSection";
            this.txtSearchSection.Size = new System.Drawing.Size(154, 24);
            this.txtSearchSection.TabIndex = 79;
            this.txtSearchSection.text = "";
            this.txtSearchSection.OnTextChange += new System.EventHandler(this.TxtSearchSection_TextChanged);
            // 
            // dgvSections
            // 
            this.dgvSections.AllowUserToAddRows = false;
            this.dgvSections.AllowUserToDeleteRows = false;
            this.dgvSections.AllowUserToResizeColumns = false;
            this.dgvSections.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvSections.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvSections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSections.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvSections.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSections.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvSections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSections.DoubleBuffered = true;
            this.dgvSections.EnableHeadersVisualStyles = false;
            this.dgvSections.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.dgvSections.HeaderForeColor = System.Drawing.Color.White;
            this.dgvSections.Location = new System.Drawing.Point(427, 119);
            this.dgvSections.Name = "dgvSections";
            this.dgvSections.ReadOnly = true;
            this.dgvSections.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSections.Size = new System.Drawing.Size(154, 242);
            this.dgvSections.TabIndex = 80;
            this.dgvSections.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSections_CellClick);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtSearch.BackgroundImage")));
            this.txtSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Icon = ((System.Drawing.Image)(resources.GetObject("txtSearch.Icon")));
            this.txtSearch.Location = new System.Drawing.Point(224, 83);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(197, 24);
            this.txtSearch.TabIndex = 78;
            this.txtSearch.text = "";
            this.txtSearch.OnTextChange += new System.EventHandler(this.TxtSearch_OnTextChange);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(220, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 21);
            this.label5.TabIndex = 81;
            this.label5.Text = "SECTIONS";
            // 
            // Section
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 420);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvSections);
            this.Controls.Add(this.txtSearchSection);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvSubjects);
            this.Controls.Add(this.cmbSearchYear);
            this.Controls.Add(this.cmbSearchTerm);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Section";
            this.Text = "Section";
            this.Load += new System.EventHandler(this.Section_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSections)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuFlatButton btnEdit;
        private Bunifu.Framework.UI.BunifuFlatButton btnAdd;
        private Bunifu.Framework.UI.BunifuFlatButton btnBack;
        private Bunifu.Framework.UI.BunifuFlatButton btnDelete;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txtSection;
        private Bunifu.Framework.UI.BunifuFlatButton btnSaveChanges;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txtCode;
        private System.Windows.Forms.Label label8;
        internal Bunifu.Framework.UI.BunifuDropdown cmbSearchYear;
        internal Bunifu.Framework.UI.BunifuDropdown cmbSearchTerm;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvSubjects;
        private Bunifu.Framework.UI.BunifuTextbox txtSearchSection;
        private Bunifu.Framework.UI.BunifuFlatButton btnEnroll;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvSections;
        private Bunifu.Framework.UI.BunifuTextbox txtSearch;
        private System.Windows.Forms.Label label5;
    }
}