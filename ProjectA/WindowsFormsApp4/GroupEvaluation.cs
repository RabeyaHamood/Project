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

namespace EE
{
    public partial class GroupEvaluation : Form
    {
        public GroupEvaluation()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source = LAPTOP-085RGBDL\SQLEXPRESS; Initial Catalog = ProjectA;Integrated Security = True; MultipleActiveResultSets = True");

        private void GroupEvaluation_Load(object sender, EventArgs e)
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
            cmd.CommandText = "select * From GroupEvaluation  ";

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
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")

            {
                // display popup box
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK);



            }
            else if (textBox1.Text.StartsWith(".") || textBox2.Text.StartsWith(".") || textBox3.Text.StartsWith(".") || textBox4.Text.StartsWith("."))

            {

                MessageBox.Show("Value can not start with .");
            }
            else if (textBox1.Text.StartsWith(" ") || textBox2.Text.StartsWith(" ") || textBox3.Text.StartsWith(" ") || textBox4.Text.StartsWith(" "))

            {

                MessageBox.Show(" Value can not start with blank space");
            }
            else
            {



                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = string.Format("INSERT INTO GroupEvaluation Values((Select Id From [Group] WHERE Id ='" + textBox3.Text + "'),(Select Id From Evaluation where Id = '" + textBox4.Text + "'), @ObtainedMarks,@EvaluationDate)");
                cmd.Parameters.AddWithValue("@ObtainedMarks", textBox1.Text);
                cmd.Parameters.AddWithValue("@EvaluationDate", textBox2.Text);
                cmd.Parameters.AddWithValue("@GID", textBox3.Text);
                cmd.Parameters.AddWithValue("@EID", textBox4.Text);
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
            textBox4.Text = "";

            


            Display_Data();
            conn.Close();
        }
            




            
         

       /* private int Eval_Id(string Id)
        {
            string query;
            query = "Select Id from Evaluation where Name = '" + Id + "'";
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            int Value = 0;
            while(reader.Read())
            {
                Value = int.Parse(reader[0].ToString());

            }
            textBox1.Text = "";
            textBox2.Text = "";
          
            Display_Data();
            return Value;
         
        } */

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string delete = "DELETE FROM GroupEvaluation WHERE EvaluationId = '" + int.Parse(ID) + "'";
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
            textBox4.Text = "";
            
            Display_Data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")

            {
                // display popup box
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK);



            }
            else if (textBox1.Text.StartsWith(".") || textBox2.Text.StartsWith(".") || textBox3.Text.StartsWith(".") || textBox4.Text.StartsWith("."))

            {

                MessageBox.Show("Value can not start with .");
            }
            else
            {


                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update GroupEvaluation set ObtainedMarks = '" + this.textBox1.Text + "' , EvaluationDate = '" + this.textBox2.Text + "'  where GroupId = '" + this.textBox3.Text + "' AND  EvaluationId = '" + this.textBox4.Text + "' ";
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
            textBox4.Text = "";

            Display_Data();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!IsDigitsOnly(textBox1.Text))
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

    

