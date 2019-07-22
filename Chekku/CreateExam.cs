using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Chekku
{
    public partial class CreateExam : Form
    {
        public CreateExam()
        {
            InitializeComponent();
            View();
            cmbSearchTerm.SelectedIndex = 0;
            cmbSearchYear.SelectedIndex = 0;
        }

        string id = "";
        string code = "";
        string oldname = "";
        string subsectcode = "";
        string subid = "";

        private void View()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                const string sql = "SELECT SubjectCode, SubjectName, Term, SchoolYear, SubjectID FROM Chekku.Subjects";

                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            this.dgvSubjects.DataSource = dataTable;
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
            this.dgvSubjects.Columns[1].Visible = false;
            this.dgvSubjects.Columns[2].Visible = false;
            this.dgvSubjects.Columns[3].Visible = false;
            this.dgvSubjects.Columns[4].Visible = false;
            ViewSections();
        }

        private void ViewSections()
        {

            //if (!String.IsNullOrWhiteSpace(txtCode.Text))
            //{
            getSubID();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                string sql = "SELECT SectionName, SubSectCode FROM Chekku.Section WHERE SubjectID ='" + id + "'";
                //string sql = "SELECT SectionName FROM Chekku.Section WHERE SubjectID =''";
                //string sql = "SELECT SectionName FROM Chekku.Section WHERE SubjectID = 'POLGOVTPolitics and Governance12019 - 2020'";
                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            this.dgvSections.DataSource = dataTable;
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
            this.dgvSections.Columns[1].Visible = false;
        }

        private void DgvSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvSubjects.Rows[e.RowIndex];
                //populate
                txtCode.Text = row.Cells[0].Value.ToString();
                subid = row.Cells[4].Value.ToString();
            }
            ViewSections();
            selectSections();
        }

        private void DgvSections_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvSections.Rows[e.RowIndex];
                //populate
                txtSection.Text = row.Cells[0].Value.ToString();
                code = row.Cells[1].Value.ToString();
                oldname = txtSection.Text;
            }
        }

        private void SelectFirst()
        {
            if (dgvSubjects.Rows.Count > 0)
            {
                var row = dgvSubjects.Rows[0];
                txtCode.Text = row.Cells[0].Value.ToString();
                dgvSubjects.CurrentCell = row.Cells[0];
                subid = row.Cells[4].Value.ToString();
                oldname = txtSection.Text;
            }
            else
            {
                txtCode.Text = "";
                oldname = txtSection.Text;
                subid = "";
            }
        }

        private void selectSections()
        {
            if (dgvSections.Rows.Count > 0)
            {
                var row = dgvSections.Rows[0];
                txtSection.Text = row.Cells[0].Value.ToString();
                lbl1.Text = dgvSections.Rows.Count.ToString();
                lbl2.Text = dgvSubjects.Rows.Count.ToString();
                dgvSections.CurrentCell = row.Cells[0];
                subsectcode = row.Cells[1].Value.ToString();
                code = row.Cells[1].Value.ToString();
            }
            else
            {
                id = "";
                txtSection.Text = "";
                code = "";
                subsectcode = "";
            }
        }

        private void Filter()
        {

            if (!String.IsNullOrWhiteSpace(txtSearch.Text) && cmbSearchTerm.SelectedIndex > -1 && cmbSearchYear.SelectedIndex > -1)
            {
                (dgvSubjects.DataSource as DataTable).DefaultView.RowFilter = string.Format("SubjectCode LIKE '{0}%' AND Term = '{1}' AND SchoolYear LIKE '{2}'", txtSearch.Text, Convert.ToInt32(cmbSearchTerm.SelectedItem.ToString()), cmbSearchYear.SelectedItem.ToString());

            }
            else if (!String.IsNullOrWhiteSpace(txtSearch.Text) && cmbSearchTerm.SelectedIndex > 0 && cmbSearchYear.SelectedIndex <= 0)
            {
                (dgvSubjects.DataSource as DataTable).DefaultView.RowFilter = string.Format("SubjectCode LIKE '{0}%' AND Term = '{1}'", txtSearch.Text, Convert.ToInt32(cmbSearchTerm.SelectedItem.ToString()));


            }
            else if (!String.IsNullOrWhiteSpace(txtSearch.Text) && cmbSearchTerm.SelectedIndex <= 0 && cmbSearchYear.SelectedIndex > 0)
            {

                (dgvSubjects.DataSource as DataTable).DefaultView.RowFilter = string.Format("SubjectCode LIKE '{0}%' AND SchoolYear = '{1}'", txtSearch.Text, cmbSearchYear.SelectedItem.ToString());
            }
            else if (String.IsNullOrWhiteSpace(txtSearch.Text) && cmbSearchTerm.SelectedIndex > -1 && cmbSearchYear.SelectedIndex > -1)
            {
                (dgvSubjects.DataSource as DataTable).DefaultView.RowFilter = string.Format("Term = '{0}' AND SchoolYear = '{1}'", Convert.ToInt32(cmbSearchTerm.SelectedItem.ToString()), cmbSearchYear.SelectedItem.ToString());
            }
            else if (String.IsNullOrWhiteSpace(txtSearch.Text) && cmbSearchTerm.SelectedIndex > 0 && cmbSearchYear.SelectedIndex <= 0)
            {
                (dgvSubjects.DataSource as DataTable).DefaultView.RowFilter = string.Format("Term = '{0}' ", Convert.ToInt32(cmbSearchTerm.SelectedItem.ToString()));


            }
            else if (String.IsNullOrWhiteSpace(txtSearch.Text) && cmbSearchTerm.SelectedIndex <= 0 && cmbSearchYear.SelectedIndex > 0)
            {
                (dgvSubjects.DataSource as DataTable).DefaultView.RowFilter = string.Format("SchoolYear = '{0}' ", cmbSearchYear.SelectedItem.ToString());
            }
            else
            {
                (dgvSubjects.DataSource as DataTable).DefaultView.RowFilter = string.Format("SubjectCode LIKE '{0}%'", txtSearch.Text);
            }

        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            Filter();
            SelectFirst();
            ViewSections();
            selectSections();
        }

        private void TxtSearchSection_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtSearchSection.Text))
            {
                (dgvSections.DataSource as DataTable).DefaultView.RowFilter = string.Format("SectionName LIKE '{0}%'", txtSearchSection.Text);
            }
            else
            {
                ViewSections();
            }

            selectSections();
        }

        private void CmbSearchTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
            SelectFirst();
            ViewSections(); selectSections();
        }

        public void getSubID()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Chekku.getSubjectID", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@SubjectCode", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@SubjectCode"].Value = txtCode.Text;

                    sqlCommand.Parameters.Add(new SqlParameter("@Term", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@Term"].Value = cmbSearchTerm.Text;

                    sqlCommand.Parameters.Add(new SqlParameter("@SchoolYear", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@SchoolYear"].Value = cmbSearchYear.Text;

                    try
                    {
                        connection.Open();


                        id = (String)sqlCommand.ExecuteScalar();
                        if (String.IsNullOrEmpty(id))
                        {
                            id = "";
                            oldname = txtSection.Text;
                        }
                        else
                        {
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error adding new student.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtSection.Text))
            {
                Form frm = new CreateExam_Details(subid, subsectcode);
                this.Hide();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Please select a section first.");
            }
        }
    }
}
