using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Chekku
{
    public partial class Add_Student : Form
    {
        public Add_Student()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (AreFieldsValid())
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                {
                    int checkState;
                    using (SqlCommand sqlCommand = new SqlCommand("Chekku.addNewStudent", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add(new SqlParameter("@StudentNo", SqlDbType.VarChar, 8000));
                        sqlCommand.Parameters["@StudentNo"].Value = txtID.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@StudentName", SqlDbType.VarChar, 8000));
                        sqlCommand.Parameters["@StudentName"].Value = txtName.Text;

                        var returnParameter = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        try
                        {
                            connection.Open();
                            sqlCommand.ExecuteNonQuery();
                            checkState = (Int32)returnParameter.Value;
                            if (checkState == 0)
                            {
                                MessageBox.Show("This student already exists!");
                            }
                            else
                            {
                                MessageBox.Show("Student is now added!");
                                this.Close();
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
        }

        private bool AreFieldsValid()
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Please enter a student number.");
                return false;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter a student name.");
                return false;
            }
            else
                return true;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Add_Student_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
