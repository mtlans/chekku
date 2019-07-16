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
    public partial class Exams : Form
    {
        public Exams()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Form frm = new CreateExam();
            this.Hide();
            frm.Show();
        }
    }
}
