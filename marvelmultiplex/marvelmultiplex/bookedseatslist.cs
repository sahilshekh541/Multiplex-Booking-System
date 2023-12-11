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
    public partial class bookedseatslist : Form
    {
        private DateTime fromdt;
        private DateTime todt;
        List<DateTime> dateList = new List<DateTime>();
        public bookedseatslist()
        {
            InitializeComponent();
        }

        private void populatedates(string mvname)
        {
            comboBox2.Items.Clear();
            dateList.Clear();
            databaseconnect db = new databaseconnect();
            SqlConnection con = db.GetConnection();
            string query = "SELECT fromdate,todate from moviedetails WHERE moviename='" +mvname+ "'";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
               
                SqlDataReader reader = cmd.ExecuteReader();
                comboBox2.Items.Clear();
                if (reader.Read())
                {
                    fromdt = Convert.ToDateTime(reader["fromdate"].ToString());
                    todt = Convert.ToDateTime(reader["todate"].ToString());
                }
                DateTime currentDate = fromdt;

                while (currentDate <= todt)
                {
                    dateList.Add(currentDate);
                    currentDate = currentDate.AddDays(1); // Increment currentDate by 1 day
                }

                // Now you can populate the ComboBox with the dateList
                foreach (DateTime date in dateList)
                {
                    comboBox2.Items.Add(date.ToString("dd-MM-yyyy"));
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
           
           
        }
       

        private void FillDataGridView()
        {
            databaseconnect db = new databaseconnect();

            string query = "SELECT * FROM seatsinformation WHERE moviename='" + comboBox1.SelectedItem.ToString() + "' AND showdate='" + comboBox2.SelectedItem.ToString() + "'";

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

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No Body Book Seat for the selected movie and date.","NO BOOK",MessageBoxButtons.OK
                                ,MessageBoxIcon.Information);
                            comboBox1.SelectedIndex = 0;
                            
                        }
                    }
                }
            }
        }
        
        private void bookedseatslist_Load(object sender, EventArgs e)
        {

            comboBox1.SelectedIndex = 0;
           
            databaseconnect db = new databaseconnect();
            SqlConnection con = db.GetConnection();
            string query = "SELECT moviename from moviedetails";
            SqlCommand cmd = new SqlCommand(query,con);
            try
            {
                con.Open();
                
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    string movienmlists = reader["moviename"].ToString();
                    comboBox1.Items.Add(movienmlists);
                }
                reader.Close();
                con.Close();
              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex > 0)
            {
                populatedates(comboBox1.SelectedItem.ToString());
            }
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            adminhomepage a = new adminhomepage();
            this.Hide();
            a.Show();
                
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                FillDataGridView();
            
           
        }

      
    }
}
