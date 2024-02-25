using System;
using System.Collections.Generic;
using System.Linq;
using Services.Models;

namespace Services.Repository
{
    public class OccupanciesRepository
    {
        private readonly HotelManagementContext _context;

        public OccupanciesRepository(HotelManagementContext context)
        {
            _context = context;
        }

        // Add methods for CRUD operations or other functionalities related to occupancies
        public List<Occupancy> GetAllOccupancies()
        {
            return _context.Occupancies.ToList();
        }

        public Occupancy GetOccupancyById(int occupancyId)
        {
            return _context.Occupancies.FirstOrDefault(o => o.OccupancyNumber == occupancyId);
        }

        public void AddOccupancy(Occupancy occupancy)
        {
            _context.Occupancies.Add(occupancy);
            _context.SaveChanges();
        }

        public void UpdateOccupancy(Occupancy occupancy)
        {
            _context.Occupancies.Update(occupancy);
            _context.SaveChanges();
        }

        public void DeleteOccupancy(int occupancyId)
        {
            var occupancy = _context.Occupancies.Find(occupancyId);
            if (occupancy != null)
            {
                _context.Occupancies.Remove(occupancy);
                _context.SaveChanges();
            }
        }

        // Add more methods as needed
    }
}
