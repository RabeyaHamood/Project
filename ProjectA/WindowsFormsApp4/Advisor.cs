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
using System.Text.RegularExpressions;

namespace Adv
{
    public partial class Form5 : Form
    {
        public Form5()
        {

            InitializeComponent();
            comboBox1.Items.Add("Male");
            comboBox1.Items.Add("Female");
            comboBox2.Items.Add("Professor");
            comboBox2.Items.Add("Associate Professor");
            comboBox2.Items.Add("Assisstant Professor");
            comboBox2.Items.Add("Lecturer");
            comboBox2.Items.Add("Industry Professional");
        }
        SqlConnection conn = new SqlConnection(@"Data Source = LAPTOP-085RGBDL\SQLEXPRESS; Initial Catalog = ProjectA;Integrated Security = True; MultipleActiveResultSets = True");

        
        private void Form5_Load(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, KeyPressEventArgs e)
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
            cmd.CommandText = "select  Person.Id,Person.FirstName , Person.LastName , Person.Contact , Person.Email ,Person.DateOfBirth , Person.Gender , Advisor.Designation , Advisor.Salary from Person join Advisor On Person.Id = Advisor.Id";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
           
           

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")

            {
                // display popup box
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK);



            }
            
            else if (textBox1.Text.StartsWith(".") || textBox2.Text.StartsWith(".") || textBox3.Text.StartsWith(".") || textBox4.Text.StartsWith(".") || textBox5.Text.StartsWith(".") || textBox6.Text.StartsWith("."))

            {

                MessageBox.Show("Value can not start with .");
            }
            else if (textBox1.Text.StartsWith(" ") || textBox2.Text.StartsWith(" ") || textBox3.Text.StartsWith(" ") || textBox4.Text.StartsWith(" ") || textBox5.Text.StartsWith(" ") || textBox6.Text.StartsWith("."))

            {

                MessageBox.Show(" Value can not start with blank space");
            }

            else
            {
                string congo = comboBox1.SelectedItem.ToString();

                string genderValue = "select Id FROM Lookup WHERE Category = 'Gender' AND value ='" + congo + "'";
                SqlCommand genderInt = new SqlCommand(genderValue, conn);
                int value = 0;
                SqlDataReader reader = genderInt.ExecuteReader();
                // genderInt.ExecuteNonQuery();
                while (reader.Read())
                {
                    value = int.Parse(reader[0].ToString());
                }

                //int gender = Convert.ToInt32(genderInt.ExecuteScalar ());

                string per = "INSERT into Person(FirstName , LastName , Contact , Email , DateOfBirth , Gender) values ('" + textBox1.Text + "' , '" + textBox2.Text + "' , '" + textBox3.Text + "' , '" + textBox4.Text + "' , '" + DateTime.Parse(textBox5.Text) + "' , '" + value + "')";

                SqlCommand persi = new SqlCommand(per, conn);
                int ii = persi.ExecuteNonQuery();
                int value1 = 0;
                string query = "Select Id from Person where (Id = SCOPE_IDENTITY())";
                SqlCommand cmd = new SqlCommand(query, conn);
                var val = cmd.ExecuteScalar().ToString();
                value1 = int.Parse(val);
                string congo1 = comboBox2.Text.ToString();
                string desg = "select Id FROM Lookup WHERE Category = 'DESIGNATION' AND Value ='" + congo1 + "'";
                SqlCommand d = new SqlCommand(desg, conn);
                int value5 = 0;
                SqlDataReader reader1 = d.ExecuteReader();
                // genderInt.ExecuteNonQuery();
                while (reader1.Read())
                {
                    value5 = int.Parse(reader1[0].ToString());
                }
                string q = "insert into Advisor values('" + value1 + "','" + value5 + "' , '" + int.Parse(textBox6.Text.ToString()) + "' )";
                SqlCommand cmd1 = new SqlCommand(q, conn);

                int ji = cmd1.ExecuteNonQuery();

                if (MessageBox.Show("Do You want to Register it", "Register", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("Student is registered");
                }
                else
                {
                    MessageBox.Show("Student not registered", "Register Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            Display_Data();
            

            


        }








        private void button4_Click(object sender, EventArgs e)
        {
            Display_Data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string delete = "DELETE FROM Advisor WHERE Id = '" + int.Parse(ID) + "'";
            SqlCommand del = new SqlCommand(delete, conn);
            if (MessageBox.Show("Do You want to delete it", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                del.ExecuteNonQuery();
                del.CommandText = string.Format("DELETE from Person where  Id ='" + int.Parse(ID) + "'");
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
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            Display_Data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || textBox6.Text.StartsWith("."))

            {
                // display popup box
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK);
            }
            else
            {



                string genderValue = "select Id FROM Lookup WHERE Category = 'GENDER' AND value ='" + comboBox1.Text.ToString() + "'";
                SqlCommand genderInt = new SqlCommand(genderValue, conn);
                int value = 0;
                SqlDataReader reader = genderInt.ExecuteReader();
                // genderInt.ExecuteNonQuery();
                while (reader.Read())
                {
                    value = int.Parse(reader[0].ToString());
                }
                //FirstName ='" + textBox2.Text + "' ,
                string query = string.Format("SELECT Id from Person Where Email = '" + textBox4.Text + "'");
                SqlCommand cmd = new SqlCommand(query, conn);
                var val = cmd.ExecuteScalar().ToString();
                int value1 = int.Parse(val);
                // int id =int.Parse( cmd.ExecuteScalar());
                string per = "Update Person set FirstName ='" + textBox1.Text + "' ,  LastName= '" + textBox2.Text + "' , Contact = '" + textBox3.Text + "', Email = '" + textBox4.Text + "', DateOfBirth ='" + DateTime.Parse(textBox5.Text) + "', Gender = '" + value + "' WHERE Id= '" + value1 + "'";
                SqlCommand persi = new SqlCommand(per, conn);
                int i = persi.ExecuteNonQuery();
                string congo1 = comboBox2.Text.ToString();
                string desg = "select Id FROM Lookup WHERE Category = 'DESIGNATION' AND Value ='" + congo1 + "'";
                SqlCommand d = new SqlCommand(desg, conn);
                int value5 = 0;
                SqlDataReader reader1 = d.ExecuteReader();
                // genderInt.ExecuteNonQuery();
                while (reader1.Read())
                {
                    value5 = int.Parse(reader1[0].ToString());
                }
                string st = "Update Advisor set Designation = '" + value5 + "',Salary = '" + int.Parse(textBox6.Text) + "' where Id ='" + value1 + "'";
                SqlCommand persi1 = new SqlCommand(st, conn);
                //int j = persi1.ExecuteNonQuery();


                if (MessageBox.Show("Do You want to Update it", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    MessageBox.Show("DATA IS Updated");
                }
                else
                {
                    MessageBox.Show("Row not Updated", "Update row", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            Display_Data();
        }

        private void textBox1_TextChanged(object sender, CancelEventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
    }











    
           

       
    


  
    

      
    
