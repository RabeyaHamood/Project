using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace jj
{
    public partial class Join : Form
    {
        public Join()
        {
            InitializeComponent();
        }

        private void Join_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            j1.Join1 f1 = new j1.Join1();
            this.Show();
            f1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            j2.Join2 f2 = new j2.Join2();
            this.Show();
            f2.ShowDialog();
        }
    }
}
