using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Chekku
{
    public partial class Subjects : Form
    {

        string Oldid = "";

        public Subjects()
        {
            InitializeComponent();
        }

        private void BtnAddSubjects_Click(object sender, EventArgs e)
        {
            Form frm = new Add_Subject();
            frm.ShowDialog();
            refreshView();
        }

        private void Subjects_Load(object sender, EventArgs e)
        {
            refreshView();
            cmbSearchYear.SelectedIndex = -1;
            cmbSearchTerm.SelectedIndex = -1;
            SelectFirst();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Form frm = new Chekku();
            frm.Show();
            this.Hide();
        }

        private void DgvViewSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvViewSubjects.Rows[e.RowIndex];
                //populate
                txtCode.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtTerm.Text = row.Cells[2].Value.ToString();
                txtYear.Text = row.Cells[3].Value.ToString();
                cmbTerm.SelectedItem = row.Cells[2].Value.ToString();
                cmbYear.SelectedItem = row.Cells[3].Value.ToString();
                Oldid = row.Cells[4].Value.ToString();
            }

            lblID.Text = Oldid;

        }

        public void refreshView()
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
                            this.dgvViewSubjects.DataSource = dataTable;
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
            if (dgvViewSubjects.Rows.Count > 0)
            {
                int index = dgvViewSubjects.FirstDisplayedScrollingRowIndex;

                dgvViewSubjects.CurrentCell = dgvViewSubjects.Rows[index].Cells[0];
                dgvViewSubjects.Rows[index].Selected = true;
            }

            this.dgvViewSubjects.Columns[4].Visible = false;
            SelectFirst();
        }




        int toggleEdit = 1;
        private void BtnEditSubjects_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Please select a subject first.");
                toggleEdit = 0;
            }

            if (toggleEdit == 1)
            {
                txtCode.Enabled = true;
                txtName.Enabled = true;
                cmbTerm.Enabled = true;
                cmbYear.Enabled = true;
                btnAddSubjects.Enabled = false;
                btnDelete.Enabled = false;
                btnBack.Enabled = false;
                cmbTerm.Visible = true;
                cmbYear.Visible = true;
                txtTerm.Visible = false;
                txtYear.Visible = false;
                btnSaveChanges.Visible = true;
                toggleEdit = 0;
            }
            else
            {
                txtCode.Enabled = false;
                txtName.Enabled = false;
                cmbTerm.Enabled = false;
                cmbYear.Enabled = false;
                btnAddSubjects.Enabled = true;
                btnDelete.Enabled = true;
                btnBack.Enabled = true;
                cmbTerm.Visible = false;
                cmbYear.Visible = false;
                txtTerm.Visible = true;
                txtYear.Visible = true;
                btnSaveChanges.Visible = false;
                toggleEdit = 1;
            }
        }

        private void BtnSaveChanges_Click(object sender, EventArgs e)
        {
            UpdateDetails();
            refreshView();
        }


        private void UpdateDetails()
        {
            if (!String.IsNullOrWhiteSpace(txtCode.Text))
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                {
                    int checkState;
                    using (SqlCommand sqlCommand = new SqlCommand("Chekku.updateSubject", connection))
                    {
                        // MessageBox.Show(Newid);
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add(new SqlParameter("@SubjectID", SqlDbType.VarChar, 50));
                        sqlCommand.Parameters["@SubjectID"].Value = Oldid;

                        sqlCommand.Parameters.Add(new SqlParameter("@SubjectCode", SqlDbType.VarChar, 50));
                        sqlCommand.Parameters["@SubjectCode"].Value = txtCode.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@SubjectName", SqlDbType.VarChar, 8000));
                        sqlCommand.Parameters["@SubjectName"].Value = txtName.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Term", SqlDbType.Int));
                        sqlCommand.Parameters["@Term"].Value = cmbTerm.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@SchoolYear", SqlDbType.VarChar, 50));
                        sqlCommand.Parameters["@SchoolYear"].Value = cmbYear.Text;

                        var returnParameter = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;


                        try
                        {
                            connection.Open();
                            sqlCommand.ExecuteNonQuery();
                            checkState = (Int32)returnParameter.Value;
                            if (checkState == 0)
                            {
                                MessageBox.Show("This subject already exists!");
                            }
                            else
                            {
                                MessageBox.Show("Subject is now updated!");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Error updating new subject.");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
                txtCode.Enabled = false;
                txtName.Enabled = false;
                cmbTerm.Enabled = false;
                cmbYear.Enabled = false;
                btnAddSubjects.Enabled = true;
                btnDelete.Enabled = true;
                btnBack.Enabled = true;
                cmbTerm.Visible = false;
                cmbYear.Visible = false;
                txtTerm.Visible = true;
                txtYear.Visible = true;
                btnSaveChanges.Visible = false;
                toggleEdit = 1;
            }
            else
            {
                MessageBox.Show("Please select a subject to edit.");
                txtSearch.Clear();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtCode.Text))
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("Chekku.deleteSubject", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add(new SqlParameter("@SubjectID", SqlDbType.VarChar, 50));
                        sqlCommand.Parameters["@SubjectID"].Value = Oldid;
                        try
                        {
                            connection.Open();
                            sqlCommand.ExecuteNonQuery();
                            MessageBox.Show("Subject is now deleted!");
                        }
                        catch
                        {
                            MessageBox.Show("Error deleting subject.");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
                refreshView();
                dgvViewSubjects.CurrentCell = null;
                ResetFields();
            }
            else
            {
                MessageBox.Show("Please select a subject to delete.");
            }

        }


        private void DgvViewSubjects_Selectionhanged(object sender, EventArgs e)
        {
        }

        private void ResetFields()
        {
            txtCode.Text = "";
            txtName.Text = "";
            cmbTerm.Text = "";
            cmbYear.Text = "";
        }

        private bool AreFieldsValid()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Please enter a subject code.");
                return false;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter a subject name.");
                return false;
            }
            else
                return true;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            Filter(); lblindex1.Text = Convert.ToString(cmbSearchTerm.SelectedIndex); lblindex2.Text = Convert.ToString(cmbSearchYear.SelectedIndex);

            SelectFirst();
        }


        private void CmbSearchTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter(); //lblindex1.Text = Convert.ToString(cmbSearchTerm.SelectedIndex); lblindex2.Text = Convert.ToString(cmbSearchYear.SelectedIndex);

            SelectFirst();
        }

        private void Filter()
        {
            if (!String.IsNullOrWhiteSpace(txtSearch.Text) && cmbSearchTerm.SelectedIndex > 0 && cmbSearchYear.SelectedIndex > 0)
            {
                (dgvViewSubjects.DataSource as DataTable).DefaultView.RowFilter = string.Format("SubjectCode LIKE '{0}%' AND Term = '{1}' AND SchoolYear LIKE '{2}'", txtSearch.Text, Convert.ToInt32(cmbSearchTerm.SelectedItem.ToString()), cmbSearchYear.SelectedItem.ToString());
                lblCHOICE.Text = "1";
            }
            else if (!String.IsNullOrWhiteSpace(txtSearch.Text) && cmbSearchTerm.SelectedIndex > 0 && cmbSearchYear.SelectedIndex <= 0)
            {
                (dgvViewSubjects.DataSource as DataTable).DefaultView.RowFilter = string.Format("SubjectCode LIKE '{0}%' AND Term = '{1}'", txtSearch.Text, Convert.ToInt32(cmbSearchTerm.SelectedItem.ToString()));

                lblCHOICE.Text = "2";
            }
            else if (!String.IsNullOrWhiteSpace(txtSearch.Text) && cmbSearchTerm.SelectedIndex <= 0 && cmbSearchYear.SelectedIndex > 0)
            {

                lblCHOICE.Text = "3"; (dgvViewSubjects.DataSource as DataTable).DefaultView.RowFilter = string.Format("SubjectCode LIKE '{0}%' AND SchoolYear = '{1}'", txtSearch.Text, cmbSearchYear.SelectedItem.ToString());
            }
            else if (String.IsNullOrWhiteSpace(txtSearch.Text) && cmbSearchTerm.SelectedIndex > 0 && cmbSearchYear.SelectedIndex > 0)
            {
                (dgvViewSubjects.DataSource as DataTable).DefaultView.RowFilter = string.Format("Term = '{0}' AND SchoolYear = '{1}'", Convert.ToInt32(cmbSearchTerm.SelectedItem.ToString()), cmbSearchYear.SelectedItem.ToString());

                lblCHOICE.Text = "4";
            }
            else if (String.IsNullOrWhiteSpace(txtSearch.Text) && cmbSearchTerm.SelectedIndex > 0 && cmbSearchYear.SelectedIndex <= 0)
            {
                (dgvViewSubjects.DataSource as DataTable).DefaultView.RowFilter = string.Format("Term = '{0}' ", Convert.ToInt32(cmbSearchTerm.SelectedItem.ToString()));

                lblCHOICE.Text = "5";
            }
            else if (String.IsNullOrWhiteSpace(txtSearch.Text) && cmbSearchTerm.SelectedIndex <= 0 && cmbSearchYear.SelectedIndex > 0)
            {
                (dgvViewSubjects.DataSource as DataTable).DefaultView.RowFilter = string.Format("SchoolYear = '{0}' ", cmbSearchYear.SelectedItem.ToString());

                lblCHOICE.Text = "6";
            }
            else
            {
                lblCHOICE.Text = "7"; (dgvViewSubjects.DataSource as DataTable).DefaultView.RowFilter = string.Format("SubjectCode LIKE '{0}%'", txtSearch.Text);
            }

        }


        private void SelectFirst()
        {
            if (dgvViewSubjects.Rows.Count > 0)
            {
                var row = dgvViewSubjects.Rows[0];
                txtCode.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtTerm.Text = row.Cells[2].Value.ToString();
                txtYear.Text = row.Cells[3].Value.ToString();
                cmbTerm.SelectedItem = row.Cells[2].Value.ToString();
                cmbYear.SelectedItem = row.Cells[3].Value.ToString();
                Oldid = row.Cells[4].Value.ToString();
                dgvViewSubjects.CurrentCell = row.Cells[0];
            }
            else
            {
                txtCode.Text = "";
                txtName.Text = "";
                txtTerm.Text = "";
                txtYear.Text = "";
                cmbTerm.SelectedIndex = -1;
                cmbYear.SelectedIndex = -1;
            }
        }
    }
}
