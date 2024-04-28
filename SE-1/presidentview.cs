using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mohsin
{
    public partial class presidentview : Form
    {

        private static int president_id;
        private static int sid;
        private static string soc_name;
        private static string connectionString = "Data Source=AYESHA\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True;";

        public presidentview(int president_id)
        {
            InitializeComponent();

            presidentview.president_id = president_id;
            pname.Text = getUserName(president_id);
            sname.Text = getSocietyname(president_id);
        }
        private string getSocietyname(int id)
        {
            int societyId = 0;
            string socname = " ";

            // Retrieve user's society ID from the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT society_id FROM Societies WHERE  president_id = @userId", connection))
                {
                    command.Parameters.AddWithValue("@userId", id);
                    societyId = (int)command.ExecuteScalar();
                    sid = societyId;
                }

                using (SqlCommand command = new SqlCommand("SELECT society_name FROM Societies WHERE society_id = @society_id ", connection))
                {
                    command.Parameters.AddWithValue("@society_id", societyId);
                    socname = (string)command.ExecuteScalar();
                }

            }

            return socname;
        }
        private string getUserName(int id)
        {

            string name = " ";

            // Retrieve user's society ID from the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT username FROM Users WHERE  user_id = @userId", connection))
                {
                    command.Parameters.AddWithValue("@userId", id);
                    name = (string)command.ExecuteScalar();
                }

            }

            return name;
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            Form3 ce = new Form3(president_id);
            ce.Show();
            this.Hide();

        }

        private void presidentview_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            ManageEvents ce = new ManageEvents(president_id);
            ce.Show();
            this.Hide();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            ReqSocRegistration ce = new ReqSocRegistration(president_id);
            ce.Show();
            this.Hide();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            vieweventscs ce = new vieweventscs(president_id,sid);
            ce.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            upcomingevents ue = new upcomingevents(president_id);
            ue.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton2_Click_1(object sender, EventArgs e)
        {
            feedback fb = new feedback(president_id);
            fb.Show();
            this.Hide();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            ViewFeedback vf = new ViewFeedback(president_id, sid);
            vf.Show();
            this.Hide();
        }
    }
}
