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
using iTextSharp.text;
using iTextSharp.text.pdf;
using DCSoft.RTF;
using System.Text.RegularExpressions;
using Image = System.Drawing.Image;
using System.Drawing.Imaging;

namespace Chekku
{
    public partial class Questions : Form
    {
        private const string Path = "D:/Test/   a.pdf";
        string qcode = ""; int hasEquation = 0;
        int hasImage = 0;
        public Questions()
        {
            InitializeComponent();
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
                txtEquation.Clear();
                txtQuestion.Text = "";
                txtTags.Text = "";
                pbImage.Image = null;
            }
        }

        public void refreshView()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                const string sql = "SELECT DISTINCT Question, QuestionCode FROM Chekku.QTags";

                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            this.dgvView.DataSource = dataTable;
                            dataReader.Close();
                        }
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
                lblQcode.Text = code;
                qcode = code;
                FillContent(code);
            }
        }

        public void FillContent(string Code)
        {
            int hasImg, hasEq;
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
                    hasEq = Convert.ToInt32(oReader["hasEquation"]);
                        if(hasImg == 1)
                        {
                            byte[] picArr = (byte[])oReader["Image"];
                            MemoryStream ms = new MemoryStream(picArr);
                            ms.Seek(0, SeekOrigin.Begin);
                            pbImage.Image = Image.FromStream(ms);
                        }
                        else
                        {
                            pbImage.Image = null;
                        }
                        if (hasEq == 1)
                        {
                            txtEquation.Rtf = oReader["Equation"].ToString();
                           // setPicture(extractImage);
                        }
                        else
                        {
                            txtEquation.Rtf = null;
                        }
                    }

                    myConnection.Close();
                }
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
            if (!String.IsNullOrEmpty(txtSearch.Text))
            {
                string tags = txtSearch.Text;
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


        Image i;
        private void Btnpdf_Click(object sender, EventArgs e) //Save Changes
        {
            UpdateDetails();
        }
        private void UpdateDetails()
        {
            //if (!String.IsNullOrWhiteSpace(qcode))
            //{
            //    using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            //    {
            //        int checkState;
            //        using (SqlCommand sqlCommand = new SqlCommand("Chekku.updateQuestion", connection))
            //        {
            //            //string Newid = CreateStudentIdentifier();
            //            sqlCommand.CommandType = CommandType.StoredProcedure;

            //            sqlCommand.Parameters.Add(new SqlParameter("@OldStudentKEY", SqlDbType.VarChar, 8000));
            //            sqlCommand.Parameters["@OldStudentKEY"].Value = Oldid;

            //            sqlCommand.Parameters.Add(new SqlParameter("@StudentKEY", SqlDbType.VarChar, 8000));
            //            sqlCommand.Parameters["@StudentKEY"].Value = Newid;

            //            sqlCommand.Parameters.Add(new SqlParameter("@StudentNo", SqlDbType.VarChar, 8000));
            //            sqlCommand.Parameters["@StudentNo"].Value = txtID.Text;

            //            sqlCommand.Parameters.Add(new SqlParameter("@StudentName", SqlDbType.VarChar, 8000));
            //            sqlCommand.Parameters["@StudentName"].Value = txtName.Text;

            //            var returnParameter = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
            //            returnParameter.Direction = ParameterDirection.ReturnValue;

            //            try
            //            {
            //                connection.Open();
            //                sqlCommand.ExecuteNonQuery();
            //                checkState = (Int32)returnParameter.Value;
            //                if (checkState == 0)
            //                {
            //                    MessageBox.Show("This student already exists!");
            //                }
            //                else
            //                {
            //                    MessageBox.Show("Student details are now updated!");
            //                }
            //            }
            //            catch
            //            {
            //                MessageBox.Show("Error updating student details.");
            //            }
            //            finally
            //            {
            //                connection.Close();
            //            }
            //        }
            //    }
            //    txtID.Enabled = false;
            //    txtName.Enabled = false;
            //    btnAddStudents.Enabled = true;
            //    btnDelete.Enabled = true;
            //    btnSaveChanges.Visible = false;
            //    toggleEdit = 1;
            //}
            //else
            //{
            //    MessageBox.Show("Please select a student to edit.");
            //    txtSearch.Clear();
            //}
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
            i = (Image)b;
            
            pbImage.Image = Bitmap.FromStream(m);

        }


        private void BtnEdit_Click(object sender, EventArgs e)
        {
            //txtQuest.Text = txtQuestion.Rtf.ToString();
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

                        string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/Question Images";
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

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string search = "";
            string count = "0";
            if (!String.IsNullOrEmpty(txtSearch.Text))
            {
                string tags = txtSearch.Text;
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

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                {
                    string sql = "SELECT DISTINCT Question, QuestionCode FROM Chekku.QTags " +
                        "WHERE Tag IN (" + search + ")" +
                        "GROUP BY Question, QuestionCode " +
                        "HAVING COUNT(Tag) =" + count;

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
            //this.dgvView.Columns[1].Visible = false;
        }


    }
}

