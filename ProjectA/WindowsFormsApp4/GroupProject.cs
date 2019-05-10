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

namespace group


{
    public partial class GroupProject : Form
    {
        public GroupProject()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source = LAPTOP-085RGBDL\SQLEXPRESS; Initial Catalog = ProjectA;Integrated Security = True; MultipleActiveResultSets = True");

        private void GroupProject_Load(object sender, EventArgs e)
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
            cmd.CommandText = "select * From GroupProject  ";

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
            /* if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string grpId = comboBox1.Text.ToString();
            int groupId = int.Parse(grpId);

            string evalua = comboBox2.Text.ToString();
            int eId = Eval_Id(evalua);
            int value = 0;

            string genderValue = "select Id FROM Evaluation WHERE value ='" + comboBox2.Text + "'";
            SqlCommand cmd2 = conn.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            SqlCommand genderInt = new SqlCommand(genderValue);

            SqlDataReader reader = genderInt.ExecuteReader();
            // genderInt.ExecuteNonQuery();
            while (reader.Read())
            {
                value = int.Parse(reader[0].ToString());
            }
            string query = "insert into GroupEvaluation(GroupId ,EvaluationId ,ObtainedMarks , EvaluationDate) values('" + groupId + "' , '" + eId + "' , '" + textBox1.Text + "' , '" + textBox2.Text + "')";
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            int cmd1 = cmd.ExecuteNonQuery();
            */
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
            else if (textBox1.Text.StartsWith(" ") || textBox2.Text.StartsWith(" ") || textBox3.Text.StartsWith(" ") )

            {

                MessageBox.Show(" Value can not start with blank space");
            }
            else
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = string.Format("INSERT INTO GroupProject Values((Select Id From [Project] WHERE Id ='" + textBox2.Text + "'),(Select Id From [Group] where Id = '" + textBox3.Text + "'), @AssignmentDate)");
                cmd.Parameters.AddWithValue("@AssignmentDate", textBox1.Text);

                cmd.Parameters.AddWithValue("@GroupId", textBox3.Text);
                cmd.Parameters.AddWithValue("@ProjectId", textBox2.Text);
                /* SqlCommand scmd = new SqlCommand("insert into [Group] (CreatedOn)values(@CreatedOn); SELECT SCOPE_IDENTITY()", conn);
                 scmd.Parameters.AddWithValue("@CreatedOn", textBox1.Text);

                 int Id = Convert.ToInt32(scmd.ExecuteScalar());

                 SqlCommand scmd2 = new SqlCommand("insert into Evaluation (Name , TotalMarks , TotalWeightage)values(@Name , @TotalMarks , @TotalWeightage); SELECT SCOPE_IDENTITY()", conn);
                 scmd2.Parameters.AddWithValue("@Name", textBox1.Text);
                 scmd2.Parameters.AddWithValue("@TotalMarks", textBox2.Text);
                 scmd2.Parameters.AddWithValue("@TotalWeightage", textBox3.Text);


                 int Id1 = Convert.ToInt32(scmd.ExecuteScalar());

                 SqlCommand scmd1 = new SqlCommand("insert into  GroupEvaluation (GroupId,EvaluationId,ObtainedMarks , EvaluationDate) VALUES(@GroupId,@EvaluationId , @ObtainedMarks,@EvaluationDate)", conn);
                 scmd1.Parameters.AddWithValue("@GroupId", item.Text);
                 scmd1.Parameters.AddWithValue("@qauntity", qauntity.Text);
                 scmd1.Parameters.AddWithValue("@custId", custId);
                 scmd1.ExecuteNonQuery(); */
                //cmd.CommandText = "INSERT into GroupEvaluation(GroupId ,EvaluationId ,  ObtainedMarks, EvaluationDate ) values ('" + int.Parse(ID) + "','" + int.Parse(ID1) + "','" + textBox1.Text + "' , '" +DateTime.Parse( textBox2.Text) + "')  ";
                // cmd.CommandText = "INSERT into GroupEvaluation(GroupId ,EvaluationId ,  ObtainedMarks, EvaluationDate ) values ('" + int.Parse(ID) + "','" + int.Parse(ID1) + "','" + textBox1.Text + "' , '" + DateTime.Parse(textBox2.Text) + "')  ";

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
           

           


            Display_Data();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string delete = "DELETE FROM GroupProject WHERE ProjectId = '" + int.Parse(ID) + "'";
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
            else
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update GroupProject set AssignmentDate = '" + this.textBox1.Text + "'   where GroupId = '" + this.textBox3.Text + "' AND  ProjectId = '" + this.textBox2.Text + "' ";
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
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            

            Display_Data();
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

