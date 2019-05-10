using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Student.Form1 f1 = new Student.Form1();
            this.Show();
            f1.ShowDialog();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegNo.Form2 f2 = new RegNo.Form2();
            this.Show();
            f2.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            project.Form3 f3 = new project.Form3();
            this.Show();
            f3.ShowDialog();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Adv.Form5 f5 = new Adv.Form5();
            this.Show();
            f5.ShowDialog();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Submain.SubMain f6 = new Submain.SubMain();
            this.Show();
            f6.ShowDialog();
            
            
            
            
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            jj.Join f7 = new jj.Join();
            this.Show();
            f7.ShowDialog();
        }
    }
}
