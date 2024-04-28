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
    public partial class ViewFeedback : Form
    {
        private static int uid = 0;
        private static int socid = 0;
        // Connection string for your database
        //string connectionString = "Data Source=ASIM-SHARIF\\SQLEXPRESS;Initial Catalog=myDB;Integrated Security=True";
        private const string connectionString = "Data Source=AYESHA\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True;";
        public ViewFeedback(int id,int societid)
        {
            InitializeComponent();
            this.Load += ViewFeedback_Load;
            uid = id;
            socid = societid;
        }

        private void ViewFeedback_Load(object sender, EventArgs e)
        {
            // Load feedback into the DataGridView when the form loads
            LoadFeedback();
        }
        private void EvaluationsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadFeedback()
        {
            try
            {
                // Create a SqlConnection using the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // SQL query to select all feedback from the Feedback table
                    string query = "SELECT * FROM Feedback";

                    // Create a SqlDataAdapter to execute the query and fill a DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    EvaluationsGrid.DataSource = dataTable;

                    // Close the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
//private void EvaluationsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
//{

//}