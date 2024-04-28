using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mohsin
{
    public partial class ApplicationForm : Form
    {
        private string selectedSociety;
        private string selectedTeam;
        private string selectedPosition;
        private static int useid = 0;
        public ApplicationForm(string selectedSociety, string selectedTeam, string selectedPosition, int uid)
        {
            InitializeComponent();

            // Store the passed values in the private variables
            this.selectedSociety = selectedSociety;
            this.selectedTeam = selectedTeam;
            this.selectedPosition = selectedPosition;
            useid = uid;

            //showSociety.Text = "Selected Society: " + selectedSociety;
            //showTeam.Text = "Selected Team: " + selectedTeam;
            //showPos.Text = "Selected Position: " + selectedPosition;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ApplicationForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void rollno_TextChanged(object sender, EventArgs e)
        {

        }

        private void phno_TextChanged(object sender, EventArgs e)
        {

        }

        private void dep_TextChanged(object sender, EventArgs e)
        {

        }

        private void q1_TextChanged(object sender, EventArgs e)
        {

        }

        private void experience_TextChanged(object sender, EventArgs e)
        {

        }

        private void selection_TextChanged(object sender, EventArgs e)
        {

        }


        private void Home_Click(object sender, EventArgs e)
        {

        }

        private void showPos_Click(object sender, EventArgs e)
        {

        }

        private void Submit_Click_1(object sender, EventArgs e)
        {
           

          
        }

        private void ApplicationForm_Load_1(object sender, EventArgs e)
        {

        }

        private void Home_Click_1(object sender, EventArgs e)
        {

        }

        private void name_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Home_Click_2(object sender, EventArgs e)
        {

            Form2 form2 = new Form2(useid);
            form2.Visible = true;
            this.Visible = false;
        }

        private void Submit_Click_2(object sender, EventArgs e)
        {
            // Check if any of the textboxes are empty
            if (string.IsNullOrWhiteSpace(name.Text) ||
                    string.IsNullOrWhiteSpace(rollno.Text) ||
                    string.IsNullOrWhiteSpace(phno.Text) ||
                    string.IsNullOrWhiteSpace(emailAns.Text) ||
                    string.IsNullOrWhiteSpace(dep.Text) ||
                    string.IsNullOrWhiteSpace(q1.Text) ||
                    string.IsNullOrWhiteSpace(experience.Text) ||
                    string.IsNullOrWhiteSpace(selection.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }


            // Validate name (only alphabetical characters)
            if (!Regex.IsMatch(name.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Name should contain only alphabetical characters.");
                return;
            }

            // Validate roll number (only numbers)
            if (!Regex.IsMatch(rollno.Text, @"^\d+$"))
            {
                MessageBox.Show("Roll number should contain only numbers.");
                return;
            }

            // Validate email
            if (!Regex.IsMatch(emailAns.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Invalid email format.");
                return;
            }

            // Validate phone number (only numbers)
            if (!Regex.IsMatch(phno.Text, @"^\d+$"))
            {
                MessageBox.Show("Phone number should contain only numbers.");
                return;
            }

            // Validate department (only alphabetical characters)
            if (!Regex.IsMatch(dep.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Department should contain only alphabetical characters.");
                return;
            }

            string username = name.Text;
            string roll_no = rollno.Text;
            string email = emailAns.Text;
            string phoneNumber = phno.Text;
            string department = dep.Text;
            string experienceText = experience.Text;
            string selectionText = selection.Text;


            string insertQuery = "INSERT INTO Applications (username, user_id,email, experience, selection, position, team , society) " +
                                 "VALUES (@username, @userId, @email, @experience, @selection, @position, @team, @society)";

            string con = "Data Source=AYESHA\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True";
            using (SqlConnection sqlConnection = new SqlConnection(con))
            {

                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(insertQuery, sqlConnection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@userId", int.Parse(rollno.Text));
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@experience", experienceText);
                cmd.Parameters.AddWithValue("@selection", selectionText);
                cmd.Parameters.AddWithValue("@position", this.selectedPosition);
                cmd.Parameters.AddWithValue("@team", this.selectedTeam);
                cmd.Parameters.AddWithValue("@society", this.selectedSociety);

                cmd.ExecuteNonQuery();
            }


            // Display success message
            MessageBox.Show("Application submitted successfully! You will be notified via email");

            Form2 form2 = new Form2(useid);
            form2.Visible = true;
            this.Visible = false;


        }

        private void name_TextChanged_2(object sender, EventArgs e)
        {

        }
    }
}
