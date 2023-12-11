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
    public partial class upipaymentpage : Form
    {
        private chooseseatspage _chooseseatpage;
        private string guestname;
        private int ticketno;
        private string paymenttype;
        private string pricelbl;
        private string seatnolbl;
        private string seattype;
        public upipaymentpage(chooseseatspage chooseseatpage,string guestname,int ticketno,string paymenttype,string pricelbl,string seatnolbl,string seattype)
        {
            InitializeComponent();
            _chooseseatpage = chooseseatpage;
            this.guestname = guestname;
            this.ticketno = ticketno;
            this.paymenttype = paymenttype;
            this.pricelbl = pricelbl;
            this.seatnolbl = seatnolbl;
            this.seattype = seattype;
        }

        private void insertdata()
        {
            DateTime paymentdate = DateTime.Today;
            databaseconnect db = new databaseconnect();
            SqlConnection con = db.GetConnection();
            string query = "INSERT into upipaymentinformation (guestname,ticketno,paymentdate,paymenttype,accountnumber)values('" + guestname + "','" + ticketno + "','" + paymentdate+ "','" + paymenttype + "','" + textBox1.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Payment done", "UPI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 10)
            {
                insertdata();
                _chooseseatpage.enablegetticketbutton();
                _chooseseatpage.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Enter Valid Mobile No", "UPI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void upipaymentpage_Load(object sender, EventArgs e)
        {
            int price = Convert.ToInt16(pricelbl.ToString());
            int seat = Convert.ToInt16(seatnolbl.ToString());
            
            if(seattype == "balcony")
            {
                int amnt = 3 * price * seat;
                amountlbl.Text = amnt.ToString();
            }
            if (seattype == "middle")
            {
                int amnt = 2 * price * seat;
                amountlbl.Text = amnt.ToString();
            }
            if (seattype == "lower")
            {
                int amnt =  price * seat;
                amountlbl.Text = amnt.ToString();
            }


        }
    }
}
