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

namespace RegNo

{
    public partial class Form2 : Form
    {
        public Form2()
        {

            InitializeComponent();
            comboBox1.Items.Add("Male");
            comboBox1.Items.Add("Female");

        }
        SqlConnection conn = new SqlConnection(@"Data Source = LAPTOP-085RGBDL\SQLEXPRESS; Initial Catalog = ProjectA;Integrated Security = True; MultipleActiveResultSets = True");
        

        public object Id { get; private set; }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            cmd.CommandText = "select Person.Id,Person.FirstName, Person.LastName, Person.Contact , Person.Email ,Person.DateOfBirth , Person.Gender , Student.RegistrationNo  from Person join Student ON Person.Id = Student.Id ";
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


        private void button1_Click(object sender, EventArgs e)
        {

            conn.Open();

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "" || textBox6.Text == "")

            {
                // display popup box
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK);



            }

            else if (textBox1.Text.StartsWith(".") || textBox2.Text.StartsWith(".") || textBox3.Text.StartsWith(".") || textBox4.Text.StartsWith(".") || textBox5.Text.StartsWith(".") || textBox6.Text.StartsWith("."))

            {

                MessageBox.Show("Value can not start with .");
            }
            else if (textBox1.Text.StartsWith(" ") || textBox2.Text.StartsWith(" ") || textBox3.Text.StartsWith(" ") || textBox4.Text.StartsWith(" ") || textBox5.Text.StartsWith(" ") || textBox6.Text.StartsWith(" "))

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

                string per = "INSERT into Person(FirstName , LastName , Contact , Email , DateOfBirth , Gender) values ('" + textBox2.Text + "' , '" + textBox3.Text + "' , '" + textBox4.Text + "' , '" + textBox5.Text + "' , '" + DateTime.Parse(textBox6.Text) + "' , '" + value + "')";

                SqlCommand persi = new SqlCommand(per, conn);
                int ii = persi.ExecuteNonQuery();
                int value1 = 0;
                string query = "Select Id from Person where (Id = SCOPE_IDENTITY())";
                SqlCommand cmd = new SqlCommand(query, conn);
                var val = cmd.ExecuteScalar().ToString();
                value1 = int.Parse(val);
                string q = "insert into Student values('" + value1 + "','" + textBox1.Text.ToString() + "')";
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
            Display_Data();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
           string  ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string delete = "DELETE FROM Student WHERE Id = '" + int.Parse(ID) + "'";
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
            Display_Data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "" || textBox6.Text == "")

            {
                // display popup box
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK);



            }

            else if (textBox1.Text.StartsWith(".") || textBox2.Text.StartsWith(".") || textBox3.Text.StartsWith(".") || textBox4.Text.StartsWith(".") || textBox5.Text.StartsWith(".") || textBox6.Text.StartsWith("."))

            {

                MessageBox.Show("Value can not start with .");
            }
            else if (textBox1.Text.StartsWith(" ") || textBox2.Text.StartsWith(" ") || textBox3.Text.StartsWith(" ") || textBox4.Text.StartsWith(" ") || textBox5.Text.StartsWith(" ") || textBox6.Text.StartsWith(" "))

            {

                MessageBox.Show(" Value can not start with blank space");
            }

            else
            {

                string genderValue = "select Id FROM Lookup WHERE Category = 'Gender' AND value ='" + comboBox1.Text.ToString() + "'";
                SqlCommand genderInt = new SqlCommand(genderValue, conn);
                int value = 0;
                SqlDataReader reader = genderInt.ExecuteReader();
                // genderInt.ExecuteNonQuery();
                while (reader.Read())
                {
                    value = int.Parse(reader[0].ToString());
                }
                //FirstName ='" + textBox2.Text + "' ,
                string query = string.Format("SELECT Id from Student Where RegistrationNo = '" + textBox1.Text + "'");
                SqlCommand cmd = new SqlCommand(query, conn);
                var val = cmd.ExecuteScalar().ToString();
                int value1 = int.Parse(val);
                // int id =int.Parse( cmd.ExecuteScalar());
                string per = "Update Person set FirstName ='" + textBox2.Text + "' ,  LastName= '" + textBox3.Text + "' , Contact = '" + textBox4.Text + "', Email = '" + textBox5.Text + "', DateOfBirth ='" + textBox6.Text + "', Gender = '" + value + "' WHERE Id= '" + value1 + "'";
                SqlCommand persi = new SqlCommand(per, conn);
                int i = persi.ExecuteNonQuery();
                // string st = "Update Student set RegistrationNo = '" + textBox1.Text + "' where Id ='"+Id+"'";
                if (MessageBox.Show("Do You want to Update it", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("DATA Updated, Thankyou");
                }
                else
                {
                    MessageBox.Show("Row not Updated", "Update row", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // SqlCommand std = new SqlCommand(st, conn);
                // int ii = std.ExecuteNonQuery();
            }

            conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            Display_Data();
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!IsDigitsOnly(textBox4.Text))
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
    }
    }
    

