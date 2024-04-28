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
    public partial class Form3 : Form
    {
        private static int useid = 0;
        public Form3(int userid)
        {
            InitializeComponent();
            useid = userid;
        }


       

    

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Form9 form9 = new Form9();
            //form9.Visible = true;
            //this.Visible = false;
            string connectionString = "Data Source=AYESHA\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True;";
            //Data Source=AYESHA\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True;Encrypt=True;Trust Server Certificate=True
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            string Query = "select society_name, description from Societies";

            SqlCommand cmd = new SqlCommand(Query, sqlConnection);

            var reader = cmd.ExecuteReader();

            DataTable table = new DataTable();

            table.Load(reader);

            dataGridView1.DataSource = table;

            sqlConnection.Close();

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Data Source=AYESHA\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            // Fetch the usertype for the given userid
            string Query = "SELECT usertype FROM Users WHERE user_id = @userid";
            SqlCommand cmd = new SqlCommand(Query, sqlConnection);
            cmd.Parameters.AddWithValue("@userid", useid);

            int usertype = Convert.ToInt32(cmd.ExecuteScalar()); 

            sqlConnection.Close();

            // Redirect based on usertype
            if (usertype == 7)
            {
                presidentview presidentView = new presidentview(useid);
                presidentView.Show();
                this.Hide();
            }
            else if (usertype == 16)
            {
                // Redirect to MentorView page
                mentorview mentorView = new mentorview(useid);
                mentorView.Show();
                this.Hide();
            }
            else if (usertype == 1)
            {
                Form2 form2 = new Form2(useid);
                form2.Show();
                this.Hide();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //Production socity
            Form6 form6 = new Form6(useid);
            form6.Visible = true;
            this.Visible = false;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            //Takhleeq socity
            Form8 form8 = new Form8(useid);
            form8.Visible = true;
            this.Visible = false;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            // computing socity
            Form4 form4 = new Form4(useid);
            form4.Visible = true;
            this.Visible = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            //Adventure Socity
            Form5 form5 = new Form5(useid);
            form5.Visible = true;
            this.Visible = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Quran socity
            Form7 form7 = new Form7(useid);
            form7.Visible = true;
            this.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // film socity
            Form9 form9 = new Form9(useid);
            form9.Visible = true;
            this.Visible = false;
        }
    }
}
