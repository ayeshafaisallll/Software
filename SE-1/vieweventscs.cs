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
    public partial class vieweventscs : Form
    {
        private static int uid = 0;
        private static int sid = 0;
        public vieweventscs(int userid, int socid)
        {
            InitializeComponent();
            uid = userid;   
            sid = socid;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void vieweventscs_Load(object sender, EventArgs e)
        {

            //string connectionString = "Data Source=LAPTOP-MR5H7PDD\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True";
            string connectionString = "Data Source=AYESHA\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            string Query = "select * from Events";

            SqlCommand cmd = new SqlCommand(Query, sqlConnection);

            var reader = cmd.ExecuteReader();

            DataTable table = new DataTable();

            table.Load(reader);

            dataGridView1.DataSource = table;

            sqlConnection.Close();

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=AYESHA\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True;";
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

     
        }
    }
}
