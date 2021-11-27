using System;
using System.Data.SqlClient;
using System.Drawing;
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

        public static int userID{ get; set; }
        private void btLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string pass = txtPassword.Text;
            string database = "dbCarWash";
            string server = "DESKTOP-JG5UF03\\MAKARA";

            string position;
            string staffName;
            try
            {
                DatabaseConnection.ConnectDatabase(server, database);
                string sql = "SELECT * FROM tbUsers WHERE UserName='" + userName + "' AND Password='" + pass + "';";
                SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    userID = int.Parse(reader.GetValue(3).ToString());
                    cmd.Dispose();
                    reader.Close();
                    string sql1 = "SELECT SName,Position FROM tbStaffs WHERE SID = " + userID + ";";
                    SqlCommand cmd1 = new SqlCommand(sql1, DatabaseConnection.DataCon);
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    if (reader1.Read())
                    {
                        staffName = "User : "+reader1.GetValue(0).ToString()+" ("+reader1.GetValue(1).ToString()+")";
                        position = reader1.GetValue(1).ToString();
                        cmd1.Dispose();
                        reader1.Close();
                        this.Hide();
                        new MainForm(staffName,userID,position).Show();
                    }
                    else
                    {

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


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btConnectToDatabase_Click(object sender, EventArgs e)
        {
            string database = "dbCarWash";
            string server = "DESKTOP-JG5UF03\\MAKARA";

            DatabaseConnection.ConnectDatabase(server, database);
            MessageBox.Show("Connect to database successfully");
        }

        //Use i to coun for %2
        int i = 0;
        private void pictureBoxShowPassword_Click(object sender, EventArgs e)
        {
            Bitmap bitmapShow = Properties.Resources.ShowPass1;
            Bitmap bitmapHide = Properties.Resources.HidePass;
            
            if (i%2==0)
            {
                txtPassword.UseSystemPasswordChar = false;
                pictureBoxShowPassword.Image = bitmapHide;
                i++;
                
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                pictureBoxShowPassword.Image = bitmapShow;
                i++;
            }
        }
    }
}
