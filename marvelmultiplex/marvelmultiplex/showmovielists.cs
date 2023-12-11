using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace marvelmultiplex
{
    public partial class showmovielists : Form
    {
        public showmovielists()
        {
            InitializeComponent();
        }

       // Import the necessary namespaces

private void FillDataGridView()
    {
            databaseconnect db = new databaseconnect();
           
        string query = "SELECT * FROM moviedetails";

        using (SqlConnection con = db.GetConnection())
        {
            con.Open();

            using (SqlCommand command = new SqlCommand(query, con))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable; // Assign the DataTable as the DataGridView's data source
                }
            }
        }
    }

    private void showmovielists_Load(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            adminhomepage a = new adminhomepage();
            this.Hide();
            a.Show();
        }
    }
}
