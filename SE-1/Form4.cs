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
    
    public partial class Form4 : Form
    {
        private static int userid = 0;
        public Form4(int uid)
        {
            InitializeComponent();
            userid = uid;
        }

        
        private void label1_Click(object sender, EventArgs e)
        {

        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(userid);
            form3.Visible = true;
            this.Visible = false;

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
