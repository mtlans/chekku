﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Chekku
{
    public partial class Exam_Questions : Form
    {
        string id = ""; //subjectID
        string subsectcode = ""; //sectioncode
        string qcode = "";
        string examCode = "";
        string qcode2 = "";
        int setNum = 1;
        List<Question> Items = new List<Question>();
        List<int>Sets = new List<int>();
        List<String> AnswerKey = new List<String>();
        List<String> toCheck = new List<String>();
        public Exam_Questions(string excode, int set, string subid, string subsectCode)
        {
            InitializeComponent();
            loadQuestions();
            loadDetails(subid, subsectCode);
            id = subid;
            subsectcode = subsectCode;
            SelectFirst();
            examCode = excode;
            setNum = set;
            for(int i = 1; i<=set; i++)
            {
                Sets.Add(i);
                System.Console.WriteLine("Set: " + i);
            }
        }

        private void loadDetails(string subCode, string subsectCode)
        {
            using (SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                string oString = "Select * from Chekku.Subjects where SubjectID=@SubjectID";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@SubjectID", subCode);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        lblSub.Text = oReader["SubjectCode"].ToString();
                        lblDesc.Text = oReader["SubjectName"].ToString();
                        lblTerm.Text = oReader["Term"].ToString();
                        lblSY.Text = oReader["SchoolYear"].ToString();
                    }
                    myConnection.Close();
                }
                oString = "Select * from Chekku.Section where SubSectCode=@SubSectCode";
                oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@SubSectCode", subsectCode);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        lblSec.Text = oReader["SectionName"].ToString();
                    }
                    myConnection.Close();
                }

            }
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
                AddItem();
                //Enrolled.RemoveAll(x => x.Id == txtID2.Text);
                Items.Add(new Question(qcode, txtQuestion.Text));
                loadQuestions();
                SelectFirst();
            }
            lblNumber.Text = Items.Count.ToString();
            Search();
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


                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        loadQuestions();
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

        private void BtnUn_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtQ.Text))
            {
                Items.RemoveAll(x => x.Qcode == qcode2);
                // MainList.Add(new Student(txtID2.Text, txtName2.Text));
                RemoveItem();
                loadQuestions();
                SelectFirst();
            }
            lblNumber.Text = Items.Count.ToString();
            Search();
            Search2();
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

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
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
                    //string trimmed = "'" + word.Trim() + "'";
                    noSpace.Add(word.Trim());
                    //System.Console.WriteLine(trimmed);
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

        private void Search2()
        {
              string search = "";
            string count = "0";
            if (!String.IsNullOrEmpty(txtSearch2.Text))
            {
                string tags = txtSearch2.Text;
                string[] words = tags.Split(',');
                List<string> noSpace = new List<string>();
                foreach (string word in words)
                {
                    //string trimmed = "'" + word.Trim() + "'";
                    noSpace.Add(word.Trim());
                    //System.Console.WriteLine(trimmed);
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

        private void TxtSearch2_TextChanged(object sender, EventArgs e)
        {
            Search2();
        }

        private void BtnBack_Click(object sender, EventArgs e)
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
                        Form frm = new Exams_Section(id, subsectcode, lblSec.Text);
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



        //GAWAAN NG PDF
        private void BtnSave_Click(object sender, EventArgs e)
        {
            foreach (int number in Sets)
            {
                ShuffleItems();
                CreatePDFandAnswerKey(number);
            }
            MessageBox.Show("Exam is now saved! Check the desktop folder for the PDF and Answer Key.");
           
            Form frm = new Exams_Section(id, subsectcode, lblSec.Text);
            this.Hide();
            frm.Show();
        }



        private void CreatePDFandAnswerKey(int SetNum)
        {
            string sub = lblSub.Text;
            string term = lblTerm.Text;
            string year = lblSY.Text;
            string sect = lblSec.Text;
            AnswerKey.Clear();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/"+sub+" " + year + " T"  + term + "/" + sect + "/Exams";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string answerKeyPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/" + sub + " " + year + " T" + term + "/" + sect + "/Answer Keys" ;
            string filename = examCode + " " + SetNum + ".pdf";
            string Open = path + "/" + filename;
            FileStream fs = new FileStream(Open, FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document(PageSize.LETTER);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            string que = "", answer = "", ch1 = "", ch2 = "", ch3 = "";
            int hasImg = 0;
            int num = 1;
            List<String> ABCD = new List<String>();
            ABCD.Add("A");
            ABCD.Add("B");
            ABCD.Add("C");
            ABCD.Add("D");

            System.Drawing.Image i = null;
            //main loop
            foreach (var question in Items)
            {
                List<String> Answers = new List<String>();

                question.Number = num;
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
                            Answers.Add(answer);
                            toCheck.Add(answer);
                            ch1 = oReader["Choice1"].ToString();
                            Answers.Add(ch1);
                            ch2 = oReader["Choice2"].ToString();
                            Answers.Add(ch2);
                            ch3 = oReader["Choice3"].ToString();
                            Answers.Add(ch3);
                            hasImg = Convert.ToInt32(oReader["hasImage"]);
                            if (hasImg == 1)
                            {
                                byte[] picArr = (byte[])oReader["Image"];
                                MemoryStream ms = new MemoryStream(picArr);
                                ms.Seek(0, SeekOrigin.Begin);
                                i = System.Drawing.Image.FromStream(ms);
                            }
                            else
                            {
                                i = null;
                            }
                        }
                        myConnection.Close();
                    }
                }
                if (hasImg == 1)
                {
                    iTextSharp.text.Image picture = iTextSharp.text.Image.GetInstance(i, System.Drawing.Imaging.ImageFormat.Jpeg);
                    picture.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                    doc.Add(picture);
                }
                doc.Add(new Paragraph(num + ". " + que));
                System.Console.WriteLine(num + ". " + que);
                Answers = Shuffle2(Answers);

                foreach (var letter in ABCD.Zip(Answers, Tuple.Create))
                {
                    System.Console.WriteLine(letter.Item1 + ".) " + letter.Item2);
                    doc.Add(new Paragraph((letter.Item1 + ".) " + letter.Item2)));
                    if (letter.Item2.Equals(answer))
                    {
                        AnswerKey.Add(letter.Item1);
                    }
                }

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                {
                    int checkState;

                    using (SqlCommand sqlCommand = new SqlCommand("Chekku.addExamItemNumber", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add(new SqlParameter("@ExamCode", SqlDbType.VarChar, 8000));
                        sqlCommand.Parameters["@ExamCode"].Value = examCode;

                        sqlCommand.Parameters.Add(new SqlParameter("@QuestionCode", SqlDbType.VarChar, 8000));
                        sqlCommand.Parameters["@QuestionCode"].Value = question.Qcode;

                        sqlCommand.Parameters.Add(new SqlParameter("@ItemNum", SqlDbType.Int));
                        sqlCommand.Parameters["@ItemNum"].Value = num;

                        sqlCommand.Parameters.Add(new SqlParameter("@SetNum", SqlDbType.Int));
                        sqlCommand.Parameters["@SetNum"].Value = SetNum;

                        var returnParameter = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;
                        
                        try
                        {
                            connection.Open();
                            sqlCommand.ExecuteNonQuery();
                            checkState = (Int32)returnParameter.Value;
                            if (checkState == 0)
                            {
                                MessageBox.Show("Error!");
                            }
                            else
                            {
                                System.Console.WriteLine("Success adding: " + " " + num + " " + question.Qcode + "Set: " + SetNum);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Error.");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }


                doc.Add(new Paragraph());
                num++;
            }
            doc.Close();
            printAnswerKey(SetNum, answerKeyPath);
            System.Diagnostics.Process.Start(Open);
        }

        private void ShuffleItems()
        {
            Items = ShuffleList(Items);
            System.Console.WriteLine("Shuffled: ");
            foreach (var question in Items)
            {
                System.Console.WriteLine(question.Qcode);
            }
        }


        private Random rng = new Random();

        private List<E> ShuffleList<E>(List<E> inputList) //items
        {
            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose random object in list
                randomList.Add(inputList[randomIndex]);
                inputList.RemoveAt(randomIndex);
            }

            return randomList;
        }


        private List<E> Shuffle2<E>(List<E> inputList) //answers
        {
            int n = inputList.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                E value = inputList[k];
                inputList[k] = inputList[n];
                inputList[n] = value;
            }
            return inputList;
        }

        private void printAnswerKey(int SetNum, string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filename = examCode + " " + SetNum + " Answer Key.pdf";
            FileStream fs = new FileStream(path + "/" + filename, FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document(PageSize.LETTER);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            int i = 1;
            foreach (var x in AnswerKey)
            {
                doc.Add(new Paragraph(i + ".) " + x));
                i++;
            }
            doc.Close();
        }




    }
}
