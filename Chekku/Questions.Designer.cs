namespace Chekku
{
    partial class Questions
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
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtQuestion = new System.Windows.Forms.RichTextBox();
            this.txtAnswer = new System.Windows.Forms.RichTextBox();
            this.txtCh1 = new System.Windows.Forms.RichTextBox();
            this.txtCh2 = new System.Windows.Forms.RichTextBox();
            this.txtCh3 = new System.Windows.Forms.RichTextBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.lblQcode = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtTags = new System.Windows.Forms.TextBox();
            this.btnEditPic = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvView
            // 
            this.dgvView.AllowUserToAddRows = false;
            this.dgvView.AllowUserToDeleteRows = false;
            this.dgvView.AllowUserToResizeColumns = false;
            this.dgvView.AllowUserToResizeRows = false;
            this.dgvView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvView.Location = new System.Drawing.Point(194, 111);
            this.dgvView.MultiSelect = false;
            this.dgvView.Name = "dgvView";
            this.dgvView.ReadOnly = true;
            this.dgvView.RowHeadersWidth = 51;
            this.dgvView.RowTemplate.Height = 24;
            this.dgvView.Size = new System.Drawing.Size(396, 471);
            this.dgvView.TabIndex = 0;
            this.dgvView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvView_CellClick);
            this.dgvView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvView_CellContentClick);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(31, 400);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(143, 57);
            this.btnBack.TabIndex = 33;
            this.btnBack.Text = "Back to Menu";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(31, 281);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(143, 57);
            this.btnDelete.TabIndex = 32;
            this.btnDelete.Text = "Delete Question";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(31, 210);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(143, 57);
            this.btnEdit.TabIndex = 31;
            this.btnEdit.Text = "Edit Question";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(31, 144);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(143, 57);
            this.btnAdd.TabIndex = 30;
            this.btnAdd.Text = "Add Question";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // txtQuestion
            // 
            this.txtQuestion.Enabled = false;
            this.txtQuestion.Location = new System.Drawing.Point(600, 111);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(684, 127);
            this.txtQuestion.TabIndex = 34;
            this.txtQuestion.Text = "";
            this.txtQuestion.TextChanged += new System.EventHandler(this.TxtQuestion_TextChanged);
            // 
            // txtAnswer
            // 
            this.txtAnswer.Enabled = false;
            this.txtAnswer.Location = new System.Drawing.Point(600, 274);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(413, 57);
            this.txtAnswer.TabIndex = 37;
            this.txtAnswer.Text = "";
            // 
            // txtCh1
            // 
            this.txtCh1.Enabled = false;
            this.txtCh1.Location = new System.Drawing.Point(600, 337);
            this.txtCh1.Name = "txtCh1";
            this.txtCh1.Size = new System.Drawing.Size(413, 57);
            this.txtCh1.TabIndex = 38;
            this.txtCh1.Text = "";
            // 
            // txtCh2
            // 
            this.txtCh2.Enabled = false;
            this.txtCh2.Location = new System.Drawing.Point(600, 400);
            this.txtCh2.Name = "txtCh2";
            this.txtCh2.Size = new System.Drawing.Size(413, 57);
            this.txtCh2.TabIndex = 39;
            this.txtCh2.Text = "";
            // 
            // txtCh3
            // 
            this.txtCh3.Enabled = false;
            this.txtCh3.Location = new System.Drawing.Point(600, 463);
            this.txtCh3.Name = "txtCh3";
            this.txtCh3.Size = new System.Drawing.Size(413, 57);
            this.txtCh3.TabIndex = 40;
            this.txtCh3.Text = "";
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(1041, 274);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(243, 157);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 43;
            this.pbImage.TabStop = false;
            // 
            // lblQcode
            // 
            this.lblQcode.AutoSize = true;
            this.lblQcode.Location = new System.Drawing.Point(600, 274);
            this.lblQcode.Name = "lblQcode";
            this.lblQcode.Size = new System.Drawing.Size(0, 17);
            this.lblQcode.TabIndex = 44;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(194, 70);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(301, 22);
            this.txtSearch.TabIndex = 45;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(501, 64);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 35);
            this.btnSearch.TabIndex = 46;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtTags
            // 
            this.txtTags.Enabled = false;
            this.txtTags.Location = new System.Drawing.Point(603, 560);
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(681, 22);
            this.txtTags.TabIndex = 47;
            // 
            // btnEditPic
            // 
            this.btnEditPic.Location = new System.Drawing.Point(1041, 437);
            this.btnEditPic.Name = "btnEditPic";
            this.btnEditPic.Size = new System.Drawing.Size(243, 83);
            this.btnEditPic.TabIndex = 48;
            this.btnEditPic.Text = "Add/Edit Image";
            this.btnEditPic.UseVisualStyleBackColor = true;
            this.btnEditPic.Visible = false;
            this.btnEditPic.Click += new System.EventHandler(this.BtnEditPic_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1041, 600);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(243, 67);
            this.btnSave.TabIndex = 49;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(839, 35);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(46, 17);
            this.lblText.TabIndex = 50;
            this.lblText.Text = "label1";
            // 
            // Questions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 679);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEditPic);
            this.Controls.Add(this.txtTags);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblQcode);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.txtCh3);
            this.Controls.Add(this.txtCh2);
            this.Controls.Add(this.txtCh1);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvView);
            this.Name = "Questions";
            this.Text = "Questions";
            this.Load += new System.EventHandler(this.Questions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RichTextBox txtQuestion;
        private System.Windows.Forms.RichTextBox txtAnswer;
        private System.Windows.Forms.RichTextBox txtCh1;
        private System.Windows.Forms.RichTextBox txtCh2;
        private System.Windows.Forms.RichTextBox txtCh3;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label lblQcode;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtTags;
        private System.Windows.Forms.Button btnEditPic;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblText;
    }
}