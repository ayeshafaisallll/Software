using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mohsin
{
    public partial class Form9 : Form
    {
        private static int uid = 0;
        public Form9(int userid)
        {
            InitializeComponent();
            uid= userid;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(uid);
            form3.Visible = true;
            this.Visible = false;
        }
    }
}
