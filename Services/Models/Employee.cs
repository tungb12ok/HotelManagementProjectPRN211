using System;
using System.Collections.Generic;

namespace Services.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Occupancies = new HashSet<Occupancy>();
            Payments = new HashSet<Payment>();
        }

        public string EmployeeNumber { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }

        public virtual ICollection<Occupancy> Occupancies { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
