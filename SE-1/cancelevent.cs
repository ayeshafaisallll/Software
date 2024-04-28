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
    

    public partial class cancelevent : Form
    {

        private static int president_id;
        public cancelevent(int president_id)
        {
            InitializeComponent();
            // Set the president_id from the constructor parameter
            cancelevent.president_id = president_id;

            label8.Text = "President ID: " + cancelevent.president_id;

        }

        private void cancelevent_Load(object sender, EventArgs e)
        {

        }

        private void Home_Click(object sender, EventArgs e)
        {
            presidentview pv = new presidentview(president_id);
            pv.Visible = true;
            this.Visible = false;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            // Check if any of the textboxes are empty
            if (string.IsNullOrWhiteSpace(target.Text) ||
                string.IsNullOrWhiteSpace(description.Text)
                )
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string target_event = target.Text;
            string event_decsription = description.Text;
            string type = "delete";
            string status = "pending";


         
            //................................


            //string connectionString = "Data Source=LAPTOP-MR5H7PDD\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True";
            //................................

            string insertQuery = "INSERT INTO EventRequests (description,target_event,request_type, request_status) " +
                                 "VALUES (@description, @target_event,@request_type, @request_status)";

            string con = "Data Source=AYESHA\\SQLEXPRESS; Initial Catalog=Clubhub;Integrated Security=True";
            //string con = "Data Source=LAPTOP-MR5H7PDD\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True";
            using (SqlConnection sqlConnection = new SqlConnection(con))
            {

                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(insertQuery, sqlConnection);
                
                cmd.Parameters.AddWithValue("@description", event_decsription);
                cmd.Parameters.AddWithValue("@target_event", target_event);
                cmd.Parameters.AddWithValue("@request_type", type);
                cmd.Parameters.AddWithValue("@request_status", status);
                cmd.ExecuteNonQuery();
            }


            // Display success message
            MessageBox.Show("Request has been sent successfully and you will be informed via email!");

        }
    }
}
