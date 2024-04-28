
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace mohsin
{
    public partial class Form1 : KryptonForm
    {
        // Define your connection string
        string connectionString = "Data Source=AYESHA\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True";
        //Data Source=AYESHA\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void studentID_TextChanged(object sender, EventArgs e)
        {

        }

        private void password1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void studentID_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void password1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
                // Get the entered username and password
                string username = studentID.Text;
                string password = password1.Text;

                // Create a SqlConnection object
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    // Create a SqlCommand object for executing SQL queries
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE username = @username AND password = @password", sqlConnection))
                    {
                        // Add parameters to the SQL query to prevent SQL injection
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        // Open the database connection
                        sqlConnection.Open();

                        // Execute the query and get the result
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            //Check if there is a row returned
                            if (reader.Read())
                            {
                                int userType = Convert.ToInt32(reader["usertype"]);
                                int userid = Convert.ToInt32(reader["user_id"]);

                                if (userType == 1) // user view
                                {
                                    // Authentication successful
                                    MessageBox.Show("Login successful!");
                                    Form2 Form2 = new Form2(userid);
                                    Form2.Visible = true;
                                    this.Visible = false;
                                }
                                else if (userType == 7)
                                {
                                    // Authentication successful
                                    MessageBox.Show("Login successful!");
                                   
                                    
                                // Pass the selected answers to the Positions form
                                int president_id = Convert.ToInt32(reader["user_id"]);
                               
                                presidentview pv = new presidentview(president_id);
                                pv.Visible = true;
                                this.Visible = false;



                                }
                                else if (userType == 16)
                                {
                                    // Authentication successful
                                    MessageBox.Show("Login successful!");
                                    mentorview mview = new mentorview(userid);
                                    mview.Visible = true;
                                    this.Visible = false;
                                }
                            }
                            else
                            {
                                // Authentication failed
                                MessageBox.Show("Invalid username or password!");
                            }
                        }
                    }
                }

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
