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
    public partial class ticketprint : Form
    {
        public ticketprint()
        {
            InitializeComponent();
        }

        private void searchticketno()
        {
            databaseconnect db = new databaseconnect();
            SqlConnection con = db.GetConnection();
            string query = "select * from seatsinformation where ticketno='"+textBox1.Text+"'";
            SqlCommand cmd = new SqlCommand(query,con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    int tknumber = Convert.ToInt32(reader["ticketno"].ToString());
                    string guestnm = reader["guestname"].ToString();
                    string seatno = reader["seatsno"].ToString();
                    string bkdate = reader["bookdate"].ToString();
                    string showdate = reader["showdate"].ToString();
                    string moviname = reader["moviename"].ToString();

                    ticketprintresult t1 = new ticketprintresult(tknumber,guestnm,seatno,bkdate,showdate,moviname);
                    this.Hide();
                    t1.Show();
                }
                else
                {
                    MessageBox.Show("This Ticket Number Is not Founded !","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            userhomepage u = new userhomepage();
            this.Hide();
            u.Show();
        }

        private void ticketprint_Load(object sender, EventArgs e)
        {

        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            searchticketno();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
