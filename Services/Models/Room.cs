using System;
using System.Collections.Generic;

namespace Services.Models
{
    public partial class Room
    {
        public Room()
        {
            Occupancies = new HashSet<Occupancy>();
        }

        public string RoomNumber { get; set; } = null!;
        public string? RoomType { get; set; }
        public string? BedType { get; set; }
        public double? Rate { get; set; }
        public string? RoomStatus { get; set; }

        public virtual ICollection<Occupancy> Occupancies { get; set; }
    }
}
