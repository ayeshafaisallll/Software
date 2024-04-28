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
    public partial class Positions : Form
    {
        private string selectedSociety;
        private string selectedTeam;
        private static int uid = 0;

        // Constructor modified to accept selectedSociety and selectedTeam as parameters
        public Positions(string selectedSociety, string selectedTeam, int userid)
        {
            InitializeComponent();
            // Store the passed values in the private variables
            this.selectedSociety = selectedSociety;
            this.selectedTeam = selectedTeam;
            uid = userid;


            // Optionally, you can display the selected values in labels or perform other actions
            // For example:
            labelSelectedSociety.Text = "Selected Society: " + selectedSociety;
            labelSelectedTeam.Text = "Selected Team: " + selectedTeam;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

         
        }

        private void labelSelectedSociety_Click(object sender, EventArgs e)
        {

        }

        private void Positions_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string selectedPosition = groupBox1.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked)?.Text;

            if (selectedPosition != null)
            {
                string con = "Data Source=AYESHA\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True";
      

                using (SqlConnection sqlConnection = new SqlConnection(con))
                {
                    sqlConnection.Open();

                    string query = @"SELECT CASE
                                    WHEN EXISTS (
                                        SELECT 1
                                        FROM Team_Members tm
                                        INNER JOIN Positions p ON tm.position_id = p.position_id
                                        INNER JOIN Teams t ON tm.team_id = t.team_id
                                        INNER JOIN Societies s ON t.society_id = s.society_id
                                        WHERE p.position_name = @position_name
                                        AND s.society_name = @society_name
                                        AND t.team_name = @team_name
                                        AND p.position_name <> 'officer' -- Excluding position officer
                                    ) THEN 'Position already taken by a team member.'
                                    ELSE 'Position available for assignment.'
                                END AS position_status;";

                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    cmd.Parameters.AddWithValue("@position_name", selectedPosition);
                    cmd.Parameters.AddWithValue("@society_name", selectedSociety);
                    cmd.Parameters.AddWithValue("@team_name", selectedTeam);

                    string positionStatus = (string)cmd.ExecuteScalar();

                    if (positionStatus == "Position available for assignment.")
                    {
                        // Position is available, proceed to the application form
                        ApplicationForm applicationForm = new ApplicationForm(selectedSociety, selectedTeam, selectedPosition,uid);
                        applicationForm.Show();
                        this.Hide();


                    }
                    else
                    {
                        MessageBox.Show("The selected position is already taken by a team member (except for the position officer).", "Position Not Available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a position.", "No Position Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

/*            TeamsAndSocieties ts = new TeamsAndSocieties();
            ts.Visible = true;
            this.Visible = false; */
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
          Form2 frm2= new Form2(uid);
         frm2.Visible = true; 
            this.Visible = false;
        }

        private void button2_Click_2(object sender, EventArgs e)
        {

        }
    }
}
