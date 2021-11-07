using System;
using System.Data.SqlClient;
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
            string userID;
            string staffName;
            try
            {
                DatabaseConnection.ConnectDatabase(server, database);
                string sql = "SELECT * FROM tbUsers WHERE UserName='" + userName + "' AND Password='" + pass + "';";
                SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    userID = reader.GetValue(2).ToString();
                    cmd.Dispose();
                    reader.Close();
                    string sql1 = "SELECT SName FROM tbStaffs WHERE SID = " + userID + ";";
                    SqlCommand cmd1 = new SqlCommand(sql1, DatabaseConnection.DataCon);
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    if (reader1.Read())
                    {
                        staffName = reader1.GetValue(0).ToString();
                        cmd1.Dispose();
                        reader1.Close();
                        this.Hide();
                        new MainForm(staffName).Show();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password");
                }
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btAuthentication_Click(object sender, EventArgs e)
        {
            string database = "dbCarWash";
            string server = "DESKTOP-JG5UF03\\MAKARA";

            DatabaseConnection.ConnectDatabase(server, database);
            this.Hide();
            new MainForm().Show();
        }

        private void btNewUser_Click(object sender, EventArgs e)
        {
            new CreateUser().ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
