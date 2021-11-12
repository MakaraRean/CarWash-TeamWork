using System;
using System.Windows.Forms;

namespace CarWash1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(string staff,string userID)
        {
            InitializeComponent();
            this.staff = staff;
            this.userID = userID;
        }
        string staff;
        string userID;
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            labelStaff.Text = staff;
        }

        private void btDrink_Click(object sender, System.EventArgs e)
        {
            new Drink().ShowDialog();
        }

        private void btStaff_Click(object sender, System.EventArgs e)
        {
            new Staff().ShowDialog();
        }

        private void btExpense_Click(object sender, System.EventArgs e)
        {
            new Expense(userID).ShowDialog();
        }

        private void btLogout_Click(object sender, System.EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure to log out?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Dispose();
                    new Form1().Show();
                }
                else
                {
                    return;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btSales_Click(object sender, EventArgs e)
        {
            new Sales().Show();
        }
    }
}
