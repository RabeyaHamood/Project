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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace j2
{
    public partial class Join2 : Form
    {
        public Join2()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source = LAPTOP-085RGBDL\SQLEXPRESS; Initial Catalog = ProjectA;Integrated Security = True; MultipleActiveResultSets = True");

        private void Join2_Load(object sender, EventArgs e)
        {

        }
        private void Display_Data()
        {

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT Project.Title as [Project Title],dbo.Person.[FirstName] +' '+Person.LastName as [Advisor Name],(SELECT Value From Lookup Where Id = ProjectAdvisor.[AdvisorRole]  AND Category ='ADVISOR_ROLE')as[Advisor Role],Student.RegistrationNo as [Registration Number] FROM Person p JOIN Advisor ON p.Id = Advisor.Id JOIN [dbo].ProjectAdvisor ON [dbo].ProjectAdvisor.AdvisorId = Advisor.Id JOIN [dbo].Project ON [dbo].ProjectAdvisor.ProjectId = Project.Id JOIN [dbo].[GroupProject] ON [dbo].GroupProject.[ProjectId] = Project.Id  JOIN [dbo].[Group] ON [dbo].[Group].[Id] = GroupProject.[GroupId] JOIN [dbo].GroupStudent ON [dbo].GroupStudent.GroupId = dbo.[Group].Id JOIN [dbo].Student ON [dbo].Student.Id = [dbo].GroupStudent.StudentId  JOIN Person on Advisor.Id = Person.Id";
            // cmd.CommandText = "select Person.Id,Person.FirstName, Person.LastName, Person.Contact , Person.Email ,Person.DateOfBirth , Person.Gender , Student.RegistrationNo  from Person join Student ON Person.Id = Student.Id ";
            cmd.CommandText = "Select * From GroupEvaluation";
            // cmd.CommandText = "(SELECT ProjectAdvisor.AdvisorId , ProjectAdvisor.ProjectId , Advisor.Designation , Advisor.Salary from Project join Advisor ON Project.Id = Advisor.Id) ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Display_Data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                //Creating iTextSharp Table from the DataTable data
                PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
                pdfTable.DefaultCell.Padding = 3;
                pdfTable.WidthPercentage = 30;
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTable.DefaultCell.BorderWidth = 1;

                pdfTable.WidthPercentage = 90f;

                int[] firstTablecellWidth = { 20, 25, 25, 30 };
                pdfTable.SetWidths(firstTablecellWidth);

                //Adding Header row
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    pdfTable.AddCell(cell);
                }

                //Adding DataRow
                int row = dataGridView1.Rows.Count;
                int cell2 = dataGridView1.Rows[1].Cells.Count;
                for (int i = 0; i < row - 1; i++)

                {

                    for (int j = 0; j < cell2; j++)
                    {


                        if (dataGridView1.Rows[1].Cells[j].Value == null)
                        {
                            dataGridView1.Rows[i].Cells[j].Value = "null";
                        }
                        pdfTable.AddCell(dataGridView1.Rows[i].Cells[j].Value.ToString());
                        this.dataGridView1.Columns[j].Width = 150;
                    }
                }

                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    foreach (DataGridViewCell cell in row.Cells)
                //    {
                //        pdfTable.AddCell(cell.Value.ToString());
                //    }
                //}


                //Exporting to PDF
                string folderPath = @"G:\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                using (FileStream stream = new FileStream(folderPath + "DataGridViewExport1.pdf", FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();
                    stream.Close();
                }

            }

            MessageBox.Show("PDF Generated Successfully");
        }
    }
}
