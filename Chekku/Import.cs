using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chekku
{
    public partial class Import : Form
    {
        List<Question> Imports = new List<Question>();

        List<Student> Students = new List<Student>();
        List<Question> FOE = new List<Question>();
        string examcode = "";
        int s = 1;
        string ssc = "";
        public Import(int state)
        {
            s = state;
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
                int added = 0;
                foreach (Question x in Imports)
                {
                    string imgloc = "";
                    if (x.img == 1)
                    {
                        imgloc = imgdir + "/" + x.Number.ToString() + ".jpg";
                    }
                    if(hasTags == 1)
                    {

                        AddQuestion add = new AddQuestion(x.Quest, x.Answer, x.choice1, x.choice2, x.choice3, x.img, x.base6, x.TL);

                        add.ShowDialog();
                        add.Hide();
                        added = added + add.added;
                        add.Dispose();
                    }
                    else if(hasTags == 0)
                    {

                        AddQuestion add = new AddQuestion(x.Quest, x.Answer, x.choice1, x.choice2, x.choice3, x.img, x.base6);

                        add.ShowDialog();
                        add.Hide();
                        added = added + add.added;
                        add.Dispose();

                    }
                }
                MessageBox.Show("Successfully imported " + added + " questions.", "Import Success.", MessageBoxButtons.OK);
                Form frm = new Questions();
                frm.Show();
                this.Hide();
            }
        }

        int hasTags = 0;
        private void GetImports(string path)
        {
            DialogResult dr = MessageBox.Show("Would you like to import the tags?", "Import tags", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                hasTags = 1;
                Console.WriteLine("Hastags = " + hasTags);
            }
            else
            {
                hasTags = 0;
            }
            using (var f = new StreamReader(path))
            {
                string line = string.Empty;
                while ((line = f.ReadLine()) != null)
                {
                    //public Question(string q, string a, string c1, string c2, string c3, int hI)
                    var parts = line.Split(new string[] { "@@@" }, StringSplitOptions.None);
                    Imports.Add(new Question(Convert.ToInt32(parts[0]), parts[1], parts[2], parts[3], parts[4], parts[5],parts[6], Convert.ToInt32(parts[7]), parts[8]));
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (s == 1)
            {
                Form frm = new Questions();
                frm.Show();
                this.Hide();
            }
            else
            {
                Form frm = new Reports();
                frm.Show();
                this.Hide();
            }
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
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
                    else if (line.Contains("Set"))
                    {
                        extractor = 3;
                    }

                    if (extractor == 1)
                    {
                        if (!String.IsNullOrWhiteSpace(line))
                        {
                            var parts = line.Split('\t');
                            examcode = parts[1];
                        }
                    }
                    else if (extractor == 2)
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
                    else if (extractor == 3)
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

        private void BtnUploadReport_Click(object sender, EventArgs e)
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
                getSSC(examcode);

                Console.WriteLine("Students: ");
                foreach (Student x in Students)
                {
                    checkEnrolled(x.Id);
                    Console.WriteLine("Student Number: " + x.Id + " Score: " + x.Score);
                }

                foreach (Student x in Students)
                {
                    Console.WriteLine("Student Number: " + x.Id + " Score: " + x.Score);
                    putScore(x.Id, x.Score);
                }

                Console.WriteLine("Scores: ");
                foreach (Question x in FOE)
                {
                    addFOE(x.Mistakes, x.Number, x.SetNum);
                    Console.WriteLine("Setnumber: " + x.SetNum + " Item Number: " + x.Number + " Mistakes: " + x.Mistakes);
                }
                Console.WriteLine("Finished extracting details.");

                MessageBox.Show("Successfully extracted details", "Import Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (s == 1)
                {
                    Form frm = new Questions();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    Form frm = new Reports();
                    frm.Show();
                    this.Hide();
                }
            }
        }

        private void getSSC(string ec)
        {
            using (SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                string oString = "Select SubSectCode from Chekku.Exams where ExamCode=@ec";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@ec", ec);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        ssc = oReader["SubSectCode"].ToString();
                    }
                    myConnection.Close();
                }
            }
            Console.WriteLine(ssc);
        }
        private bool checkEnrolled(string num)
        {
            string enrolled = "";
            using (SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                string oString = "Select * from Chekku.SectionStudents where StudentNo=@num and SectStudCode =@ssc";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@num", num);
                oCmd.Parameters.AddWithValue("@ssc", ssc);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        enrolled = oReader["StudentNo"].ToString();
                    }
                    myConnection.Close();
                }
                if (String.IsNullOrWhiteSpace(enrolled))
                {
                    bool exists = checkExists(num);
                    if (exists)
                    {
                        EnrollStudent(num);
                        return true;
                    }
                    else
                    {
                        if(MessageBox.Show("No record of student number " + num + " in records.\nPlease add student.", 
                            "No student record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                        {
                            Form frm = new Add_Student(num, 1);
                            frm.ShowDialog();
                            EnrollStudent(num);
                        }
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("True");
                    return true;
                }
            }
        }
        private bool checkExists(string num)
        {
            string name = "";
            using (SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                string oString = "Select * from Chekku.Students where StudentNo=@num";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@num", num);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        name = oReader["StudentName"].ToString();
                    }
                    myConnection.Close();
                }
                if (String.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("False");
                    return false;
                }
                else
                {
                    Console.WriteLine("True");
                    return true;
                }
            }
        }
        private void EnrollStudent(string num)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Chekku.EnrollStudent", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@StudentNo", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@StudentNo"].Value = num;

                    sqlCommand.Parameters.Add(new SqlParameter("@SectStudCode", SqlDbType.VarChar, 50));
                    sqlCommand.Parameters["@SectStudCode"].Value = ssc;
                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Error enrolling student.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void putScore(string num, int score)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Chekku.addScore", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@StudentNo", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@StudentNo"].Value = num;

                    sqlCommand.Parameters.Add(new SqlParameter("@ExamCode", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@ExamCode"].Value = examcode;

                    sqlCommand.Parameters.Add(new SqlParameter("@Score", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@Score"].Value = score;

                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Error adding score.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void addFOE(int m, int i, int snum)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Chekku.addFOE", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@Mistakes", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@Mistakes"].Value = m;

                    sqlCommand.Parameters.Add(new SqlParameter("@ExamCode", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@ExamCode"].Value = examcode;

                    sqlCommand.Parameters.Add(new SqlParameter("@ItemNumber", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@ItemNumber"].Value = i;

                    sqlCommand.Parameters.Add(new SqlParameter("@SetNum", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@SetNum"].Value = snum;
                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Error adding FOE.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void Import_Load(object sender, EventArgs e)
        {
            if (s == 1)
            {
                btnUploadReport.Visible = false;
                btnImport.Visible = true;
                lblQues.Visible = true;
                lblImport.Visible = false;
            }
            else
            {
                btnImport.Visible = false;
                btnUploadReport.Visible = true;
                lblQues.Visible = false;
                lblImport.Visible = true;
            }
        }
    }
}

