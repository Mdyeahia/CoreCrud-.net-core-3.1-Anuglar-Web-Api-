using System;
using System.Collections.Generic;

#nullable disable

namespace CoreCrud.Models
{
    public partial class PpMaster
    {
        public PpMaster()
        {
            PpDetails = new HashSet<PpDetail>();
        }

        public int Id { get; set; }
        public string PpNo { get; set; }
        public string Buyer { get; set; }
        public string Customer { get; set; }
        public string Merchandiser { get; set; }
        public string StyleNo { get; set; }

        public virtual ICollection<PpDetail> PpDetails { get; set; }
    }
}
