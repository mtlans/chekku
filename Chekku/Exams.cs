﻿using System;
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
        string id = "";
        string oldname = "";
        string code = "";
        string SubSectCode = "";

        string i1, c1, s1, oldexamid;
        int reuse = 0;
        public Exams()
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

        public Exams(int i, string id, string code, string section, string old)
        {
            InitializeComponent();
            reuse = i;
            i1 = id;
            c1 = code;
            s1 = section;
            oldexamid = old;
            btnExams.Text = "Select Section";
            btnBack.Text = "Cancel";
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
            }
            i++;
            ViewSections();
            selectSections();
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

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            Filter();
            SelectFirst();
            ViewSections();
            selectSections();
        }

        private void CmbSearchTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
            SelectFirst();
            ViewSections(); selectSections();
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
            }
            else
            {
                id = "";
                txtSection.Text = "";
                code = "";
            }
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

        private void BtnExams_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrWhiteSpace(txtSection.Text))
            {
                if(reuse == 1)
                {
                    Form frm = new CreateExam_Details(id, code, oldexamid);
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    Form frm = new Exams_Section(id, code, txtSection.Text);
                    frm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Please select a section first.");
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (reuse == 1)
            {
                Form frm = new Exams_Section(id, code, txtSection.Text);
                frm.Show();
                this.Hide();
            }
            else
            {
                Form frm = new Chekku();
                frm.Show();
                this.Hide();
            }
        }

        private void Exams_Load(object sender, EventArgs e)
        {

        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Exams_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
