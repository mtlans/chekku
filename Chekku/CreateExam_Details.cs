using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Chekku
{
    public partial class CreateExam_Details : Form
    {
        string subsectcode = "";
        string id = ""; //subjectID
        string code = ""; //sectioncode\
        string oldexamid = "";
        public CreateExam_Details(string subCode, string subsectCode)
        {
            InitializeComponent();
            this.id = subCode;
            this.code = subsectCode;
            loadDetails(subCode, subsectCode);
            subsectcode = subsectCode;
            cmbSet.SelectedIndex = 0;
        }

        public CreateExam_Details(string subCode, string subsectCode, string old)
        {
            InitializeComponent();
            this.id = subCode;
            this.code = subsectCode;
            this.oldexamid = old;
            loadDetails(subCode, subsectCode);
            subsectcode = subsectCode;
            cmbSet.SelectedIndex = 0;
        }

        private void CreateExam_Details_Load(object sender, EventArgs e)
        {

        }

        private void loadDetails(string subCode, string subsectCode)
        {
            Console.WriteLine("YO WTF Oldid: " + oldexamid + " Ayan.");
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

        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(2, true));
            builder.Append(RandomNumber(10, 99));
            return builder.ToString();
        }

        private string generateCode()
        {
            string code = RandomPassword();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                int checkState;
                using (SqlCommand sqlCommand = new SqlCommand("Chekku.checkExamCode", connection))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@ExamCode", SqlDbType.VarChar, 50));
                    sqlCommand.Parameters["@ExamCode"].Value = code;

                    var returnParameter = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        checkState = (Int32)returnParameter.Value;
                        if (checkState == 0)
                        {
                            generateCode();
                        }
                        else
                        {
                            return code;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error adding new subject.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return code;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string code = generateCode();
            if (checkfields())
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                {
                    int checkState;

                    using (SqlCommand sqlCommand = new SqlCommand("Chekku.addNewExam", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add(new SqlParameter("@SubSectCode", SqlDbType.VarChar, 8000));
                        sqlCommand.Parameters["@SubSectCode"].Value = subsectcode;

                        sqlCommand.Parameters.Add(new SqlParameter("@ExamCode", SqlDbType.VarChar, 8000));
                        sqlCommand.Parameters["@ExamCode"].Value = code;

                        sqlCommand.Parameters.Add(new SqlParameter("@ExamName", SqlDbType.VarChar, 8000));
                        sqlCommand.Parameters["@ExamName"].Value = txtExam.Text;

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
                                if (String.IsNullOrWhiteSpace(oldexamid))
                                {
                                    Form frm = new Exam_Questions(code, Convert.ToInt32(cmbSet.SelectedItem), id, this.code);
                                    frm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    Form frm = new Exam_Questions(code, Convert.ToInt32(cmbSet.SelectedItem), id, this.code, oldexamid);
                                    frm.Show();
                                    this.Hide();
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Error creating exam.");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        private bool checkfields()
        {
            if (String.IsNullOrWhiteSpace(txtExam.Text))
            {
                MessageBox.Show("Please enter an exam name.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Form frm = new Exams_Section(id, code, lblSec.Text);
            this.Hide();
            frm.Show();
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
