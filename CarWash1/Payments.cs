using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWash1
{
    public partial class Payments : Form
    {
        public Payments(double totalAmount)
        {
            InitializeComponent();
            this.totalAmount = totalAmount;
        }
        double totalAmount;
        private void Payments_Load(object sender, EventArgs e)
        {
            txtTotalAmount.Text = totalAmount.ToString();
            txtDisPrice.Text = "0";
            txtPayment.Text = txtTotalAmount.Text;
            txtCashReturn.Text = "0";
        }

        private void comboDiscount_TextChanged(object sender, EventArgs e)
        {
            if (comboDiscount.Text == "")
            {
                txtDisPrice.Text = "0";
                txtPayment.Text = txtTotalAmount.Text;
                return;
            }
            double total = double.Parse(txtTotalAmount.Text);
            int dis = int.Parse(comboDiscount.Text);
            double disPrice = total * dis / 100;
            txtDisPrice.Text = disPrice.ToString();
            payment = total - disPrice;
            txtPayment.Text = payment.ToString();
            txtCashReceived_TextChanged(sender, e);
        }

        private void txtCashReceived_TextChanged(object sender, EventArgs e)
        {
            if (txtCashReceived.Text == "")
            {
                return;
            }
            double cashReceived = double.Parse(txtCashReceived.Text);
            payment = double.Parse(txtPayment.Text);
            double cashReturn;
            if (cashReceived<payment)
            {
                txtCashReturn.Text = "0";
                btPay.Enabled = false;
            }
            else
            {
                cashReturn = cashReceived - payment;
                txtCashReturn.Text = cashReturn.ToString();
                btPay.Enabled = true;
            }
        }

        private void btAddMore_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public double payment { get; set; }

        private void btPay_Click(object sender, EventArgs e)
        {
            this.Dispose();
            DialogResult = DialogResult.OK;
        }
    }
}
