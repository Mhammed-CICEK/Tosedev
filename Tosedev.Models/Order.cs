using System;
using System.Collections.Generic;

#nullable disable

namespace Tosedev.Models
{
    public partial class Order   {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public Guid AdressId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Adress Adress { get; set; }
        public virtual Product Product { get; set; }
        
    }
}
