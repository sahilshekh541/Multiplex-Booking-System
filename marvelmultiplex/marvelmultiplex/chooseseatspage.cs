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
    public partial class chooseseatspage : Form
    {
        private List<Button> btnlist;
        private List<Button> lowerseats;
        private List<Button> middleseats;
        private List<Button> balconyseats;
        private int choosencont=0;
        private int ticketno;
        private string seattype;
        private int maxno;
        private string seats;
        private string paymenttype;
        private string showdate;
        private string guestname;
        private string pricelbl;
        private string moviename;

        public chooseseatspage(int ticketno,string seattype,string seats,string paymenttype,string showdate,string guestname,string pricelbl,string moviename)
        {
            InitializeComponent();
            this.ticketno = ticketno;
            this.seattype = seattype;
            this.seats = seats;
            maxno = Convert.ToInt16(seats);
            this.paymenttype = paymenttype;
            this.showdate = showdate;
            this.guestname = guestname;
            this.pricelbl = pricelbl;
            this.moviename = moviename;
            btnlist = new List<Button>
            {
   button1,button2,button3,button4,button5,button6,button7,button8,button9,button10,button11,button12,button13,button14,button15,button16,button17,button18,button19,button20,button21,button22,button23,button24,button25,button26,button27,button28,button29,button30,button31,button32,button33,button34,button35,button36,button37,button38,button39,button40,button41,button42,button43,button44,button45,button46,button47,button48,button49,button50,button51,button52,button53,button54,button55,button56,button57,button58,button59,button60,button61,button62,button63,button64,button65,button66,button67,button68,button69,button70,button71,button72,button73,button74,button75,button76,button77,button78,button79,button80,button81,button82,button83,button84,button85,button86,button87,button88,button89,button90,button91,button92

            };
            lowerseats = new List<Button>
            {
                button1,button2,button3,button4,button5,button6,button7,button8,button9,button10,button11,button12,button13,button14,button15,button16,button17,button18,button19,button20,button21,button22,button23,button24,button25,button26,button27,button28,button29
            };
            middleseats = new List<Button>
            {
                button30,button31,button32,button33,button34,button35,button36,button37,button38,button39,button40,button41,button42,button43,button44,button45,button46,button47,button48,button49,button50,button51,button52,button53,button54,button55,button56,button57,button58,button59,button60,button61
            };
            balconyseats = new List<Button>
            {
                button62,button63,button64,button65,button66,button67,button68,button69,button70,button71,button72,button73,button74,button75,button76,button77,button78,button79,button80,button81,button82,button83,button84,button85,button86,button87,button88,button89,button90,button91,button92
            };
        }


        public chooseseatspage()
        {
            InitializeComponent();
        }
        private void seatcheck()
        {
            string seattp1 = "balcony";
            string seattp2 = "middle";
            string seattp3 = "lower";
            if(seattype== seattp1)
            {
                
                foreach(var btn in lowerseats)
                {
                    btn.Enabled = false;
                    
                }
                foreach(var bt in middleseats)
                {
                    bt.Enabled = false;
                }
                if (choosencont >= maxno)
                {
                    foreach (var btn in btnlist)
                    {
                        btn.Enabled = false;
                    }
                }
                else
                {
                    foreach (var bt in balconyseats)
                    {
                        bt.Enabled = true;
                    }
                }
            }
           
           else if (seattype == seattp2)
            {
                
                
                foreach (var bt in lowerseats)
                {
                    bt.Enabled = false;
                }
                foreach(var eco in balconyseats)
                {
                    eco.Enabled = false;
                }
                if (choosencont >= maxno)
                {
                    foreach (var btn in btnlist)
                    {
                        btn.Enabled = false;
                    }
                }
                else
                {
                    foreach (var bt in middleseats)
                    {
                        bt.Enabled = true;
                    }
                }

            }
            else if (seattype == seattp3)
            {
                
                foreach (var btn in balconyseats)
                {
                    btn.Enabled = false;

                }
                foreach (var bt in middleseats)
                {
                    bt.Enabled = false;
                }
                if (choosencont >= maxno)
                {
                    foreach (var btn in btnlist)
                    {
                        btn.Enabled = false;
                    }
                }
                else
                {
                    foreach (var bt in lowerseats)
                    {
                        bt.Enabled = true;
                    }
                }

            }
            


        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.BackColor == Color.Red)
            {
                button.BackColor = Color.White;
                choosencont--;

                // Remove the button text from the label
                UpdateSelectedSeatsLabel(button.Tag.ToString(), false);
            }
            else if (button.BackColor == Color.Green)
            {
                if (choosencont < maxno)
                {
                    button.BackColor = Color.White;
                    choosencont--;

                    // Remove the button text from the label
                    UpdateSelectedSeatsLabel(button.Tag.ToString(), false);
                }
                else
                {
                    MessageBox.Show("You have already chosen the maximum number of seats.");
                }
            }
            else
            {
                if (choosencont < maxno)
                {
                    button.BackColor = Color.Green;
                    choosencont++;

                    // Add the button text to the label
                    UpdateSelectedSeatsLabel(button.Tag.ToString(), true);
                }
                else
                {
                    MessageBox.Show("You have already chosen the maximum number of seats.");
                }
            }

            // Call the method to update seat availability
            seatcheck();
        }


        private void UpdateSelectedSeatsLabel(string seatText, bool add)
        {
            if (add)
            {
                if (string.IsNullOrEmpty(seatnolbl.Text))
                    seatnolbl.Text = seatText;
                else
                    seatnolbl.Text += ", " + seatText;
            }
            else
            {
                seatnolbl.Text = seatnolbl.Text.Replace(seatText, "").Replace(", ,", ", ").Trim(',', ' ');
            }
        }

        private void seatisBooked()
        {
            databaseconnect db = new databaseconnect();
            SqlConnection con = db.GetConnection();

            string query = "SELECT seatsno FROM seatsinformation WHERE showdate = @showdate AND moviename = @moviename";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@showdate", showdate); // Assuming showdate is a DateTime variable
            cmd.Parameters.AddWithValue("@moviename", moviename);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                List<string> bookedSeatNumbers = new List<string>();

                while (reader.Read())
                {
                    string seatNumberStr = reader["seatsno"].ToString();
                    bookedSeatNumbers.Add(seatNumberStr);
                }

                reader.Close();

                // Trim trailing and leading commas
                string trimmedSeatNumbers = string.Join(",", bookedSeatNumbers).Trim(',');

                // Find the buttons with the corresponding Tag values
                foreach (Button button in btnlist)
                {
                    string buttonTag = button.Tag.ToString();

                    if (trimmedSeatNumbers.Contains(buttonTag))
                    {
                        button.BackColor = System.Drawing.Color.Red;
                        button.Enabled = false;
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


        private void chooseseatspage_Load(object sender, EventArgs e)
        {
            // Example: To set button with tag "1" to red

            paymentbtn.Enabled = false;
            seatisBooked();
            seatcheck();
            ticketnolbl.Text = ticketno.ToString();
            seatlbl.Text = seats.ToString();
            seattypelbl.Text = seattype;

            foreach(var btn in btnlist)
            {
                btn.Click += SeatButton_Click;
            }
          
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public void enablegetticketbutton()
        {
            getticketbtn.Enabled = true;
            paymentbtn.Enabled = false;
        }

        private void button93_Click(object sender, EventArgs e)
        {
            if(paymenttype == "UPI")
            {
               
                upipaymentpage u = new upipaymentpage(this,guestname,ticketno,paymenttype,pricelbl,seatlbl.Text,seattypelbl.Text);
                u.Show();
                
            }
            else
            {
               
                creditcardpaymentpage c = new creditcardpaymentpage(this, guestname, ticketno, paymenttype,pricelbl,seatlbl.Text,seattypelbl.Text);
                c.Show();
            }
        }

        private void conformseatbtn_Click(object sender, EventArgs e)
        {
            DateTime bookdate = DateTime.Today;
            databaseconnect db = new databaseconnect();
            SqlConnection con = db.GetConnection();
            string query = "INSERT into seatsinformation(ticketno,guestname,seatsno,bookdate,showdate,moviename)values('"+ticketno+"','"+guestname+"','"+seatnolbl.Text+"','"+bookdate+"','"+showdate+"','"+moviename+"')";
            SqlCommand cmd = new SqlCommand(query,con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your seat no is conform pay to print your ticket \n click on pay button and pay ","CONFORM SEAT",MessageBoxButtons.OK,MessageBoxIcon.Information);
                conformseatbtn.Enabled = false;
                paymentbtn.Enabled = true;

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getticketbtn_Click(object sender, EventArgs e)
        {
            ticketprint t1 = new ticketprint();
            this.Hide();
            t1.Show();

        }
    }

  


}
