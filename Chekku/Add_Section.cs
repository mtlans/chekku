using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Chekku
{
    public partial class Add_Section : Form
    {

        public string SubjectID { get; set; }
        public string SubjectName { get; set; }
        public Add_Section(string SubjectID, string SubjectName)
        {
            InitializeComponent();
            this.SubjectID = SubjectID;
            this.SubjectName = SubjectName;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string code = generateCode();
            if (checkFields())
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                {
                    int checkState;

                    using (SqlCommand sqlCommand = new SqlCommand("Chekku.addNewSection", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add(new SqlParameter("@SubSectCode", SqlDbType.VarChar, 8000));
                        sqlCommand.Parameters["@SubSectCode"].Value = code;

                        sqlCommand.Parameters.Add(new SqlParameter("@SubjectID", SqlDbType.VarChar, 8000));
                        sqlCommand.Parameters["@SubjectID"].Value = SubjectID;

                        sqlCommand.Parameters.Add(new SqlParameter("@SectionName", SqlDbType.VarChar, 50));
                        sqlCommand.Parameters["@SectionName"].Value = txtSection.Text;

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
                                MessageBox.Show("Section is now added!");
                                Form sect = new Section();
                                sect.Show();
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
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(2, true));
            builder.Append(RandomNumber(1000, 9999));
            return builder.ToString();
        }

        private string generateCode()
        {
            string code = RandomPassword();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                int checkState;
                using (SqlCommand sqlCommand = new SqlCommand("Chekku.checkSectionCode", connection))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;

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


        //private String getSubjectID()
        //{
        //    String id = "";
        //    using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
        //    {
        //        int checkState;
        //        using (SqlCommand sqlCommand = new SqlCommand("Chekku.addNewSubject", connection))
        //        {

        //            sqlCommand.Parameters.Add(new SqlParameter("@SubjectCode", SqlDbType.VarChar, 50));
        //            sqlCommand.Parameters["@SubjectCode"].Value = Subject;

        //            sqlCommand.Parameters.Add(new SqlParameter("@Term", SqlDbType.Int));
        //            sqlCommand.Parameters["@Term"].Value = cmbSearchTerm.Text;

        //            sqlCommand.Parameters.Add(new SqlParameter("@SchoolYear", SqlDbType.VarChar, 50));
        //            sqlCommand.Parameters["@SchoolYear"].Value = cmbSearchYear.Text;

        //            var returnParameter = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
        //            returnParameter.Direction = ParameterDirection.ReturnValue;


        //            try
        //            {
        //                connection.Open();
        //                sqlCommand.ExecuteNonQuery();
        //                checkState = (Int32)returnParameter.Value;
        //                if (checkState == 0)
        //                {
        //                    MessageBox.Show("This subject already exists!");
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Subject is now added!");
        //                    this.Close();
        //                }
        //            }
        //            catch
        //            {
        //                MessageBox.Show("Error adding new subject.");
        //            }
        //            finally
        //            {
        //                connection.Close();
        //            }
        //        }
        //    }

        //    return id;
        //}

        private bool checkFields()
        {
            if (txtSection.Text == "")
            {
                MessageBox.Show("Please enter a section.");
                return false;
            }
            else
            {
                return true;
            }
        }



        private void Add_Section_Load(object sender, EventArgs e)
        {
            lblSubject.Text = SubjectName;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Form section = new Section();
            section.Show();
            this.Hide();
        }
    }
}
