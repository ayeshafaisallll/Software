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
    public partial class AnnouncementOfficers : Form
    {
        private static int uid = 0;
        private static int utype = 0;
        private static int tid = 0;
        private const string connectionString = "Data Source=AYESHA\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True;";
        public AnnouncementOfficers(int id)
        {
            InitializeComponent();
            uid= id;
            FillAnnouncementsGridView();
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
                            dataGridView1.Rows.Add(announcerName, role, societyname, teamname, announcement, announcementFor);
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

            Form2 f2 = new Form2(uid);
            f2.Show();
            this.Close();
        }
    }
}
