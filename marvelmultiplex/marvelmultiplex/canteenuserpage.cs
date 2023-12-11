using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace marvelmultiplex
{
    public partial class canteenuserpage : Form
    {

        private string price;
        private string foodname;
        public canteenuserpage()
        {
            InitializeComponent();
            DisplayCanteenItemsFromDatabase();
        }


        private void DisplayCanteenItemsFromDatabase()
        {
            databaseconnect db = new databaseconnect();
            SqlConnection con = db.GetConnection();

            try
            {
                con.Open();
                string query = "SELECT foodimg, foodname, price FROM canteenitems";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int panelWidth = 150;
                        int panelHeight = 220;
                        int x = 10;
                        int y = 10;

                        int horizontalSpacing = 180; // Increase this value for more space between panels
                        int verticalSpacing = 100;   // Increase this value for more space between rows

                        while (reader.Read())
                        {
                            byte[] imageData = (byte[])reader["foodimg"];
                            foodname = reader["foodname"].ToString();
                            price = reader["price"].ToString();

                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                Image image = Image.FromStream(ms);

                                Panel itemPanel = new Panel();
                                itemPanel.Size = new Size(panelWidth, panelHeight);
                                itemPanel.Location = new Point(x, y);
                                moviesPanel.Controls.Add(itemPanel); // Add the panel to the moviesPanel

                                PictureBox pictureBox = new PictureBox();
                                pictureBox.Image = image;
                                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                                pictureBox.Size = new Size(panelWidth - 20, panelHeight - 60);
                                pictureBox.Location = new Point(10, 10);
                                pictureBox.Click += (sender, e) => PictureBox_Click(sender, e, foodname, image,price);
                                itemPanel.Controls.Add(pictureBox);

                                Label nameLabel = new Label();
                                nameLabel.Text = foodname;
                                nameLabel.Font = new Font(nameLabel.Font.FontFamily, 10, FontStyle.Bold);
                                nameLabel.ForeColor = Color.White;
                                nameLabel.AutoSize = false;
                                nameLabel.Size = new Size(panelWidth, 30);
                                nameLabel.TextAlign = ContentAlignment.MiddleCenter;
                                nameLabel.Location = new Point(0, pictureBox.Bottom + 10);
                                itemPanel.Controls.Add(nameLabel);

                                x += panelWidth + horizontalSpacing;

                                if (x + panelWidth > moviesPanel.Width) // Check if controls exceed panel width
                                {
                                    x = 10;
                                    y += panelHeight + verticalSpacing;
                                }
                            }
                        }
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


        private void PictureBox_Click(object sender, EventArgs e, string movieName, Image image, string price)
        {
            canteensale detailsForm = new canteensale(image, foodname,price);
            detailsForm.Show(); // Show the details form as a modal dialog
        }



        private void canteenuserpage_Load(object sender, EventArgs e)
        {

        }

        private void homebtn_Click(object sender, EventArgs e)
        {
            userhomepage u = new userhomepage();
            this.Hide();
            u.Show();
        }
    }
}
