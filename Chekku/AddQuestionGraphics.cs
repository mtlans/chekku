using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chekku
{
    public partial class AddQuestionGraphics : Form
    {
        public AddQuestionGraphics()
        {
            InitializeComponent();
        }
        string q, c1, c2, c3, tags, code;
        public AddQuestionGraphics(string q, string c1, string c2, string c3, string tags, string code)
        {
            InitializeComponent();
            this.q = q;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
            this.tags = tags;
            this.code = code;
        }

        private void BtnEq_Click(object sender, EventArgs e)
        {
            Form frm = new Q_Equation(this.q, c1, c2, c3, tags, code);
            this.Hide();
            frm.ShowDialog();
        }

        private void BtnImage_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}
