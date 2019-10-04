using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Image = System.Drawing.Image;

namespace Chekku
{

    public partial class AddQuestion : Form
    {
        bool isImported = false;
        public int added = 1;
        public AddQuestion()
        {
            InitializeComponent();
            code = generateQuestionCode();

            btnSkip.Visible = false;
            btnAddImp.Visible = false;
        }

        public AddQuestion(string q, string a, string c1, string c2, string c3, int hI, string base64, string tg)
        {
            InitializeComponent();
            code = generateQuestionCode();
            txtQuestion.Text = q;
            txtAnswer.Text = a;
            txtCh1.Text = c1;
            txtCh2.Text = c2;
            txtCh3.Text = c3;
            hasImage = hI;
            txtTags.Text = tg;
            isImported = true;
            if (hI == 1)
            {
                LoadImage(base64);
                origfile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Chekku/Question Images/TEMP.jpg";
                File.WriteAllBytes(origfile, Convert.FromBase64String(base64));
                //pbImage.Image = Image.FromFile(path);
                //origfile = path;
            }
            btnEditPic.Visible = false;
            btnRemoveImg.Visible = false;
            btnSkip.Visible = true;
            btnAddImp.Visible = true;
            btnAdd.Visible = false;
            btnCancel.Visible = false;
        }

        public AddQuestion(string q, string a, string c1, string c2, string c3, int hI, string base64)
        {
            InitializeComponent();
            code = generateQuestionCode();
            txtQuestion.Text = q;
            txtAnswer.Text = a;
            txtCh1.Text = c1;
            txtCh2.Text = c2;
            txtCh3.Text = c3;
            hasImage = hI;
            isImported = true;
            if(hI == 1)
            {
                LoadImage(base64);
                origfile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Chekku/Question Images/TEMP.jpg";
                File.WriteAllBytes(origfile, Convert.FromBase64String(base64));
                //pbImage.Image = Image.FromFile(path);
                //origfile = path;
            }
            btnEditPic.Visible = false;
            btnRemoveImg.Visible = false;
            btnSkip.Visible = true;
            btnAddImp.Visible = true;
            btnAdd.Visible = false;
            btnCancel.Visible = false;
        }

        public void LoadImage(string base64)
        {
            //data:image/gif;base64,
            //this image is a single pixel (black)
            byte[] bytes = Convert.FromBase64String(base64);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }
            pbImage.Image = image;
        }
        private void setPicture(string ext) //EQUATION TO
        {
            string rtfTxt = ext;
            Match mat = Regex.Match(rtfTxt, @"picw[\d]+");
            mat = Regex.Match(rtfTxt, @"picwgoal[\d]+");
            //width of image
            int width = int.Parse(mat.Value.Replace("picwgoal", "")) / 15;
            mat = Regex.Match(rtfTxt, @"pichgoal[\d]+");

            //height of image
            int hight = int.Parse(mat.Value.Replace("pichgoal", "")) / 15;
            string content = rtfTxt.Substring(mat.Index + mat.Length, rtfTxt.IndexOf("}", (mat.Index + mat.Length)) - (mat.Index + mat.Length));
            string text = content.Replace("\r\n", "").Replace(" ", "");

            int _Count = text.Length / 2;
            byte[] buffer = new byte[_Count];
            for (int z = 0; z != _Count; z++)
            {
                string _TempText = text[z * 2].ToString() + text[(z * 2) + 1].ToString();
                buffer[z] = Convert.ToByte(_TempText, 16);
            }

            MemoryStream m = new MemoryStream(buffer);

            Bitmap b = new Bitmap(Bitmap.FromStream(m));
            //i = (Image)b;

            pbImage.Image = Bitmap.FromStream(m);

        }


