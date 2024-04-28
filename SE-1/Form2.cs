using mohsin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mohsin
{
    public partial class Form2 : Form
    {
        private static int uid = 0;
        private const string connectionString = "Data Source=AYESHA\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True;";
        public Form2(int userid)
        {
            InitializeComponent();
            uid = userid;
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(uid);
            form3.Visible = true;
            this.Visible = false;
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            int count;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Team_Members WHERE  user_id = @user_id ", connection))
                {
                    command.Parameters.AddWithValue("@user_id", uid);
                    count = (int)command.ExecuteScalar();
                }
            }

            if(count == 0)
            {
                TeamsAndSocieties teamsAndSocieties = new TeamsAndSocieties(uid);
                teamsAndSocieties.Visible = true;
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("oops!! Already a member of a society, you can't apply for another one :(");
            }
            

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {         
            ReqSocRegistration req = new ReqSocRegistration(uid);
            req.Visible = true;
            this.Visible = false;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            int userType = GetUserType(uid); // Get the user type

            if (userType == 1) 
            {
                // Check if the user's role is officer
                if (IsUserOfficer(uid))
                {
                    // User is an officer, navigate to AnnouncementOfficers form
                    AnnouncementOfficers form1 = new AnnouncementOfficers(uid);
                    form1.Show();
                    this.Hide();
                }
                else if (IsUserother(uid))
                {
                    // User is not an officer, navigate to AnnouncementMentors form
                    AnnouncementsMentors f2 = new AnnouncementsMentors(uid);
                    f2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("You cannot access this functionality, you need to be in a society team to able to view announcements");

                }
            }
            
        }

        private int GetUserType(int userId)
        {
            int userType = 0;

            // Retrieve user's type from the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT usertype FROM Users WHERE user_id = @userId", connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userType = Convert.ToInt32(result);
                    }
                }
            }

            return userType;
        }

        private bool IsUserOfficer(int userId)
        {
            // Check if the user's role is officer
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Team_Members WHERE user_id = @userId AND role = 'Officer'", connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private bool IsUserother(int userId)
        {
            // Check if the user's role is officer
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Team_Members WHERE role in ('Head','Vice Head','Secretary','Deputy Secretary') AND role !='Officer' AND  user_id = @user_id ", connection))
                {
                    command.Parameters.AddWithValue("@user_id", userId);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            upcomingevents ue = new upcomingevents(uid);
            ue.Show();
            this.Hide();
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            feedback fb = new feedback(uid);
            fb.Show();
            this.Hide();
        }
    }
}
