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
    public partial class canteensale : Form
    {
        private Image foodimg;
        private string foodname;
        private string price;
        public canteensale(Image image,string foodname,string price)
        {
            this.foodimg = image;
            this.foodname = foodname;
            this.price = price;
            InitializeComponent();
        }

        private void movienmlbl_Click(object sender, EventArgs e)
        {

        }

        private void storedata()
        {
            DateTime selldate = DateTime.Today;

            databaseconnect db = new databaseconnect();
            SqlConnection con = db.GetConnection();
            string query = "INSERT into canteensale(customername,foodname,price,selldate)values('"+custnmtxt.Text+"','"+foodname+"','"+price+"','"+selldate+"')";
            SqlCommand cmd = new SqlCommand(query,con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Collect your purchase item","information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void buybtn_Click(object sender, EventArgs e)
        {
            storedata();
        }

        private void canteensale_Load(object sender, EventArgs e)
        {
            pricelbl.Text = price;
            foodnmlbl.Text = foodname;
            foodnamelbl.Text = foodname;
            foodimage.Image = foodimg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userhomepage u = new userhomepage();
            this.Hide();
            u.Show();
        }
    }
}
