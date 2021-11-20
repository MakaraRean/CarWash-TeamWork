using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CarWash1
{
    public partial class Drink : Form
    {
        public Drink()
        {
            InitializeComponent();
        }

        List<int> catID = new List<int>();
        private void Drink_Load(object sender, EventArgs e)
        {
            
            GetData();
            try
            {
                string sql = "SELECT * FROM tbCategories;";
                SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int catid = int.Parse(reader.GetValue(0).ToString());
                    catID.Add(catid);
                    string catName = reader.GetValue(1).ToString();
                    cbCatName.Items.Add(catName);
                    cbCatName.SelectedIndex = 0;
                }
                if (reader.Read() == false)
                {
                    MessageBox.Show("Don't have any category in your database");
                }
                
                cmd.Dispose();
                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void GetData()
        {
            dataGridView1.Rows.Clear();
            string name, qty, price, catName;
            try
            {
                string sql = "SELECT DName,SUM(SQty),Price,CatName FROM tbDrinks  INNER JOIN tbCategories ON tbDrinks.CatID = tbCategories.CatID GROUP BY DName,Catname,Price;";
                SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    
                    name = reader.GetString(0).ToString();
                    qty = reader.GetValue(1).ToString();
                    price = reader.GetValue(2).ToString();
                    catName = reader.GetValue(3).ToString();

                    dataGridView1.Rows.Add(name, qty, price, catName);
                }
                cmd.Dispose();
                reader.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string qty = txtQty.Text;
            string price = txtPrice.Text;
            try
            {
                string sql = "INSERT INTO tbDrinks (DName,SQty,Price,CatID) VALUES('"+name+"',"+qty+","+price+","+ catID[cbCatName.SelectedIndex]+ ");";
                SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                GetData();
                MessageBox.Show("A product has been added");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btEdit.Enabled = true;
            namefordeleteupdate = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            qtyfordeleteupdate = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            pricefordeleteupdate = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            namefordeleteupdate = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            qtyfordeleteupdate = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            pricefordeleteupdate = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            txtName.Text = namefordeleteupdate;
            txtQty.Text = qtyfordeleteupdate;
            txtPrice.Text = pricefordeleteupdate;
            cbCatName.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            
        }

        string namefordeleteupdate;
        string qtyfordeleteupdate;
        string pricefordeleteupdate;
        private void btUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string qty = txtQty.Text;
            string price = txtPrice.Text;
            try
            {
                string sql = "DELETE tbDrinks WHERE DName = '"+namefordeleteupdate+"' AND SQty="+qtyfordeleteupdate+" AND Price="+pricefordeleteupdate+";";
                SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                sql = "INSERT INTO tbDrinks (DName,SQty,Price,CatID) VALUES('" + name + "'," + qty + "," + price + "," + catID[cbCatName.SelectedIndex] + ");";
                cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure to delete?","Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string sql = "DELETE tbDrinks WHERE DName = '" + namefordeleteupdate + "' AND SQty=" + qtyfordeleteupdate + " AND Price=" + pricefordeleteupdate + ";";
                    SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    MessageBox.Show("A row has been deleted");
                    GetData();
                }
                else
                {
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
