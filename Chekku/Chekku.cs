using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Chekku
{
    public partial class Chekku : Form
    {
        public Chekku()
        {
            InitializeComponent();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku";
            string checkPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Chekku";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!Directory.Exists(checkPath))
            {
                Directory.CreateDirectory(checkPath);
                Console.WriteLine("Pumasok DITO!!!");
                Reset();
            }
            string locationToSavePdf = Path.Combine(path, "Answer Sheet.pdf");  // select other location if you want
            if (!File.Exists(locationToSavePdf))
            {
                File.WriteAllBytes(locationToSavePdf, Properties.Resources.AnswerSheet);    // write the file from the resources to the location you want
            }
        }

        private void BtnExams_Click(object sender, EventArgs e)
        {
            Form frm = new Exams();
            frm.Show();
            this.Hide();
        }

        private void BtnSubjects_Click(object sender, EventArgs e)
        {
            Form frm = new Subjects();
            frm.Show();
            this.Hide();
        }

        private void BtnStudents_Click(object sender, EventArgs e)
        {
            Form frm = new Students();
            frm.Show();
            this.Hide();
        }

        private void BtnSection_Click(object sender, EventArgs e)
        {
            Form frm = new Section();
            frm.Show();
            this.Hide();
        }

        private void BtnQuestions_Click(object sender, EventArgs e)
        {
            Form frm = new Questions();
            frm.Show();
            this.Hide();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Chekku_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Reports_Click(object sender, EventArgs e)
        {
            Form frm = new Reports();
            frm.Show();
            this.Hide();
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            Form frm = new Test_SQLITE();
            frm.Show();
            this.Hide();
        }

        private void Reset()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Chekku.ResetAll", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Successful deletion");
                    }
                    catch
                    {
                        MessageBox.Show("Error deleting subject.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
