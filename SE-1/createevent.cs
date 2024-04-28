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
    public partial class createevent : Form
    {

        private static int president_id;
        
        public createevent(int president_id)
        {
            InitializeComponent();

            // Set the president_id from the constructor parameter
            createevent.president_id = president_id;

            label8.Text = "President ID: " + createevent.president_id;

        }

        private void createevent_Load(object sender, EventArgs e)
        {

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            // Check if any of the textboxes are empty
            if (string.IsNullOrWhiteSpace(name.Text) ||
                string.IsNullOrWhiteSpace(description.Text) ||
                string.IsNullOrWhiteSpace(date.Text) ||
                string.IsNullOrWhiteSpace(location.Text)
                )
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string event_name = name.Text;
            string event_decsription = description.Text;
            string event_date = date.Text;
            string event_location = location.Text;
            string type = "register";
            string status = "pending";

            //................................


            // string connectionString = "Data Source=LAPTOP-MR5H7PDD\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True";
            string connectionString = "Data Source=AYESHA\\SQLEXPRESS; Initial Catalog=Clubhub;Integrated Security=True";



            string query = @"SELECT s.society_id FROM Societies s JOIN Users u ON s.president_id = u.user_id WHERE u.user_id = @user_id";

            int society_id = -1; 

             
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    
                    connection.Open();

                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@user_id", president_id);

                        
                        object result = command.ExecuteScalar();
                        society_id = Convert.ToInt32(result);
                        
                        //if (result != null)
                        //{
                        //    // Parsing the result to int (society ID)
                        //    label11.Text = "Null";

                        //}
                    }
                }
          

            //................................

            string insertQuery = "INSERT INTO EventRequests (event_name,description, event_date,location,request_type,request_status,requested_by,society_id) " +
                                 "VALUES (@event_name, @description, @event_date, @event_location, @type, @status,@requested_by,@society_id)";

            string con = "Data Source=AYESHA\\SQLEXPRESS; Initial Catalog=Clubhub;Integrated Security=True";
            //string con = "Data Source=LAPTOP-MR5H7PDD\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True";
            using (SqlConnection sqlConnection = new SqlConnection(con))
            {

                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(insertQuery, sqlConnection);
                cmd.Parameters.AddWithValue("@event_name", event_name);
                cmd.Parameters.AddWithValue("@description", event_decsription);
                cmd.Parameters.AddWithValue("@event_date", event_date);
                cmd.Parameters.AddWithValue("@event_location", event_location);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@requested_by", president_id);
                cmd.Parameters.AddWithValue("@society_id", society_id); 

                cmd.ExecuteNonQuery();
            }


            // Display success message
            MessageBox.Show("Request has been sent successfully and you will be informed via email!");


        }

        private void Home_Click(object sender, EventArgs e)
        {

            presidentview pv = new presidentview(president_id);
            pv.Visible = true;
            this.Visible = false;
        }
    }
}
