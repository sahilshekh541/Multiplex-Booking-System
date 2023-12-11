using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace marvelmultiplex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 1;
            if (progressBar1.Value < 50 )
            {
                label1.Text = "Welcome To The Marvel Multiplex";
               
            }
             if (progressBar1.Value >  50)
            {
                label1.Text = "Wait application is launching";
               
            }
            
            if(progressBar1.Value == 100)
            {
          
                timer1.Stop();
                form2 f2 = new form2();
                this.Hide();
                f2.Show();

            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            
        }
    }
}
