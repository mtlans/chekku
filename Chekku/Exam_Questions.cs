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
    public partial class Exam_Questions : Form
    {
        string qcode = "";
        string examCode = "";
        string qcode2 = "";
        public Exam_Questions(string code)
        {
            InitializeComponent();
            loadQuestions();
            SelectFirst();
            examCode = code;
        }

        private void loadQuestions()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                //const string sql = "SELECT DISTINCT Question, QuestionCode FROM Chekku.QTags";

                string sql = "SELECT DISTINCT Question, QuestionCode FROM Chekku.QTags " +
                    "EXCEPT\nSELECT Question, QuestionCode FROM Chekku.ExamItems " +
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
                string sql = "SELECT Question, QuestionCode FROM Chekku.ExamItems WHERE ExamCode = '" + examCode + "'";

                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    try
                    {
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
                            pbImage.Image = Image.FromStream(ms);
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
                loadQuestions();
            }
            SelectFirst();
            //this.dgvView.Columns[1].Visible = false;
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
                loadQuestions();
                SelectFirst();
            }
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

                    sqlCommand.Parameters.Add(new SqlParameter("@Question", SqlDbType.VarChar, 8000));
                    sqlCommand.Parameters["@Question"].Value = txtQuestion.Text;

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
                // Enrolled.RemoveAll(x => x.Id == txtID2.Text);
                // MainList.Add(new Student(txtID2.Text, txtName2.Text));
                RemoveItem();
                loadQuestions();
                SelectFirst();
            }
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
                DataGridViewRow row = this.dgvView.Rows[e.RowIndex];
                //populate
                txtQuestion.Text = row.Cells[0].Value.ToString();
                string code2 = row.Cells[1].Value.ToString();
                //string extractImage = row.Cells[1].Value.ToString();
                //setPicture(extractImage);
                qcode2 = code2;
                FillContent2(code2);
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
                            pbI.Image = Image.FromStream(ms);
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



    }
}   
