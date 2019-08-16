using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Chekku
{
    public partial class Section : Form
    {


        string id = "";
        string oldname = "";
        string code = "";
        string oldpath = "";

        string subjectID = ""; //pang iba ng folderhuhu
        public Section()
        {
            InitializeComponent();

            cmbSearchTerm.selectedIndex = 0;
            cmbSearchYear.selectedIndex = 0;
            oldname = txtSection.Text;
            View();
            Filter();
            SelectFirst();
            ViewSections();
            selectSections();
        }

        private void View()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                int termnum = Convert.ToInt32(cmbSearchTerm.selectedValue);
                string yearnum = cmbSearchYear.selectedValue.ToString();
                string sql = "SELECT SubjectCode, SubjectName, Term, SchoolYear, SubjectID FROM Chekku.Subjects";

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
        int i = 0;
        private void DgvSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvSubjects.Rows[e.RowIndex];
                //populate
                txtCode.Text = row.Cells[0].Value.ToString();
                System.Console.WriteLine("PUmasok dito." + i);
                this.subjectID = row.Cells[4].Value.ToString();
            }
            i++;
            ViewSections();
            selectSections();
        }


        private void Filter()
        {

            if (!String.IsNullOrWhiteSpace(txtSearch.text) && cmbSearchTerm.selectedIndex > -1 && cmbSearchYear.selectedIndex > -1)
            {
                (dgvSubjects.DataSource as DataTable).DefaultView.RowFilter = string.Format("SubjectCode LIKE '{0}%' AND Term = '{1}' AND SchoolYear LIKE '{2}'", txtSearch.text, Convert.ToInt32(cmbSearchTerm.selectedValue.ToString()), cmbSearchYear.selectedValue.ToString());
            }
            else if (!String.IsNullOrWhiteSpace(txtSearch.text) && cmbSearchTerm.selectedIndex > 0 && cmbSearchYear.selectedIndex <= 0)
            {
                (dgvSubjects.DataSource as DataTable).DefaultView.RowFilter = string.Format("SubjectCode LIKE '{0}%' AND Term = '{1}'", txtSearch.text, Convert.ToInt32(cmbSearchTerm.selectedValue.ToString()));


            }
            else if (!String.IsNullOrWhiteSpace(txtSearch.text) && cmbSearchTerm.selectedIndex <= 0 && cmbSearchYear.selectedIndex > 0)
            {

                (dgvSubjects.DataSource as DataTable).DefaultView.RowFilter = string.Format("SubjectCode LIKE '{0}%' AND SchoolYear = '{1}'", txtSearch.text, cmbSearchYear.selectedValue.ToString());
            }
            else if (String.IsNullOrWhiteSpace(txtSearch.text) && cmbSearchTerm.selectedIndex > -1 && cmbSearchYear.selectedIndex > -1)
            {
                (dgvSubjects.DataSource as DataTable).DefaultView.RowFilter = string.Format("Term = '{0}' AND SchoolYear = '{1}'", Convert.ToInt32(cmbSearchTerm.selectedValue.ToString()), cmbSearchYear.selectedValue.ToString());


            }
            else if (String.IsNullOrWhiteSpace(txtSearch.text) && cmbSearchTerm.selectedIndex > 0 && cmbSearchYear.selectedIndex <= 0)
            {
                (dgvSubjects.DataSource as DataTable).DefaultView.RowFilter = string.Format("Term = '{0}' ", Convert.ToInt32(cmbSearchTerm.selectedValue.ToString()));


            }
            else if (String.IsNullOrWhiteSpace(txtSearch.text) && cmbSearchTerm.selectedIndex <= 0 && cmbSearchYear.selectedIndex > 0)
            {
                (dgvSubjects.DataSource as DataTable).DefaultView.RowFilter = string.Format("SchoolYear = '{0}' ", cmbSearchYear.selectedValue.ToString());


            }
            else
            {
                (dgvSubjects.DataSource as DataTable).DefaultView.RowFilter = string.Format("SubjectCode LIKE '{0}%'", txtSearch.text);
            }

        }


        private void CmbSearchYear_selectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
            SelectFirst();
            ViewSections(); selectSections();
            //lbl1.Text = cmbSearchTerm.selectedIndex.ToString();
            // lbl2.Text = cmbSearchYear.selectedIndex.ToString();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (checkToAdd())
            {
                getCode();
                getSubID();
                Form Add = new Add_Section(id, txtCode.Text, this.subjectID);
                Add.ShowDialog();
                this.Hide();
            }
        }


        public void getSubID()
        {
            Console.WriteLine("pumasok dito. 54353");
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Chekku.getSubjectID", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@SubjectCode", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@SubjectCode"].Value = txtCode.Text;

                    sqlCommand.Parameters.Add(new SqlParameter("@Term", SqlDbType.Int));
                    sqlCommand.Parameters["@Term"].Value = Convert.ToInt32(cmbSearchTerm.selectedValue); 
                    
                    sqlCommand.Parameters.Add(new SqlParameter("@SchoolYear", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@SchoolYear"].Value = cmbSearchYear.selectedValue.ToString();

                    try
                    {
                        connection.Open();
                        id = (String)sqlCommand.ExecuteScalar();
                        Console.WriteLine(id);
                        if (String.IsNullOrEmpty(id))
                        {
                            id = "qwe";
                            oldname = txtSection.Text;
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
            Console.WriteLine(id);
        }


        private bool checkToAdd()
        {
            if (String.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Please select a subject to add a section to.");
                return false;
            }
            else
            {
                return true;
            }
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
            oldpath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/Subjects/" + txtCode.Text + " " +
                    cmbSearchYear.selectedValue.ToString() + " T" + cmbSearchTerm.selectedValue.ToString() + "/" + txtSection.Text ;
        }

        private void Section_Load(object sender, EventArgs e)
        {
            //SelectFirst();
        }

        private void SelectFirst()
        {
            if (dgvSubjects.Rows.Count > 0)
            {
                var row = dgvSubjects.Rows[0];
                txtCode.Text = row.Cells[0].Value.ToString();
                this.subjectID = row.Cells[4].Value.ToString();
                dgvSubjects.CurrentCell = row.Cells[0];
                oldname = txtSection.Text;

            }
            else
            {
                txtCode.Text = "";
                oldname = txtSection.Text;
            }
        }

        private void selectSections()
        {
            if (dgvSections.Rows.Count > 0)
            {
                var row = dgvSections.Rows[0];
                txtSection.Text = row.Cells[0].Value.ToString();
                dgvSections.CurrentCell = row.Cells[0];
                code = row.Cells[1].Value.ToString();
                oldpath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/Subjects/" + txtCode.Text + " " +
                cmbSearchYear.selectedValue.ToString() + " T" + cmbSearchTerm.selectedValue.ToString() + "/" + txtSection.Text;
            }
            else
            {
                id = "";
                txtSection.Text = "";
                code = "";
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Form frm = new Chekku();
            frm.Show();
            this.Hide();
        }


        private void BtnSaveChanges_Click(object sender, EventArgs e)
        {
            UpdateDetails();
            SelectFirst();
            ViewSections();
            selectSections();
        }
        int toggleEdit = 1;
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSection.Text))
            {
                MessageBox.Show("Please select a section first.");
                toggleEdit = 0;
            }
            if (toggleEdit == 1)
            {
                txtSection.ReadOnly= false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnSaveChanges.Visible = true;
                btnEnroll.Visible = false;
                toggleEdit = 0;
            }
            else
            {
                txtSection.ReadOnly= true;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnSaveChanges.Visible = false;
                btnEnroll.Visible = true;
                toggleEdit = 1;
            }
        }

        private void UpdateDetails()
        {
            if (!String.IsNullOrWhiteSpace(txtCode.Text))
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                {
                    int checkState;
                    using (SqlCommand sqlCommand = new SqlCommand("Chekku.updateSection", connection))
                    {
                        getSubID();
                        // MessageBox.Show(Newid);
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add(new SqlParameter("@SubjectID", SqlDbType.VarChar, 50));
                        sqlCommand.Parameters["@SubjectID"].Value = id;

                        sqlCommand.Parameters.Add(new SqlParameter("@SectionName", SqlDbType.VarChar, 50));
                        sqlCommand.Parameters["@SectionName"].Value = txtSection.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@SubSectCode", SqlDbType.VarChar, 50));
                        sqlCommand.Parameters["@SubSectCode"].Value = code;

                        var returnParameter = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        string NewPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/Subjects/" + txtCode.Text + " " +
                                cmbSearchYear.selectedValue.ToString() + " T" + cmbSearchTerm.selectedValue.ToString() + "/" + txtSection.Text;
                        
                        try
                        {
                            connection.Open();
                            sqlCommand.ExecuteNonQuery();
                            checkState = (Int32)returnParameter.Value;
                            if (checkState == 0)
                            {
                                MessageBox.Show("This section already exists!");
                            }
                            else
                            {
                                MessageBox.Show("Section is now updated!");
                                if (!oldpath.Equals(NewPath))
                                {
                                    Directory.Move(oldpath, NewPath);
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Error updating section.");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
                txtSection.ReadOnly= true;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnSaveChanges.Visible = false;
                toggleEdit = 1;
                btnEnroll.Visible = true;
            }
            else
            {
                MessageBox.Show("Please select a section to edit.");
                txtSearch.ResetText();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Chekku.deleteSection", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    getSubID();
                    sqlCommand.Parameters.Add(new SqlParameter("@SubjectID", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@SubjectID"].Value = id;

                    sqlCommand.Parameters.Add(new SqlParameter("@SectionName", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@SectionName"].Value = txtSection.Text;

                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Section is now deleted!");
                    }
                    catch
                    {
                        MessageBox.Show("Error deleting section.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            SelectFirst();
            ViewSections();
            selectSections();
        }

        private void TxtSearchSection_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtSearchSection.text))
            {
                (dgvSections.DataSource as DataTable).DefaultView.RowFilter = string.Format("SectionName LIKE '{0}%'", txtSearchSection.text);
            }
            else
            {
                ViewSections();
            }

            selectSections();
        }

        private void BtnEnroll_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(txtCode.Text) && !String.IsNullOrWhiteSpace(txtSection.Text)){
                Form enroll = new Section_Enrolled(id, code, txtSection.Text);
                this.Hide();
                enroll.Show();
            }
            else
            {
                MessageBox.Show("No section selected", "Please select a section.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void getCode()
        {

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

        private void TxtSearch_OnTextChange(object sender, EventArgs e)
        {
            Filter();
            SelectFirst();
            ViewSections();
            selectSections();
        }
    }
}

