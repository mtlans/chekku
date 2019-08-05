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
        string examCode = "";
        string setNum = "";
        
        public Exams_Section(string id, string code, string section)
        {
            InitializeComponent();
            this.id = id;
            this.code = code;
            loadDetails(id, code);
            btnOpen.Enabled = false;
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
                        lblDesc.Text = oReader["SubjectName"].ToString();
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
                string sql = "SELECT DISTINCT Chekku.Exams.ExamName, Chekku.SetMapper.SetNum, Chekku.Exams.ExamCode FROM Chekku.Exams " +
                    "\nINNER JOIN Chekku.SetMapper ON Chekku.Exams.ExamCode = Chekku.SetMapper.ExamCode WHERE SubSectCode ='" + code + "'";
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

                this.dgvView.Columns[2].Visible = false;
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
            
                string sub = lblSub.Text;
                string term = lblTerm.Text;
                string year = lblSY.Text;
                string sect = lblSec.Text;
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/" + sub + " " + year + " T" + term + "/" + sect + "/Exams";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string answerKeyPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/" + sub + " " + year + " T" + term + "/" + sect + "/Answer Keys";
                string filename = examCode + " " + setNum + ".pdf";
                string Open = path + "/" + filename;

                System.Diagnostics.Process.Start(Open);
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
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Confirm deletion of exam?\nThis will also delete the saved pdf, answer keys, and reports.", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
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
                            deleteFile();
                            MessageBox.Show("Files have now been deleted.");
                            loadExams();

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
        }

        private void deleteFile()
        {
            string sub = lblSub.Text;
            string term = lblTerm.Text;
            string year = lblSY.Text;
            string sect = lblSec.Text;
            string answerKeyPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/" + sub + " " + year + " T" + term + "/" + sect + "/Answer Keys";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/" + sub + " " + year + " T" + term + "/" + sect;
            string filename = examCode + " " + setNum + ".pdf";
            string PDF = path + "/" + filename;
            string ansfilename = examCode + " " + setNum + " Answer Key.pdf";
            string answerKey = answerKeyPath + ansfilename;
            if (File.Exists(PDF))
            {
                File.Delete(PDF);
            }
            if (File.Exists(answerKey))
            {
                File.Delete(answerKey);
            }
        }

    }
}
