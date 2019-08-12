using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chekku
{
    public partial class Chekku : Form
    {
        public Chekku()
        {
            InitializeComponent();
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
    }
}
