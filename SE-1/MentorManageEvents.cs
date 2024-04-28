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
    public partial class MentorManageEvents : Form
    {
        private static int uid = 0;
        private static int sid = 0;
        public MentorManageEvents(int id, int sid)
        {
            InitializeComponent();
            uid = id;
            MentorManageEvents.sid=sid;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

            approve_update au = new approve_update(uid,sid);
            au.Visible = true;
            this.Visible = false;
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            approve_create ac = new approve_create(uid,sid);
            ac.Show();
            this.Hide();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            approve_delete au = new approve_delete(uid,sid);
            au.Visible = true;
            this.Visible = false;
        }

        private void Home_Click(object sender, EventArgs e)
        {
            mentorview mv = new mentorview(uid);
            mv.Show();
            this.Hide();
        }
    }
}
