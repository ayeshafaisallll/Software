using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace mohsin
{
    public partial class AnnouncementsMentors : Form
    {
        private static int uid = 0;
        private static int utype = 0;
        private static int tid = 0;
        private const string connectionString = "Data Source=AYESHA\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True;";
        public AnnouncementsMentors(int id)
        {
            InitializeComponent();
            uid= id;
            int dummy = GetUserSocietyId();
            if(utype == 7 || utype == 16)
            {
                FillAnnouncementsGridViewPresMentor();
            }
            else
                FillAnnouncementsGridView();
        }

        private void FillAnnouncementsGridViewPresMentor()
        {
            // Clear existing columns and rows in the dataGridView1
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            // Add columns to the dataGridView1
            dataGridView1.Columns.Add("AnnouncerName", "Announcer Name");
            dataGridView1.Columns.Add("Role", "Role");
            dataGridView1.Columns.Add("SocietyName", "Society Name");
            dataGridView1.Columns.Add("Announcement", "Announcement");
            dataGridView1.Columns.Add("AnnouncementFor", "Announcement For");

            // Retrieve the user's society ID
            int societyId = GetUserSocietyId();
            string societyname = " ";

            // Check if the user's society ID is valid
            if (societyId == 0)
            {
                MessageBox.Show("Failed to retrieve user's society ID.");
                return;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT society_name FROM Societies WHERE society_id = @society_id ", connection))
                {
                    command.Parameters.AddWithValue("@society_id", societyId);
                    societyname = (string)command.ExecuteScalar();
                }
            }
            // Query the announcements table for announcements related to the user's society
            string query = "SELECT Users.username AS AnnouncerName, Announcements.Role, Announcements.Announcement, Announcements.Annfor " +
                           "FROM Announcements " +
                           "INNER JOIN Users ON Announcements.Announcer = Users.user_id " +
                           "WHERE Announcements.societyid = @societyId";

            // Create a connection to the database and execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Provide the societyId as a parameter to the query
                    command.Parameters.AddWithValue("@societyId", societyId);


                    // Execute the query and read the results
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Iterate through the results and populate the dataGridView1
                        while (reader.Read())
                        {
                            // Retrieve data from the reader
                            string announcerName = reader["AnnouncerName"].ToString();
                            string role = reader["Role"].ToString();
                            string announcement = reader["Announcement"].ToString();
                            string announcementFor = reader["Annfor"].ToString();

                            // Add a new row to the dataGridView1 with the retrieved data
                            dataGridView1.Rows.Add(announcerName, role,societyname, announcement, announcementFor);
                        }
                    }
                }
            }
        }
        private void FillAnnouncementsGridView()
        {
            // Clear existing columns and rows in the dataGridView1
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            // Add columns to the dataGridView1
            dataGridView1.Columns.Add("AnnouncerName", "Announcer Name");
            dataGridView1.Columns.Add("Role", "Role");
            dataGridView1.Columns.Add("SocietyName", "Society Name");
            dataGridView1.Columns.Add("TeamName", "Team Name");
            dataGridView1.Columns.Add("Announcement", "Announcement");
            dataGridView1.Columns.Add("AnnouncementFor", "Announcement For");

            // Retrieve the user's society ID
            int societyId = GetUserSocietyId();
            string societyname = " ";
            string teamname = " ";

            // Check if the user's society ID is valid
            if (societyId == 0)
            {
                MessageBox.Show("Failed to retrieve user's society ID.");
                return;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT society_name FROM Societies WHERE society_id = @society_id ", connection))
                {
                    command.Parameters.AddWithValue("@society_id", societyId);
                    societyname = (string)command.ExecuteScalar();
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT team_name FROM teams WHERE team_id = @team_id ", connection))
                {
                    command.Parameters.AddWithValue("@team_id", tid);
                    teamname = (string)command.ExecuteScalar();
                }
            }
            // Query the announcements table for announcements related to the user's society
            string query = "SELECT Users.username AS AnnouncerName, Announcements.Role, Announcements.Announcement, Announcements.Annfor " +
                           "FROM Announcements " +
                           "INNER JOIN Users ON Announcements.Announcer = Users.user_id " +
                           "WHERE Announcements.societyid = @societyId";

            // Create a connection to the database and execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Provide the societyId as a parameter to the query
                    command.Parameters.AddWithValue("@societyId", societyId);

                    // Execute the query and read the results
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Iterate through the results and populate the dataGridView1
                        while (reader.Read())
                        {
                            // Retrieve data from the reader
                            string announcerName = reader["AnnouncerName"].ToString();
                            string role = reader["Role"].ToString();
                            string announcement = reader["Announcement"].ToString();
                            string announcementFor = reader["Annfor"].ToString();

                            // Add a new row to the dataGridView1 with the retrieved data
                            dataGridView1.Rows.Add(announcerName, role,societyname, teamname, announcement, announcementFor);
                        }
                    }
                }
            }
        }

        private int GetUserSocietyId()
        {
            int societyId = 0;
            int usertype;
            int teamId;

            // Retrieve user's society ID from the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT usertype FROM Users WHERE user_id = @userId", connection))
                {
                    command.Parameters.AddWithValue("@userId", uid);
                    usertype = (int)command.ExecuteScalar();
                }


                if (usertype == 7)
                {
                    // If the user is president or mentor, leave team ID blank
                    // Retrieve society ID
                    utype = usertype;
                    teamId = 0;
                    using (SqlCommand command = new SqlCommand("SELECT society_id FROM Societies WHERE president_id = @userId ", connection))
                    {
                        command.Parameters.AddWithValue("@userId", uid);
                        societyId = (int)command.ExecuteScalar();
                    }
                }
                else if (usertype == 16)
                { 
                    teamId = 0;
                    utype = usertype;
                    using (SqlCommand command = new SqlCommand("SELECT society_id FROM Societies WHERE  mentor_id = @userId", connection))
                    {
                        command.Parameters.AddWithValue("@userId", uid);
                        societyId = (int)command.ExecuteScalar();
                    }
                }
                else
                {
                    utype = usertype;
                    
                    // Retrieve user's team ID
                    using (SqlCommand command = new SqlCommand("SELECT team_id FROM Team_Members WHERE user_id = @userId", connection))
                    {
                        command.Parameters.AddWithValue("@userId", uid);
                        teamId = (int)command.ExecuteScalar();
                        tid = teamId;
                    }

                    // Retrieve user's society ID based on the team ID
                    using (SqlCommand command = new SqlCommand("SELECT society_id FROM Teams WHERE team_id = @teamId", connection))
                    {
                        command.Parameters.AddWithValue("@teamId", teamId);
                        societyId = (int)command.ExecuteScalar();
                    }
                   
                }
            }

            return societyId;
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)// announcement
        {

        }

        private void announcementfor_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)  // Submit Announcement
        {
            string announcementText = announcement.Text.Trim();
            string announcementFor = announcementfor.Text.Trim();

            // Retrieve user's role, team ID, and society ID based on user ID (uid)
            int usertype = 0; // Assuming a default role ID
            int societyId = 0; // Assuming a default society ID
            int teamId = 0;
            String role = " ";
            // Assuming a default team ID

            // Retrieve user's role, team ID, and society ID from the database based on the user ID (uid)
            using (SqlConnection connection = new SqlConnection("Data Source=AYESHA\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True;"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT usertype FROM Users WHERE user_id = @userId", connection))
                {
                    command.Parameters.AddWithValue("@userId", uid);
                    usertype = (int)command.ExecuteScalar();
                }


                if (usertype == 7)
                {
                    // If the user is president or mentor, leave team ID blank
                    // Retrieve society ID
                    role = "president";
                    teamId = 0;
                    using (SqlCommand command = new SqlCommand("SELECT society_id FROM Societies WHERE president_id = @userId ", connection))
                    {
                        command.Parameters.AddWithValue("@userId", uid);
                        societyId = (int)command.ExecuteScalar();
                    }
                }
                else if (usertype == 16)
                {
                    role = "Mentor";
                    teamId = 0;
                    using (SqlCommand command = new SqlCommand("SELECT society_id FROM Societies WHERE  mentor_id = @userId", connection))
                    {
                        command.Parameters.AddWithValue("@userId", uid);
                        societyId = (int)command.ExecuteScalar();
                    }
                }
                else
                {
                    // Retrieve user's team ID
                    using (SqlCommand command = new SqlCommand("SELECT team_id FROM Team_Members WHERE user_id = @userId", connection))
                    {
                        command.Parameters.AddWithValue("@userId", uid);
                        teamId = (int)command.ExecuteScalar();
                    }

                    // Retrieve user's society ID based on the team ID
                    using (SqlCommand command = new SqlCommand("SELECT society_id FROM Teams WHERE team_id = @teamId", connection))
                    {
                        command.Parameters.AddWithValue("@teamId", teamId);
                        societyId = (int)command.ExecuteScalar();
                    }
                    // Retrieve user's Role based on Society ID and Team ID
                    using (SqlCommand command = new SqlCommand("SELECT role FROM Team_members WHERE team_id = @teamId AND user_id=@userId", connection))
                    {
                        command.Parameters.AddWithValue("@teamId", teamId);
                        command.Parameters.AddWithValue("@user_id", uid);
                        role = (string)command.ExecuteScalar();
                    }
                }
            }

            // Insert the announcement into the database
            using (SqlConnection connection = new SqlConnection("Data Source=AYESHA\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True;"))
            {
                if(usertype ==7 || usertype ==16)
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("INSERT INTO announcements (Announcer, societyid,role, Announcement, Annfor)VALUES (@announcer, @societyId,@role, @announcement, @announcementFor)", connection))
                    {
                        command.Parameters.AddWithValue("@announcer", uid);
                        command.Parameters.AddWithValue("@societyId", societyId);
                       // command.Parameters.AddWithValue("@teamId", teamId);
                        command.Parameters.AddWithValue("@role", role);
                        command.Parameters.AddWithValue("@announcement", announcementText);
                        command.Parameters.AddWithValue("@announcementFor", announcementFor);
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("INSERT INTO announcements (Announcer, societyid, teamid,role, Announcement, Annfor) VALUES (@announcer, @societyId, @teamId,@role, @announcement, @announcementFor)", connection))
                    {
                        command.Parameters.AddWithValue("@announcer", uid);
                        command.Parameters.AddWithValue("@societyId", societyId);
                        command.Parameters.AddWithValue("@teamId", teamId);
                        command.Parameters.AddWithValue("@role", role);
                        command.Parameters.AddWithValue("@announcement", announcementText);
                        command.Parameters.AddWithValue("@announcementFor", announcementFor);
                        command.ExecuteNonQuery();
                    }
                }
                
            }

            MessageBox.Show("Announcement submitted successfully!");
            if (utype == 7 || utype == 16)
            {
                FillAnnouncementsGridViewPresMentor();
            }
            else
                FillAnnouncementsGridView();

        }  


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)  //back home
        {
            if(utype ==7 || utype == 16)
            {
                mentorview mv = new mentorview(uid);
                mv.Show();
                this.Hide();
            }
            else
            {
                Form2 mv = new Form2(uid);
                mv.Show();
                this.Hide();
            }
            
        }

    }
}
