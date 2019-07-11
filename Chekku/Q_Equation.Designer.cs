namespace Chekku
{
    partial class Q_Equation
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
            this.btnCancelEq = new System.Windows.Forms.Button();
            this.lblEq = new System.Windows.Forms.Label();
            this.rtbEquation = new System.Windows.Forms.RichTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancelEq
            // 
            this.btnCancelEq.Location = new System.Drawing.Point(28, 204);
            this.btnCancelEq.Name = "btnCancelEq";
            this.btnCancelEq.Size = new System.Drawing.Size(169, 34);
            this.btnCancelEq.TabIndex = 58;
            this.btnCancelEq.Text = "Cancel";
            this.btnCancelEq.UseVisualStyleBackColor = true;
            // 
            // lblEq
            // 
            this.lblEq.AutoSize = true;
            this.lblEq.Location = new System.Drawing.Point(25, 27);
            this.lblEq.Name = "lblEq";
            this.lblEq.Size = new System.Drawing.Size(172, 17);
            this.lblEq.TabIndex = 57;
            this.lblEq.Text = "Paste your equation here:";
            // 
            // rtbEquation
            // 
            this.rtbEquation.Location = new System.Drawing.Point(28, 50);
            this.rtbEquation.Name = "rtbEquation";
            this.rtbEquation.Size = new System.Drawing.Size(533, 120);
            this.rtbEquation.TabIndex = 56;
            this.rtbEquation.Text = "";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(392, 204);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(169, 34);
            this.btnAccept.TabIndex = 59;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // Q_Equation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 264);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancelEq);
            this.Controls.Add(this.lblEq);
            this.Controls.Add(this.rtbEquation);
            this.Name = "Q_Equation";
            this.Text = "Q_Equation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelEq;
        private System.Windows.Forms.Label lblEq;
        private System.Windows.Forms.RichTextBox rtbEquation;
        private System.Windows.Forms.Button btnAccept;
    }
}