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
    public partial class ManageEvents : Form
    {
        private static int president_id;

        public ManageEvents(int president_id)    
        {
            InitializeComponent();

            ManageEvents.president_id = president_id;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            updateevent ce = new updateevent(president_id);
            ce.Visible = true;
            this.Visible = false;
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            cancelevent ce = new cancelevent(president_id);
            ce.Visible = true;
            this.Visible = false;
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            createevent ce = new createevent(president_id);
            ce.Visible = true;
            this.Visible = false;
        }

        private void Home_Click(object sender, EventArgs e)
        {
            presidentview pv = new presidentview(president_id);
            pv.Show();
            pv.Hide();
        }
    }
}
