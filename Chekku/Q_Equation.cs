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
    public partial class Q_Equation : Form
    {
        string q, c1, c2, c3, tags, code;
        public Q_Equation(string q, string c1, string c2, string c3, string tags, string code)
        {
            InitializeComponent();
            this.q = q;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
            this.tags = tags;
            this.code = code;
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            string rtf = Convert.ToString(rtbEquation.Rtf);
            Form q = new AddQuestion(this.q, c1, c2, c3, tags, code, 1, 0, rtf);
            q.Show();
            this.Close();
        }
    }
}
