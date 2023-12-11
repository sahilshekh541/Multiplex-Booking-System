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
    public partial class cancelticketresult : Form
    {
        private int tknumber;
        private string guestnm;
        private string seatno;
        private string bkdate;
        private string showdate;
        private string moviename;

        public cancelticketresult(int tknumber, string guestnm, string seatno, string bkdate, string showdate, string moviename)
        {
            this.tknumber = tknumber;
            this.guestnm = guestnm;
            this.seatno = seatno;
            this.bkdate = bkdate;
            this.showdate = showdate;
            this.moviename = moviename;
            InitializeComponent();
        }

        private void cancelticketresult_Load(object sender, EventArgs e)
        {
            movienmlbl.Text = moviename;
            guestnamelbl.Text = guestnm;
            ticketnolbl.Text = tknumber.ToString();
            showdatelbl.Text = showdate;
            bookdatelbl.Text = bkdate;
            seatnolbl.Text = seatno;
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            databaseconnect db = new databaseconnect();
            SqlConnection con = db.GetConnection();
            string query = "Delete from seatsinformation where ticketno='"+tknumber+"'";
            string query1 = "INSERT into cancelticketinfo(ticketno,guestname,seatsno,bookdate,showdate,moviename)values('" + tknumber + "','" + guestnm + "','" + seatno + "','" + bkdate + "','" + showdate + "','" + moviename + "')";
            string mainquery = query1 + query;
            SqlCommand cmd = new SqlCommand(mainquery,con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Your Ticket Is Cancel Succesfully ","CANCEL",MessageBoxButtons.OK,MessageBoxIcon.Information);
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            userhomepage u1 = new userhomepage();
            this.Hide();
            u1.Show();

        }
    }
}
