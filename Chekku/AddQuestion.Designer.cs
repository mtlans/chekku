namespace Chekku
{
    partial class AddQuestion
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
            this.txtCh3 = new System.Windows.Forms.RichTextBox();
            this.txtCh2 = new System.Windows.Forms.RichTextBox();
            this.txtCh1 = new System.Windows.Forms.RichTextBox();
            this.txtAnswer = new System.Windows.Forms.RichTextBox();
            this.txtQuestion = new System.Windows.Forms.RichTextBox();
            this.btnImage = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.pbox = new System.Windows.Forms.PictureBox();
            this.lblimg = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTags = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblTags = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCh3
            // 
            this.txtCh3.Location = new System.Drawing.Point(35, 423);
            this.txtCh3.Name = "txtCh3";
            this.txtCh3.Size = new System.Drawing.Size(496, 57);
            this.txtCh3.TabIndex = 45;
            this.txtCh3.Text = "";
            // 
            // txtCh2
            // 
            this.txtCh2.Location = new System.Drawing.Point(35, 360);
            this.txtCh2.Name = "txtCh2";
            this.txtCh2.Size = new System.Drawing.Size(496, 57);
            this.txtCh2.TabIndex = 44;
            this.txtCh2.Text = "";
            // 
            // txtCh1
            // 
            this.txtCh1.Location = new System.Drawing.Point(35, 297);
            this.txtCh1.Name = "txtCh1";
            this.txtCh1.Size = new System.Drawing.Size(496, 57);
            this.txtCh1.TabIndex = 43;
            this.txtCh1.Text = "";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(35, 209);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(496, 57);
            this.txtAnswer.TabIndex = 42;
            this.txtAnswer.Text = "";
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(35, 46);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(496, 127);
            this.txtQuestion.TabIndex = 41;
            this.txtQuestion.Text = "";
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(645, 423);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(425, 57);
            this.btnImage.TabIndex = 47;
            this.btnImage.Text = "Add Image";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.BtnImage_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(877, 612);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(193, 56);
            this.btnAdd.TabIndex = 50;
            this.btnAdd.Text = "Add Question";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(35, 602);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(193, 56);
            this.btnBack.TabIndex = 51;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // pbox
            // 
            this.pbox.Location = new System.Drawing.Point(645, 209);
            this.pbox.Name = "pbox";
            this.pbox.Size = new System.Drawing.Size(425, 192);
            this.pbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox.TabIndex = 56;
            this.pbox.TabStop = false;
            // 
            // lblimg
            // 
            this.lblimg.AutoSize = true;
            this.lblimg.Location = new System.Drawing.Point(674, 174);
            this.lblimg.Name = "lblimg";
            this.lblimg.Size = new System.Drawing.Size(46, 17);
            this.lblimg.TabIndex = 57;
            this.lblimg.Text = "label1";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(470, 19);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(46, 17);
            this.lblX.TabIndex = 58;
            this.lblX.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 510);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 59;
            this.label1.Text = "Tags";
            this.label1.Visible = false;
            // 
            // txtTags
            // 
            this.txtTags.Location = new System.Drawing.Point(78, 510);
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(453, 22);
            this.txtTags.TabIndex = 60;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(573, 508);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(147, 74);
            this.btnTest.TabIndex = 61;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // lblTags
            // 
            this.lblTags.AutoSize = true;
            this.lblTags.Location = new System.Drawing.Point(374, 549);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(46, 17);
            this.lblTags.TabIndex = 62;
            this.lblTags.Text = "label2";
            // 
            // AddQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 689);
            this.Controls.Add(this.lblTags);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txtTags);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.lblimg);
            this.Controls.Add(this.pbox);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.txtCh3);
            this.Controls.Add(this.txtCh2);
            this.Controls.Add(this.txtCh1);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.txtQuestion);
            this.Name = "AddQuestion";
            this.Text = "AddQuestion";
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtCh3;
        private System.Windows.Forms.RichTextBox txtCh2;
        private System.Windows.Forms.RichTextBox txtCh1;
        private System.Windows.Forms.RichTextBox txtAnswer;
        private System.Windows.Forms.RichTextBox txtQuestion;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox pbox;
        private System.Windows.Forms.Label lblimg;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTags;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblTags;
    }
}