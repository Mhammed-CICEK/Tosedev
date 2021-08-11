using System;
using System.Collections.Generic;

#nullable disable

namespace Tosedev.Models
{
    public partial class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid AdressId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Adress Adress { get; set; }

    }
}
