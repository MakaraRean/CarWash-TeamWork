using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CarWash1
{
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }


        private void GetData()
        {
            DataGridStaff.Rows.Clear();
            string id;
            string name;
            string postion;
            string address;
            string phone;
            string salary;
            try
            {
                string sql = "SELECT * FROM tbStaffs;";
                SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    id = reader.GetValue(0).ToString();
                    name = reader.GetValue(1).ToString();
                    postion = reader.GetValue(2).ToString();
                    address = reader.GetValue(3).ToString();
                    phone = reader.GetValue(4).ToString();
                    salary = reader.GetValue(5).ToString();

                    DataGridStaff.Rows.Add(id, name, postion, address, phone, salary);
                }
                cmd.Dispose();
                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void ClearTextbox()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtPosition.Clear();
            txtAddress.Clear();
            txtSalary.Clear();
        }

        int id;
        private void Staff_Load_1(object sender, EventArgs e)
        {
            GetData();
        }

        private void btAdd_Click_1(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string postion = txtPosition.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;
            double salary = double.Parse(txtSalary.Text);
            try
            {
                string sql = "INSERT INTO tbStaffs (SName,Position,Address,PhoneNumber,Salary) VALUES('" + name + "','" + postion + "','" + address + "','" + phone + "'," + salary + ");";
                SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("A new staff has been added");
                GetData();
                ClearTextbox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btUpdate_Click_1(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string postion = txtPosition.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;
            double salary = double.Parse(txtSalary.Text);
            try
            {
                string sql = "UPDATE tbStaffs SET SName='" + name + "', Position='" + postion + "', Address='" + address + "', PhoneNumber='" + phone + "',Salary=" + salary + " WHERE SID=" + id + ";";
                SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("A staff's data has been updated");
                GetData();
                ClearTextbox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btEdit_Click_1(object sender, EventArgs e)
        {
            id = int.Parse(DataGridStaff.CurrentRow.Cells[0].Value.ToString());
            txtName.Text = DataGridStaff.CurrentRow.Cells[1].Value.ToString();
            txtPosition.Text = DataGridStaff.CurrentRow.Cells[2].Value.ToString();
            txtAddress.Text = DataGridStaff.CurrentRow.Cells[3].Value.ToString();
            txtPhone.Text = DataGridStaff.CurrentRow.Cells[4].Value.ToString();
            txtSalary.Text = DataGridStaff.CurrentRow.Cells[5].Value.ToString();
        }

        private void btDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                string id = DataGridStaff.CurrentRow.Cells[0].Value.ToString();
                DialogResult result = MessageBox.Show("Are you sure to remove?", "Remove staff", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string sql = "DELETE tbStaffs WHERE SID=" + id + ";";
                    SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    MessageBox.Show("A staff has been removed");
                    GetData();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridStaff.Rows.Clear();
                string sid = txtSearch.Text;
                string sql = "SELECT * FROM tbStaffs WHERE SID=" + sid + ";";
                SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    DataGridStaff.Rows.Add(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), reader.GetValue(5).ToString());
                }
                else
                {
                    MessageBox.Show("Don't have staff ID " + sid + "");
                }
                cmd.Dispose();
                reader.Close();
                txtSearch.Clear();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
