using System;
using System.Collections.Generic;

namespace PTShop.Models
{
    public partial class ProductMedium
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string? Uri { get; set; }

        public virtual Product? Product { get; set; }
    }
}
