using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWash1
{
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
        }

        private void checkDrink_CheckedChanged(object sender, EventArgs e)
        {
            if(checkDrink.Checked != true)
            {
                txtDrink.Enabled = false;
                labelDrink.Enabled = false;        
                pictureDrink2.BringToFront();

                comboCar.Enabled = true;
                labelCar.Enabled = true;
                pictureCar.BringToFront();
                comboCar.BringToFront();
            }
            else
            {
                txtDrink.Enabled = true;
                labelDrink.Enabled = true;
                pictureDrink2.SendToBack();

                comboCar.Enabled = false;
                labelCar.Enabled = false;
                pictureCar2.BringToFront();
                comboCar.BringToFront();
            }
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            pictureDrink2.BringToFront();
            txtDrink.Enabled = false;
            labelDrink.Enabled = false;
            pictureDrink.Enabled = false;
        }

        private void pictureCar2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureCar_Click(object sender, EventArgs e)
        {
         
        }

        private void pictureDrink2_Click(object sender, EventArgs e)
        {

        }

        private void pictureDrink_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
    }
}
