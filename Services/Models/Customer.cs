using System;
using System.Collections.Generic;

namespace Services.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Occupancies = new HashSet<Occupancy>();
            Payments = new HashSet<Payment>();
        }

        public string AccountNumber { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmergencyName { get; set; }
        public string? EmergencyPhone { get; set; }

        public virtual ICollection<Occupancy> Occupancies { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
