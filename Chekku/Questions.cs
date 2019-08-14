using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Image = System.Drawing.Image;

namespace Chekku
{
    public partial class Questions : Form
    {
        string qcode = "";
        int hasImage = 0;

        string origfile;
        string pathstring;
        public Questions()
        {
            InitializeComponent();
            refreshView();
            SelectFirst();
        }

        private void Questions_Load(object sender, EventArgs e)
        {
            refreshView();
            SelectFirst();
        }

        private void TxtQuestion_TextChanged(object sender, EventArgs e)
        {

        }

        private void SelectFirst()
        {
            if (dgvView.Rows.Count > 0)
            {
                var row = dgvView.Rows[0];
                string code = row.Cells[1].Value.ToString();
                dgvView.CurrentCell = row.Cells[0];
                FillContent(code);
            }
            else
            {
                txtAnswer.Text = "";
                txtCh1.Text = "";
                txtCh2.Text = "";
                txtCh3.Text = "";
                txtQuestion.Text = "";
                txtTags.Text = "";
                pbImage.Image = null;
                lblImg.Visible = false;
            }
        }

        public void refreshView()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                const string sql = "SELECT DISTINCT Chekku.QTags.Question, Chekku.QTags.QuestionCode, Chekku.Questions.Answer FROM Chekku.QTags" +
                    "\nINNER JOIN Chekku.Questions ON Chekku.Qtags.QuestionCode=Chekku.Questions.QuestionCode";

                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        this.dgvView.DataSource = dataTable;
                        dataReader.Close();
                    }
                    try
                    {

                    }
                    catch
                    {
                        MessageBox.Show("EWAN KO BA.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            this.dgvView.Columns[1].Visible = false;
            //this.dgvView.Columns[2].Visible = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Form frm = new AddQuestion();
            frm.Show();
            this.Hide();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Form frm = new Chekku();
            frm.Show();
            this.Hide();
        }

        private void DgvView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvView.Rows[e.RowIndex];
                //populate
                txtQuestion.Text = row.Cells[0].Value.ToString();
                string code = row.Cells[1].Value.ToString();
                //string extractImage = row.Cells[1].Value.ToString();
                //setPicture(extractImage);
                //lblQcode.Text = code;
                qcode = code;
                FillContent(code);
            }
        }

        public void FillContent(string Code)
        {
            int hasImg;
            using (SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                string oString = "Select * from Chekku.Questions where QuestionCode=@Code";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@Code", Code);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        txtQuestion.Text = oReader["Question"].ToString();
                        txtAnswer.Text = oReader["Answer"].ToString();
                        txtCh1.Text = oReader["Choice1"].ToString();
                        txtCh2.Text = oReader["Choice2"].ToString();
                        txtCh3.Text = oReader["Choice3"].ToString();
                        hasImg = Convert.ToInt32(oReader["hasImage"]);
                        if (hasImg == 1)
                        {
                            byte[] picArr = (byte[])oReader["Image"];
                            MemoryStream ms = new MemoryStream(picArr);
                            ms.Seek(0, SeekOrigin.Begin);
                            pbImage.Image = Image.FromStream(ms);
                            Console.WriteLine("Image size: Height: " + pbImage.Image.Height.ToString() + " Width: " + pbImage.Image.Width.ToString());
                            lblImg.Visible = true;
                        }
                        else
                        {
                            lblImg.Visible = false;
                            pbImage.Image = null;
                        }
                    }

                    myConnection.Close();
                }
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Chekku/Question Images";
                string imgname = qcode + ".jpg";
                pathstring = System.IO.Path.Combine(path, imgname);
                //lblimg.Text = pathstring;
                origfile = pathstring; 
            }

            using (SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                string oString = "Select * from Chekku.QTagString where QuestionCode=@Code";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@Code", Code);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        txtTags.Text = oReader["Tagline"].ToString();
                    }
                    myConnection.Close();
                }
            }
            //lblQcode.Text = Code;
            qcode = Code;
        }

        public void CreatePdf()
        {
            //FileStream fs = new FileStream("D:/Test/Chapter1_Example1.pdf", FileMode.Create, FileAccess.Write, FileShare.None); 
            //Document doc = new Document(PageSize.A4.Rotate());
            //PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            //doc.Open();
            //doc.Add(new Paragraph("Hello World"));
            //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(i, System.Drawing.Imaging.ImageFormat.Jpeg);
            //doc.Add(img);
            //doc.Close();
            string search = "";
            string count = "0";
            if (!String.IsNullOrEmpty(txtSearch.text))
            {
                string tags = txtSearch.text;
                string[] words = tags.Split(',');
                List<string> noSpace = new List<string>();
                foreach (string word in words)
                {
                    string trimmed = "'" + word.Trim() + "'";
                    noSpace.Add(trimmed);
                    System.Console.WriteLine(trimmed);
                }
                int lastIndex = noSpace.Count - 1;

                for (int i = 0; i <= lastIndex; i++)
                {
                    if (i == lastIndex)
                    {
                        search += noSpace[i];
                    }
                    else
                    {
                        search += noSpace[i] + ", ";
                    }
                }
                System.Console.WriteLine(noSpace.Count);
                count = noSpace.Count.ToString();
                System.Console.WriteLine(search);
            }
        }

        private int setHasImage()
        {
            if (pbImage.Image == null)
            {
                hasImage = 0;
            }
            else
            {
                hasImage = 1;
            }
            return hasImage;
        }

        private void UpdateDetails()
        {
            if (!String.IsNullOrWhiteSpace(qcode))
            {
                int checkstate;
                if (checkFields())
                {
                    using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("Chekku.UpdateQuestion", connection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            sqlCommand.Parameters.Add(new SqlParameter("@Question", SqlDbType.NVarChar, 50));
                            sqlCommand.Parameters["@Question"].Value = txtQuestion.Text.Trim();

                            sqlCommand.Parameters.Add(new SqlParameter("@QuestionCode", SqlDbType.VarChar, 50));
                            sqlCommand.Parameters["@QuestionCode"].Value = qcode;

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
                            hasImage = setHasImage();
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
        }

        //private void setPicture(string ext) //EQUATION TO
        //{
        //    string rtfTxt = ext;
        //    Match mat = Regex.Match(rtfTxt, @"picw[\d]+");
        //    mat = Regex.Match(rtfTxt, @"picwgoal[\d]+");
        //    //width of image
        //    int width = int.Parse(mat.Value.Replace("picwgoal", "")) / 15;
        //    mat = Regex.Match(rtfTxt, @"pichgoal[\d]+");

        //    //height of image
        //    int hight = int.Parse(mat.Value.Replace("pichgoal", "")) / 15;
        //    string content = rtfTxt.Substring(mat.Index + mat.Length, rtfTxt.IndexOf("}", (mat.Index + mat.Length)) - (mat.Index + mat.Length));
        //    string text = content.Replace("\r\n", "").Replace(" ", "");

        //    int _Count = text.Length / 2;
        //    byte[] buffer = new byte[_Count];
        //    for (int z = 0; z != _Count; z++)
        //    {
        //        string _TempText = text[z * 2].ToString() + text[(z * 2) + 1].ToString();
        //        buffer[z] = Convert.ToByte(_TempText, 16);
        //    }

        //    MemoryStream m = new MemoryStream(buffer);

        //    Bitmap b = new Bitmap(Bitmap.FromStream(m));
        //    i = (Image)b;

        //    pbImage.Image = Bitmap.FromStream(m);
        //}

        int toggleEdit = 1;
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                MessageBox.Show("Please select a question first.");
                toggleEdit = 0;
            }
            if (toggleEdit == 1)
            {
                btnSave.Visible = true;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnEditPic.Visible = true;
                btnRemoveImg.Visible = true;
                txtQuestion.Enabled = true;
                txtAnswer.Enabled = true;
                txtCh1.Enabled = true;
                txtCh2.Enabled = true;
                txtCh3.Enabled = true;
                txtTags.Enabled = true;
                btnImport.Enabled = false;
                btnExport.Enabled = false;
                toggleEdit = 0;
            }
            else
            {
                btnSave.Visible = false;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnEditPic.Visible = false;
                btnRemoveImg.Visible = false;
                txtQuestion.Enabled = false;
                txtAnswer.Enabled = false;
                txtCh1.Enabled = false;
                txtCh2.Enabled = false;
                txtCh3.Enabled = false;
                txtTags.Enabled = false;
                btnImport.Enabled = true;
                btnExport.Enabled = true;
                toggleEdit = 1;
            }
        }
        //else
        //{
        //    MessageBox.Show("Please select a subject to delete.");
        //}
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

        public class Question
        {
            public string question { get; set; }
            public string answer { get; set; }
            public string choice1 { get; set; }
            public string choice2 { get; set; }
            public string choice3 { get; set; }
            public int hasequation { get; set; }
            public string equation { get; set; }
            public int hasimage { get; set; }
            public string image { get; set; }
        }

        private void DgvView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Chekku.deleteQuestion", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@QuestionCode", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@QuestionCode"].Value = qcode;

                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();

                        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Chekku/Question Images";
                        string imgname = qcode + ".jpg";
                        string pathstring = System.IO.Path.Combine(path, imgname);
                        if (File.Exists(pathstring))
                        {
                            System.IO.File.Delete(pathstring);
                        }
                        MessageBox.Show("Question is now deleted!");
                        refreshView();
                        SelectFirst();
                    }
                    catch
                    {
                        MessageBox.Show("Error deleting question.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        string search = "";
        string count = "0";

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            
            //this.dgvView.Columns[1].Visible = false;
        }

        private void BtnEditPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "(*.jpg;*.jpeg;*.png;) | *.jpg; *.jpeg; *.png; ";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pbImage.Image = Image.FromFile(dialog.FileName);
                origfile = dialog.FileName;
            }
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Chekku/Question Images";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }


        private string SaveImage()
        {
            System.Console.WriteLine(origfile);
            System.Console.WriteLine(pathstring);
            if (origfile.Equals(pathstring))
            {
                return pathstring;
            }
            else
            {
                if (File.Exists(pathstring))
                {
                    File.Delete(pathstring);
                }
                System.IO.File.Copy(origfile, pathstring);
                return pathstring;
            }


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
                deleteTags();
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
                            sqlCommand.Parameters["@QuestionCode"].Value = qcode;

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

                MessageBox.Show("Question is now updated!");
                refreshView();
                SelectFirst();
            }

            else
            {
                MessageBox.Show("Please add some tags.");
            }
        }

        private void deleteTags()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Chekku.deleteTags", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@QuestionCode", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@QuestionCode"].Value = qcode;
                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Error deleting student.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            UpdateDetails();
            btnSave.Visible = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnEditPic.Visible = false;
            btnRemoveImg.Visible = false;
            txtQuestion.Enabled = false;
            txtAnswer.Enabled = false;
            txtTags.Enabled = false;
            txtCh1.Enabled = false;
            txtCh2.Enabled = false;
            txtCh3.Enabled = false;
            btnImport.Enabled = true;
            btnExport.Enabled = true;
            toggleEdit = 1;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSearch.text))
            {
                string tags = txtSearch.text;
                string[] words = tags.Split(',');
                List<string> noSpace = new List<string>();
                foreach (string word in words)
                {
                    //string trimmed = "'" + word.Trim() + "'";
                    noSpace.Add(word.Trim());
                    System.Console.WriteLine(word.Trim());
                }
                int lastIndex = noSpace.Count - 1;

                for (int i = 0; i <= lastIndex; i++)
                {
                    if (i == lastIndex)
                    {
                        search += noSpace[i];
                    }
                    else
                    {
                        search += noSpace[i] + ", ";
                    }
                }
                System.Console.WriteLine(noSpace.Count);
                count = noSpace.Count.ToString();
                System.Console.WriteLine(search);
                String last = noSpace.Last();
                String sql = "";
                foreach (string word in noSpace)
                {
                    System.Console.WriteLine(word);

                }


                //foreach (string word in noSpace)
                //{
                //    if (word.Equals(last))
                //    {
                //        sql += "\nSELECT Chekku.QTags.Question, Chekku.QTags.QuestionCode, Chekku.Questions.Answer FROM Chekku.QTags WHERE Tag LIKE '%" + word + "'"
                //        +" INNER JOIN Chekku.Questions ON Chekku.Qtags.QuestionCode = Chekku.Questions.QuestionCode\n";

                //    }
                //    else
                //    {
                //        sql += "\nSELECT Chekku.QTags.Question, Chekku.QTags.QuestionCode, Chekku.Questions.Answer FROM Chekku.QTags WHERE Tag LIKE '%" + word + "'" 
                //             + " INNER JOIN Chekku.Questions ON Chekku.Qtags.QuestionCode = Chekku.Questions.QuestionCode"
                //             + "\nUNION";
                //    }

                //}


                foreach (string word in noSpace)
                {
                    if (word.Equals(last))
                    {
                        sql += "\nSELECT Chekku.QTags.Question, Chekku.QTags.QuestionCode, Chekku.Questions.Answer FROM Chekku.QTags "
                            + "\nINNER JOIN Chekku.Questions ON Chekku.Qtags.QuestionCode = Chekku.Questions.QuestionCode WHERE Tag LIKE '" + word + "%'";

                    }
                    else
                    {
                        sql += "\nSELECT Chekku.QTags.Question, Chekku.QTags.QuestionCode, Chekku.Questions.Answer FROM Chekku.QTags "
                            + "\nINNER JOIN Chekku.Questions ON Chekku.Qtags.QuestionCode = Chekku.Questions.QuestionCode WHERE Tag LIKE '" + word + "%'"
                            + "\nINTERSECT";
                    }

                }

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                {
                    //string sql = "SELECT DISTINCT Chekku.QTags.Question, Chekku.QTags.QuestionCode, Chekku.Questions.Answer FROM Chekku.QTags " +
                    //"\nINNER JOIN Chekku.Questions ON Chekku.Qtags.QuestionCode=Chekku.Questions.QuestionCode " +
                    //"WHERE Tag IN (" + search + ") " +
                    //"GROUP BY Chekku.QTags.Question, Chekku.QTags.QuestionCode, Chekku.Questions.Answer " +
                    //"HAVING COUNT(Tag) =" + count;

                    System.Console.WriteLine(sql);


                    using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            this.dgvView.DataSource = dataTable;
                            dataReader.Close();
                        }
                        try
                        {

                        }
                        catch
                        {
                            MessageBox.Show("EWAN KO BA.");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
            else
            {
                refreshView();
            }
            SelectFirst();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            Form frm = new Export_Questions();
            frm.Show();
            this.Hide();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            Form frm = new Import(1);
            frm.Show();
            this.Hide();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Questions_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void BtnRemoveImg_Click(object sender, EventArgs e)
        {
            pbImage.Image = null;
        }
        //end
    }
}

