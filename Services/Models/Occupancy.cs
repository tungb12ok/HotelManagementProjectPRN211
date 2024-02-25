using System;
using System.Collections.Generic;

namespace Services.Models
{
    public partial class Occupancy
    {
        public int OccupancyNumber { get; set; }
        public string? EmployeeNumber { get; set; }
        public DateTime? DateOccupied { get; set; }
        public string? AccountNumber { get; set; }
        public string? RoomNumber { get; set; }
        public double? RateApplied { get; set; }
        public double? PhoneCharge { get; set; }

        public virtual Customer? AccountNumberNavigation { get; set; }
        public virtual Employee? EmployeeNumberNavigation { get; set; }
        public virtual Room? RoomNumberNavigation { get; set; }
    }
}
