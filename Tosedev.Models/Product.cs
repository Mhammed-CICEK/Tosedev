using System;
using System.Collections.Generic;

#nullable disable

namespace Tosedev.Models
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
            
        }

        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
       
    }
}
