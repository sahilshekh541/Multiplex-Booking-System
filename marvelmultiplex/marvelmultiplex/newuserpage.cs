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
    public partial class newuserpage : Form
    {
        public newuserpage()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(firstnametxt.Text) || string.IsNullOrEmpty(lastnametxt.Text) || string.IsNullOrEmpty(mobilenotxt.Text) || string.IsNullOrEmpty(emailaddresstxt.Text) || string.IsNullOrEmpty(usernametxt.Text) || string.IsNullOrEmpty(passwordtxt.Text))
            {
                MessageBox.Show("Enter All fields To create New Account","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            if(mobilenotxt.Text.Length < 10)
            {
                MessageBox.Show("Enter Valid mobile no", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                emailvalidation();
            }
        }
        private bool IsFilled(string s)
        {
            if (s != "")
            { return true; }
            else
            { return false; }
        }


        //regex for emial validation 
        System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");




        private void emailvalidation()
        {
            if (expr.IsMatch(emailaddresstxt.Text))
            {
               

                string result = emailaddresstxt.Text.Split()[0];
                databaseconnect db = new databaseconnect();
                string query = "INSERT into newuser_info (firstname,lastname,mobileno,emailaddress,username,password) values('" + firstnametxt.Text + "','" + lastnametxt.Text + "','" + mobilenotxt.Text + "','" + emailaddresstxt.Text +"','"+usernametxt.Text+"','"+passwordtxt.Text+"')";
                string query1 = "INSERT into userlogin(username,password) values('" + usernametxt.Text + "','" + passwordtxt.Text + "')";
                try
                {
                    SqlConnection con=db.GetConnection();
                    con.Open();
                    string query3="SELECT mobileno FROM newuser_info where mobileno='"+mobilenotxt.Text+"'";
                    SqlCommand cmd = new SqlCommand(query3,con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show("Mobile number is already used","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    else
                    {
                        con.Close();
                        reader.Close();
                        try
                        {
                            db.setdata(query);
                            db.setdata(query1);
                            MessageBox.Show("Your Account is Create A succesfully ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("email is invalid", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form2 f2 = new form2();
            this.Hide();
            f2.Show();
        }
    }
}
