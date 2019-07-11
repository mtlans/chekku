namespace Chekku
{
    partial class Section_Enrolled
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtYear = new System.Windows.Forms.Label();
            this.txtTerm = new System.Windows.Forms.Label();
            this.txtSub = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSelect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvViewStudents = new System.Windows.Forms.DataGridView();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtSection = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // txtYear
            // 
            this.txtYear.AutoSize = true;
            this.txtYear.Location = new System.Drawing.Point(146, 54);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(54, 17);
            this.txtYear.TabIndex = 61;
            this.txtYear.Text = "label10";
            // 
            // txtTerm
            // 
            this.txtTerm.AutoSize = true;
            this.txtTerm.Location = new System.Drawing.Point(348, 31);
            this.txtTerm.Name = "txtTerm";
            this.txtTerm.Size = new System.Drawing.Size(46, 17);
            this.txtTerm.TabIndex = 60;
            this.txtTerm.Text = "label9";
            // 
            // txtSub
            // 
            this.txtSub.AutoSize = true;
            this.txtSub.Location = new System.Drawing.Point(146, 31);
            this.txtSub.Name = "txtSub";
            this.txtSub.Size = new System.Drawing.Size(46, 17);
            this.txtSub.TabIndex = 59;
            this.txtSub.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 17);
            this.label7.TabIndex = 58;
            this.label7.Text = "Year:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(247, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 57;
            this.label6.Text = "Term:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 56;
            this.label5.Text = "Subject:";
            // 
            // cmbSelect
            // 
            this.cmbSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelect.FormattingEnabled = true;
            this.cmbSelect.Items.AddRange(new object[] {
            "Student No",
            "Student Name"});
            this.cmbSelect.Location = new System.Drawing.Point(48, 165);
            this.cmbSelect.Name = "cmbSelect";
            this.cmbSelect.Size = new System.Drawing.Size(121, 24);
            this.cmbSelect.TabIndex = 55;
            this.cmbSelect.SelectedIndexChanged += new System.EventHandler(this.CmbSelect_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 54;
            this.label2.Text = "Student Name";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(149, 127);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(245, 22);
            this.txtName.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 52;
            this.label1.Text = "Student No.";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(149, 100);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(245, 22);
            this.txtID.TabIndex = 51;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(185, 165);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(209, 22);
            this.txtSearch.TabIndex = 50;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvViewStudents.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvViewStudents.Location = new System.Drawing.Point(48, 213);
            this.dgvViewStudents.MultiSelect = false;
            this.dgvViewStudents.Name = "dgvViewStudents";
            this.dgvViewStudents.ReadOnly = true;
            this.dgvViewStudents.RowHeadersWidth = 51;
            this.dgvViewStudents.RowTemplate.Height = 24;
            this.dgvViewStudents.Size = new System.Drawing.Size(346, 276);
            this.dgvViewStudents.TabIndex = 49;
            this.dgvViewStudents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvViewStudents_CellClick);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(268, 515);
            this.btnChange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(126, 50);
            this.btnChange.TabIndex = 62;
            this.btnChange.Text = "Change Enrolled";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.BtnChange_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(48, 515);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(121, 50);
            this.btnBack.TabIndex = 63;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // txtSection
            // 
            this.txtSection.AutoSize = true;
            this.txtSection.Location = new System.Drawing.Point(348, 54);
            this.txtSection.Name = "txtSection";
            this.txtSection.Size = new System.Drawing.Size(54, 17);
            this.txtSection.TabIndex = 65;
            this.txtSection.Text = "label11";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(247, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 17);
            this.label12.TabIndex = 64;
            this.label12.Text = "Section:";
            // 
            // Section_Enrolled
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 595);
            this.Controls.Add(this.txtSection);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtTerm);
            this.Controls.Add(this.txtSub);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvViewStudents);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Section_Enrolled";
            this.Text = "Section_Enrolled";
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtYear;
        private System.Windows.Forms.Label txtTerm;
        private System.Windows.Forms.Label txtSub;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvViewStudents;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label txtSection;
        private System.Windows.Forms.Label label12;
    }
}