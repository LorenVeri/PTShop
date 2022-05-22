using System;
using System.Collections.Generic;

namespace PTShop.Models
{
    public partial class Favorite
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }

        public virtual Product? Product { get; set; }
    }
}
