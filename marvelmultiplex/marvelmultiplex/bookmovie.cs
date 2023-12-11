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
    public partial class bookmovie : Form
    {
        private string moviename;
        private Image movieimage;
        private DateTime todate;
        public bookmovie(string moviename , Image movieimage)
        {
            this.moviename = moviename;
            this.movieimage = movieimage;
            InitializeComponent();

            movienamelbl.Text = moviename;
            movieimg.Image = movieimage;
        }

        private void homebtn_Click(object sender, EventArgs e)
        {
            userhomepage u1 = new userhomepage();
            this.Hide();
            u1.Show();
        }

        private void timelbl_Click(object sender, EventArgs e)
        {

        }

        private void movienmlbl_Click(object sender, EventArgs e)
        {

        }

        private void bookmovie_Load(object sender, EventArgs e)
        {
            databaseconnect db = new databaseconnect();
            SqlConnection con = db.GetConnection();
            string query = "SELECT * from moviedetails WHERE moviename='"+moviename+"'";
            
            SqlCommand cmd = new SqlCommand(query,con);
           
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string movienm = reader["moviename"].ToString();
                    DateTime fromdate = Convert.ToDateTime(reader["fromdate"].ToString());
                    todate = Convert.ToDateTime(reader["todate"].ToString());
                    string shows= reader["shows"].ToString();
                    string time = reader["time"].ToString();
                    double price = Convert.ToDouble(reader["price"].ToString());
                    string discription  = reader["discription"].ToString();


                    movienmlbl.Text = movienm;
                    fromdatelbl.Text = fromdate.ToShortDateString();
                    todatelbl.Text = todate.ToShortDateString();
                    showlbl.Text = shows;
                    timelbl.Text = time;
                    pricelbl.Text = price.ToString() ;
                    discriptionlbl.Text = discription;
                }
                reader.Close();
                con.Close();
                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            userhomepage u1 = new userhomepage();
            this.Hide();
            u1.Show();

        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            DateTime tddate = DateTime.Today;
            
            if(tddate > todate)
            {
                MessageBox.Show("This movie is not available","NOT AVAILABLE",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                userhomepage a = new userhomepage();
                this.Hide();
                a.Show();

            }
            else
            {
                bookmovieresult a = new bookmovieresult(moviename,pricelbl.Text);
                this.Hide();
                a.Show();

            }
        }
    }
}
