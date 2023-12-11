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
    public partial class form2 : Form
    {
        public form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            passwordtxt.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            databaseconnect db = new databaseconnect();
            try
            {
                 SqlConnection con=db.GetConnection();
                 con.Open();
                string query = "SELECT * FROM userlogin where username='" + usernametxt.Text + "' AND password='" + passwordtxt.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    userhomepage u1 = new userhomepage();
                    this.Hide();
                    u1.Show();


                }
                else
                {
                    con.Close();
                    reader.Close();
                    MessageBox.Show("invalid details","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newuserpage n1 = new newuserpage();
            this.Hide();
            n1.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            adminlogin a1 = new adminlogin();
            this.Hide();
            a1.Show();
        }
    }
}
