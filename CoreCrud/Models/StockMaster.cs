using System;
using System.Collections.Generic;

#nullable disable

namespace CoreCrud.Models
{
    public partial class StockMaster
    {
        public StockMaster()
        {
            StockDetails = new HashSet<StockDetail>();
        }

        public int Id { get; set; }
        public string TrnNo { get; set; }
        public string SuppplierId { get; set; }
        public DateTime? Entrydate { get; set; }

        public virtual ICollection<StockDetail> StockDetails { get; set; }
    }
}
