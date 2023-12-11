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
    public partial class userhomepage : Form
    {
        public userhomepage()
        {
            InitializeComponent();
            DisplayMoviesFromDatabase();
        }

        private void userhomepage_Load(object sender, EventArgs e)
        {
           
        }


        // Assuming you have a Panel named moviesPanel on your form

        private void DisplayMoviesFromDatabase()
        {
            databaseconnect db = new databaseconnect();
            SqlConnection con = db.GetConnection();

            try
            {
                con.Open();
                string query = "SELECT moviename, movieimg FROM movieimg";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int panelWidth = 150;
                        int panelHeight = 220;
                        int x = 10;
                        int y = 10;

                        while (reader.Read())
                        {
                            string movieName = reader["moviename"].ToString();
                            byte[] imageData = (byte[])reader["movieimg"];

                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                Image image = Image.FromStream(ms);

                                Panel moviePanel = new Panel();
                                moviePanel.Size = new Size(panelWidth, panelHeight);
                                moviePanel.Location = new Point(x, y);
                                moviesPanel.Controls.Add(moviePanel); // Add the panel to the moviesPanel

                                PictureBox pictureBox = new PictureBox();
                                pictureBox.Image = image;
                                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                                pictureBox.Size = new Size(panelWidth - 20, panelHeight - 60);
                                pictureBox.Location = new Point(10, 10);
                                pictureBox.Click += (sender, e) => PictureBox_Click(sender, e, movieName, image);
                                moviePanel.Controls.Add(pictureBox);

                                Label nameLabel = new Label();
                                nameLabel.Text = movieName;
                                nameLabel.Font = new Font(nameLabel.Font.FontFamily, 10, FontStyle.Bold);
                                nameLabel.ForeColor = Color.White;
                                nameLabel.AutoSize = false;
                                nameLabel.Size = new Size(panelWidth, 30);
                                nameLabel.TextAlign = ContentAlignment.MiddleCenter;
                                nameLabel.Location = new Point(0, pictureBox.Bottom + 10);
                                moviePanel.Controls.Add(nameLabel);

                                x += panelWidth + 10;

                                if (x + panelWidth > moviesPanel.Width) // Check if controls exceed panel width
                                {
                                    x = 10;
                                    y += panelHeight + 10;
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
        private void PictureBox_Click(object sender, EventArgs e, string movieName, Image image)
        {
            bookmovie detailsForm = new bookmovie(movieName, image);
            detailsForm.Show(); // Show the details form as a modal dialog
        }


        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void bookmoviebtn_Click(object sender, EventArgs e)
        {

        }

        private void moviesPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void homebtn_Click(object sender, EventArgs e)
        {
            ticketprint t = new ticketprint();
            this.Hide();
            t.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cancelticket c1 = new cancelticket();
            this.Hide();
            c1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            canteenuserpage c = new canteenuserpage();
            this.Hide();
            c.Show();

        }

        private void button3_Click(object sender, EventArgs e)
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
