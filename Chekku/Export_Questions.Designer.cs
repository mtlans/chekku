namespace Chekku
{
    partial class Export_Questions
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
            this.lblNumber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUn = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSearch2 = new System.Windows.Forms.TextBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.txtT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtD = new System.Windows.Forms.RichTextBox();
            this.txtC = new System.Windows.Forms.RichTextBox();
            this.txtB = new System.Windows.Forms.RichTextBox();
            this.txtA = new System.Windows.Forms.RichTextBox();
            this.txtQ = new System.Windows.Forms.RichTextBox();
            this.txtTags = new System.Windows.Forms.TextBox();
            this.txtCh3 = new System.Windows.Forms.RichTextBox();
            this.txtCh2 = new System.Windows.Forms.RichTextBox();
            this.txtCh1 = new System.Windows.Forms.RichTextBox();
            this.txtAnswer = new System.Windows.Forms.RichTextBox();
            this.txtQuestion = new System.Windows.Forms.RichTextBox();
            this.pbI = new System.Windows.Forms.PictureBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(1306, 315);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(35, 13);
            this.lblNumber.TabIndex = 112;
            this.lblNumber.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1207, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 111;
            this.label2.Text = "Number of Items:";
            // 
            // btnUn
            // 
            this.btnUn.Location = new System.Drawing.Point(574, 461);
            this.btnUn.Margin = new System.Windows.Forms.Padding(2);
            this.btnUn.Name = "btnUn";
            this.btnUn.Size = new System.Drawing.Size(86, 40);
            this.btnUn.TabIndex = 110;
            this.btnUn.Text = "<<";
            this.btnUn.UseVisualStyleBackColor = true;
            this.btnUn.Click += new System.EventHandler(this.BtnUn_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(574, 409);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 40);
            this.btnAdd.TabIndex = 109;
            this.btnAdd.Text = ">>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // txtSearch2
            // 
            this.txtSearch2.Location = new System.Drawing.Point(789, 283);
            this.txtSearch2.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch2.Name = "txtSearch2";
            this.txtSearch2.Size = new System.Drawing.Size(400, 20);
            this.txtSearch2.TabIndex = 108;
            this.txtSearch2.TextChanged += new System.EventHandler(this.TxtSearch2_TextChanged);
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeColumns = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItems.Location = new System.Drawing.Point(709, 315);
            this.dgvItems.Margin = new System.Windows.Forms.Padding(2);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersWidth = 51;
            this.dgvItems.RowTemplate.Height = 24;
            this.dgvItems.Size = new System.Drawing.Size(479, 230);
            this.dgvItems.TabIndex = 107;
            this.dgvItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvItems_CellClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(114, 283);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(400, 20);
            this.txtSearch.TabIndex = 106;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvView.Location = new System.Drawing.Point(34, 315);
            this.dgvView.Margin = new System.Windows.Forms.Padding(2);
            this.dgvView.MultiSelect = false;
            this.dgvView.Name = "dgvView";
            this.dgvView.ReadOnly = true;
            this.dgvView.RowHeadersWidth = 51;
            this.dgvView.RowTemplate.Height = 24;
            this.dgvView.Size = new System.Drawing.Size(479, 230);
            this.dgvView.TabIndex = 105;
            this.dgvView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvView_CellClick);
            // 
            // txtT
            // 
            this.txtT.Enabled = false;
            this.txtT.Location = new System.Drawing.Point(641, 254);
            this.txtT.Margin = new System.Windows.Forms.Padding(2);
            this.txtT.Name = "txtT";
            this.txtT.Size = new System.Drawing.Size(548, 20);
            this.txtT.TabIndex = 104;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(641, 177);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 103;
            // 
            // txtD
            // 
            this.txtD.Enabled = false;
            this.txtD.Location = new System.Drawing.Point(919, 195);
            this.txtD.Margin = new System.Windows.Forms.Padding(2);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(270, 46);
            this.txtD.TabIndex = 101;
            this.txtD.Text = "";
            // 
            // txtC
            // 
            this.txtC.Enabled = false;
            this.txtC.Location = new System.Drawing.Point(641, 195);
            this.txtC.Margin = new System.Windows.Forms.Padding(2);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(270, 46);
            this.txtC.TabIndex = 100;
            this.txtC.Text = "";
            // 
            // txtB
            // 
            this.txtB.Enabled = false;
            this.txtB.Location = new System.Drawing.Point(919, 145);
            this.txtB.Margin = new System.Windows.Forms.Padding(2);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(270, 46);
            this.txtB.TabIndex = 99;
            this.txtB.Text = "";
            // 
            // txtA
            // 
            this.txtA.Enabled = false;
            this.txtA.Location = new System.Drawing.Point(641, 145);
            this.txtA.Margin = new System.Windows.Forms.Padding(2);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(270, 46);
            this.txtA.TabIndex = 98;
            this.txtA.Text = "";
            // 
            // txtQ
            // 
            this.txtQ.Enabled = false;
            this.txtQ.Location = new System.Drawing.Point(641, 47);
            this.txtQ.Margin = new System.Windows.Forms.Padding(2);
            this.txtQ.Name = "txtQ";
            this.txtQ.Size = new System.Drawing.Size(326, 82);
            this.txtQ.TabIndex = 97;
            this.txtQ.Text = "";
            // 
            // txtTags
            // 
            this.txtTags.Enabled = false;
            this.txtTags.Location = new System.Drawing.Point(34, 254);
            this.txtTags.Margin = new System.Windows.Forms.Padding(2);
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(548, 20);
            this.txtTags.TabIndex = 96;
            // 
            // txtCh3
            // 
            this.txtCh3.Enabled = false;
            this.txtCh3.Location = new System.Drawing.Point(312, 195);
            this.txtCh3.Margin = new System.Windows.Forms.Padding(2);
            this.txtCh3.Name = "txtCh3";
            this.txtCh3.Size = new System.Drawing.Size(270, 46);
            this.txtCh3.TabIndex = 94;
            this.txtCh3.Text = "";
            // 
            // txtCh2
            // 
            this.txtCh2.Enabled = false;
            this.txtCh2.Location = new System.Drawing.Point(34, 195);
            this.txtCh2.Margin = new System.Windows.Forms.Padding(2);
            this.txtCh2.Name = "txtCh2";
            this.txtCh2.Size = new System.Drawing.Size(270, 46);
            this.txtCh2.TabIndex = 93;
            this.txtCh2.Text = "";
            // 
            // txtCh1
            // 
            this.txtCh1.Enabled = false;
            this.txtCh1.Location = new System.Drawing.Point(312, 145);
            this.txtCh1.Margin = new System.Windows.Forms.Padding(2);
            this.txtCh1.Name = "txtCh1";
            this.txtCh1.Size = new System.Drawing.Size(270, 46);
            this.txtCh1.TabIndex = 92;
            this.txtCh1.Text = "";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Enabled = false;
            this.txtAnswer.Location = new System.Drawing.Point(34, 145);
            this.txtAnswer.Margin = new System.Windows.Forms.Padding(2);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(270, 46);
            this.txtAnswer.TabIndex = 91;
            this.txtAnswer.Text = "";
            // 
            // txtQuestion
            // 
            this.txtQuestion.Enabled = false;
            this.txtQuestion.Location = new System.Drawing.Point(34, 47);
            this.txtQuestion.Margin = new System.Windows.Forms.Padding(2);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(326, 82);
            this.txtQuestion.TabIndex = 90;
            this.txtQuestion.Text = "";
            // 
            // pbI
            // 
            this.pbI.Location = new System.Drawing.Point(994, 47);
            this.pbI.Margin = new System.Windows.Forms.Padding(2);
            this.pbI.Name = "pbI";
            this.pbI.Size = new System.Drawing.Size(194, 81);
            this.pbI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbI.TabIndex = 102;
            this.pbI.TabStop = false;
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(386, 47);
            this.pbImage.Margin = new System.Windows.Forms.Padding(2);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(194, 81);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 95;
            this.pbImage.TabStop = false;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(34, 578);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(123, 46);
            this.btnBack.TabIndex = 113;
            this.btnBack.Text = "Cancel";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(1218, 578);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(123, 46);
            this.btnExport.TabIndex = 114;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // Export_Questions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 635);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnUn);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtSearch2);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvView);
            this.Controls.Add(this.txtT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbI);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.txtQ);
            this.Controls.Add(this.txtTags);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.txtCh3);
            this.Controls.Add(this.txtCh2);
            this.Controls.Add(this.txtCh1);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.txtQuestion);
            this.Name = "Export_Questions";
            this.Text = "Export_Questions";
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUn;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtSearch2;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.TextBox txtT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbI;
        private System.Windows.Forms.RichTextBox txtD;
        private System.Windows.Forms.RichTextBox txtC;
        private System.Windows.Forms.RichTextBox txtB;
        private System.Windows.Forms.RichTextBox txtA;
        private System.Windows.Forms.RichTextBox txtQ;
        private System.Windows.Forms.TextBox txtTags;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.RichTextBox txtCh3;
        private System.Windows.Forms.RichTextBox txtCh2;
        private System.Windows.Forms.RichTextBox txtCh1;
        private System.Windows.Forms.RichTextBox txtAnswer;
        private System.Windows.Forms.RichTextBox txtQuestion;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnExport;
    }
}