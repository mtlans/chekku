using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Chekku
{
    public partial class Exams_Section : Form
    {
        string id = ""; //subjectID
        string code = ""; //subSectCode
        string s = "";
        string examCode = "";
        string setNum = "";
        
        public Exams_Section(string id, string code, string section)
        {
            InitializeComponent();
            this.id = id;
            this.code = code;
            this.s = section;
            loadDetails(id, code);
            btnOpen.Enabled= false;
            loadExams();
        }
        private void loadDetails(string subCode, string subsectCode)
        {
             
            using (SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                string oString = "Select * from Chekku.Subjects where SubjectID=@SubjectID";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@SubjectID", subCode);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        lblSub.Text = oReader["SubjectCode"].ToString();
                        lblTerm.Text = oReader["Term"].ToString();
                        lblSY.Text = oReader["SchoolYear"].ToString();
                    }
                    myConnection.Close();
                }
                oString = "Select * from Chekku.Section where SubSectCode=@SubSectCode";
                oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@SubSectCode", subsectCode);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        lblSec.Text = oReader["SectionName"].ToString();
                    }
                    myConnection.Close();
                }

            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Form frm = new CreateExam_Details(id, code);
            this.Hide();
            frm.Show();
        }

        private void loadExams()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                string sql = "SELECT DISTINCT Chekku.Exams.ExamName, MAX(Chekku.SetMapper.SetNum), Chekku.Exams.ExamCode FROM Chekku.Exams " +
                    "\nINNER JOIN Chekku.SetMapper ON Chekku.Exams.ExamCode = Chekku.SetMapper.ExamCode WHERE SubSectCode ='" + code + "'" +
                    "\nGROUP BY Chekku.Exams.ExamCode, Chekku.Exams.ExamName";
                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            this.dgvView.DataSource = dataTable;
                            dataReader.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("EWAN KO BA.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                this.dgvView.Columns[1].Visible = false;
                this.dgvView.Columns[2].Visible = false;
            }
        }

        private void SelectFirst()
        {
            if (dgvView.Rows.Count > 0)
            {
                var row = dgvView.Rows[0];
                setNum = row.Cells[1].Value.ToString();
                examCode = row.Cells[2].Value.ToString();
                dgvView.CurrentCell = row.Cells[0];

                Console.WriteLine(examCode + " setNUM: " + setNum);
                if (!String.IsNullOrWhiteSpace(examCode))
                {
                    btnOpen.Enabled= true;
                }
                else
                {
                    btnOpen.Enabled = false;
                }
            }
            else
            {
                setNum = "";
                examCode = "";
            }

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Form frm = new Exams();
            frm.Show();
            this.Hide();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= Convert.ToInt32(setNum); i++)
            {
                string sub = lblSub.Text;
                string term = lblTerm.Text;
                string year = lblSY.Text;
                string sect = lblSec.Text;
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/Subjects/" + sub + " " + year + " T" + term + "/" + sect + "/Exams";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string answerKeyPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/Subjects/" + sub + " " + year + " T" + term + "/" + sect + "/Answer Keys";
                string filename = examCode + " " + i + ".pdf";
                string Open = path + "/" + filename;

                System.Diagnostics.Process.Start(Open);
            }
        }

        private void DgvView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvView.Rows[e.RowIndex];
                //populate
                examCode = row.Cells[2].Value.ToString();
                setNum = row.Cells[1].Value.ToString();
                if (!String.IsNullOrWhiteSpace(examCode))
                {
                    btnOpen.Enabled = true;
                }
                else
                {
                    btnOpen.Enabled = false;
                }
            }

            Console.WriteLine(examCode + " setNUM: " + setNum);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Confirm deletion of exam?\nThis will also delete the saved pdf, answer keys, and reports.", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("Chekku.deleteExam", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add(new SqlParameter("@ExamCode", SqlDbType.VarChar, 8000));
                        sqlCommand.Parameters["@ExamCode"].Value = examCode;

                        try
                        {
                            connection.Open();
                            sqlCommand.ExecuteNonQuery();
                            for(int i = 0; i<Convert.ToInt32(setNum); i++)
                            {
                                deleteFile(examCode, i);
                            }
                            MessageBox.Show("Files have now been deleted.");
                        }
                        catch
                        {
                            MessageBox.Show("Error deleting exam.");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }

            loadExams();
        }

        private void deleteFile(string examcode, int i)
        {
            i = i + 1;
            string sub = lblSub.Text;
            string term = lblTerm.Text;
            string year = lblSY.Text;
            string sect = lblSec.Text;
            string answerKeyPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/Subjects/" + sub + " " + year + " T" + term + "/" + sect + "/Answer Keys";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/Subjects/" + sub + " " + year + " T" + term + "/" + sect + "/Exams";
            string filename = examcode + " " + i.ToString() + ".pdf";
            string PDF = path + "/" + filename;
            Console.WriteLine(PDF);
            string ansfilename = examCode + " " + i.ToString() + " Answer Key.pdf";
            string answerKey = answerKeyPath + "/" +  ansfilename;
            Console.WriteLine(answerKey);
            if (File.Exists(PDF))
            {
                File.Delete(PDF);
            }
            if (File.Exists(answerKey))
            {
                File.Delete(answerKey);
            }
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Exams_Section_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Exams_Section_Load(object sender, EventArgs e)
        {
            SelectFirst();
        }

        private void BtnReuse_Click(object sender, EventArgs e)
        {
            Form frm = new Exams(1, id, code, s, examCode);
            frm.Show();
            this.Hide();
        }
    }
}
