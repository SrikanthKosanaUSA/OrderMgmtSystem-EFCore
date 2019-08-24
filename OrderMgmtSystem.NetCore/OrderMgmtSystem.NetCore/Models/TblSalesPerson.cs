using System;
using System.Collections.Generic;

namespace OrderMgmtSystem.NetCore.Models
{
    public partial class TblSalesPerson
    {
        public TblSalesPerson()
        {
            TblInvoice = new HashSet<TblInvoice>();
        }

        public int SalesPersonId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }

        public ICollection<TblInvoice> TblInvoice { get; set; }
    }
}
