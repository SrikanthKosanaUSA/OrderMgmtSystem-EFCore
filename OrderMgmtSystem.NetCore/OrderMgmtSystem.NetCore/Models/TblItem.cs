using System;
using System.Collections.Generic;

namespace OrderMgmtSystem.NetCore.Models
{
    public partial class TblItem
    {
        public TblItem()
        {
            TblLineItem = new HashSet<TblLineItem>();
        }

        public int ItemId { get; set; }
        public string ItemNumber { get; set; }
        public string Description { get; set; }
        public decimal? UnitPrice { get; set; }

        public ICollection<TblLineItem> TblLineItem { get; set; }
    }
}
