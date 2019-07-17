using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            loadExams();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Form frm = new CreateExam();
            this.Hide();
            frm.Show();
        }

        private void loadExams()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                //const string sql = "SELECT DISTINCT Question, QuestionCode FROM Chekku.QTags";

                string sql = "SELECT ExamName FROM Chekku.Exams";
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
    }
}
