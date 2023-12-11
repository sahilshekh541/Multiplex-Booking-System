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

namespace marvelmultiplex
{
    public partial class canteenitemslist : Form
    {
        public canteenitemslist()
        {
            InitializeComponent();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            adminhomepage a = new adminhomepage();
            this.Hide();
            a.Show();

        }


        private void FillDataGridView()
        {
            databaseconnect db = new databaseconnect();

            string query = "SELECT foodname,price FROM canteenitems";

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

        private void delete()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                string foodname = dataGridView1.Rows[selectedIndex].Cells["foodname"].Value.ToString();

                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected item?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    databaseconnect db = new databaseconnect();
                    SqlConnection con = db.GetConnection();

                    try
                    {
                        con.Open();

                        SqlCommand command = new SqlCommand();
                        command.Connection = con;
                        command.CommandText = "DELETE FROM canteenitems WHERE foodname = @foodname";
                        command.Parameters.Add("@foodname", SqlDbType.VarChar).Value = foodname;

                        command.ExecuteNonQuery();

                        dataGridView1.Rows.RemoveAt(selectedIndex); // Remove the row from the DataGridView
                        MessageBox.Show("Item Deleted Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void canteenitemslist_Load(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            delete();
        }
    }
}
