using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mohsin
{
    public partial class mentorview : Form
    {
        private static int socid;
       private static int userid;
       private static string username;
    private static string society;
        private const string connectionString = "Data Source=AYESHA\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True;";

        public mentorview(int userid)
        {
            InitializeComponent();
            mentorview.userid = userid;
            mentorname.Text =getUserName(userid);
            societyname.Text = getSocietyname(userid);
        }
        private string getSocietyname(int id)
        {
            int societyId = 0;
            string socname = " ";
            
            // Retrieve user's society ID from the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
               
             
                    using (SqlCommand command = new SqlCommand("SELECT society_id FROM Societies WHERE  mentor_id = @userId", connection))
                    {
                        command.Parameters.AddWithValue("@userId", id);
                        societyId = (int)command.ExecuteScalar();
                        socid = societyId;
                    }

                using (SqlCommand command = new SqlCommand("SELECT society_name FROM Societies WHERE society_id = @society_id ", connection))
                {
                    command.Parameters.AddWithValue("@society_id", societyId);
                    socname = (string)command.ExecuteScalar();
                }

            }

            return socname;
        }
        private string getUserName(int id)
        {
            
            string name = " ";

            // Retrieve user's society ID from the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT username FROM Users WHERE  user_id = @userId", connection))
                {
                    command.Parameters.AddWithValue("@userId", id);
                    name = (string)command.ExecuteScalar();
                }

            }

            return name;
        }
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            MentorManageEvents managevents = new MentorManageEvents(mentorview.userid, socid);
            managevents.Show();
            this.Hide();

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(mentorview.userid);
            form3.Show();   
            this.Hide();   

        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            vieweventscs vieweventscs = new vieweventscs(mentorview.userid,socid);
            vieweventscs.Show();    
            this.Hide();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            ManageRequests au = new ManageRequests(userid);
            au.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            AnnouncementsMentors am = new AnnouncementsMentors(userid);
            am.Show();
            this.Hide();
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            upcomingevents ue = new upcomingevents(userid);
            ue.Show();
            this.Hide();
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            ViewFeedback vf = new ViewFeedback(userid,socid );
            vf.Show();
            this.Hide();
        }
    }
}
