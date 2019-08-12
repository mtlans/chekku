using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Chekku
{
    public partial class Section_Enrolled : Form
    {
        string id = ""; //subjectID
        string code = ""; //sectioncode
        public Section_Enrolled(string id, string code, string section)
        {
            InitializeComponent();


            this.id = id;
            this.code = code;
            loadData();
            loadInfo(id);
            cmbSelect.selectedIndex = 1;
            lblSec.Text = section;
            // loadInfo(code);
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            Form enroll = new Section_Students(id, code, lblSec.Text);
            this.Close();
            enroll.Show();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Form enroll = new Section();
            this.Close();
            enroll.Show();
        }

        private void loadInfo(string id)
        {
            using (SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                string oString = "Select * from Chekku.Subjects where SubjectID=@Code";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@Code", id);
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
            }
        }

        private void loadData()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                string sql = "SELECT Chekku.SectionStudents.StudentNo, Chekku.Students.StudentName FROM Chekku.SectionStudents " +
                    "INNER JOIN Chekku.Students ON Chekku.SectionStudents.StudentNo = Chekku.Students.StudentNo" +
                    "\nWHERE SectStudCode = '" + code + "'";

                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        this.dgvViewStudents.DataSource = dataTable;
                        dataReader.Close();
                    }
                    try
                    {
                        
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

        private void DgvViewStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvViewStudents.Rows[e.RowIndex];
                //populate
                txtID.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
            }
        }

        private void CmbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.ResetText();
            Filter();
            SelectFirst();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            Filter();
            SelectFirst();
        }

        private void Filter()
        {
            string toSearch = cmbSelect.selectedValue.ToString();
            toSearch = toSearch.Replace(" ", String.Empty);
            if (toSearch.Equals("StudentName"))
            {
                (dgvViewStudents.DataSource as DataTable).DefaultView.RowFilter = string.Format("StudentName LIKE '{0}%'", txtSearch.text);
            }
            else
            {
                (dgvViewStudents.DataSource as DataTable).DefaultView.RowFilter = string.Format("StudentNo LIKE '{0}%'", txtSearch.text);
            }
        }

        private void SelectFirst()
        {
            if (dgvViewStudents.Rows.Count > 0)
            {
                var row = dgvViewStudents.Rows[0];
                txtID.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                dgvViewStudents.CurrentCell = row.Cells[0];
            }
            else
            {
                txtID.Text = "";
                txtName.Text = "";
            }
        }
    }
}
