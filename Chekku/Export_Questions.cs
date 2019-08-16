using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chekku
{
    public partial class Export_Questions : Form
    {
        string examCode = "TEMP";
        string qcode = "";
        string qcode2 = "";
        List<Question> Items = new List<Question>();

        public Export_Questions()
        {
            InitializeComponent();
            loadQuestions();
            SelectFirst();
        }

        private void loadQuestions()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                //const string sql = "SELECT DISTINCT Question, QuestionCode FROM Chekku.QTags";

                string sql = "SELECT DISTINCT Chekku.QTags.Question, Chekku.QTags.QuestionCode, Chekku.Questions.Answer FROM Chekku.QTags " +
                    "\nINNER JOIN Chekku.Questions ON Chekku.Qtags.QuestionCode=Chekku.Questions.QuestionCode " +
                    "EXCEPT\nSELECT Chekku.Questions.Question, Chekku.ExamItems.QuestionCode, Chekku.Questions.Answer FROM Chekku.ExamItems " +
                    "\nINNER JOIN Chekku.Questions ON Chekku.ExamItems.QuestionCode=Chekku.Questions.QuestionCode " +
                    "WHERE ExamCode = '" + examCode + "'";
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


            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                string sql = "SELECT DISTINCT Chekku.Questions.Question, Chekku.ExamItems.QuestionCode, Chekku.Questions.Answer FROM Chekku.ExamItems " +
                    "\nINNER JOIN Chekku.Questions ON Chekku.ExamItems.QuestionCode = Chekku.Questions.QuestionCode " +
                    "\nWHERE Chekku.ExamItems.ExamCode = '" + examCode + "'";


                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {

                    try
                    {
                        connection.Open();
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            this.dgvItems.DataSource = dataTable;
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
            this.dgvItems.Columns[1].Visible = false;
            if (!String.IsNullOrWhiteSpace(txtSearch.text))
            {
                Search();
            }
            if (!String.IsNullOrWhiteSpace(txtSearch2.text))
            {
                Search2();
            }
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
                            pbImage.Image = System.Drawing.Image.FromStream(ms);
                        }
                        else
                        {
                            pbImage.Image = null;
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
            qcode = Code;
        }

        public void FillContent2(string Code)
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
                        txtQ.Text = oReader["Question"].ToString();
                        txtA.Text = oReader["Answer"].ToString();
                        txtB.Text = oReader["Choice1"].ToString();
                        txtC.Text = oReader["Choice2"].ToString();
                        txtD.Text = oReader["Choice3"].ToString();
                        hasImg = Convert.ToInt32(oReader["hasImage"]);
                        if (hasImg == 1)
                        {
                            byte[] picArr = (byte[])oReader["Image"];
                            MemoryStream ms = new MemoryStream(picArr);
                            ms.Seek(0, SeekOrigin.Begin);
                            pbI.Image = System.Drawing.Image.FromStream(ms);
                        }
                        else
                        {
                            pbI.Image = null;
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
                        txtT.Text = oReader["Tagline"].ToString();
                    }
                    myConnection.Close();
                }
            }
            qcode2 = Code;
        }


        private void SelectFirst()
        {
            if (dgvView.Rows.Count > 0)
            {
                var row = dgvView.Rows[0];
                string code = row.Cells[1].Value.ToString();
                dgvView.CurrentCell = row.Cells[0];
                FillContent(code);
                Console.WriteLine(qcode);
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
            }
            if (dgvItems.Rows.Count > 0)
            {
                var row = dgvItems.Rows[0];
                string code = row.Cells[1].Value.ToString();
                dgvItems.CurrentCell = row.Cells[0];
                FillContent2(code);
            }
            else
            {
                txtA.Text = "";
                txtB.Text = "";
                txtC.Text = "";
                txtD.Text = "";
                txtQ.Text = "";
                txtT.Text = "";
                pbI.Image = null;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                Console.WriteLine("Step 1");
                AddItem();
                //Enrolled.RemoveAll(x => x.Id == txtID2.Text);
                Console.WriteLine("Step 2");
                Items.Add(new Question(qcode, txtQuestion.Text));
                Console.WriteLine("Step 3");
                loadQuestions();
                Console.WriteLine("Step 4");
                Search();
                Console.WriteLine("Step 6");
                SelectFirst();
            }
            lblNumber.Text = Items.Count.ToString();
            Search2();
        }

        private void AddItem()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Chekku.addExamItem", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@ExamCode", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@ExamCode"].Value = examCode;

                    sqlCommand.Parameters.Add(new SqlParameter("@QuestionCode", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@QuestionCode"].Value = qcode;

                    var returnParameter = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        int checkState = (Int32)returnParameter.Value;
                        if (checkState == 0)
                        {
                            Console.WriteLine("ERROR.");
                        }
                        else
                        {
                            loadQuestions();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error exporting item.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void BtnUn_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtQ.Text))
            {
                Items.RemoveAll(x => x.Qcode == qcode2);
                // MainList.Add(new Student(txtID2.Text, txtName2.Text));
                RemoveItem();
                loadQuestions();
                Search2();
                Search();
                SelectFirst();
            }
            lblNumber.Text = Items.Count.ToString();
        }

        private void RemoveItem()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Chekku.removeItem", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@ExamCode", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@ExamCode"].Value = examCode;

                    sqlCommand.Parameters.Add(new SqlParameter("@QuestionCode", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@QuestionCode"].Value = qcode2;

                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        loadQuestions();
                    }
                    catch
                    {
                        MessageBox.Show("Error deleting item.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void DgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvItems.Rows[e.RowIndex];
                //populate
                txtQ.Text = row.Cells[0].Value.ToString();
                string code2 = row.Cells[1].Value.ToString();
                //string extractImage = row.Cells[1].Value.ToString();
                //setPicture(extractImage);
                qcode2 = code2;
                FillContent2(code2);
            }
            else
            {
                txtA.Text = "";
                txtB.Text = "";
                txtC.Text = "";
                txtD.Text = "";
                txtQ.Text = "";
                txtT.Text = "";
                pbI.Image = null;
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
            Search2();
        }

        private void Search()
        {
            string search = "";
            string count = "0";
            if (!String.IsNullOrEmpty(txtSearch.text))
            {
                Console.WriteLine("Pumasoko dito");
                string tags = txtSearch.text;
                string[] words = tags.Split(',');
                List<string> noSpace = new List<string>();
                foreach (string word in words)
                {
                    //string trimmed = "'" + word.Trim() + "'";
                    noSpace.Add(word.Trim());
                    ////System.Console.WriteLine(trimmed);
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
                //System.Console.WriteLine(noSpace.Count);
                count = noSpace.Count.ToString();
                //System.Console.WriteLine("Nakalagay sa search: " + search);
                string sql = "";
                String last = noSpace.Last();
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                {
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
                    sql += "\nEXCEPT\nSELECT Chekku.Questions.Question, Chekku.ExamItems.QuestionCode, Chekku.Questions.Answer FROM Chekku.ExamItems " +
                    "\nINNER JOIN Chekku.Questions ON Chekku.ExamItems.QuestionCode=Chekku.Questions.QuestionCode " +
                    "WHERE ExamCode = '" + examCode + "'";
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
            }
            else
            {
                loadQuestions();
            }
            SelectFirst();
        }

        private void TxtSearch2_TextChanged(object sender, EventArgs e)
        {
            Search2();
        }

        private void Search2()
        {
            string search = "";
            string count = "0";
            if (!String.IsNullOrEmpty(txtSearch2.text))
            {
                string tags = txtSearch2.text;
                string[] words = tags.Split(',');
                List<string> noSpace = new List<string>();
                foreach (string word in words)
                {
                    //string trimmed = "'" + word.Trim() + "'";
                    noSpace.Add(word.Trim());
                    ////System.Console.WriteLine(trimmed);
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
                //System.Console.WriteLine(noSpace.Count);
                count = noSpace.Count.ToString();
                //System.Console.WriteLine(search);
                string sql = "";
                String last = noSpace.Last();
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                {
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
                    sql += "\nINTERSECT\nSELECT Chekku.Questions.Question, Chekku.ExamItems.QuestionCode, Chekku.Questions.Answer FROM Chekku.ExamItems " +
                    "\nINNER JOIN Chekku.Questions ON Chekku.ExamItems.QuestionCode=Chekku.Questions.QuestionCode " +
                    "WHERE ExamCode = '" + examCode + "'";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                    {

                        try
                        {
                            connection.Open();

                            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                            {
                                DataTable dataTable = new DataTable();
                                dataTable.Load(dataReader);
                                this.dgvItems.DataSource = dataTable;
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
            }
            else
            {
                loadQuestions();
            }
            SelectFirst();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            DeleteTemp();
        }

        private void DeleteTemp()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Chekku.deleteExam", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ExamCode", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@ExamCode"].Value = examCode;

                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        Form frm = new Questions();
                        frm.Show();
                        this.Hide();
                    }
                    catch
                    {
                        MessageBox.Show("Error deleting exam.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        private void BtnExport_Click(object sender, EventArgs e)
        {
            if(!(Items.Count == 0))
            {
                GetFileName a = new GetFileName();
                a.ShowDialog();
                a.Hide();
                string filename = a.filename;
                string path = a.path;
                a.Dispose();
                if (!filename.Equals("cancelled"))
                {
                    CreateTextFile(filename, path);
                }
            }
            else
            {
                MessageBox.Show("Please choose questions to export.");
            }
        }

        private void CreateTextFile(string filename, string path)
        {
            string Open = path + "/" + filename + ".txt";
            var delimiter = "@@@";

            using (var writer = new StreamWriter(Open))
            {
                int num = 1;
                foreach (var question in Items)
                {
                    string que = "", answer = "", ch1 = "", ch2 = "", ch3 = "";
                    int hasImg = 0;
                    List<String> line = new List<String>();
                    using (SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                    {
                        string oString = "Select * from Chekku.Questions where QuestionCode=@Code";
                        SqlCommand oCmd = new SqlCommand(oString, myConnection);
                        oCmd.Parameters.AddWithValue("@Code", question.Qcode);
                        myConnection.Open();
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                que = oReader["Question"].ToString();
                                answer = oReader["Answer"].ToString();
                                ch1 = oReader["Choice1"].ToString();
                                ch2 = oReader["Choice2"].ToString();
                                ch3 = oReader["Choice3"].ToString();
                                hasImg = Convert.ToInt32(oReader["hasImage"]);
                                if (hasImg == 1)
                                {
                                    string imgpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Chekku/Question Images";
                                    string imgname = question.Qcode + ".jpg";
                                    string imgloc = System.IO.Path.Combine(imgpath, imgname);

                                    string imgOut = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/Export Question Banks/" + filename + "/Images";
                                    if (!Directory.Exists(imgOut))
                                    {
                                        Directory.CreateDirectory(imgOut);
                                    }
                                    string imgFinal = imgOut + "/"+ num.ToString() + ".jpg";
                                    File.Copy(imgloc, imgFinal);
                                }
                                else
                                {
                                    //    i = null;
                                }
                            }
                            myConnection.Close();
                        }
                    }
                    line.Add(num.ToString());
                    line.Add(que);
                    line.Add(answer);
                    line.Add(ch1);
                    line.Add(ch2);
                    line.Add(ch3);
                    line.Add(hasImg.ToString());
                    var toWrite = string.Join(delimiter, line.ToArray());
                    writer.WriteLine(toWrite);
                    line.Clear();
                    num++;
                }
                writer.Close();
            }
            MessageBox.Show("Successfully created file!");
            DeleteTemp();
        }

        private void BtnExportAll_Click(object sender, EventArgs e)
        {
            int i = dgvView.RowCount;
            Console.WriteLine("Row count: " + i);
            for (int x=0; x<i; x++)
            {
                if (!String.IsNullOrWhiteSpace(txtQuestion.Text))
                {
                    AddItem();
                    //Enrolled.RemoveAll(x => x.Id == txtID2.Text);
                    Items.Add(new Question(qcode, txtQuestion.Text));
                    loadQuestions();
                    Search();
                    SelectFirst();
                }
                lblNumber.Text = Items.Count.ToString();
            }
        }
        //end
    }
}
