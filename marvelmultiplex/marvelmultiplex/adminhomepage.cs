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
    public partial class adminhomepage : Form
    {
        public adminhomepage()
        {
            InitializeComponent();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            addnewmovie a1 = new addnewmovie();
            this.Hide();
            a1.Show();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            updatemovie u1 = new updatemovie();
            this.Hide();
            u1.Show();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            deletemovie d1 = new deletemovie();
            this.Hide();
            d1.Show();
        }

        private void movielists_Click(object sender, EventArgs e)
        {
            showmovielists s = new showmovielists();
            this.Hide();
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bookedseatslist b = new bookedseatslist();
            this.Hide();
            b.Show();
        }

        private void addcanteenbtn_Click(object sender, EventArgs e)
        {
            addcanteenitems add = new addcanteenitems();
            this.Hide();
            add.Show();
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected item?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                form2 f2 = new form2();
                this.Hide();
                f2.Show();
            }
           
        }

        private void canteenitemslist_Click(object sender, EventArgs e)
        {
            canteenitemslist cl = new canteenitemslist();
            this.Hide();
            cl.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            canteensalelist c = new canteensalelist();
            this.Hide();
            c.Show();
        }
    }
}
