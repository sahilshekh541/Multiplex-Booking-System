using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace marvelmultiplex
{
    public partial class addcanteenitems : Form
    {
        public addcanteenitems()
        {
            InitializeComponent();
        }

        private void selectimgbtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.png; *.gif; *.bmp)|*.jpg; *.png; *.gif; *.bmp|All Files (*.*)|*.*";
                openFileDialog.InitialDirectory = "C:";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foodimg.Image = new Bitmap(openFileDialog.FileName);
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

                    command.CommandText = "INSERT INTO canteenitems (foodimg, foodname, price) VALUES (@foodimg, @foodname, @price)";
                    command.Parameters.Add("@foodimg", SqlDbType.VarBinary).Value = imageData;
                    command.Parameters.Add("@foodname", SqlDbType.VarChar).Value = descptxt.Text;
                    command.Parameters.Add("@price", SqlDbType.VarChar).Value = pricetxt.Text;

                    // Execute the query
                    command.ExecuteNonQuery();

                    MessageBox.Show("Item Added Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void addbtn_Click(object sender, EventArgs e)
        {
            StoreImageInDatabase(foodimg.Image);
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            adminhomepage a = new adminhomepage();
            this.Hide();
            a.Show();
        }
    }
}
