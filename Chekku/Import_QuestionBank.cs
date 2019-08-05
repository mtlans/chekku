using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chekku
{
    public partial class Import_QuestionBank : Form
    {
        List<Question> Imports = new List<Question>();
        public Import_QuestionBank()
        {
            InitializeComponent();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = ".txt files|*.txt";
            if (op.ShowDialog() == DialogResult.OK)
            {
                string filename = op.FileName;
                string directory = Path.GetDirectoryName(op.FileName);
                string imgdir = directory + "/Images";
                System.Console.WriteLine(filename);
                System.Console.WriteLine(imgdir);
                GetImports(filename);

                Console.WriteLine("Questions: ");
                foreach (Question x in Imports)
                {
                    Console.WriteLine(x.Quest);
                }
                Console.WriteLine("/n");
                Console.WriteLine("Answers: ");
                foreach (Question x in Imports)
                {
                    Console.WriteLine(x.Answer);
                }

                foreach (Question x in Imports)
                {
                    string imgloc = "";
                    if (x.img == 1)
                    {
                        imgloc = imgdir + "/" + x.Number.ToString() + ".jpg";
                    }
                    AddQuestion add = new AddQuestion(x.Quest, x.Answer, x.choice1, x.choice2, x.choice3, x.img, imgloc);
                    add.ShowDialog();
                }
            }
        }


        private void GetImports(string path)
        {
            using (var f = new StreamReader(path))
            {
                string line = string.Empty;
                while ((line = f.ReadLine()) != null)
                {
                    //public Question(string q, string a, string c1, string c2, string c3, int hI)
                    var parts = line.Split(new string[] { "@@@" }, StringSplitOptions.None);
                    Imports.Add(new Question(Convert.ToInt32(parts[0]), parts[1], parts[2], parts[3], parts[4], parts[5], Convert.ToInt32(parts[6])));
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Form frm = new Questions();
            frm.Show();
            this.Hide();
        }
    }
}
