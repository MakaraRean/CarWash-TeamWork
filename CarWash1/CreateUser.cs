using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWash1
{
    public partial class CreateUser : Form
    {
        public CreateUser()
        {
            InitializeComponent();
        }

        private void ClearTextbox()
        {
            txtCfPassword.Clear();
            txtPassword.Clear();
            txtUser.Clear();
        }
        private void GetData()
        {
            DataGridUser.Rows.Clear();
            string id,username,pass,position;
            try
            {
                string sql = "SELECT UID,UserName,Password,Position FROM tbUsers INNER JOIN tbStaffs ON tbUsers.SID = tbStaffs.SID;";
                SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetValue(0).ToString();
                    username = reader.GetValue(1).ToString();
                    pass = reader.GetValue(2).ToString();
                    position = reader.GetValue(3).ToString();

                    DataGridUser.Rows.Add(id, username, pass, position);
                }
                cmd.Dispose();
                reader.Close();
                sql = "SELECT * FROM tbUsers WHERE SID IS NULL;";
                cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetValue(0).ToString();
                    username = reader.GetValue(1).ToString();
                    pass = reader.GetValue(2).ToString();

                    DataGridUser.Rows.Add(id, username, pass);
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        List<string> sName = new List<string>();
        List<int> sID = new List<int>();
        private void CreateUser_Load(object sender, EventArgs e)
        {
            GetData();
            try
            {
                
                string sql = "SELECT SID,SName FROM tbStaffs;";
                SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    sID.Add(int.Parse(reader.GetValue(0).ToString()));
                    string name = reader.GetValue(1).ToString();
                    cbSName.Items.Add(name);
                }
                cmd.Dispose();
                reader.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int sid=0;
        private void btCreate_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPassword.Text;
            string cfPass = txtCfPassword.Text;
            if (password != cfPass)
            {
                MessageBox.Show("Password doesn't match");
                return;
            }
            else
            {
                try
                {
                    string sql;
                    if (sid==0)
                    {
                        sql = "INSERT INTO tbUsers (UserName,Password) VALUES('" + username + "','" + password + "')";

                    }
                    else
                    {
                        sql = "INSERT INTO tbUsers (UserName,Password,SID) VALUES('" + username + "','" + password + "'," + sid + ")";

                    }

                    SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    MessageBox.Show("A new user has been added");
                    GetData();
                    ClearTextbox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void checkBoxStaffName_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStaffName.Checked)
            {
                cbSName.Enabled = true;
            }
            else
            {
                cbSName.Enabled = false;
                cbSName.Text = null;
            }
        }

        private void checkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPass.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void checkBoxShowCfPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowCfPass.Checked)
            {
                txtCfPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtCfPassword.UseSystemPasswordChar = true;
            }
        }

        private void cbSName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBoxStaffName.Checked)
            {
                sid = sID[cbSName.SelectedIndex];
            }
            else
            {
                sid = 0;
            }
            
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DataGridUser_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        int uid;
        private void btUpdate_Click(object sender, EventArgs e)
        {

            string name = txtUser.Text;
            string pass = txtPassword.Text;
            string cfPass = txtCfPassword.Text;
            
            string sql;
            if (btUpdate.Text == "EDIT")
            {
                if (DataGridUser.CurrentRow.Cells[3].Value == null)
                {
                    txtPassword.Text = DataGridUser.CurrentRow.Cells[2].Value.ToString();
                    txtCfPassword.Text = DataGridUser.CurrentRow.Cells[2].Value.ToString();
                    txtUser.Text = DataGridUser.CurrentRow.Cells[1].Value.ToString();
                    uid=int.Parse(DataGridUser.CurrentRow.Cells[0].Value.ToString());
                }
                else
                {
                    txtPassword.Text = DataGridUser.CurrentRow.Cells[2].Value.ToString();
                    txtCfPassword.Text = DataGridUser.CurrentRow.Cells[2].Value.ToString();
                    txtUser.Text = DataGridUser.CurrentRow.Cells[1].Value.ToString();
                    cbSName.Text = DataGridUser.CurrentRow.Cells[3].Value.ToString();
                    uid = int.Parse(DataGridUser.CurrentRow.Cells[0].Value.ToString());
                }
                
                btUpdate.Text = "UPDATE";
            }
            else
            {
                if (pass != cfPass)
                {
                    MessageBox.Show("Password doesn't match");
                    return;
                }
                else
                {
                    try
                    {
                        if (cbSName.Text == "")
                        {
                            sql = "UPDATE tbUsers SET UserName='" + name + "',Password='" + pass + "' WHERE UID="+uid+";";
                        }
                        else
                        {
                            sql = "UPDATE tbUsers SET UserName='" + name + "',Password='" + pass + "',SID=" + sid + " WHERE UID=" + uid + ";";
                        }
                        SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        MessageBox.Show("A user has been updated");
                        GetData();
                        ClearTextbox();
                        btUpdate.Text = "EDIT";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
  
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            string id = DataGridUser.CurrentRow.Cells[0].Value.ToString();
            try
            {
                DialogResult result = MessageBox.Show("Are you sure to delete this user?", "Delete user", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string sql = "DELETE tbUsers WHERE UID=" + id + ";";
                    SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    GetData();
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
    }
}
