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
    public partial class feedback : Form
    {
        private static int uid = 0;
        public feedback(int id)
        {
            InitializeComponent();
            uid = id;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void submitbutton_Click(object sender, EventArgs e)
        {
            // Retrieve user input from textboxes
            int userId, eventId;
            string eventReviews = eventreviewstextbox.Text;
            string additionalComments = additionalcommentstextbox.Text;

            if ( !int.TryParse(eventidtextbox.Text, out eventId))
            {
                MessageBox.Show("Please enter valid  event ID.");
                return;
            }

            // Check if the entered event ID exists in the Events table
            bool isEventValid = IsIdValid("Events", "event_id", eventId);
            if (!isEventValid)
            {
                MessageBox.Show("Event ID does not exist. Please enter a valid event ID.");
                return;
            }

            // Insert data into the Feedback table
            InsertFeedback(eventId, eventReviews, additionalComments);

            MessageBox.Show("Feedback submitted successfully.");
        }
        //  private string connectionString = "Data Source=ASIM-SHARIF\\SQLEXPRESS;Initial Catalog=myDB;Integrated Security=True";
        private const string connectionString = "Data Source=AYESHA\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True;";
        private bool IsIdValid(string tableName, string idColumnName, int id)
        {
            string query = $"SELECT COUNT(*) FROM {tableName} WHERE {idColumnName} = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void InsertFeedback(int eventId, string eventReviews, string additionalComments)
        {
            string query = "INSERT INTO Feedback (event_id, user_id, event_reviews, additional_comments) " +
                           "VALUES (@EventId, @UserId, @EventReviews, @AdditionalComments)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventId", eventId);
                    command.Parameters.AddWithValue("@UserId", uid);
                    command.Parameters.AddWithValue("@EventReviews", eventReviews);
                    command.Parameters.AddWithValue("@AdditionalComments", additionalComments);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=AYESHA\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True";
            //string connectionString = "Data Source=LAPTOP-MR5H7PDD\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            // Fetch the usertype for the given userid
            string Query = "SELECT usertype FROM Users WHERE user_id = @userid";
            SqlCommand cmd = new SqlCommand(Query, sqlConnection);
            cmd.Parameters.AddWithValue("@userid", uid);

            int usertype = Convert.ToInt32(cmd.ExecuteScalar());

            sqlConnection.Close();
            if (usertype == 7)
            {
                presidentview presidentView = new presidentview(uid);
                presidentView.Show();
                this.Hide();
            }
            else if (usertype == 16)
            {
                // Redirect to MentorView page
                mentorview mentorView = new mentorview(uid);
                mentorView.Show();
                this.Hide();
            }
            else if (usertype == 1)
            {
                Form2 f2 = new Form2(uid);
                f2.Show();
                this.Hide();
            }
        }
    }
}
