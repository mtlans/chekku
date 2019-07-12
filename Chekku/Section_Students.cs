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
    public partial class Section_Students : Form
    {
        string id = "";//subject
        string code = "";//section
        List<Student> MainList = new List<Student>();
        List<Student> Enrolled = new List<Student>();

        public Section_Students(string id, string code, string section)
        {
            InitializeComponent();
            this.id = id;
            this.code = code;
            txtSection.Text = section;
            loadInfo(id);
            //fillDataTable();
            refresh();
            SelectFirst();
            cmbSelect.SelectedIndex = 1;
            cmbSelect2.SelectedIndex = 1;
        }
        private void Section_Students_Load(object sender, EventArgs e)
        {
        }

        private void refresh()
        {
            //var bindingList = new BindingList<Student>(MainList);
            //var source = new BindingSource(bindingList, null);
            //dgvViewStudents.DataSource = source;
            //var bindingList2 = new BindingList<Student>(Enrolled);
            //var source2 = new BindingSource(bindingList2, null);
            //dgvViewEnrolled.DataSource = source2;
            fillDataTable();
            SelectFirst();
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
                        txtSub.Text = oReader["SubjectCode"].ToString();
                        txtTerm.Text = oReader["Term"].ToString();
                        txtYear.Text = oReader["SchoolYear"].ToString();
                    }
                    myConnection.Close();
                }
            }
        }
        
        private void fillDataTable()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                string sql = "SELECT StudentNo, StudentName FROM Chekku.Students " +
                    "EXCEPT\nSELECT StudentNo, StudentName FROM Chekku.SectionStudents " +
                    "WHERE SectStudCode = '" + code + "'";

                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    try
                    {
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

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                string sql = "SELECT StudentNo, StudentName FROM Chekku.SectionStudents WHERE SectStudCode = '" + code + "'";

                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    try
                    {
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            this.dgvViewEnrolled.DataSource = dataTable;
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

        private void DgvViewEnrolled_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvViewEnrolled.Rows[e.RowIndex];
                //populate
                txtID2.Text = row.Cells[0].Value.ToString();
                txtName2.Text = row.Cells[1].Value.ToString();
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Form enroll = new Section_Enrolled(id, code, txtSection.Text);
            this.Hide();
            enroll.Show();
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
            if (dgvViewEnrolled.Rows.Count > 0)
            {
                var row = dgvViewEnrolled.Rows[0];
                txtID2.Text = row.Cells[0].Value.ToString();
                txtName2.Text = row.Cells[1].Value.ToString();
                dgvViewEnrolled.CurrentCell = row.Cells[0];
            }
            else
            {
                txtID2.Text = "";
                txtName2.Text = "";
            }
        }

        private void BtnEnroll_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtID.Text))
            {
                //MainList.RemoveAll(x => x.Id == txtID.Text);
                Enrolled.Add(new Student(txtID.Text, txtName.Text));
                Enroll();
            }

            //DataRow[] drr = dt.Select("Student =' " + id + " ' ");
            //for (int i = 0; i < drr.Length; i++)
            //    drr[i].Delete();
            //dt.AcceptChanges();


            refresh();
        }

        private void BtnUn_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtID2.Text))
            {
                Enrolled.RemoveAll(x => x.Id == txtID2.Text);
                // MainList.Add(new Student(txtID2.Text, txtName2.Text));
                Unenroll();
            }
            refresh();
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

        private void Filter2()
        {
            string toSearch = cmbSelect2.SelectedItem.ToString();
            toSearch = toSearch.Replace(" ", String.Empty);
            if (toSearch.Equals("StudentName"))
            {
                (dgvViewEnrolled.DataSource as DataTable).DefaultView.RowFilter = string.Format("StudentName LIKE '{0}%'", txtSearch2.Text);
            }
            else
            {
                (dgvViewEnrolled.DataSource as DataTable).DefaultView.RowFilter = string.Format("StudentNo LIKE '{0}%'", txtSearch2.Text);
            }
        }

        private void Enroll()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Chekku.EnrollStudent", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@StudentNo", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@StudentNo"].Value = txtID.Text;

                    sqlCommand.Parameters.Add(new SqlParameter("@StudentName", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@StudentName"].Value = txtName.Text;

                    sqlCommand.Parameters.Add(new SqlParameter("@SectStudCode", SqlDbType.VarChar, 50));
                    sqlCommand.Parameters["@SectStudCode"].Value = code;
                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        refresh();
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
        }


        private void Unenroll()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Chekku.UnenrollStudent", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@StudentNo", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@StudentNo"].Value = txtID2.Text;

                    sqlCommand.Parameters.Add(new SqlParameter("@SectStudCode", SqlDbType.VarChar, 50));
                    sqlCommand.Parameters["@SectStudCode"].Value = code;
                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        refresh();
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
        }

        private void CmbSelect2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch2.Clear();
            Filter2();
            SelectFirst();
        }

        private void TxtSearch2_TextChanged(object sender, EventArgs e)
        {
            Filter2();
            SelectFirst();
        }







        //end
    }
}
