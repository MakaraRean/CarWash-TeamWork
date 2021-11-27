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
    public partial class Income : Form
    {
        public Income()
        {
            InitializeComponent();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string startdate = dateTimeStart.Value.ToString("yyyy-MM-dd");
            string enddate = dateTimeEnd.Value.ToString("yyyy-MM-dd");
            int inID;
            string date,seller;
            double amount;
            double totalAmount = 0;
            try
            {
                string sql = "SELECT InID,Date,Total,SName FROM tbInvoices INNER JOIN tbStaffs ON tbStaffs.SID=tbInvoices.SID WHERE Date BETWEEN '" + startdate + "' AND '" + enddate + "';";
                SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    inID = int.Parse(reader.GetValue(0).ToString());
                    date = reader.GetValue(1).ToString();
                    amount = double.Parse(reader.GetValue(2).ToString());
                    seller = reader.GetValue(3).ToString();
                    totalAmount += amount;

                    dataGridView1.Rows.Add(inID, date, amount, seller);
                }
                txtTotalAmount.Text = totalAmount.ToString();
                cmd.Dispose();
                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            
        }
    }
}
