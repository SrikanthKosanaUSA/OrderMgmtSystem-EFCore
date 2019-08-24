using System;
using System.Collections.Generic;

namespace OrderMgmtSystem.NetCore.Models
{
    public partial class TblCustomer
    {
        public TblCustomer()
        {
            TblInvoice = new HashSet<TblInvoice>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }

        public ICollection<TblInvoice> TblInvoice { get; set; }
    }
}
