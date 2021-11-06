using System;
using System.Windows.Forms;

namespace CarWash1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string pass = txtPassword.Text;
            string database = "dbCarWash";
            string server = "DESKTOP-JG5UF03\\MAKARA";

            DatabaseConnection.ConnectDatabase(server, database, userName, pass);
            this.Hide();
            new MainForm().Show();
        }

        private void btAuthentication_Click(object sender, EventArgs e)
        {
            string database = "dbCarWash";
            string server = "DESKTOP-JG5UF03\\MAKARA";

            DatabaseConnection.ConnectDatabase(server, database);
            this.Hide();
            new MainForm().Show();
        }
    }
}
