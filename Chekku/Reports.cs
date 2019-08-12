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
    public partial class Reports : Form
    {
        List<Student> Students = new List<Student>();
        List<Question> FOE = new List<Question>();
        string examcode = "";
        public Reports()
        {
            InitializeComponent();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = ".txt files|*.txt";
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtFilename.Text = op.FileName;
                string filename = op.FileName;
                string directory = Path.GetDirectoryName(op.FileName);
                string imgdir = directory + "/Images";
                System.Console.WriteLine(filename);
                System.Console.WriteLine(imgdir);
                ExtractInfo(filename);

                Console.WriteLine("Exam Code: " + examcode);

                Console.WriteLine("Students: ");
                foreach (Student x in Students)
                {
                    Console.WriteLine("Student Number: " + x.Id + " Score: " + x.Score);
                }

                Console.WriteLine("Scores: ");
                foreach (Question x in FOE)
                {
                    Console.WriteLine("Setnumber: " + x.SetNum + " Item Number: " + x.Number + " Mistakes: " + x.Mistakes);
                }
                Console.WriteLine("Finished extracting details.");
                
                MessageBox.Show("Successfully extracted details", "Import Success.", MessageBoxButtons.OK);
                Form frm = new Questions();
                frm.Show();
                this.Hide();
            }
        }

        private void ExtractInfo(string path)
        {
            int extractor = 1;
            int setnum = 1;
            using (var f = new StreamReader(path))
            {
                string line = string.Empty;
                while ((line = f.ReadLine()) != null)
                {
                    Console.WriteLine(line + " Extractor: " + extractor);
                    //public Question(string q, string a, string c1, string c2, string c3, int hI)
                    if (line.Contains("ExamCode"))
                    {
                        extractor = 1;
                    }
                    else if (line.Contains("Scores"))
                    {
                        extractor = 2;
                    }
                    else if(line.Contains("Set"))
                    {
                        extractor = 3;
                    }

                    if(extractor == 1)
                    {
                        if (!String.IsNullOrWhiteSpace(line))
                        {
                            var parts = line.Split('\t');
                            examcode = parts[1];
                        }
                    }
                    else if(extractor == 2)
                    {
                        if (!String.IsNullOrWhiteSpace(line))
                        {
                            if (!line.Contains("Scores"))
                            {
                                var parts = line.Split('\t');
                                Students.Add(new Student(parts[0], Convert.ToInt32(parts[1])));
                            }
                        }
                    }
                    else if(extractor == 3)
                    {
                        if (!String.IsNullOrWhiteSpace(line))
                        {
                            if (line.Contains("Set"))
                            {
                                var parts = line.Split('\t');
                                setnum = Convert.ToInt32(parts[1]);
                            }
                            else
                            {
                                var parts = line.Split('\t');
                                FOE.Add(new Question(setnum, Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1])));
                            }
                        }
                    }
                }

                    
            }
        }

            

        
    }
}
