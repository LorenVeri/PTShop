using System;
using System.Collections.Generic;

namespace PTShop.Models
{
    public partial class Transaction
    {
        public Transaction()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int? CatogoryId { get; set; }
        public int? UseId { get; set; }
        public bool? Passersby { get; set; }
        public int? Amount { get; set; }
        public string? Message { get; set; }
        public string? Payment { get; set; }
        public string? PaymentInfo { get; set; }
        public string? Security { get; set; }
        public DateTime? CreateAt { get; set; }

        public virtual User? Use { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
