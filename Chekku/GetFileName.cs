using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chekku
{
    public partial class GetFileName : Form
    {
        public string filename;
        public string path;
        public GetFileName()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/Export Question Banks/" + txtFilename.Text;
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    filename = txtFilename.Text;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("File already exists. Please enter another filename.");
                }
            }
            catch
            {
                MessageBox.Show("Invalid Filename. Please enter another filename.");
            }
            
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            filename = "cancelled";
            path = "";
            this.Close();
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {

        }
    }
}
