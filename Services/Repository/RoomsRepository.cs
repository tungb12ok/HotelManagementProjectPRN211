using System;
using System.Collections.Generic;
using System.Linq;
using Services.Models;

namespace Services.Repository
{
    public class RoomsRepository
    {
        private readonly HotelManagementContext _context;

        public RoomsRepository(HotelManagementContext context)
        {
            _context = context;
        }

        // Add methods for CRUD operations or other functionalities related to rooms
        public List<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }

        public Room GetRoomById(string roomNumber)
        {
            return _context.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
        }

        public void AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public void UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            _context.SaveChanges();
        }

        public void DeleteRoom(string roomNumber)
        {
            var room = _context.Rooms.Find(roomNumber);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
        }

        // Add more methods as needed
    }
}
