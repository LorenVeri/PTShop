using System;
using System.Collections.Generic;

namespace PTShop.Models
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public int? Phone { get; set; }
        public string? Email { get; set; }
    }
}
