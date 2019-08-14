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
    public partial class Reports_Section : Form
    {
        string id = ""; //subjectID
        string code = ""; //subSectCode
        string examCode = "";
        int itemNum = 0;    
        public Reports_Section(string id, string code, string section)
        {
            InitializeComponent();
            this.id = id;
            this.code = code;
            loadDetails(id, code);
            loadReports();

            SelectFirst();
            Console.WriteLine(itemNum);
        }

        private void loadDetails(string subCode, string subsectCode)
        {
            using (SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                string oString = "Select * from Chekku.Subjects where SubjectID=@SubjectID";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@SubjectID", subCode);
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
                oString = "Select * from Chekku.Section where SubSectCode=@SubSectCode";
                oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@SubSectCode", subsectCode);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        lblSec.Text = oReader["SectionName"].ToString();
                    }
                    myConnection.Close();
                }
            }
        }

        private void loadReports()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                string sql = "SELECT DISTINCT Chekku.Exams.ExamName, Chekku.Exams.ExamCode, MAX(Chekku.SetMapper.ItemNumber) FROM Chekku.Exams" +
                    "\nINNER JOIN Chekku.SetMapper ON Chekku.Exams.ExamCode = Chekku.SetMapper.ExamCode " +
                    " WHERE SubSectCode ='" + code + "' AND hasReport = 1 AND SetNum = 1" +
                    "\nGROUP BY Chekku.Exams.ExamCode, Chekku.Exams.ExamName";
                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    connection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            this.dgvView.DataSource = dataTable;
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
               // this.dgvView.Columns[2].Visible = false;
            }
        }


        private void SelectFirst()
        {
            if (dgvView.Rows.Count > 0)
            {
                var row = dgvView.Rows[0];
                examCode = row.Cells[1].Value.ToString();
                itemNum = Convert.ToInt32(row.Cells[2].Value.ToString());
                dgvView.CurrentCell = row.Cells[0];
                if (!String.IsNullOrWhiteSpace(examCode))
                {
                    btnView.Enabled = true;
                }
                else
                {
                    btnView.Enabled = false;
                }
            }
            else
            {
                examCode = "";
                itemNum = 0;
            }
        }

        private void Reports_Section_Load(object sender, EventArgs e)
        {
            SelectFirst();
            Console.WriteLine(itemNum);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Form frm = new Reports();
            frm.Show();
            this.Hide();
        }

        private void DgvView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvView.Rows[e.RowIndex];
                //populate
                examCode = row.Cells[1].Value.ToString();
                itemNum = Convert.ToInt32(row.Cells[2].Value.ToString());
                if (!String.IsNullOrWhiteSpace(examCode))
                {
                    btnView.Enabled = true;
                }
                else
                {
                    btnView.Enabled = false;
                }
            }
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Reports_Section_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            Form frm = new ReportTables(examCode, itemNum, id, code);
            frm.Show();
            this.Hide();
        }
    }
}
