using System;
using System.Collections.Generic;

#nullable disable

namespace CoreCrud.Models
{
    public partial class Menu
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string NavUrl { get; set; }
    }
}
