using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace marvelmultiplex
{
    public partial class ticketprintresult : Form
    {
        private int tknumber;
        private string guestnm;
        private string seatno;
        private string bkdate;
        private string showdate;
        private string moviename;


        public ticketprintresult(int tknumber,string guestnm,string seatno,string bkdate,string showdate,string moviename)
        {
            this.tknumber = tknumber;
            this.guestnm = guestnm;
            this.seatno = seatno;
            this.bkdate = bkdate;
            this.showdate = showdate;
            this.moviename = moviename;
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void movienm_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void ChangeFontInPanel(Control parent, Font newFont)
        {
            foreach (Control control in parent.Controls)
            {
                // Check if the control has text that can be modified (e.g., Label, TextBox)
                if (control is Label || control is TextBox || control is Button || control is RichTextBox)
                {
                    control.Font = newFont;
                }

                // If the control is a container (e.g., another Panel), recursively change font within it
                if (control.Controls.Count > 0)
                {
                    ChangeFontInPanel(control, newFont);
                }
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            // Create a graphics object to draw on the print document
            Graphics g = e.Graphics;

            // Create a new font (replace "Arial" and 12 with your desired font and size)
            Font newFont = new Font("Arial", 12);

            // Change the font of all text-based controls within the panel
            ChangeFontInPanel(panel1, newFont);

            // Calculate the scaling factor to fit panel1's content within the print page
            float scale = Math.Min(
                e.MarginBounds.Width / panel1.Width,
                e.MarginBounds.Height / panel1.Height
            );

            // Create a bitmap that matches the panel1's size
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);

            // Draw panel1's content onto the bitmap
            panel1.DrawToBitmap(bmp, new Rectangle(0, 0, panel1.Width, panel1.Height));

            // Draw the bitmap on the print document at its original size
            g.DrawImage(bmp, 0, 0);
        }


        private void printbtn_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintPage);

            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = pd;

            previewDialog.WindowState = FormWindowState.Maximized;

            // Show the print preview dialog
            previewDialog.ShowDialog();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            userhomepage u = new userhomepage();
            this.Hide();
            u.Show();
        }

        private void ticketprintresult_Load(object sender, EventArgs e)
        {
            movienmlbl.Text = moviename;
            guestnamelbl.Text = guestnm;
            ticketnolbl.Text = tknumber.ToString();
            showdatelbl.Text = showdate;
            bookdatelbl.Text = bkdate;
            seatnolbl.Text = seatno;
        }
    }
}