        int hasImage = 0;
        string code = "";

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            int checkstate;
            if (checkFields())
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("Chekku.addNewQuestion", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add(new SqlParameter("@Question", SqlDbType.NVarChar, 8000));
                        sqlCommand.Parameters["@Question"].Value = txtQuestion.Text.Trim();

                        sqlCommand.Parameters.Add(new SqlParameter("@QuestionCode", SqlDbType.VarChar, 50));
                        sqlCommand.Parameters["@QuestionCode"].Value = code;

                        sqlCommand.Parameters.Add(new SqlParameter("@Answer", SqlDbType.NVarChar, 8000));
                        sqlCommand.Parameters["@Answer"].Value = txtAnswer.Text.Trim();

                        sqlCommand.Parameters.Add(new SqlParameter("@Choice1", SqlDbType.NVarChar, 8000));
                        sqlCommand.Parameters["@Choice1"].Value = txtCh1.Text.Trim();

                        sqlCommand.Parameters.Add(new SqlParameter("@Choice2", SqlDbType.NVarChar, 8000));
                        sqlCommand.Parameters["@Choice2"].Value = txtCh2.Text.Trim();

                        sqlCommand.Parameters.Add(new SqlParameter("@Choice3", SqlDbType.NVarChar, 8000));
                        sqlCommand.Parameters["@Choice3"].Value = txtCh3.Text.Trim();

                        sqlCommand.Parameters.Add(new SqlParameter("@hasImage", SqlDbType.Bit));
                        sqlCommand.Parameters["@hasImage"].Value = hasImage;

                        sqlCommand.Parameters.Add(new SqlParameter("@Tagline", SqlDbType.VarChar, 8000));
                        sqlCommand.Parameters["@Tagline"].Value = txtTags.Text;
                        if (hasImage == 0)
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("@Image", SqlDbType.Image));
                            sqlCommand.Parameters["@Image"].Value = DBNull.Value;
                        }
                        else
                        {
                            string imgfilename = SaveImage();
                            FileStream fs = new FileStream(imgfilename, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            byte[] img = new byte[fs.Length];
                            fs.Read(img, 0, Convert.ToInt32(fs.Length));
                            fs.Close();
                            sqlCommand.Parameters.Add(new SqlParameter("@Image", SqlDbType.VarBinary, img.Length));
                            sqlCommand.Parameters["@Image"].Value = img;
                            //  sqlCommand.Parameters["@Image"].Value = //convert file stream
                        }



                        //sqlCommand.Parameters.Add(new SqlParameter("@Tags", SqlDbType.VarChar, 50));
                        //sqlCommand.Parameters["@Tags"].Value = cmbYear.Text;


                        var returnParameter = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        checkstate = (Int32)returnParameter.Value;
                        if (checkstate == 0)
                        {
                            MessageBox.Show("This question already exists!");
                        }
                        else
                        {
                            connection.Close();
                            AddTags();
                        }
                    }
                }
            }
        }

        private bool checkFields()
        {
            if (pbImage.Image != null)
            {
                hasImage = 1;//meron
            }
            else
            {
                hasImage = 0;//wala
            }

            if (String.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                MessageBox.Show("Please enter a question.");
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtAnswer.Text))
            {
                MessageBox.Show("Please enter an answer.");
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtCh1.Text) && String.IsNullOrWhiteSpace(txtCh2.Text) && String.IsNullOrWhiteSpace(txtCh3.Text))
            {
                MessageBox.Show("Please enter at least one choice.");
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtTags.Text))
            {
                MessageBox.Show("Please enter at least one tag.");
                return false;
            }
            else
            {
                return true;
            }
        }


        private String generateQuestionCode()
        {
            string code = RandomPassword();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                int checkState;
                using (SqlCommand sqlCommand = new SqlCommand("Chekku.checkQuestionCode", connection))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@QuestionCode", SqlDbType.VarChar, 50));
                    sqlCommand.Parameters["@QuestionCode"].Value = code;

                    var returnParameter = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        checkState = (Int32)returnParameter.Value;
                        if (checkState == 0)
                        {
                            generateQuestionCode();
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


        string origfile;
        private void BtnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "(*.jpg;*.jpeg;*.png;) | *.jpg; *.jpeg; *.png; ";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pbImage.Image = Image.FromFile(dialog.FileName);
                origfile = dialog.FileName;
            }
            //lblimg.Text = origfile;
        }


        private string SaveImage()
        {
            string imgLocation = "";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Chekku/Question Images";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string imgname = code + ".jpg";
            string pathstring = System.IO.Path.Combine(path, imgname);

            //lblimg.Text = pathstring;
            System.IO.File.Copy(origfile, pathstring);
            string filedel = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Chekku/Question Images/TEMP.jpg";

            if (File.Exists(filedel))
            {
                File.Delete(filedel);
            }
            return pathstring;
     
           
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {

        }

        private void AddTags()
        {
            if (!String.IsNullOrEmpty(txtTags.Text))
            {
                string tags = txtTags.Text;
                string[] words = tags.Split(',');
                List<string> noSpace = new List<string>();
                foreach (string word in words)
                {
                    string trimmed = word.Trim();
                    noSpace.Add(trimmed);
                }
                foreach (var word in noSpace)
                {
                    using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                    {

                        using (SqlCommand sqlCommand = new SqlCommand("Chekku.addQTags", connection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            sqlCommand.Parameters.Add(new SqlParameter("@Question", SqlDbType.VarChar, 8000));
                            sqlCommand.Parameters["@Question"].Value = txtQuestion.Text;

                            sqlCommand.Parameters.Add(new SqlParameter("@QuestionCode", SqlDbType.VarChar, 50));
                            sqlCommand.Parameters["@QuestionCode"].Value = code;

                            sqlCommand.Parameters.Add(new SqlParameter("@Tag", SqlDbType.VarChar, 50));
                            sqlCommand.Parameters["@Tag"].Value = word;

                            connection.Open();
                            sqlCommand.ExecuteNonQuery();

                            try
                            {
                                //connection.Open();
                                //sqlCommand.ExecuteNonQuery();
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

                
                if (!isImported)
                {
                    MessageBox.Show("Question is now added!", "Question added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form ques = new AddQuestion();
                    ques.Show();
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (!isImported)
            {
                Form frm = new Questions();
                frm.Show();
                this.Hide();
            }
            else
            {
                this.Close();
            }
        }

        private void BtnRemoveImg_Click(object sender, EventArgs e)
        {
            pbImage.Image = null;
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

        private void BtnSkip_Click(object sender, EventArgs e)
        {
            added = 0;
            this.Close();
        }



        //end

    }
}

