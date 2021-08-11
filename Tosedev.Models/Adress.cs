using System;
using System.Collections.Generic;

#nullable disable

namespace Tosedev.Models
{
    public partial class Adress
    {
        public Adress()
        {
            Customers = new HashSet<Customer>();
            Orders = new HashSet<Order>();
        }

        public Guid AdressId { get; set; }
        public string AdressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CityCode { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
