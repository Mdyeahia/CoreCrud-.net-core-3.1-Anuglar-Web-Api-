using System;
using System.Collections.Generic;

#nullable disable

namespace CoreCrud.Models
{
    public partial class MachineAllocation
    {
        public int Id { get; set; }
        public int MachineNo { get; set; }
        public int? McDia { get; set; }
        public int? McGg { get; set; }
        public string PpNo { get; set; }
        public int? OrderQty { get; set; }
        public DateTime? StartDate { get; set; }
        public string Status { get; set; }
        public decimal? Sl { get; set; }
    }
}
