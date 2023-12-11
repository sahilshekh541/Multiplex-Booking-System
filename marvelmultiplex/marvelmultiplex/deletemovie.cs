using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace marvelmultiplex
{
    public partial class deletemovie : Form
    {
        public deletemovie()
        {
            InitializeComponent();
        }

        private void displaydata()
        {
            databaseconnect db = new databaseconnect();
            SqlConnection con = db.GetConnection();
            string query = "SELECT * FROM moviedetails WHERE moviename = @moviename";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@moviename", movienametxt.Text); // Replace with the movie name you want to retrieve
                con.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DateTime retrievedFromDate = DateTime.Parse(reader["fromdate"].ToString());
                        DateTime retrievedToDate = DateTime.Parse(reader["todate"].ToString());

                        string formattedFromDate = retrievedFromDate.ToString("dd-MM-yyyy");
                        string formattedToDate = retrievedToDate.ToString("dd-MM-yyyy");

                        string retrievedShows = reader["shows"].ToString();
                        string retrievedTime = reader["time"].ToString();
                        string retrievedPrice = reader["price"].ToString();
                        string retrievedDiscription = reader["discription"].ToString();

                        textBox1.Text =formattedFromDate;
                        textBox2.Text = formattedToDate;
                        textBox3.Text = retrievedShows;
                        pricetxt.Text = retrievedPrice.ToString();
                        timetxt.Text = retrievedTime;
                        discriptiontxt.Text = retrievedDiscription;
                    }
                    else
                    {

                    }
                }
            }
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

        private void deletemovie_Load(object sender, EventArgs e)
        {
           
        }

        private void Loadbtn_Click(object sender, EventArgs e)
        {
            DisplayImageFromDatabase();
            displaydata();
        }

        private void homebtn_Click(object sender, EventArgs e)
        {
            adminhomepage a1 = new adminhomepage();
            this.Hide();
            a1.Show();

        }

        private void deletemoviedata()
        {
            databaseconnect db = new databaseconnect();
            SqlConnection con = db.GetConnection();
            string query = "Delete from moviedetails where moviename='" + movienametxt.Text + "'";
            string query1 = "Delete from movieimg where moviename='" + movienametxt.Text + "'";
            string mainquery = query + query1;
            SqlCommand cmd = new SqlCommand(mainquery, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("This Movie is Delete Succesfully", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                adminhomepage a = new adminhomepage();
                this.Hide();
                a.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void delbtn_Click(object sender, EventArgs e)
        {
            deletemoviedata();
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

        private void deletebtn_Click(object sender, EventArgs e)
        {
            updatemovie u = new updatemovie();
            this.Hide();
            u.Show();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            addnewmovie a1 = new addnewmovie();
            this.Hide();
            a1.Show();
        }
    }
}
