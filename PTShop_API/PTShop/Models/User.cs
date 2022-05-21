using System;
using System.Collections.Generic;

namespace PTShop.Models
{
    public partial class User
    {
        public User()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public bool? Faeces { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
