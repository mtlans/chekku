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
        public CreateExam_Details(string subCode, string subsectCode)
        {
            InitializeComponent();
            loadDetails(subCode, subsectCode);
            subsectcode = subsectCode;
            cmbSet.SelectedIndex = 1;
        }

        private void CreateExam_Details_Load(object sender, EventArgs e)
        {

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
                        lblDesc.Text = oReader["SubjectName"].ToString();
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
            builder.Append(RandomNumber(1, 99));
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

                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        checkState = (Int32)returnParameter.Value;
                        if (checkState == 0)
                        {
                            MessageBox.Show("This section already exists!");
                        }
                        else
                        {
                            Form frm = new Exam_Questions(code, Convert.ToInt32(cmbSet.SelectedItem));
                            frm.Show();
                            this.Hide();
                        }
                        try
                        {

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



    }
}
