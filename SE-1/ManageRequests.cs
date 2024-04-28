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
    public partial class ManageRequests : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dataTable;
        private static int uid = 0;

        //  private string con = "Data Source=DESKTOP-B2D2JBE\\SQLEXPRESS;Initial Catalog=clubhub;Integrated Security=True;";
        string con = "Data Source=AYESHA\\SQLEXPRESS;Initial Catalog=Clubhub;Integrated Security=True";

        public ManageRequests(int userid)
        {
            InitializeComponent();
            uid = userid;
            InitializeDataGridView();

            LoadData();
        }




        private void InitializeDataGridView()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }


        private void LoadData()
        {




            string query = "SELECT * FROM Request_Society_Reg";

            using (connection = new SqlConnection(con))


            {
                adapter = new SqlDataAdapter(query, connection);
                dataTable = new DataTable();

                adapter.Fill(dataTable);


                dataGridView1.DataSource = dataTable;
            }
        }

        private void ApproveRequest(int reqID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    conn.Open();

                    string query = "UPDATE Request_Society_Reg SET ApproveStatus = 'Approved' WHERE ReqID = @ReqID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ReqID", reqID);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Request approved successfully.");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to approve request.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void RejectRequest(int reqID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    conn.Open();
                    string query = "UPDATE Request_Society_Reg SET ApproveStatus = 'Rejected' WHERE ReqID = @ReqID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ReqID", reqID);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Request rejected successfully.");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to reject request.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                int reqID = (int)dataGridView1.Rows[e.RowIndex].Cells["ReqID"].Value;





                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Approve")
                {
                    ApproveRequest(reqID);
                }
                else if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Reject")
                {
                    RejectRequest(reqID);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mentorview mv = new mentorview(uid);
            mv.Show();
            this.Hide();
        }
    }
}


