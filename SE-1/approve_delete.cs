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
    public partial class approve_delete : Form
    {
        private static int uid = 0;
        private static int sid = 0;
        public approve_delete(int userid, int socid)
        {
            InitializeComponent();
            uid = userid;
            sid = socid;
        }

        private void approve_delete_Load(object sender, EventArgs e)
        {

            string connectionString = "Data Source=AYESHA\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            string Query = "select request_id, target_event, description, request_status, request_type from EventRequests where request_type = 'delete'";

            SqlCommand cmd = new SqlCommand(Query, sqlConnection);

            var reader = cmd.ExecuteReader();

            DataTable table = new DataTable();

            table.Load(reader);

            dataGridView1.DataSource = table;

            sqlConnection.Close();


        }

        private void button8_Click(object sender, EventArgs e)
        {
            string Status = "Rejected";
            string Request = guna2TextBox1.Text;
            int RequestId = int.Parse(Request);

            string connectionString = "Data Source=AYESHA\\SQLEXPRESS; Initial Catalog=Clubhub;Integrated Security=True";
            //string connectionString = "Data Source=LAPTOP-MR5H7PDD\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True";
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


            approve_delete_Load(sender, e);

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            mentorview mv = new mentorview(uid);
            mv.Visible = true;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string Status = "Approved";
            string Request = guna2TextBox1.Text;
            int RequestId = int.Parse(Request);
            string request_type = "delete";
            // string connectionString = "Data Source=LAPTOP-MR5H7PDD\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True";
            string connectionString = "Data Source=AYESHA\\SQLEXPRESS; Initial Catalog=Clubhub;Integrated Security=True";
            string updateQuery = "UPDATE EventRequests SET request_status = @Status WHERE request_id = @RequestId";
            string selectQuery = "SELECT event_name, description, event_date, location, request_status, society_id, target_event FROM EventRequests WHERE request_id = @RequestId";
            string deleteQuery2 = "DELETE FROM Events WHERE event_name = @target_event";
            //string insertQuery = "INSERT INTO Events (event_name, description, event_date, location, status, society_id) VALUES (@EventName, @Description, @EventDate, @Location, @Status, @SocietyId)";
            string checkQuery = "SELECT COUNT(*) FROM Events WHERE event_name = @EventName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();


                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {

                    command.Parameters.AddWithValue("@Status", Status);
                    command.Parameters.AddWithValue("@RequestId", RequestId);


                    command.ExecuteNonQuery();




                }

                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@RequestId", RequestId);

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            string target_event = reader["target_event"].ToString();


                            reader.Close();

                            using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                            {
                                checkCommand.Parameters.AddWithValue("@EventName", target_event);
                                int count = (int)checkCommand.ExecuteScalar();
                                if (count == 0)
                                {
                                    MessageBox.Show("Event not found.");
                                    return;
                                }
                            }


                            using (SqlCommand updateCommand = new SqlCommand(deleteQuery2, connection))
                            {


                                updateCommand.Parameters.AddWithValue("@target_event", target_event);



                                updateCommand.ExecuteNonQuery();
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

            approve_delete_Load(sender, e);



        }
    }
}
