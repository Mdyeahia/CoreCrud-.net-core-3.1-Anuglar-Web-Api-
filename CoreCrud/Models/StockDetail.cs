using System;
using System.Collections.Generic;

#nullable disable

namespace CoreCrud.Models
{
    public partial class StockDetail
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string ProductName { get; set; }
        public string ProductQty { get; set; }

        public virtual StockMaster Master { get; set; }
    }
}
