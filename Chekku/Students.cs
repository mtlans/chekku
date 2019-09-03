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
        string oldnum = "";
        string oldname = "";
        private void Students_Load(object sender, EventArgs e)
        {
            refreshView();
            cmbSelect.selectedIndex = 1;
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
                oldnum = row.Cells[0].Value.ToString();
                oldname = row.Cells[1].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
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
                    sqlCommand.Parameters["@StudentNo"].Value = txtID.Text;
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
                txtID.ReadOnly= false;
                txtName.ReadOnly= false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Visible = true;
                toggleEdit = 0;
            }
            else
            {
                txtID.ReadOnly= true;
                txtName.ReadOnly= true;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Visible = false;
                toggleEdit = 1;
            }
            refreshView();
            SelectFirst();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtID.Text) || (String.IsNullOrWhiteSpace(txtName.Text)))
            {
                MessageBox.Show("Please do not leave any blanks on the required fields.");
                txtSearch.ResetText();
            }
            else
            {

                UpdateDetails();
                refreshView();
            }
        }

private void UpdateDetails()
        {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                {
                    int checkState;
                    using (SqlCommand sqlCommand = new SqlCommand("Chekku.updateStudent", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add(new SqlParameter("@Oldno", SqlDbType.VarChar, 8000));
                        sqlCommand.Parameters["@Oldno"].Value = oldnum;

                        sqlCommand.Parameters.Add(new SqlParameter("@OldName", SqlDbType.VarChar, 8000));
                        sqlCommand.Parameters["@OldName"].Value = oldname;

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
                txtID.ReadOnly= true;
                txtName.ReadOnly= true;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Visible = false;
                toggleEdit = 1;
            refreshView();
            SelectFirst();
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
                oldnum = row.Cells[0].Value.ToString();
                oldname = row.Cells[1].Value.ToString();
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
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
