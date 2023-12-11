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
    public partial class bookmovieresult : Form
    {
        private DateTime fromdt;
        private DateTime todt;
        private string paymnettype;
        private string moviname;
        List<DateTime> dateList = new List<DateTime>();
        private string pricelbl;
        private int maximumSeatCount = 92;

        public bookmovieresult(string moviename,string pricelbl)
        {
            InitializeComponent();
            this.moviname = moviename;
            this.pricelbl = pricelbl;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            paymnettype = "UPI";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            paymnettype = "Credit-Card";
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            userhomepage u1 = new userhomepage();
            this.Hide();
            u1.Show();
        }

        private void bookmovieresult_Load(object sender, EventArgs e)
        {
            databaseconnect db = new databaseconnect();
            SqlConnection con = db.GetConnection();
            string query = "SELECT fromdate,todate from moviedetails WHERE moviename='"+moviname+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    fromdt = Convert.ToDateTime(reader["fromdate"].ToString());
                    todt = Convert.ToDateTime(reader["todate"].ToString());
                }
                reader.Close();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            populatedates();
        }

        private void populatedates()
        {
            DateTime currentDate = fromdt;
            while (currentDate <= todt)
            {
                dateList.Add(currentDate);
                currentDate = currentDate.AddDays(1); // Increment currentDate by 1 day
            }

            // Now you can populate the ComboBox with the dateList
            foreach (DateTime date in dateList)
            {
                dtcombobox.Items.Add(date.ToString("dd-MM-yyyy"));
            }
        }

        private void insertdata()
        {
            int randticketno()
            {
                int _min = 1000;
                int _max = 9999;
                Random _rdm = new Random();
                return _rdm.Next(_min, _max);
            }

            int ticketno = randticketno();

            databaseconnect db = new databaseconnect();
            SqlConnection con = db.GetConnection();

            // Check if all seats are booked for the given movie and show date
            string checkSeatsQuery = "SELECT COUNT(*) FROM seatsinformation WHERE moviename = @moviename AND showdate = @showdate";
            SqlCommand checkSeatsCmd = new SqlCommand(checkSeatsQuery, con);
            checkSeatsCmd.Parameters.AddWithValue("@moviename", moviname);
            checkSeatsCmd.Parameters.AddWithValue("@showdate", dtcombobox.Text.ToString());

            // Execute the count query
            int bookedSeatsCount = 0;
            try
            {
                con.Open();
                bookedSeatsCount = Convert.ToInt32(checkSeatsCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            // Check if all seats are booked
            if (bookedSeatsCount >= maximumSeatCount) // Replace maximumSeatCount with the total number of seats for the venue
            {
                MessageBox.Show("All seats for the selected movie and show date are booked.", "No Available Seats", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Seats are available, proceed with insertion
                string insertQuery = "INSERT INTO guestinformation (moviename, guestname, tickets, ticketno, seattype, paymenttype, date) VALUES (@moviename, @guestname, @tickets, @ticketno, @seattype, @paymenttype, @date)";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@moviename", moviname);
                cmd.Parameters.AddWithValue("@guestname", guestnmtxt.Text);
                cmd.Parameters.AddWithValue("@tickets", ticketstxt.Text);
                cmd.Parameters.AddWithValue("@ticketno", ticketno);
                cmd.Parameters.AddWithValue("@seattype", seattypestxt.Text);
                cmd.Parameters.AddWithValue("@paymenttype", paymnettype);
                cmd.Parameters.AddWithValue("@date", dtcombobox.Text.ToString());

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("This information is printed on your ticket", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chooseseatspage a = new chooseseatspage(ticketno, seattypestxt.Text, ticketstxt.Text, paymnettype, dtcombobox.Text, guestnmtxt.Text, pricelbl, moviname);
                    this.Hide();
                    a.Show();
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


        private void submitbtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(guestnmtxt.Text) )
            {
                
                
                    MessageBox.Show("Enter Your Name....", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {
                insertdata();
            }
                
        }

        private void seattypestxt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
