using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash1
{
    class InvoiceDetails
    {
        private int qty;
        private int did;

        public InvoiceDetails(int qty, int did)
        {
            this.qty = qty;
            this.did = did;
        }
        public int Qty { get => qty; set => qty = value; }
        public int Did { get => did; set => did = value; }
    }
}
