using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Chekku
{
    public partial class Subjects : Form
    {

        string Oldid = "";
        string oldPath = "";
        public Subjects()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form frm = new Add_Subject();
            frm.ShowDialog();
            refreshView();
        }

        private void Subjects_Load(object sender, EventArgs e)
        {
            refreshView();
            cmbSearchYear.selectedIndex = -1;
            cmbSearchTerm.selectedIndex = -1;
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
                DataGridViewRow row = this.dgvView.Rows[e.RowIndex];
                //populate
                txtCode.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtTerm.Text = row.Cells[2].Value.ToString();
                txtYear.Text = row.Cells[3].Value.ToString();
                cmbTerm.SelectedValue = row.Cells[2].Value.ToString();
                cmbYear.SelectedValue = row.Cells[3].Value.ToString();
                Oldid = row.Cells[4].Value.ToString();
            }

            oldPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/Subjects/" + txtCode.Text + " " + txtYear.Text + " T" + txtTerm.Text;

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
            if (dgvView.Rows.Count > 0)
            {
                int index = dgvView.FirstDisplayedScrollingRowIndex;
                dgvView.CurrentCell = dgvView.Rows[index].Cells[0];
                dgvView.Rows[index].Selected = true;
            }
            this.dgvView.Columns[1].Visible = false;
            this.dgvView.Columns[4].Visible = false;
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
                txtCode.ReadOnly=false;
                txtName.ReadOnly=false;
                cmbTerm.Enabled = true;
                cmbYear.Enabled = true;
                btnAdd.Enabled = false;
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
                txtCode.ReadOnly= true;
                txtName.ReadOnly= true;
                cmbTerm.Enabled = false;
                cmbYear.Enabled = false;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnBack.Enabled = true;
                cmbTerm.Visible = false;
                cmbYear.Visible = false;
                txtTerm.Visible = true;
                txtYear.Visible = true;
                btnSaveChanges.Visible = false;
                toggleEdit = 1;
            }
            refreshView();
            SelectFirst();
        }

        private void BtnSaveChanges_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtCode.Text) || (String.IsNullOrWhiteSpace(txtName.Text)))
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
                            string NewPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/Subjects/" + txtCode.Text + " " +
                            cmbYear.SelectedItem.ToString() + " T" + cmbTerm.SelectedItem.ToString();
                            Directory.Move(oldPath, NewPath);
                        }
                        try
                        {

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

                txtCode.ReadOnly = true;
                txtName.ReadOnly = true;
                cmbTerm.Enabled = false;
                cmbYear.Enabled = false;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnBack.Enabled = true;
                cmbTerm.Visible = false;
                cmbYear.Visible = false;
                txtTerm.Visible = true;
                txtYear.Visible = true;
                btnSaveChanges.Visible = false;
                toggleEdit = 1;
            }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete the subject?", "Delete Subject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {

            }
            else
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
                                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/Subjects/" + txtCode.Text + " " + txtYear.Text + " T" + txtTerm.Text;
                                Console.WriteLine("Path = " + path);
                                if (Directory.Exists(path))
                                {
                                    Directory.Delete(path);
                                }
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
                }
                else
                {
                    MessageBox.Show("Please select a subject to delete.");
                }
                refreshView();



            }

        }


        private void DgvViewSubjects_Selectionhanged(object sender, EventArgs e)
        {
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

            System.Console.WriteLine(txtSearch.Text);
            Filter(); 
            SelectFirst();
        }


        private void CmbSearchTerm_selectedIndexChanged(object sender, EventArgs e)
        {
            Filter(); 
            SelectFirst();
        }

        private void Filter()
        {
            if (!String.IsNullOrWhiteSpace(txtSearch.text) && cmbSearchTerm.selectedIndex > 0 && cmbSearchYear.selectedIndex > 0)
            {
                (dgvView.DataSource as DataTable).DefaultView.RowFilter = string.Format("SubjectCode LIKE '{0}%' AND Term = '{1}' AND SchoolYear LIKE '{2}'", txtSearch.text, Convert.ToInt32(cmbSearchTerm.selectedValue.ToString()), cmbSearchYear.selectedValue.ToString());
        
            }
            else if (!String.IsNullOrWhiteSpace(txtSearch.text) && cmbSearchTerm.selectedIndex > 0 && cmbSearchYear.selectedIndex <= 0)
            {
                (dgvView.DataSource as DataTable).DefaultView.RowFilter = string.Format("SubjectCode LIKE '{0}%' AND Term = '{1}'", txtSearch.text, Convert.ToInt32(cmbSearchTerm.selectedValue.ToString()));

            }
            else if (!String.IsNullOrWhiteSpace(txtSearch.text) && cmbSearchTerm.selectedIndex <= 0 && cmbSearchYear.selectedIndex > 0)
            {

             (dgvView.DataSource as DataTable).DefaultView.RowFilter = string.Format("SubjectCode LIKE '{0}%' AND SchoolYear = '{1}'", txtSearch.text, cmbSearchYear.selectedValue.ToString());
            }
            else if (String.IsNullOrWhiteSpace(txtSearch.text) && cmbSearchTerm.selectedIndex > 0 && cmbSearchYear.selectedIndex > 0)
            {
                (dgvView.DataSource as DataTable).DefaultView.RowFilter = string.Format("Term = '{0}' AND SchoolYear = '{1}'", Convert.ToInt32(cmbSearchTerm.selectedValue.ToString()), cmbSearchYear.selectedValue.ToString());

            }
            else if (String.IsNullOrWhiteSpace(txtSearch.text) && cmbSearchTerm.selectedIndex > 0 && cmbSearchYear.selectedIndex <= 0)
            {
                (dgvView.DataSource as DataTable).DefaultView.RowFilter = string.Format("Term = '{0}' ", Convert.ToInt32(cmbSearchTerm.selectedValue.ToString()));

            }
            else if (String.IsNullOrWhiteSpace(txtSearch.text) && cmbSearchTerm.selectedIndex <= 0 && cmbSearchYear.selectedIndex > 0)
            {
                (dgvView.DataSource as DataTable).DefaultView.RowFilter = string.Format("SchoolYear = '{0}' ", cmbSearchYear.selectedValue.ToString());

            }
            else
            { (dgvView.DataSource as DataTable).DefaultView.RowFilter = string.Format("SubjectCode LIKE '{0}%'", txtSearch.text);
            }

        }


        private void SelectFirst()
        {
            if (dgvView.Rows.Count > 0)
            {
                var row = dgvView.Rows[0];
                txtCode.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtTerm.Text = row.Cells[2].Value.ToString();
                txtYear.Text = row.Cells[3].Value.ToString();
                cmbTerm.SelectedItem = row.Cells[2].Value.ToString();
                cmbYear.SelectedItem = row.Cells[3].Value.ToString();
                Oldid = row.Cells[4].Value.ToString();
                dgvView.CurrentCell = row.Cells[0];
                oldPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/Subjects/" + txtCode.Text + " " + txtYear.Text + " T" + txtTerm.Text;
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
    }
}
