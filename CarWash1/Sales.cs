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
        public Sales(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }
        int userID;
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

        //List<int> did = new List<int>();
        //List<string> carName = new List<string>();
        private void btAdd_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (checkDrink.Checked==true)
                {
                    int dID = int.Parse(txtDrink.Text);
                    int qty = int.Parse(txtQty.Text);
                    string pName;
                    double amount;
                    double price;
                    int catID;
                    string sql = "SELECT DName,Price,CatID FROM tbDrinks WHERE DID=" + dID + ";";
                    SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        pName = reader.GetValue(0).ToString();
                        price = double.Parse(reader.GetValue(1).ToString());
                        catID = int.Parse(reader.GetValue(2).ToString());
                        amount = qty * price;

                        dataGridView1.Rows.Add(pName, qty, price, "Drink", amount,dID,"",catID);
                        
                        cmd.Dispose();
                        reader.Close();
                        ClearText();
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

                        dataGridView1.Rows.Add(pName, qty, price, "Car", amount,"",catCar);
                        cmd.Dispose();
                        reader.Close();
                        ClearText();
                    }
                }
                txtTotalAmount.Text = TotalAmount().ToString("##,#000៛");
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


        private int InsertToInvoice(double payment)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            double total = payment;
            int invoiceID = 0;
            try
            {
                string sql = "INSERT INTO tbInvoices (Date,Total,SID) VALUES('" + date + "'," + total + "," + userID + ");";
                SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                cmd.ExecuteNonQuery();

                
                sql = "SELECT SCOPE_IDENTITY();";
                cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    invoiceID = int.Parse(reader.GetValue(0).ToString());
                }
                cmd.Dispose();
                reader.Close();
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return invoiceID;
        }


        List<InvoiceDetails> Order = new List<InvoiceDetails>();
        private void InsertToInvoiceDetails(int inID)
        {
            int invID = inID;
            //int qty=0;
            //double amount = 0;
            int did;
            //string catID;
            //string carName;
            //string sql;
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                //Int32.TryParse(dataGridView1.Rows[i].Cells[1].ToString(), out qty);
                //Double.TryParse(dataGridView1.Rows[i].Cells[4].ToString(), out amount);
                //qty = int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                //amount = double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                if (dataGridView1.Rows[i].Cells[5].Value.ToString()=="")
                {
                    //did = "NULL";
                    //catID = "NULL";
                    //carName = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    string sql = "INSERT INTO tbInvoiceDetails (Qty,Amount,CarName,InID) VALUES(" + dataGridView1.Rows[i].Cells[1].Value + "," + dataGridView1.Rows[i].Cells[4].Value + ",'" + dataGridView1.Rows[i].Cells[6].Value + "'," + invID + ")";
                    SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else
                {
                    //carName = "NULL";
                    did = int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                    int qty = int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    //catID = dataGridView1.Rows[i].Cells[7].Value.ToString();
                    string sql = "INSERT INTO tbInvoiceDetails (Qty,Amount,InID,DID,CatID) VALUES(" + dataGridView1.Rows[i].Cells[1].Value + "," + dataGridView1.Rows[i].Cells[4].Value + "," + invID + ","+ dataGridView1.Rows[i].Cells[5].Value + ","+ dataGridView1.Rows[i].Cells[7].Value + ")";
                    SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                    InvoiceDetails invoiceDetails = new InvoiceDetails(qty, did);
                    Order.Add(invoiceDetails);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                
            }
        }

        private void UpdateStock()
        {
            foreach(InvoiceDetails temp in Order)
            {
                int qty = temp.Qty;
                int did = temp.Did;
                MessageBox.Show(qty + "And" + did);
                string sql = "UPDATE tbDrinks SET SQty=SQty-" + qty + " WHERE DID= " + did + ";";
                SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
        private void btPayment_Click(object sender, EventArgs e)
        {
            Payments payment = new Payments(TotalAmount());
            if (payment.ShowDialog() == DialogResult.OK)
            {
                //Intsert to invoice
                int invoceID = InsertToInvoice(payment.payment);
                //Insert to invoicedetails
                InsertToInvoiceDetails(invoceID);
                //Updata stock
                UpdateStock();
                //Clear form after pay
                dataGridView1.Rows.Clear();
                Order = new List<InvoiceDetails>();
                txtTotalAmount.Clear();
            }
        }
    }
}
