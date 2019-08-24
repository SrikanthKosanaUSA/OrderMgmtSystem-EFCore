using System;
using System.Collections.Generic;

namespace OrderMgmtSystem.NetCore.Models
{
    public partial class TblLineItem
    {
        public int LineItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public int InvoiceId { get; set; }
        public int ItemId { get; set; }

        public TblInvoice Invoice { get; set; }
        public TblItem Item { get; set; }
    }
}
