using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Documents;
using System.Text.RegularExpressions;
using Image = System.Drawing.Image;

namespace Chekku
{
    
    public partial class AddQuestion : Form
    {
        public AddQuestion()
        {
            InitializeComponent();
            code = generateQuestionCode();
            string start = rtbEquation.Rtf.Length.ToString();
            lblX.Text = start;
        }

   
        public AddQuestion(string q, string c1, string c2, string c3, string tags, string code, int hasEq, int hasIm, string rtf)
        {
            InitializeComponent();
            code = generateQuestionCode();
            string start = rtbEquation.Rtf.Length.ToString();
            lblX.Text = start;
            hasEquation = hasEq;
            hasImage = hasIm;
            txtQuestion.Text = q;
            txtCh1.Text = c1;
            txtCh2.Text = c2 ;
            txtCh3.Text = c3;
            txtTags.Text = tags;
            this.code = code;
            setPicture(rtf);

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

            pbox.Image = Bitmap.FromStream(m);

        }


        int hasEquation = 0;
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

                        sqlCommand.Parameters.Add(new SqlParameter("@Question", SqlDbType.NVarChar, 50));
                        sqlCommand.Parameters["@Question"].Value = txtQuestion.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@QuestionCode", SqlDbType.VarChar, 50));
                        sqlCommand.Parameters["@QuestionCode"].Value = code;

                        sqlCommand.Parameters.Add(new SqlParameter("@Answer", SqlDbType.NVarChar, 8000));
                        sqlCommand.Parameters["@Answer"].Value = txtAnswer.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Choice1", SqlDbType.NVarChar, 8000));
                        sqlCommand.Parameters["@Choice1"].Value = txtCh1.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Choice2", SqlDbType.NVarChar, 8000));
                        sqlCommand.Parameters["@Choice2"].Value = txtCh2.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@Choice3", SqlDbType.NVarChar, 8000));
                        sqlCommand.Parameters["@Choice3"].Value = txtCh3.Text;

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

                        sqlCommand.Parameters.Add(new SqlParameter("@hasEquation", SqlDbType.Bit));
                        sqlCommand.Parameters["@hasEquation"].Value = hasEquation;

                        if (hasEquation == 0)
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("@Equation", DBNull.Value));
                        }
                        else
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("@Equation", SqlDbType.NVarChar, 8000));
                            sqlCommand.Parameters["@Equation"].Value = rtbEquation.Rtf.ToString();
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

            if(pbox.Image != null)
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
            if (String.IsNullOrWhiteSpace(txtCh1.Text)&& String.IsNullOrWhiteSpace(txtCh2.Text) && String.IsNullOrWhiteSpace(txtCh3.Text))
            {
                MessageBox.Show("Please enter at least one choice.");
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtTags.Text)){
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

        private void BtnEquate_Click(object sender, EventArgs e)
        {
            rtbEquation.Visible = true;
            lblEq.Visible = true;
            btnEquate.Visible = false;
            btnCancelEq.Visible = true;
            hasEquation = 1;
        }

        private void BtnCancelEq_Click(object sender, EventArgs e)
        {
            rtbEquation.Visible = false;
            lblEq.Visible = false;
            btnEquate.Visible = true;
            btnCancelEq.Visible = false;
            hasEquation = 0;
        }


        string origfile;
        private void BtnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "(*.jpg;*.jpeg;*.png;) | *.jpg; *.jpeg; *.png; ";
            if(dialog.ShowDialog()== DialogResult.OK);
            {
                pbox.Image = Image.FromFile(dialog.FileName);
                origfile = dialog.FileName;
            }
            lblimg.Text = origfile;
        }


        private string SaveImage()
        {
            string imgLocation = "";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/Question Images";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string imgname = code +".jpg";
            string pathstring = System.IO.Path.Combine(path, imgname);
            lblimg.Text = pathstring;
            System.IO.File.Copy(origfile, pathstring);
            return pathstring;
        }

        private void RtbEquation_TextChanged(object sender, EventArgs e)
        {
            string start = rtbEquation.Rtf.Length.ToString();
            lblX.Text = start;
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

                MessageBox.Show("Question is now added!");
                Form ques = new Questions();
                ques.Show();
                this.Close();
            }          
        }

        private void BtnGraphic_Click(object sender, EventArgs e)
        {
            string q, c1, c2, c3, tags, code;
            q = txtQuestion.Text;
            c1 = txtCh1.Text;
            c2 = txtCh2.Text;
            c3 = txtCh3.Text;
            tags = txtTags.Text;
            code = this.code;
            Form ques = new AddQuestionGraphics(q, c1, c2, c3, tags, code);
            ques.ShowDialog();
            this.Close();
        }

        //end

    }
}

