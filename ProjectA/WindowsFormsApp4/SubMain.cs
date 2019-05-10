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

namespace Submain
{
    public partial class SubMain : Form
    {
        public SubMain()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source = LAPTOP-085RGBDL\SQLEXPRESS; Initial Catalog = ProjectA;Integrated Security = True; MultipleActiveResultSets = True");

        private void SubMain_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EE.GroupEvaluation f7 = new EE.GroupEvaluation();
            this.Show();
            f7.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ss.GroupStudent f8 = new ss.GroupStudent();
            this.Show();
            f8.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pp.projectAdvisor f9 = new pp.projectAdvisor();
            this.Show();
            f9.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            group.GroupProject f10 = new group.GroupProject();
            this.Show();
            f10.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            grp.Group f11 = new grp.Group();
            this.Show();
            f11.ShowDialog();
        }
    }
}
