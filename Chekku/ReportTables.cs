using iTextSharp.text;
using iTextSharp.text.pdf;
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
using System.Windows.Forms.DataVisualization.Charting;
using Image = iTextSharp.text.Image;

namespace Chekku
{
    public partial class ReportTables : Form
    {
        string examcode = "";
        int maxItems = 0;
        DataTable scores = new DataTable();
        List<int> mmm = new List<int>();//Mean
        List<string> ques = new List<string>();//questions
        List<Question> FOE = new List<Question>();
        List<int> final = new List<int>();
        string id = "";
        string code = "";
        string sub = "";
        string term = "";
        string year = "";
        string sect = "";
        string examName = "";
        double passed70 = 0;
        public ReportTables(string ex, int maxItems, string id, string code)
        {
            InitializeComponent();
            examcode = ex;
            this.id = id;
            this.code = code;
            this.maxItems = maxItems;
            Console.WriteLine("MaxItems: " + maxItems);
            loadScores();
            loadDetails(id, code);
            txtPass.Text = "70";
            changePercent();
            MakeItGlow();
            loadFOE();
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
                        sub = oReader["SubjectCode"].ToString();
                        term = oReader["Term"].ToString();
                        year = oReader["SchoolYear"].ToString();
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
                        sect = oReader["SectionName"].ToString();
                    }
                    myConnection.Close();
                }

