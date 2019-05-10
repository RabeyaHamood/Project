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

namespace ss

{
    public partial class GroupStudent : Form
    {
        public GroupStudent()
        {
            InitializeComponent();
            comboBox1.Items.Add("Active");
            comboBox1.Items.Add("InActive");
        }
        SqlConnection conn = new SqlConnection(@"Data Source = LAPTOP-085RGBDL\SQLEXPRESS; Initial Catalog = ProjectA;Integrated Security = True; MultipleActiveResultSets = True");


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GroupStudent_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string ID = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string delete = "DELETE FROM GroupStudent WHERE StudentId = '" + int.Parse(ID) + "'";
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
            comboBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";


            Display_Data();
        }
        private void Display_Data()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * From GroupStudent  ";

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
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "")
       

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
                string congo = comboBox1.SelectedItem.ToString();

                string genderValue = "select Id FROM Lookup WHERE Category = 'Status' AND value ='" + congo + "'";
                SqlCommand genderInt = new SqlCommand(genderValue, conn);
                int value = 0;
                SqlDataReader reader = genderInt.ExecuteReader();
                // genderInt.ExecuteNonQuery();
                while (reader.Read())
                {
                    value = int.Parse(reader[0].ToString());
                }

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = string.Format("INSERT INTO GroupStudent Values((Select Id From [Group] WHERE Id ='" + textBox2.Text + "'),(Select Id From [Student] where Id = '" + textBox3.Text + "'), @Status , @AssignmentDate)");
                cmd.Parameters.AddWithValue("@AssignmentDate", textBox1.Text);
                cmd.Parameters.AddWithValue("@Status", value);
                cmd.Parameters.AddWithValue("@GroupId", textBox2.Text);
                cmd.Parameters.AddWithValue("@StudentId", textBox3.Text);
                if (MessageBox.Show("Do You want to Insert it", "Register", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data inserted");
                }
                else
                {
                    MessageBox.Show("Data is not inserted", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            Display_Data();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "")


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
                string genderValue = "select Id FROM Lookup WHERE Category = 'STATUS' AND value ='" + comboBox1.Text.ToString() + "'";
                SqlCommand genderInt = new SqlCommand(genderValue, conn);
                int value = 0;
                SqlDataReader reader = genderInt.ExecuteReader();
                // genderInt.ExecuteNonQuery();
                while (reader.Read())
                {
                    value = int.Parse(reader[0].ToString());
                }
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update GroupStudent set Status = '" + value + "', AssignmentDate = '" + this.textBox1.Text + "'    where GroupId = '" + this.textBox2.Text + "' AND  StudentId = '" + this.textBox3.Text + "' ";
                if (MessageBox.Show("Do You want to Update it", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("DATA IS Updated");
                }
                else
                {
                    MessageBox.Show("Row not Updated", "Update row", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                cmd.ExecuteNonQuery();
            }
            conn.Close();
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";


            Display_Data();
        }

        private void label2_Click(object sender, EventArgs e)
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
