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
    public partial class approve_create : Form
    {
        private static int userid = 0;
        private static int sid = 0;
        public approve_create(int uid, int socid)
        {
            InitializeComponent();
            userid = uid;
            sid = socid;
        }

        private void approve_create_Load(object sender, EventArgs e)
        {
            //string connectionString = "Data Source=AYESHA\\SQLEXPRESS; Initial Catalog=Clubhub;Integrated Security=True";
            string connectionString = "Data Source=AYESHA\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            string Query = "select * from EventRequests where request_type = 'register'";

            SqlCommand cmd = new SqlCommand(Query, sqlConnection);
            var reader = cmd.ExecuteReader();

            DataTable table = new DataTable();

            table.Load(reader);

            dataGridView1.DataSource = table;

            sqlConnection.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Status = "Approved";
            string Request = guna2TextBox1.Text;
            int RequestId = int.Parse(Request);
            string request_type = "register";
            //  string connectionString = "Data Source=LAPTOP-MR5H7PDD\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True";
            string connectionString = "Data Source=AYESHA\\SQLEXPRESS; Initial Catalog=Clubhub;Integrated Security=True";
            string updateQuery = "UPDATE EventRequests SET request_status = @Status WHERE request_id = @RequestId";
            string selectQuery = "SELECT event_name, description, event_date, location, request_status, society_id FROM EventRequests WHERE request_id = @RequestId";
            string insertQuery = "INSERT INTO Events (event_name, description, event_date, location, status, society_id, request_id) VALUES (@EventName, @Description, @EventDate, @Location, @Status, @SocietyId, @RequestId)";
            string checkQuery = "SELECT COUNT(*) FROM Events WHERE event_name = @EventName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();


                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {

                    command.Parameters.AddWithValue("@Status", Status);
                    command.Parameters.AddWithValue("@RequestId", RequestId);
                    command.Parameters.AddWithValue("@request_type", request_type);

                    command.ExecuteNonQuery();

                  

                   
                }

                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@RequestId", RequestId);

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string eventName = reader["event_name"].ToString();
                            string description = reader["description"].ToString();
                            DateTime eventDate = Convert.ToDateTime(reader["event_date"]);
                            string location = reader["location"].ToString();
                            string eventStatus = reader["request_status"].ToString();
                            int societyId = Convert.ToInt32(reader["society_id"]);


                            reader.Close();

                            using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                            {
                                checkCommand.Parameters.AddWithValue("@EventName", eventName);
                                int count = (int)checkCommand.ExecuteScalar();
                                if (count > 0)
                                {
                                    MessageBox.Show("Event with the same name already exists.");
                                    return;
                                }
                            }


                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@EventName", eventName);
                                insertCommand.Parameters.AddWithValue("@Description", description);
                                insertCommand.Parameters.AddWithValue("@EventDate", eventDate);
                                insertCommand.Parameters.AddWithValue("@Location", location);
                                insertCommand.Parameters.AddWithValue("@Status", eventStatus);
                                insertCommand.Parameters.AddWithValue("@SocietyId", societyId);
                                insertCommand.Parameters.AddWithValue("@RequestId", RequestId);
                                insertCommand.ExecuteNonQuery();
                            }


                        }
                        else
                        {
                            MessageBox.Show("Event request not found.");
                            return;
                        }
                    }
                }


            }

            approve_create_Load(sender, e);



        }

        private void button8_Click(object sender, EventArgs e)
        {

            string Status = "Rejected";
            string Request = guna2TextBox1.Text;
            int RequestId = int.Parse(Request);

            //string connectionString = "Data Source=LAPTOP-MR5H7PDD\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True";
            string connectionString = "Data Source=AYESHA\\SQLEXPRESS; Initial Catalog=Clubhub;Integrated Security=True";
            string updateQuery = "UPDATE EventRequests SET request_status = @Status WHERE request_id = @RequestId";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();


                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {

                    command.Parameters.AddWithValue("@Status", Status);
                    command.Parameters.AddWithValue("@RequestId", RequestId);


                    command.ExecuteNonQuery();

                    this.Visible = true;


                }
            }


            approve_create_Load(sender, e);


        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            mentorview mv = new mentorview(userid);
            mv.Visible = true;
            this.Visible = false;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
