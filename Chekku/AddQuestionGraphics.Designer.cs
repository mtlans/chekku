namespace Chekku
{
    partial class AddQuestionGraphics
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
            this.btnEq = new System.Windows.Forms.Button();
            this.btnImage = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEq
            // 
            this.btnEq.Location = new System.Drawing.Point(23, 26);
            this.btnEq.Name = "btnEq";
            this.btnEq.Size = new System.Drawing.Size(404, 119);
            this.btnEq.TabIndex = 0;
            this.btnEq.Text = "Equation";
            this.btnEq.UseVisualStyleBackColor = true;
            this.btnEq.Click += new System.EventHandler(this.BtnEq_Click);
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(23, 160);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(404, 119);
            this.btnImage.TabIndex = 1;
            this.btnImage.Text = "Image";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.BtnImage_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(23, 352);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(404, 57);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.Button3_Click);
            // 
            // AddQuestionGraphics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 440);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.btnEq);
            this.Name = "AddQuestionGraphics";
            this.Text = "AddQuestionGraphics";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEq;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.Button btnCancel;
    }
}