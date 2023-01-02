using System;
using System.Collections.Generic;

#nullable disable

namespace CoreCrud.Models
{
    public partial class PpDetail
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string Color { get; set; }
        public int? Qty { get; set; }
        public int? FmCode { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public virtual PpMaster Master { get; set; }
    }
}
