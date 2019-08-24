using System;
using System.Collections.Generic;

namespace OrderMgmtSystem.NetCore.Models
{
    public partial class TblInvoice
    {
        public TblInvoice()
        {
            TblLineItem = new HashSet<TblLineItem>();
        }

        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Subtotal { get; set; }
        public decimal SalesTax { get; set; }
        public decimal Total { get; set; }
        public DateTime? ShipDate { get; set; }
        public string Terms { get; set; }
        public int? SalesPersonId { get; set; }
        public int CustomerId { get; set; }

        public TblCustomer Customer { get; set; }
        public TblSalesPerson SalesPerson { get; set; }
        public ICollection<TblLineItem> TblLineItem { get; set; }
    }
}
