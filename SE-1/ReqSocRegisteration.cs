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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace mohsin
{
    public partial class ReqSocRegistration : Form
    {
        //connection

        //string connectionString = "Data Source=DESKTOP-B2D2JBE\\SQLEXPRESS;Initial Catalog=clubhub;Integrated Security=True";
        private static int userid;

        public ReqSocRegistration(int user_id)
        {
            InitializeComponent();
            userid = user_id;   

        }

        private void submitbutton_Click(object sender, EventArgs e)
        {

        }

       

        private void usernamelabel_Click(object sender, EventArgs e)
        {

        }

        private void usernametextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void socDescriptiontextBox_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void Cancelbutton1_Click_2(object sender, EventArgs e)
        {
            string connectionString = "Data Source=AYESHA\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True;";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                // Create a SqlCommand object for executing SQL queries
                using (SqlCommand cmd = new SqlCommand("SELECT usertype FROM Users WHERE user_id = @userID", sqlConnection))
                {
                    // Add parameters to the SQL query to prevent SQL injection
                    cmd.Parameters.AddWithValue("@userID", userid);
                    Console.WriteLine("Meow :", userid);

                    // Open the database connection
                    sqlConnection.Open();

                    // Execute the query and get the result
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //Check if there is a row returned
                        if (reader.Read())
                        {
                            int userType = Convert.ToInt32(reader["usertype"]);

                            if (userType == 1) // user view
                            {
                                Form2 Form2 = new Form2(userid);
                                Form2.Visible = true;
                                this.Visible = false;
                            }
                            else if (userType == 7)
                            {
                                presidentview pv = new presidentview(userid);
                                pv.Visible = true;
                                this.Visible = false;
                            }
                        }
                        else
                            MessageBox.Show("There seems to be a problem, please restart program");


                    }
                }
            }
        }

        private void submitbutton_Click_1(object sender, EventArgs e)
        {
            string RequestedBy = usernametextBox.Text;
            string Soc_Name = societynametextBox.Text;
            string Soc_Type = societytypetextBox.Text;
            string Soc_Description = socDescriptiontextBox.Text;

            string insertQuery = "INSERT INTO Request_Society_Reg (RequestedBy, Soc_Name, Soc_Type, Soc_Description) " +
                                    "VALUES (@RequestedBy, @Soc_Name, @Soc_Type, @Soc_Description)";

            string con = "Data Source=AYESHA\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True";
            //string con = "Data Source=DESKTOP-B2D2JBE\\SQLEXPRESS;Initial Catalog=clubhub;Integrated Security=True";
            using (SqlConnection sqlConnection = new SqlConnection(con))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(insertQuery, sqlConnection);
                cmd.Parameters.AddWithValue("@RequestedBy", RequestedBy);
                cmd.Parameters.AddWithValue("@Soc_Name", Soc_Name);
                cmd.Parameters.AddWithValue("@Soc_Type", Soc_Type);
                cmd.Parameters.AddWithValue("@Soc_Description", Soc_Description);

                cmd.ExecuteNonQuery();
            }

            // Display success message
            MessageBox.Show("Request submitted successfully!");
            Form2 pos = new Form2(userid);
            pos.Show();
            this.Hide();
        }
    }
}
