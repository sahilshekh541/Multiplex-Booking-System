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
    public partial class adminlogin : Form
    {
        public adminlogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form2 f2 = new form2();
            this.Hide();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            databaseconnect db = new databaseconnect();
            try
            {
                SqlConnection con = db.GetConnection();
                con.Open();
                string query = "SELECT * FROM admin_login where adminuname='" + usernametxt.Text + "' AND adminpass='" + passwordtxt.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    adminhomepage a1 = new adminhomepage();
                    this.Hide();
                    a1.Show();
                }
                else
                {
                    con.Close();
                    reader.Close();
                    MessageBox.Show("invalid details","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void passwordtxt_TextChanged(object sender, EventArgs e)
        {
            passwordtxt.PasswordChar = '*';
        }
    }
}
