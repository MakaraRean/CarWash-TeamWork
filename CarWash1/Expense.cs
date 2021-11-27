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
    public partial class Expense : Form
    {
        public Expense()
        {
            InitializeComponent();
        }
        public Expense(int sID)
        {
            InitializeComponent();
            this.sID = sID;
        }
        int sID;

        private void ClearText()
        {
            txtAmount.Clear();
            txtDescription.Clear();
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            string des = txtDescription.Text;
            double amount = double.Parse(txtAmount.Text);
            string date = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            
            DataGridExpense.Rows.Add(sID,des,date,amount);
            ClearText();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (btUpdate.Text == "Edit")
            {
                txtAmount.Text = DataGridExpense.CurrentRow.Cells[3].Value.ToString();
                txtDescription.Text = DataGridExpense.CurrentRow.Cells[1].Value.ToString();
                btUpdate.Text = "Update";
            }
            else
            {
                DataGridExpense.CurrentRow.Cells[3].Value = txtAmount.Text;
                DataGridExpense.CurrentRow.Cells[1].Value = txtDescription.Text;
                btUpdate.Text = "Edit";
                ClearText();
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            DataGridExpense.Rows.Remove(DataGridExpense.CurrentRow);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            double total = 0;
            string date = DateTime.Now.ToString("MM/dd/yyyy h:mm:ss");
            try
            {
                //Calulate Total in tbExpenses
                for(int i = 0; i < DataGridExpense.Rows.Count; i++)
                {
                    total += double.Parse(DataGridExpense.Rows[i].Cells[3].Value.ToString());
                    
                }
                //add data to tbExpenses
                string sql = "INSERT INTO tbExpenses (Total,SID,Date) VALUES(" + total + ","+sID+",'"+date+"');";
                SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                //scope expID to add data to tbExpenseDetails
                int expID=0;
                sql = "SELECT SCOPE_IDENTITY();";
                cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    expID = int.Parse(reader.GetValue(0).ToString());
                }
                cmd.Dispose();
                reader.Close();
                //add data to tbExpenseDetails
                for (int i = 0; i < DataGridExpense.Rows.Count; i++)
                {
                    sql = "INSERT INTO tbExpenseDetails VALUES(" + DataGridExpense.Rows[i].Cells[3].Value + ",'" + DataGridExpense.Rows[i].Cells[1].Value + "'," + expID + ");";
                    cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    reader.Close();
                }
                cmd.Dispose();
                reader.Close();
                DataGridExpense.Rows.Clear();
                dataGridView1.Rows.Clear();
                Expense_Load(sender, e);
                ClearText();
                MessageBox.Show("Data saved");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Expense_Load(object sender, EventArgs e)
        {
            string sid, des, date, amount;
            try
            {
                string sql = "SELECT SID,Description,Date,Amount FROM tbExpenseDetails INNER JOIN tbExpenses ON tbExpenseDetails.ExpID=tbExpenses.ExpID;";
                SqlCommand cmd = new SqlCommand(sql, DatabaseConnection.DataCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    sid = reader.GetValue(0).ToString();
                    des = reader.GetValue(1).ToString();
                    date = reader.GetValue(2).ToString();
                    amount = reader.GetValue(3).ToString();

                    dataGridView1.Rows.Add(sid, des, date, amount);
                }
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