                oString = "Select DISTINCT QuestionCode,SetNum, ItemNumber from Chekku.SetMapper where ExamCode=@examcode order by SetNum, ItemNumber";
                oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@examcode", examcode);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        string qc = oReader["QuestionCode"].ToString();
                        if (!ques.Contains(qc))
                        {
                            ques.Add(qc);
                        }
                    }
                    myConnection.Close();
                }

                oString = "Select ExamName from Chekku.Exams where ExamCode=@examcode";
                oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@examcode", examcode);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        examName = oReader["ExamName"].ToString();
                    }
                    myConnection.Close();
                }
                foreach (var x in ques)
                {
                    Console.WriteLine("OOGABOOGA " + x);
                }

            }
        }

        private void loadScores()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
            {
                string sql = "SELECT Chekku.Reports.StudentNo, Chekku.Students.StudentName, Chekku.Reports.Score FROM Chekku.Reports" +
                    "\nINNER JOIN Chekku.Students ON Chekku.Reports.StudentNo = Chekku.Students.StudentNo" +
                    " WHERE ExamCode ='" + examcode + "'";

                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            scores.Load(dataReader);
                            this.dgvScores.DataSource = scores;
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

        private void TxtPass_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void changePercent()
        {
            mmm.Clear();
            if (dgvScores.Rows.Count > 0)
            {
                double pasado = 0;
                double total = 0;
                Console.WriteLine(maxItems + " " + (Convert.ToInt32(txtPass.Text) + " " + 100));
                Console.WriteLine((Convert.ToDouble(txtPass.Text) / 100));
                double passing = maxItems * (Convert.ToDouble(txtPass.Text) / 100);
                foreach (DataRow row in scores.Rows)
                {
                    mmm.Add(Convert.ToInt32(row["Score"].ToString()));
                    if (Convert.ToDouble(row["Score"].ToString()) >= passing)
                    {
                        Console.WriteLine(row["Score"].ToString());
                        pasado = pasado + 1;
                    }
                }
                Console.WriteLine(passing);
                Console.WriteLine(pasado + " / " + scores.Rows.Count + " *100 = " + (pasado / scores.Rows.Count) * 100);
                txtScore.Text = passing.ToString();
                txtPStud.Text = pasado.ToString();
                gPassing.Value = Convert.ToInt32((pasado / scores.Rows.Count) * 100);
                passed70 = pasado;

                double average = mmm.Average();
                txtMean.Text = average.ToString();
                double least = mmm.Min();
                txtLow.Text = least.ToString();
                double high = mmm.Max();
                txtHigh.Text = high.ToString();
                MakeItGlow();
            }
        }

        private void BtnRecalc_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtPass.Text) > 100)
            {
                MessageBox.Show("Please enter a value between 0 - 100 only.", "Invalid value.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                changePercent();
            }
        }

        private void MakeItGlow()
        {
            if (dgvScores.Rows.Count > 0)
            {
                double pasado = 0;
                Console.WriteLine(maxItems + " asdsadsads " + (Convert.ToInt32(txtPass.Text) + " " + 100));
                Console.WriteLine((Convert.ToDouble(txtPass.Text) / 100));
                double passing = maxItems * (Convert.ToDouble(txtPass.Text) / 100);
                var i = 0;
                Console.WriteLine(scores.Rows.Count);
                foreach (DataGridViewRow row in dgvScores.Rows)
                {
                    Console.WriteLine("1234 Score: " + row.Cells["Score"].Value);
                            try
                            {
                                if (Convert.ToDouble(row.Cells["Score"].Value) >= passing)
                                {
                                    dgvScores.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(1, 169, 156);
                                }
                                else
                                {
                                    dgvScores.Rows[i].DefaultCellStyle.BackColor = DefaultBackColor;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("amp" + i);
                            }
                            i++;
                }
            }
            
        }

        private void TxtSearch_OnTextChange(object sender, EventArgs e)
        {
            Filter();
        }

        private void CmbSelect_onItemSelected(object sender, EventArgs e)
        {
            txtSearch.ResetText();
            Filter();
        }

        private void Filter()
        {
            string toSearch = cmbSelect.selectedValue.ToString();
            toSearch = toSearch.Replace(" ", String.Empty);
            if (toSearch.Equals("StudentName"))
            {
                (dgvScores.DataSource as DataTable).DefaultView.RowFilter = string.Format("StudentName LIKE '{0}%'", txtSearch.text);
            }
            else
            {
                (dgvScores.DataSource as DataTable).DefaultView.RowFilter = string.Format("StudentNo LIKE '{0}%'", txtSearch.text);
            }
            MakeItGlow();
        }

        private void ReportTables_Load(object sender, EventArgs e)
        {
            MakeItGlow();
            LoadGraph();
            LoadGraphN();
        }

        private void LoadGraph()
        {
            double interval = Convert.ToDouble(maxItems) / 5;
            double q1 = 0 + interval;
            double q2 = q1 + interval;
            double q3 = q2 + interval;
            double q4 = maxItems;
            double c1 = 0;
            double c2 = 0;
            double c3 = 0;
            double c4 = 0;
            foreach (var x in mmm)
            {
                if (x <= q1)
                {
                    c1 = c1 + 1;
                    Console.WriteLine("Score: " + x + "c1");
                }
                else if (x > q1 && x <= q2)
                {
                    c2 = c2 + 1; Console.WriteLine("Score: " + x + "c2");
                }
                else if (x > q2 && x <= q3)
                {
                    c3 = c3 + 1; Console.WriteLine("Score: " + x + "c3");
                }
                else
                {
                    c4 = c4 + 1; Console.WriteLine("Score: " + x + "c4");
                }

            }
            Console.WriteLine(interval + " " + q1 + " " + q2 + " " + q3 + " " + q4);
            scoreChart.ChartAreas[0].AxisY.Maximum = scores.Rows.Count;
            scoreChart.Series["Students"].Points.AddXY("0 - " + q1.ToString(), c1);
            scoreChart.Series["Students"].Points.AddXY(q1.ToString() + " - " + q2.ToString(), c2);
            scoreChart.Series["Students"].Points.AddXY(q2.ToString() + " - " + q3.ToString(), c3);
            scoreChart.Series["Students"].Points.AddXY(q3.ToString() + " - " + maxItems, c4);
            scoreChart.ChartAreas[0].AxisY.Interval = 1;
        }


        private void LoadGraphN()
        {
            double average = mmm.Average();
            List<double> step2 = new List<double>();
            foreach(var x in mmm)
            {
                step2.Add(Math.Pow((x - average), 2));
            }
            double newave = step2.Average();
            double sd = Math.Sqrt(newave);

            double q1 = average - (sd * 2);
            double q2 = average - sd;
            double q3 = average + (sd);
            double q4 = average + (sd * 2);
            double c1 = 0;
            double c2 = 0;
            double c3 = 0;
            double c4 = 0;
            foreach (var x in mmm)
            {
                if (x <= q1)
                {
                    c1 = c1 + 1;
                    Console.WriteLine("Score: " + x + "c1");
                }
                else if (x > q1 && x <= q2)
                {
                    c2 = c2 + 1; Console.WriteLine("Score: " + x + "c2");
                }
                else if (x > q2 && x <= q3)
                {
                    c3 = c3 + 1; Console.WriteLine("Score: " + x + "c3");
                }
                else
                {
                    c4 = c4 + 1; Console.WriteLine("Score: " + x + "c4");
                }

            }
            Console.WriteLine(sd + " " + q1 + " " + q2 + " " + q3 + " " + q4);
            q1 = Math.Round(q1,2);
            q2 = Math.Round(q2,2);
            q3 = Math.Round(q3,2);
            //q4 = Math.Round(q4,2);
            //chartNorm.ChartAreas[0].AxisY.Maximum = scores.Rows.Count;
            //chartNorm.Series["Students"].Points.AddXY( q1.ToString(), c1);
            //chartNorm.Series["Students"].Points.AddXY(q1.ToString() + " - " + q2.ToString(), c2);
            //chartNorm.Series["Students"].Points.AddXY(q2.ToString() + " - " + q3.ToString(), c3);
            //chartNorm.Series["Students"].Points.AddXY(q3.ToString() + " - " + maxItems, c4);
            //txtSD.Text = sd.ToString();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Chekku/Subjects/" + sub + " " + year + " T" + term + "/" + sect + "/Reports";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filename = examcode + " Report.pdf";
            string Open = path + "/" + filename;
            FileStream fs = new FileStream(Open, FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document(PageSize.LETTER, 10f, 10f, 10f, 0f);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.Add(new Paragraph("Subject Code: " + sub + "\n" + "Term: " + term + "\n" + "Year: " + year));
            doc.Add(new Paragraph("Section: " + sect));
            doc.Add(new Paragraph("Exam Code: " + examcode));
            doc.Add(new Paragraph("Exam Name: " + examName));
            Paragraph x = new Paragraph("Table of Scores\n\n");
            x.Alignment = Element.ALIGN_CENTER;
            doc.Add(x);
            doc.Add(new Paragraph(""));
            DataView dv = scores.DefaultView;
            dv.Sort = "StudentNo";
            DataTable sortedDT = dv.ToTable();
            PdfPTable table = new PdfPTable(sortedDT.Columns.Count);
            table.WidthPercentage = 100;

            //Set columns names in the pdf file
            for (int k = 0; k < sortedDT.Columns.Count; k++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(sortedDT.Columns[k].ColumnName));

                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                cell.BackgroundColor = new iTextSharp.text.BaseColor(51, 102, 102);

                table.AddCell(cell);
            }

            //Add values of DataTable in pdf file
            for (int i = 0; i < sortedDT.Rows.Count; i++)
            {
                for (int j = 0; j < sortedDT.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(sortedDT.Rows[i][j].ToString()));

                    //Align the cell in the center
                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                    table.AddCell(cell);
                }
            }
            
            doc.Add(table);
            Paragraph x2 = new Paragraph("\n\nExam Summary");
            x2.Alignment = Element.ALIGN_CENTER;
            doc.Add(x2);
            doc.Add(new Paragraph("\nNo. of Students: " + scores.Rows.Count));
            doc.Add(new Paragraph("Average Score: " + txtMean.Text));
            doc.Add(new Paragraph("No. of Passing (70% above): " + passed70.ToString()));
            doc.Add(new Paragraph("Highest Score: " + txtHigh.Text + "\nLowest Score: " + txtLow.Text ));
            Paragraph x1 = new Paragraph("\n\nFrequency of Errors\n\n");
            x1.Alignment = Element.ALIGN_CENTER;
            doc.Add(x1);
            var chartimage = new MemoryStream();
                chartFOE.SaveImage(chartimage, ChartImageFormat.Png);
            var foe = Image.GetInstance(chartimage.GetBuffer());
            var scalePercent = (((doc.PageSize.Width / foe.Width) * 100) - 4);
            foe.ScalePercent(scalePercent);
            foe.Alignment = Element.ALIGN_CENTER;
            doc.Add(foe);
            doc.Close();
            MessageBox.Show("Succesfully created PDF.", "PDF Creation", MessageBoxButtons.OK);
            System.Diagnostics.Process.Start(Open);
            MakeItGlow();
        }

        private void BunifuFlatButton2_Click(object sender, EventArgs e)
        {
            pIA.Visible = false;
            pScores.Visible = true;
        }

        private void BunifuFlatButton3_Click(object sender, EventArgs e)
        {
            pIA.Visible = true;
            pScores.Visible = false;
        }
        int chartState = 1;

        private void loadFOE()
        {
            final.Clear();
            FOE.Clear();
            if (chartState ==1)
            {
                foreach (var x in ques)
                {
                    Console.WriteLine(x);
                }
                Console.WriteLine("Count: " + ques.Count);
                int i = 1;
                foreach (var x in ques)
                {
                    int n = 0;
                    using (SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                    {
                        string oString = "Select Mistakes from Chekku.SetMapper where QuestionCode=@quescode AND ExamCode=@examcode";
                        SqlCommand oCmd = new SqlCommand(oString, myConnection);
                        oCmd.Parameters.AddWithValue("@quescode", x);
                        oCmd.Parameters.AddWithValue("@examcode", examcode);
                        myConnection.Open();
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                FOE.Add(new Question(i, Convert.ToInt32(oReader["Mistakes"].ToString())));
                                n += Convert.ToInt32(oReader["Mistakes"].ToString());
                                Console.WriteLine("Number: " + i + " Mistakes: " + oReader["Mistakes"].ToString());
                            }
                            myConnection.Close();
                        }
                    }
                    final.Add(n);
                    i++;
                }
                foreach (var series in chartFOE.Series)
                {
                    series.Points.Clear();
                }
                chartFOE.Series["Mistakes"].ChartType = SeriesChartType.Bar;
                chartFOE.ChartAreas[0].AxisX.Title = "Item Number";
                chartFOE.ChartAreas[0].AxisY.Title = "Number of Mistakes";
                chartFOE.ChartAreas[0].AxisX.Interval = 1;
                chartFOE.ChartAreas[0].AxisY.Interval = 1;
                chartFOE.ChartAreas[0].AxisX.Maximum = maxItems + 1;
                chartFOE.ChartAreas[0].AxisY.Maximum = final.Max();
                int num = 1;
                foreach (var x in final)
                {
                    Console.WriteLine("Mistakes: " + x);
                    chartFOE.Series["Mistakes"].Points.AddXY(num.ToString(), x);
                    num++;
                }
                chartState = 0;
            }
            else
            {
                foreach (var x in ques)
                {
                    Console.WriteLine(x);
                }
                Console.WriteLine("Count: " + ques.Count);
                int i = 1;
                foreach (var x in ques)
                {
                    int n = 0;
                    using (SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                    {
                        string oString = "Select Mistakes from Chekku.SetMapper where QuestionCode=@quescode AND ExamCode=@examcode";
                        SqlCommand oCmd = new SqlCommand(oString, myConnection);
                        oCmd.Parameters.AddWithValue("@quescode", x);
                        oCmd.Parameters.AddWithValue("@examcode", examcode);
                        myConnection.Open();
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                FOE.Add(new Question(i, Convert.ToInt32(oReader["Mistakes"].ToString())));
                                n += Convert.ToInt32(oReader["Mistakes"].ToString());
                                Console.WriteLine("Number: " + i + " Mistakes: " + oReader["Mistakes"].ToString());
                            }
                            myConnection.Close();

                        }
                    }
                    final.Add(n);
                    i++;
                }
                foreach (var series in chartFOE.Series)
                {
                    series.Points.Clear();
                }
                chartFOE.Series["Mistakes"].ChartType = SeriesChartType.Bar;
                chartFOE.ChartAreas[0].AxisX.Title = "Item Number";
                chartFOE.ChartAreas[0].AxisY.Title = "Number of Mistakes";
                chartFOE.ChartAreas[0].AxisX.Interval = 1;
                chartFOE.ChartAreas[0].AxisY.Interval = 1;
                chartFOE.ChartAreas[0].AxisX.Maximum = maxItems + 1;
                chartFOE.ChartAreas[0].AxisY.Maximum = final.Max();
                int num = maxItems;
                final.Reverse();
                foreach (var x in final)
                {
                    Console.WriteLine("Mistakes: " + x);
                    chartFOE.Series["Mistakes"].Points.AddXY(num.ToString(), x);
                    num--;
                }
                chartState = 1;
            }
           
            
        }

        private void BunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Form frm = new Reports_Section(id, code, sect);
            this.Hide();
            frm.Show();
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
        int stateChart = 1;
        private void BtnSortMis_Click(object sender, EventArgs e)
        {
            final.Clear();
            FOE.Clear();
            if (stateChart == 1)
            {
                int i = 1;
                foreach (var x in ques)
                {
                    int n = 0;
                    using (SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                    {
                        string oString = "Select Mistakes from Chekku.SetMapper where QuestionCode=@quescode AND ExamCode=@examcode";
                        SqlCommand oCmd = new SqlCommand(oString, myConnection);
                        oCmd.Parameters.AddWithValue("@quescode", x);
                        oCmd.Parameters.AddWithValue("@examcode", examcode);
                        myConnection.Open();
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                n += Convert.ToInt32(oReader["Mistakes"].ToString());
                                Console.WriteLine("1 Number: " + i + " Mistakes: " + oReader["Mistakes"].ToString());
                            }
                            myConnection.Close();
                        }
                    }
                    final.Add(n);
                    i++;
                }

                int p = 1;
                foreach (var z in final)
                {
                    FOE.Add(new Question(p, z));
                    Console.WriteLine("2 Number: " + p + " Mistakes: " + z);
                    p++;
                }
                List<Question> SortedList = FOE.OrderBy(o => o.Mistakes).ToList();
                foreach (var n in SortedList)
                {
                    Console.WriteLine("3 Number: " + n.Number + " Mistakes: " + n.Mistakes);
                }
                foreach (var series in chartFOE.Series)
                {
                    series.Points.Clear();
                }
                chartFOE.Series["Mistakes"].ChartType = SeriesChartType.Bar;
                chartFOE.ChartAreas[0].AxisX.Title = "Item Number";
                chartFOE.ChartAreas[0].AxisY.Title = "Number of Mistakes";
                chartFOE.ChartAreas[0].AxisX.Interval = 1;
                chartFOE.ChartAreas[0].AxisY.Interval = 1;
                chartFOE.ChartAreas[0].AxisX.Maximum = maxItems + 1;
                chartFOE.ChartAreas[0].AxisY.Maximum = final.Max();
                int num = 1;
                foreach (var n in SortedList)
                {
                    chartFOE.Series["Mistakes"].Points.AddXY(n.Number.ToString(), n.Mistakes);
                    num++;
                }
                stateChart = 0;
            }
            else
            {
                int i = 1;
                foreach (var x in ques)
                {
                    int n = 0;
                    using (SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.ChekkuConnectionString))
                    {
                        string oString = "Select Mistakes from Chekku.SetMapper where QuestionCode=@quescode AND ExamCode=@examcode";
                        SqlCommand oCmd = new SqlCommand(oString, myConnection);
                        oCmd.Parameters.AddWithValue("@quescode", x);
                        oCmd.Parameters.AddWithValue("@examcode", examcode);
                        myConnection.Open();
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                n += Convert.ToInt32(oReader["Mistakes"].ToString());
                                Console.WriteLine("1 Number: " + i + " Mistakes: " + oReader["Mistakes"].ToString());
                            }
                            myConnection.Close();
                        }
                    }
                    final.Add(n);
                    i++;
                }

                int p = 1;
                foreach (var z in final)
                {
                    FOE.Add(new Question(p, z));
                    Console.WriteLine("2 Number: " + p + " Mistakes: " + z);
                    p++;
                }
                List<Question> SortedList = FOE.OrderByDescending(o => o.Mistakes).ToList();
                foreach (var n in SortedList)
                {
                    Console.WriteLine("3 Number: " + n.Number + " Mistakes: " + n.Mistakes);
                }
                foreach (var series in chartFOE.Series)
                {
                    series.Points.Clear();
                }
                chartFOE.Series["Mistakes"].ChartType = SeriesChartType.Bar;
                chartFOE.ChartAreas[0].AxisX.Title = "Item Number";
                chartFOE.ChartAreas[0].AxisY.Title = "Number of Mistakes";
                chartFOE.ChartAreas[0].AxisX.Interval = 1;
                chartFOE.ChartAreas[0].AxisY.Interval = 1;
                chartFOE.ChartAreas[0].AxisX.Maximum = maxItems + 1;
                chartFOE.ChartAreas[0].AxisY.Maximum = final.Max();
                int num = 1;
                foreach (var n in SortedList)
                {
                    chartFOE.Series["Mistakes"].Points.AddXY(n.Number.ToString(), n.Mistakes);
                    num++;
                }
                stateChart = 1;
            }
            
        }

        private void BtnSortNum_Click(object sender, EventArgs e)
        {
            loadFOE();
        }
    }
}
