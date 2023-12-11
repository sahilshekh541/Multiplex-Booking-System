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
using System.IO;


namespace marvelmultiplex
{
    public partial class updatemovie : Form
    {
        private string movienm;
        public updatemovie()
        {
            InitializeComponent();
        }

        private void homebtn_Click(object sender, EventArgs e)
        {
            adminhomepage a1 = new adminhomepage();
            this.Hide();
            a1.Show();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            addnewmovie a1 = new addnewmovie();
            this.Hide();
            a1.Show();
        }



        private void DisplayImageFromDatabase()
        {
            databaseconnect db = new databaseconnect();
            SqlConnection con = db.GetConnection();

            try
            {
                con.Open();
                string query = "SELECT movieimg FROM movieimg WHERE moviename = @moviename";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@moviename", movienametxt.Text); // Replace with the movie name you want to retrieve
                    movienm = movienametxt.Text;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] imageData = (byte[])reader["movieimg"];
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                Image image = Image.FromStream(ms);
                                movieimg.Image = image;
                            }
                            dateTimePicker1.Enabled = true;
                            dateTimePicker2.Enabled = true;
                            comboBox1.Enabled = true;
                            timetxt.Enabled = true;
                            pricetxt.Enabled = true;
                            discriptiontxt.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show(" Not-found the given movie name.");
                        }
                    }
                }
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
            private void Loadbtn_Click(object sender, EventArgs e)
            {
               DisplayImageFromDatabase();
            }

        private void movieimg_Click(object sender, EventArgs e)
        {

        }

        private void updatemovie_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            comboBox1.Enabled = false;
            timetxt.Enabled = false;
            pricetxt.Enabled = false;
            discriptiontxt.Enabled = false;

        }

        private void selectimgbtn_Click(object sender, EventArgs e)
        {
          
        }

        private void updatedetails()
        {
            databaseconnect db = new databaseconnect();
            using (SqlConnection con = db.GetConnection())
            {
                con.Open();

                
                

                // Update the existing record in moviedetails
                string updateQuery = "UPDATE moviedetails SET fromdate = @fromdate, todate = @todate, shows = @shows, time = @time, price = @price, discription = @discription WHERE moviename = @moviename";
                using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                {
                    updateCmd.Parameters.AddWithValue("@fromdate", dateTimePicker1.Text);
                    updateCmd.Parameters.AddWithValue("@todate", dateTimePicker2.Text);
                    updateCmd.Parameters.AddWithValue("@shows", comboBox1.Text);
                    updateCmd.Parameters.AddWithValue("@time", timetxt.Text);
                    updateCmd.Parameters.AddWithValue("@price", pricetxt.Text);
                    updateCmd.Parameters.AddWithValue("@discription", discriptiontxt.Text);
                    updateCmd.Parameters.AddWithValue("@moviename", movienm);
                    updateCmd.ExecuteNonQuery();

                    // Check if it's the first show of the day
                    string checkShowQuery = "SELECT COUNT(*) FROM moviedetails WHERE shows = @shows AND fromdate = @fromdate AND todate = @todate AND moviename = @moviename";
                    using (SqlCommand checkShowCmd = new SqlCommand(checkShowQuery, con))
                    {
                        checkShowCmd.Parameters.AddWithValue("@shows", comboBox1.Text);
                        checkShowCmd.Parameters.AddWithValue("@fromdate", dateTimePicker1.Text);
                        checkShowCmd.Parameters.AddWithValue("@todate", dateTimePicker2.Text);
                        checkShowCmd.Parameters.AddWithValue("@moviename", movienm);

                        int showCount = (int)checkShowCmd.ExecuteScalar();

                        if (showCount > 0)
                        {
                            MessageBox.Show("Another movie already has the first show scheduled for the same date.", "Show Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("Movie Updated Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                MessageBox.Show("Movie Updated Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            updatedetails();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                timetxt.Text = "02:00 To 04:00";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                timetxt.Text = "04:00 To 06:00";
            }
            if (comboBox1.SelectedIndex == 2)
            {
                timetxt.Text = "06:00 To 08:00";
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            deletemovie d1 = new deletemovie();
            this.Hide();
            d1.Show();
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected item?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                form2 f2 = new form2();
                this.Hide();
                f2.Show();
            }
        }
    }
}
