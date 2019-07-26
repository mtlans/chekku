using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Chekku
{
    public partial class Exams_Section : Form
    {
        string id = ""; //subjectID
        string code = ""; //subSectCode
        public Exams_Section(string id, string code, string section)
        {
            InitializeComponent();
            this.id = id;
            this.code = code;
            loadExams();
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
                string sql = "SELECT ExamName FROM Chekku.Exams WHERE SubSectCode ='" + code+"'";
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
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Form frm = new Exams();
            frm.Show();
            this.Hide();
        }
    }
}
