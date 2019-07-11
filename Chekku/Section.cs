﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Chekku
{
    public partial class Section : Form
    {


        string id = "";
        String oldname = "";
        string code = "";
        public Section()
        {
            InitializeComponent();

            View();
            cmbSearchTerm.SelectedIndex = 0;
            cmbSearchYear.SelectedIndex = 0;
            oldname = txtSection.Text;
        }

        private void View()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                const string sql = "SELECT SubjectCode, SubjectName, Term, SchoolYear FROM Chekku.Subjects";

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
            ViewSections();
            //if (dgvSubjects.Rows.Count > 0)
            //{
            //    int index = dgvSubjects.FirstDisplayedScrollingRowIndex;

            //    dgvSubjects.CurrentCell = dgvSubjects.Rows[index].Cells[0];
            //    dgvSubjects.Rows[index].Selected = true;
            //}
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
            }
            i++;
            ViewSections();
            selectSections();
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

    private void CmbSearchYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
            SelectFirst();
            ViewSections(); selectSections();
            //lbl1.Text = cmbSearchTerm.SelectedIndex.ToString();
            // lbl2.Text = cmbSearchYear.SelectedIndex.ToString();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (checkToAdd())
            {
                getCode();
                getSubID();
                Form Add = new Add_Section(id, txtCode.Text);
                Add.Show();
                this.Hide();
            }
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
        }

        private void Section_Load(object sender, EventArgs e)
        {
            //SelectFirst();
            ViewSections();
            selectSections();
        }

        private void SelectFirst()
        {
            if (dgvSubjects.Rows.Count > 0)
            {
                var row = dgvSubjects.Rows[0];
                txtCode.Text = row.Cells[0].Value.ToString();
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
                lbl1.Text = dgvSections.Rows.Count.ToString();
                lbl2.Text = dgvSubjects.Rows.Count.ToString();
                dgvSections.CurrentCell = row.Cells[0];

                code = row.Cells[1].Value.ToString();
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
                txtSection.Enabled = true;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnSaveChanges.Visible = true;
                btnEnroll.Visible = false;
                toggleEdit = 0;
            }
            else
            {
                txtSection.Enabled = false;
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
                txtSection.Enabled = false;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnSaveChanges.Visible = false;
                toggleEdit = 1;
                btnEnroll.Visible = true;
            }
            else
            {
                MessageBox.Show("Please select a section to edit.");
                txtSearch.Clear();
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

        private void BtnEnroll_Click(object sender, EventArgs e)
        {
            Form enroll = new Section_Enrolled(id, code, txtSection.Text);
            this.Hide();
            enroll.Show();
        }

        private void getCode()
        {

        }
       
    }
}
