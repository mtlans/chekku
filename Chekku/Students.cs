using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Chekku
{
    public partial class Students : Form
    {
        public Students()
        {
            InitializeComponent();
        }
        string num = "";

        private void Students_Load(object sender, EventArgs e)
        {
            refreshView();
            cmbSelect.SelectedIndex = 1;
            SelectFirst();
        }

        public void refreshView()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                const string sql = "SELECT StudentNo, StudentName FROM Chekku.Students";

                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            this.dgvViewStudents.DataSource = dataTable;
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
            if (dgvViewStudents.Rows.Count > 0)
            {
                int index = dgvViewStudents.FirstDisplayedScrollingRowIndex;

                dgvViewStudents.CurrentCell = dgvViewStudents.Rows[index].Cells[0];
                dgvViewStudents.Rows[index].Selected = true;
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
            num = txtID.Text;
        }

        private void BtnAddStudents_Click(object sender, EventArgs e)
        {
            Form frm = new Add_Student();
            frm.ShowDialog();
            refreshView();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Chekku.deleteStudent", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@StudentNo", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@StudentNo"].Value = num;
                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Student is now deleted!");
                    }
                    catch
                    {
                        MessageBox.Show("Error deleting student.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            refreshView();
            dgvViewStudents.CurrentCell = null;
            ResetFields();
        }

        private void ResetFields()
        {
            txtID.Text = "";
            txtName.Text = "";
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Form frm = new Chekku();
            frm.Show();
            this.Hide();
        }
        int toggleEdit = 1;
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Please select a student first.");
                toggleEdit = 0;
            }
            if (toggleEdit == 1)
            {
                txtID.Enabled = true;
                txtName.Enabled = true;
                btnAddStudents.Enabled = false;
                btnDelete.Enabled = false;
                btnSaveChanges.Visible = true;
                toggleEdit = 0;
            }
            else
            {
                txtID.Enabled = false;
                txtName.Enabled = false;
                btnAddStudents.Enabled = true;
                btnDelete.Enabled = true;
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
            if (!String.IsNullOrWhiteSpace(txtID.Text))
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                {
                    int checkState;
                    using (SqlCommand sqlCommand = new SqlCommand("Chekku.updateStudent", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add(new SqlParameter("@Oldno", SqlDbType.VarChar, 8000));
                        sqlCommand.Parameters["@Oldno"].Value = num;

                        sqlCommand.Parameters.Add(new SqlParameter("@StudentNo", SqlDbType.VarChar, 8000));
                        sqlCommand.Parameters["@StudentNo"].Value = txtID.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@StudentName", SqlDbType.VarChar, 8000));
                        sqlCommand.Parameters["@StudentName"].Value = txtName.Text;

                        var returnParameter = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        try
                        {
                            connection.Open();
                            sqlCommand.ExecuteNonQuery();
                            checkState = (Int32)returnParameter.Value;
                            if (checkState == 0)
                            {
                                MessageBox.Show("This student already exists!");
                            }
                            else
                            {
                                MessageBox.Show("Student details are now updated!");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Error updating student details.");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
                txtID.Enabled = false;
                txtName.Enabled = false;
                btnAddStudents.Enabled = true;
                btnDelete.Enabled = true;
                btnSaveChanges.Visible = false;
                toggleEdit = 1;
            }
            else
            {
                MessageBox.Show("Please select a student to edit.");
                txtSearch.Clear();
            }
        }

        private String CreateStudentIdentifier()
        {
            string id = txtID.Text + txtName.Text;
            return id;
        }
        private bool AreFieldsValid()
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Please enter a student number.");
                return false;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter a student name.");
                return false;
            }
            else
                return true;
        }

        private void CmbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Clear();
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
            string toSearch = cmbSelect.SelectedItem.ToString();
            toSearch = toSearch.Replace(" ", String.Empty);
            if (toSearch.Equals("StudentName"))
            {
                (dgvViewStudents.DataSource as DataTable).DefaultView.RowFilter = string.Format("StudentName LIKE '{0}%'", txtSearch.Text);
            }
            else
            {
                (dgvViewStudents.DataSource as DataTable).DefaultView.RowFilter = string.Format("StudentNo LIKE '{0}%'", txtSearch.Text);
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

        private void DgvViewStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
