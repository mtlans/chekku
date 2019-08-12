namespace Chekku
{
    partial class Section_Students
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Section_Students));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbSelect = new Bunifu.Framework.UI.BunifuDropdown();
            this.txtSearch = new Bunifu.Framework.UI.BunifuTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.txtID = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvViewStudents = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvViewEnrolled = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.cmbSelect2 = new Bunifu.Framework.UI.BunifuDropdown();
            this.txtSearch2 = new Bunifu.Framework.UI.BunifuTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName2 = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.txtID2 = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSY = new System.Windows.Forms.Label();
            this.lblTerm = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCancel = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnEnroll = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnUn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewStudents)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewEnrolled)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
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
            this.cmbSelect.Location = new System.Drawing.Point(21, 76);
            this.cmbSelect.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSelect.Name = "cmbSelect";
            this.cmbSelect.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.cmbSelect.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.cmbSelect.selectedIndex = 0;
            this.cmbSelect.Size = new System.Drawing.Size(254, 24);
            this.cmbSelect.TabIndex = 124;
            this.cmbSelect.onItemSelected += new System.EventHandler(this.CmbSelect_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtSearch.BackgroundImage")));
            this.txtSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Icon = ((System.Drawing.Image)(resources.GetObject("txtSearch.Icon")));
            this.txtSearch.Location = new System.Drawing.Point(21, 106);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(255, 24);
            this.txtSearch.TabIndex = 123;
            this.txtSearch.text = "";
            this.txtSearch.OnTextChange += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 122;
            this.label1.Text = "Student Name";
            // 
            // txtName
            // 
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(125, 46);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(151, 23);
            this.txtName.TabIndex = 121;
            // 
            // txtID
            // 
            this.txtID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(125, 19);
            this.txtID.Multiline = true;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(151, 23);
            this.txtID.TabIndex = 120;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 22);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 17);
            this.label8.TabIndex = 119;
            this.label8.Text = "Student No.";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.dgvViewStudents);
            this.panel1.Controls.Add(this.cmbSelect);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(27, 145);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 396);
            this.panel1.TabIndex = 133;
            // 
            // dgvViewStudents
            // 
            this.dgvViewStudents.AllowUserToAddRows = false;
            this.dgvViewStudents.AllowUserToDeleteRows = false;
            this.dgvViewStudents.AllowUserToResizeColumns = false;
            this.dgvViewStudents.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvViewStudents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvViewStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvViewStudents.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvViewStudents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvViewStudents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvViewStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewStudents.DoubleBuffered = true;
            this.dgvViewStudents.EnableHeadersVisualStyles = false;
            this.dgvViewStudents.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.dgvViewStudents.HeaderForeColor = System.Drawing.Color.White;
            this.dgvViewStudents.Location = new System.Drawing.Point(22, 136);
            this.dgvViewStudents.MultiSelect = false;
            this.dgvViewStudents.Name = "dgvViewStudents";
            this.dgvViewStudents.ReadOnly = true;
            this.dgvViewStudents.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvViewStudents.Size = new System.Drawing.Size(254, 241);
            this.dgvViewStudents.TabIndex = 134;
            this.dgvViewStudents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvViewStudents_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.dgvViewEnrolled);
            this.panel2.Controls.Add(this.cmbSelect2);
            this.panel2.Controls.Add(this.txtSearch2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtName2);
            this.panel2.Controls.Add(this.txtID2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(473, 145);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(295, 396);
            this.panel2.TabIndex = 135;
            // 
            // dgvViewEnrolled
            // 
            this.dgvViewEnrolled.AllowUserToAddRows = false;
            this.dgvViewEnrolled.AllowUserToDeleteRows = false;
            this.dgvViewEnrolled.AllowUserToResizeColumns = false;
            this.dgvViewEnrolled.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvViewEnrolled.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvViewEnrolled.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvViewEnrolled.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvViewEnrolled.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvViewEnrolled.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvViewEnrolled.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvViewEnrolled.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewEnrolled.DoubleBuffered = true;
            this.dgvViewEnrolled.EnableHeadersVisualStyles = false;
            this.dgvViewEnrolled.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.dgvViewEnrolled.HeaderForeColor = System.Drawing.Color.White;
            this.dgvViewEnrolled.Location = new System.Drawing.Point(22, 136);
            this.dgvViewEnrolled.MultiSelect = false;
            this.dgvViewEnrolled.Name = "dgvViewEnrolled";
            this.dgvViewEnrolled.ReadOnly = true;
            this.dgvViewEnrolled.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvViewEnrolled.Size = new System.Drawing.Size(254, 241);
            this.dgvViewEnrolled.TabIndex = 134;
            this.dgvViewEnrolled.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvViewEnrolled_CellClick);
            // 
            // cmbSelect2
            // 
            this.cmbSelect2.BackColor = System.Drawing.Color.Transparent;
            this.cmbSelect2.BorderRadius = 3;
            this.cmbSelect2.DisabledColor = System.Drawing.Color.Gray;
            this.cmbSelect2.ForeColor = System.Drawing.Color.White;
            this.cmbSelect2.Items = new string[] {
        "Student No.",
        "Student Name"};
            this.cmbSelect2.Location = new System.Drawing.Point(21, 76);
            this.cmbSelect2.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSelect2.Name = "cmbSelect2";
            this.cmbSelect2.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.cmbSelect2.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.cmbSelect2.selectedIndex = 0;
            this.cmbSelect2.Size = new System.Drawing.Size(254, 24);
            this.cmbSelect2.TabIndex = 124;
            this.cmbSelect2.onItemSelected += new System.EventHandler(this.CmbSelect2_SelectedIndexChanged);
            // 
            // txtSearch2
            // 
            this.txtSearch2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearch2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtSearch2.BackgroundImage")));
            this.txtSearch2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtSearch2.ForeColor = System.Drawing.Color.Black;
            this.txtSearch2.Icon = ((System.Drawing.Image)(resources.GetObject("txtSearch2.Icon")));
            this.txtSearch2.Location = new System.Drawing.Point(21, 106);
            this.txtSearch2.Name = "txtSearch2";
            this.txtSearch2.Size = new System.Drawing.Size(255, 24);
            this.txtSearch2.TabIndex = 123;
            this.txtSearch2.text = "";
            this.txtSearch2.OnTextChange += new System.EventHandler(this.TxtSearch2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 122;
            this.label2.Text = "Student Name";
            // 
            // txtName2
            // 
            this.txtName2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.txtName2.Enabled = false;
            this.txtName2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName2.Location = new System.Drawing.Point(125, 46);
            this.txtName2.Multiline = true;
            this.txtName2.Name = "txtName2";
            this.txtName2.Size = new System.Drawing.Size(151, 23);
            this.txtName2.TabIndex = 121;
            // 
            // txtID2
            // 
            this.txtID2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.txtID2.Enabled = false;
            this.txtID2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID2.Location = new System.Drawing.Point(125, 19);
            this.txtID2.Multiline = true;
            this.txtID2.Name = "txtID2";
            this.txtID2.Size = new System.Drawing.Size(151, 23);
            this.txtID2.TabIndex = 120;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 119;
            this.label3.Text = "Student No.";
            // 
            // lblSY
            // 
            this.lblSY.AutoSize = true;
            this.lblSY.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSY.Location = new System.Drawing.Point(576, 96);
            this.lblSY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSY.Name = "lblSY";
            this.lblSY.Size = new System.Drawing.Size(79, 17);
            this.lblSY.TabIndex = 141;
            this.lblSY.Text = "School Year:";
            // 
            // lblTerm
            // 
            this.lblTerm.AutoSize = true;
            this.lblTerm.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerm.Location = new System.Drawing.Point(576, 69);
            this.lblTerm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTerm.Name = "lblTerm";
            this.lblTerm.Size = new System.Drawing.Size(40, 17);
            this.lblTerm.TabIndex = 140;
            this.lblTerm.Text = "Term:";
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSub.Location = new System.Drawing.Point(269, 69);
            this.lblSub.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(53, 17);
            this.lblSub.TabIndex = 139;
            this.lblSub.Text = "Subject:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(470, 96);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 138;
            this.label4.Text = "School Year:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(470, 69);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 137;
            this.label5.Text = "Term:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(163, 69);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 136;
            this.label6.Text = "Subject:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(1, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(799, 46);
            this.panel3.TabIndex = 142;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(324, 13);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 21);
            this.label7.TabIndex = 52;
            this.label7.Text = "CHANGE ENROLLED";
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSec.Location = new System.Drawing.Point(269, 96);
            this.lblSec.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(53, 17);
            this.lblSec.TabIndex = 144;
            this.lblSec.Text = "Subject:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(163, 96);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 17);
            this.label10.TabIndex = 143;
            this.label10.Text = "Section:";
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
            this.btnCancel.ButtonText = "Back";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IdleBorderThickness = 1;
            this.btnCancel.IdleCornerRadius = 20;
            this.btnCancel.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnCancel.IdleForecolor = System.Drawing.Color.White;
            this.btnCancel.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnCancel.Location = new System.Drawing.Point(27, 549);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 59);
            this.btnCancel.TabIndex = 145;
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnEnroll
            // 
            this.btnEnroll.ActiveBorderThickness = 1;
            this.btnEnroll.ActiveCornerRadius = 20;
            this.btnEnroll.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnEnroll.ActiveForecolor = System.Drawing.Color.White;
            this.btnEnroll.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnEnroll.BackColor = System.Drawing.SystemColors.Control;
            this.btnEnroll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnroll.BackgroundImage")));
            this.btnEnroll.ButtonText = ">>";
            this.btnEnroll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnroll.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnroll.ForeColor = System.Drawing.Color.White;
            this.btnEnroll.IdleBorderThickness = 1;
            this.btnEnroll.IdleCornerRadius = 20;
            this.btnEnroll.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnEnroll.IdleForecolor = System.Drawing.Color.White;
            this.btnEnroll.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnEnroll.Location = new System.Drawing.Point(350, 251);
            this.btnEnroll.Margin = new System.Windows.Forms.Padding(5);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(100, 59);
            this.btnEnroll.TabIndex = 146;
            this.btnEnroll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEnroll.Click += new System.EventHandler(this.BtnEnroll_Click);
            // 
            // btnUn
            // 
            this.btnUn.ActiveBorderThickness = 1;
            this.btnUn.ActiveCornerRadius = 20;
            this.btnUn.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnUn.ActiveForecolor = System.Drawing.Color.White;
            this.btnUn.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(110)))));
            this.btnUn.BackColor = System.Drawing.SystemColors.Control;
            this.btnUn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUn.BackgroundImage")));
            this.btnUn.ButtonText = "<<";
            this.btnUn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUn.ForeColor = System.Drawing.Color.White;
            this.btnUn.IdleBorderThickness = 1;
            this.btnUn.IdleCornerRadius = 20;
            this.btnUn.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnUn.IdleForecolor = System.Drawing.Color.White;
            this.btnUn.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.btnUn.Location = new System.Drawing.Point(350, 320);
            this.btnUn.Margin = new System.Windows.Forms.Padding(5);
            this.btnUn.Name = "btnUn";
            this.btnUn.Size = new System.Drawing.Size(100, 59);
            this.btnUn.TabIndex = 147;
            this.btnUn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnUn.Click += new System.EventHandler(this.BtnUn_Click);
            // 
            // Section_Students
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 621);
            this.Controls.Add(this.btnUn);
            this.Controls.Add(this.btnEnroll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblSec);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblSY);
            this.Controls.Add(this.lblTerm);
            this.Controls.Add(this.lblSub);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Section_Students";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Section_Students";
            this.Load += new System.EventHandler(this.Section_Students_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewStudents)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewEnrolled)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal Bunifu.Framework.UI.BunifuDropdown cmbSelect;
        private Bunifu.Framework.UI.BunifuTextbox txtSearch;
        private System.Windows.Forms.Label label1;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txtName;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txtID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvViewStudents;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvViewEnrolled;
        internal Bunifu.Framework.UI.BunifuDropdown cmbSelect2;
        private Bunifu.Framework.UI.BunifuTextbox txtSearch2;
        private System.Windows.Forms.Label label2;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txtName2;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txtID2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSY;
        private System.Windows.Forms.Label lblTerm;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label label10;
        private Bunifu.Framework.UI.BunifuThinButton2 btnCancel;
        private Bunifu.Framework.UI.BunifuThinButton2 btnEnroll;
        private Bunifu.Framework.UI.BunifuThinButton2 btnUn;
    }
}