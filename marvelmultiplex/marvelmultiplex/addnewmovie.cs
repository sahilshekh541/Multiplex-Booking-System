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
using System.IO;

namespace marvelmultiplex
{
    public partial class addnewmovie : Form
    {
        public addnewmovie()
        {
            InitializeComponent();
        }

        private void addnewmovie_Load(object sender, EventArgs e)
        {

        }

        private void homebtn_Click(object sender, EventArgs e)
        {
            adminhomepage a1 = new adminhomepage();
            this.Hide();
            a1.Show();
        }

        private void selectimgbtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.png; *.gif; *.bmp)|*.jpg; *.png; *.gif; *.bmp|All Files (*.*)|*.*";
                openFileDialog.InitialDirectory = "C:";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    movieimg.Image = new Bitmap(openFileDialog.FileName);
                }
            }
        }



        private void StoreImageInDatabase(Image image)
        {
            databaseconnect db = new databaseconnect();
            SqlConnection con = db.GetConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            
           
            try
            {
                con.Open();

                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // You can adjust the format
                    byte[] imageData = ms.ToArray();

                    command.CommandText = "INSERT INTO movieimg (moviename, movieimg) VALUES (@moviename, @imageData)";

                    // Define the parameters with explicit types and sizes
                    command.Parameters.Add("@moviename", SqlDbType.VarChar).Value = movienametxt.Text;
                    command.Parameters.Add("@imageData", SqlDbType.VarBinary).Value = imageData;

                    string checkShowQuery = "SELECT COUNT(*) FROM moviedetails WHERE shows = @shows AND fromdate = @fromdate AND todate = @todate AND moviename = @moviename";
                    using (SqlCommand checkShowCmd = new SqlCommand(checkShowQuery, con))
                    {
                        checkShowCmd.Parameters.AddWithValue("@shows", comboBox1.Text);
                        checkShowCmd.Parameters.AddWithValue("@fromdate", dateTimePicker1.Text);
                        checkShowCmd.Parameters.AddWithValue("@todate", dateTimePicker2.Text);
                        checkShowCmd.Parameters.AddWithValue("@moviename", movienametxt.Text);

                        int showCount = (int)checkShowCmd.ExecuteScalar();

                        if (showCount > 0)
                        {
                            MessageBox.Show("Another movie already has the first show scheduled for the same date.", "Show Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            string query = "INSERT into moviedetails(moviename,fromdate,todate,shows,time,price,discription) values ('" + movienametxt.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + comboBox1.Text + "','" + timetxt.Text + "','" + pricetxt.Text + "','" + discriptiontxt.Text + "')";
                            db.setdata(query);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Movie Add Succesfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
       

        private void savebtn_Click(object sender, EventArgs e)
        {
            StoreImageInDatabase(movieimg.Image);
           
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            updatemovie u1 = new updatemovie();
            this.Hide();
            u1.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timetxt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                timetxt.Text = "02:00 To 04:00";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                timetxt.Text = "04:00 To 06:00";
            }
            if (comboBox1.SelectedIndex == 2)
            {
                timetxt.Text = "06:00 To 08:00";
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            deletemovie dl = new deletemovie();
            this.Hide();
            dl.Show();

        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected item?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                form2 f2 = new form2();
                this.Hide();
                f2.Show();
            }
        }
    }
}
