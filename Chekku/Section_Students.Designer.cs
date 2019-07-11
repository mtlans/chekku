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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbSelect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvViewStudents = new System.Windows.Forms.DataGridView();
            this.cmbSelect2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtID2 = new System.Windows.Forms.TextBox();
            this.txtSearch2 = new System.Windows.Forms.TextBox();
            this.dgvViewEnrolled = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSub = new System.Windows.Forms.Label();
            this.txtTerm = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.Label();
            this.txtSection = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnEnroll = new System.Windows.Forms.Button();
            this.btnUn = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewEnrolled)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSelect
            // 
            this.cmbSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelect.FormattingEnabled = true;
            this.cmbSelect.Items.AddRange(new object[] {
            "Student No",
            "Student Name"});
            this.cmbSelect.Location = new System.Drawing.Point(53, 183);
            this.cmbSelect.Name = "cmbSelect";
            this.cmbSelect.Size = new System.Drawing.Size(121, 24);
            this.cmbSelect.TabIndex = 35;
            this.cmbSelect.SelectedIndexChanged += new System.EventHandler(this.CmbSelect_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 34;
            this.label2.Text = "Student Name";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(155, 146);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(237, 22);
            this.txtName.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 32;
            this.label1.Text = "Student No.";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(155, 118);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(237, 22);
            this.txtID.TabIndex = 31;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(190, 183);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(201, 22);
            this.txtSearch.TabIndex = 30;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // dgvViewStudents
            // 
            this.dgvViewStudents.AllowUserToAddRows = false;
            this.dgvViewStudents.AllowUserToDeleteRows = false;
            this.dgvViewStudents.AllowUserToResizeColumns = false;
            this.dgvViewStudents.AllowUserToResizeRows = false;
            this.dgvViewStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvViewStudents.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvViewStudents.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvViewStudents.Location = new System.Drawing.Point(53, 231);
            this.dgvViewStudents.MultiSelect = false;
            this.dgvViewStudents.Name = "dgvViewStudents";
            this.dgvViewStudents.ReadOnly = true;
            this.dgvViewStudents.RowHeadersWidth = 51;
            this.dgvViewStudents.RowTemplate.Height = 24;
            this.dgvViewStudents.Size = new System.Drawing.Size(338, 276);
            this.dgvViewStudents.TabIndex = 29;
            this.dgvViewStudents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvViewStudents_CellClick);
            // 
            // cmbSelect2
            // 
            this.cmbSelect2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelect2.FormattingEnabled = true;
            this.cmbSelect2.Items.AddRange(new object[] {
            "Student No",
            "Student Name"});
            this.cmbSelect2.Location = new System.Drawing.Point(660, 183);
            this.cmbSelect2.Name = "cmbSelect2";
            this.cmbSelect2.Size = new System.Drawing.Size(121, 24);
            this.cmbSelect2.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(657, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 41;
            this.label3.Text = "Student Name";
            // 
            // txtName2
            // 
            this.txtName2.Enabled = false;
            this.txtName2.Location = new System.Drawing.Point(762, 146);
            this.txtName2.Name = "txtName2";
            this.txtName2.Size = new System.Drawing.Size(237, 22);
            this.txtName2.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(657, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 39;
            this.label4.Text = "Student No.";
            // 
            // txtID2
            // 
            this.txtID2.Enabled = false;
            this.txtID2.Location = new System.Drawing.Point(762, 118);
            this.txtID2.Name = "txtID2";
            this.txtID2.Size = new System.Drawing.Size(237, 22);
            this.txtID2.TabIndex = 38;
            // 
            // txtSearch2
            // 
            this.txtSearch2.Location = new System.Drawing.Point(797, 183);
            this.txtSearch2.Name = "txtSearch2";
            this.txtSearch2.Size = new System.Drawing.Size(201, 22);
            this.txtSearch2.TabIndex = 37;
            // 
            // dgvViewEnrolled
            // 
            this.dgvViewEnrolled.AllowUserToAddRows = false;
            this.dgvViewEnrolled.AllowUserToDeleteRows = false;
            this.dgvViewEnrolled.AllowUserToResizeColumns = false;
            this.dgvViewEnrolled.AllowUserToResizeRows = false;
            this.dgvViewEnrolled.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvViewEnrolled.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvViewEnrolled.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvViewEnrolled.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvViewEnrolled.Location = new System.Drawing.Point(660, 231);
            this.dgvViewEnrolled.MultiSelect = false;
            this.dgvViewEnrolled.Name = "dgvViewEnrolled";
            this.dgvViewEnrolled.ReadOnly = true;
            this.dgvViewEnrolled.RowHeadersWidth = 51;
            this.dgvViewEnrolled.RowTemplate.Height = 24;
            this.dgvViewEnrolled.Size = new System.Drawing.Size(338, 276);
            this.dgvViewEnrolled.TabIndex = 36;
            this.dgvViewEnrolled.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvViewEnrolled_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 43;
            this.label5.Text = "Subject:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 44;
            this.label6.Text = "Term:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 17);
            this.label7.TabIndex = 45;
            this.label7.Text = "Year:";
            // 
            // txtSub
            // 
            this.txtSub.AutoSize = true;
            this.txtSub.Location = new System.Drawing.Point(151, 28);
            this.txtSub.Name = "txtSub";
            this.txtSub.Size = new System.Drawing.Size(46, 17);
            this.txtSub.TabIndex = 46;
            this.txtSub.Text = "label8";
            // 
            // txtTerm
            // 
            this.txtTerm.AutoSize = true;
            this.txtTerm.Location = new System.Drawing.Point(151, 52);
            this.txtTerm.Name = "txtTerm";
            this.txtTerm.Size = new System.Drawing.Size(46, 17);
            this.txtTerm.TabIndex = 47;
            this.txtTerm.Text = "label9";
            // 
            // txtYear
            // 
            this.txtYear.AutoSize = true;
            this.txtYear.Location = new System.Drawing.Point(151, 75);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(54, 17);
            this.txtYear.TabIndex = 48;
            this.txtYear.Text = "label10";
            // 
            // txtSection
            // 
            this.txtSection.AutoSize = true;
            this.txtSection.Location = new System.Drawing.Point(527, 28);
            this.txtSection.Name = "txtSection";
            this.txtSection.Size = new System.Drawing.Size(54, 17);
            this.txtSection.TabIndex = 50;
            this.txtSection.Text = "label11";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(426, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 17);
            this.label12.TabIndex = 49;
            this.label12.Text = "Section:";
            // 
            // btnEnroll
            // 
            this.btnEnroll.Location = new System.Drawing.Point(472, 268);
            this.btnEnroll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(108, 51);
            this.btnEnroll.TabIndex = 51;
            this.btnEnroll.Text = ">>";
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.BtnEnroll_Click);
            // 
            // btnUn
            // 
            this.btnUn.Location = new System.Drawing.Point(472, 333);
            this.btnUn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUn.Name = "btnUn";
            this.btnUn.Size = new System.Drawing.Size(108, 51);
            this.btnUn.TabIndex = 52;
            this.btnUn.Text = "<<";
            this.btnUn.UseVisualStyleBackColor = true;
            this.btnUn.Click += new System.EventHandler(this.BtnUn_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(53, 557);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(108, 51);
            this.btnBack.TabIndex = 53;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // Section_Students
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 636);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnUn);
            this.Controls.Add(this.btnEnroll);
            this.Controls.Add(this.txtSection);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtTerm);
            this.Controls.Add(this.txtSub);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSelect2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtID2);
            this.Controls.Add(this.txtSearch2);
            this.Controls.Add(this.dgvViewEnrolled);
            this.Controls.Add(this.cmbSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvViewStudents);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Section_Students";
            this.Text = "Section_Students";
            this.Load += new System.EventHandler(this.Section_Students_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewEnrolled)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvViewStudents;
        private System.Windows.Forms.ComboBox cmbSelect2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtID2;
        private System.Windows.Forms.TextBox txtSearch2;
        private System.Windows.Forms.DataGridView dgvViewEnrolled;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label txtSub;
        private System.Windows.Forms.Label txtTerm;
        private System.Windows.Forms.Label txtYear;
        private System.Windows.Forms.Label txtSection;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnEnroll;
        private System.Windows.Forms.Button btnUn;
        private System.Windows.Forms.Button btnBack;
    }
}