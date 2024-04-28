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
    public partial class TeamsAndSocieties : Form
    {
        private static int uid = 0;
        public TeamsAndSocieties(int userid)
        {
            InitializeComponent();
            uid = userid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void TeamsAndSocieties_Load(object sender, EventArgs e)
        {

        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 pos = new Form2(uid);
            pos.Show();
            this.Hide();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Get selected answers from the radio buttons in group box 1
            string selectedSociety = groupBox1.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked)?.Text;

            // Get selected answers from the radio buttons in group box 2
            string selectedTeam = groupBox2.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked)?.Text;

            // Pass the selected answers to the Positions form
            Positions pos = new Positions(selectedSociety, selectedTeam,uid);
            pos.Show();
            this.Hide();
        }
    }
}
