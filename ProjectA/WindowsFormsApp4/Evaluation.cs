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
namespace Student

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source = LAPTOP-085RGBDL\SQLEXPRESS; Initial Catalog = ProjectA;Integrated Security = True; MultipleActiveResultSets = True");

        public int rowsaffected { get; private set; }

       
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")

            {
                // display popup box
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK);



            }
            
            else if (textBox1.Text.StartsWith(".") || textBox2.Text.StartsWith(".") || textBox3.Text.StartsWith("."))

            {

                MessageBox.Show("Value can not start with .");
            }
            else if (textBox1.Text.StartsWith(" ") || textBox2.Text.StartsWith(" ") || textBox3.Text.StartsWith(" "))

            {

                MessageBox.Show(" Value can not start with blank space");
            }
           


            else
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT into Evaluation(Name, TotalMarks , TotalWeightage) values ('" + textBox1.Text + "' , '" + textBox2.Text + "' , '" + textBox3.Text + "')";
                if (MessageBox.Show("Do You want to Insert it", "Register", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("Data inserted");
                }
                else
                {
                    MessageBox.Show("Data is not inserted", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            Display_Data();
         
            
        }


        

        private void Display_Data()
        {
       
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from Evaluation";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Display_Data();
            
        }
        private void Edit_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            String delete = "DELETE FROM Evaluation WHERE Id = '" + int.Parse(ID) + "'";
            SqlCommand del = new SqlCommand(delete, conn);
            if (MessageBox.Show("Do You want to delete it", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                del.ExecuteNonQuery();
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                MessageBox.Show("DATA IS DELETED");
            }
            else
            {
                MessageBox.Show("Row not deleted", "Remove row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
           
            conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            Display_Data();
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")

            {
                // display popup box
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK);



            }
            else if (textBox1.Text.StartsWith(".") || textBox2.Text.StartsWith(".") || textBox3.Text.StartsWith("."))

            {

                MessageBox.Show("Value can not start with .");
            }
            else if (textBox1.Text.StartsWith(" ") || textBox2.Text.StartsWith(" ") || textBox3.Text.StartsWith(" "))

            {

                MessageBox.Show(" Value can not start with blank space");
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "  ^ [0-9]"))
            {
                textBox2.Text = "";
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "  ^ [0-9]"))
            {
                textBox3.Text = "";
            }

            else
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Evaluation set  Name = '" + this.textBox1.Text + "' ,TotalMarks = '" + this.textBox2.Text + "' ,TotalWeightage= '" + this.textBox3.Text + "' where Name = '" + this.textBox1.Text + "'";
                if (MessageBox.Show("Do You want to Update it", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("DATA IS Updated");
                }
                else
                {
                    MessageBox.Show("Row not Updated", "Update row", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                conn.Close();
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            Display_Data();
            
          
        }
       

        private void button5_Click(object sender, EventArgs e)
        {
           

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                    

            }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!IsDigitsOnly(textBox2.Text))
            {
                MessageBox.Show("Enter Numbers");
            }
        }

        private bool IsDigitsOnly(string text)
        {
            
                foreach (char c in text)
                {
                    if (c < '0' || c > '9')
                        return false;
                }

                return true;
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!IsDigitsOnly(textBox3.Text))
            {
                MessageBox.Show("Enter Numbers");
            }
        }
    }
    }
    
    

