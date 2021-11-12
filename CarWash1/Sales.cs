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
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
        }
        public Sales(string userID)
        {
            InitializeComponent();
            this.userID = userID;
        }
        string userID;
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
            pictureDrink.Enabled = false;

            string carType;
            try
            {
                string sql = "SELECT * FROM tbCategoryCars;";
                SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    carType = reader.GetValue(1).ToString();
                    comboCar.Items.Add(carType);
                }
                cmd.Dispose();
                reader.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void ClearText()
        {
            txtDrink.Clear();
            txtQty.Clear();
            comboCar.Text = "";
        }

        private double TotalAmount()
        {
            double amount = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                amount += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
            }
            return amount;
        }


        private void btAdd_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (checkDrink.Checked==true)
                {
                    string dID = txtDrink.Text;
                    int qty = int.Parse(txtQty.Text);
                    string pName;
                    double amount;
                    double price;
                    string sql = "SELECT DName,Price FROM tbDrinks WHERE DID=" + dID + ";";
                    SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        pName = reader.GetValue(0).ToString();
                        price = double.Parse(reader.GetValue(1).ToString());
                        amount = qty * price;

                        dataGridView1.Rows.Add(pName, qty, price, "Drink", amount);
                        cmd.Dispose();
                        reader.Close();
                        ClearText();
                    }
                    else
                    {
                        MessageBox.Show("Drink ID you input don't have in stock");
                    }
                }
                else if(checkDrink.Checked==false)
                {
                    string catCar = comboCar.Text;
                    int qty = int.Parse(txtQty.Text);
                    string pName;
                    double amount;
                    double price;
                    string sql = "SELECT CatCar,Price FROM tbCategoryCars WHERE CatCar='" + catCar + "';";
                    SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        pName = reader.GetValue(0).ToString();
                        price = double.Parse(reader.GetValue(1).ToString());
                        amount = qty * price;

                        dataGridView1.Rows.Add(pName, qty, price, "Car", amount);
                        cmd.Dispose();
                        reader.Close();
                        ClearText();
                    }
                }
                txtTotalAmount.Text = TotalAmount().ToString("$#,##0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (btUpdate.Text == "EDIT")
            {
                txtQty.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                btUpdate.Text = "UPDATE";
                btAdd.Enabled = false;
                btRemove.Enabled = false;
            }
            else
            {
                int qty = int.Parse(txtQty.Text);
                double price = Convert.ToDouble(dataGridView1.CurrentRow.Cells[2].Value);
                double amount;
                dataGridView1.CurrentRow.Cells[1].Value = qty;
                amount = qty * price;
                dataGridView1.CurrentRow.Cells[4].Value = amount;
                ClearText();
                btUpdate.Text = "EDIT";
                btRemove.Enabled = true;
                btAdd.Enabled = true;
            }
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }
    }
}
