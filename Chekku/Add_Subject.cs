using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Chekku
{
    public partial class Add_Subject : Form
    {
        public Add_Subject()
        {
            InitializeComponent();
            cmbTerm.SelectedIndex = 0;
            cmbYear.SelectedIndex = 0;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (AreFieldsValid())
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                {
                    int checkState;
                    using (SqlCommand sqlCommand = new SqlCommand("Chekku.addNewSubject", connection))
                    {
                        string id = generateID();
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add(new SqlParameter("@SubjectID", SqlDbType.VarChar, 50));
                        sqlCommand.Parameters["@SubjectID"].Value = id;

                        sqlCommand.Parameters.Add(new SqlParameter("@SubjectCode", SqlDbType.VarChar, 50));
                        sqlCommand.Parameters["@SubjectCode"].Value = txtSubjectCode.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@SubjectName", SqlDbType.VarChar, 8000));
                        sqlCommand.Parameters["@SubjectName"].Value = txtSubjectName.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Term", SqlDbType.Int));
                        sqlCommand.Parameters["@Term"].Value = cmbTerm.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@SchoolYear", SqlDbType.VarChar, 50));
                        sqlCommand.Parameters["@SchoolYear"].Value = cmbYear.Text;

                        var returnParameter = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;
                        try
                        {
                            connection.Open();
                            sqlCommand.ExecuteNonQuery();
                            checkState = (Int32)returnParameter.Value;
                            if (checkState == 0)
                            {
                                MessageBox.Show("This subject already exists!");
                            }
                            else
                            {
                                MessageBox.Show("Subject is now added!");
                                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/Subjects/" + txtSubjectCode.Text + " " + cmbYear.SelectedItem.ToString() + " T" + cmbTerm.SelectedItem.ToString();
                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path);
                                }
                                this.Close();
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
            }
        }







        private bool AreFieldsValid()
        {
            if (txtSubjectCode.Text == "")
            {
                MessageBox.Show("Please enter a subject code.");
                return false;
            }
            if (txtSubjectName.Text == "")
            {
                MessageBox.Show("Please enter a subject name.");
                return false;
            }
            else
                return true;
        }


        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        // Generate a random string with a given size  
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

        public string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(2, true));
            builder.Append(RandomNumber(1000, 9999));
            return builder.ToString();
        }

        private String generateID()
        {
            string id = RandomPassword();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                int checkState;
                using (SqlCommand sqlCommand = new SqlCommand("Chekku.checkSubID", connection))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@SubID", SqlDbType.VarChar, 50));
                    sqlCommand.Parameters["@SubID"].Value = id;

                    var returnParameter = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    checkState = (Int32)returnParameter.Value;
                    if (checkState == 0)
                    {
                        generateID();
                    }
                    else
                    {
                        return id;
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
            return id;
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
