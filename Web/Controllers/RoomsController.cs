using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Services.Models;
using Web.Models;

namespace Web.Controllers
{
    public class RoomsController : Controller
    {
        private readonly HotelManagementContext _context;

        public RoomsController(HotelManagementContext context)
        {
            _context = context;
        }

        // GET: Rooms
        public IActionResult Index()
        {
            return _context.Rooms != null
                ? View(_context.Rooms.ToList())
                : Problem("Entity set 'HotelManagementContext.Rooms' is null.");
        }

        // GET: Rooms/Details/5
        public IActionResult Details(string id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = _context.Rooms.FirstOrDefault(m => m.RoomNumber == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            ViewBag.RoomStatusList = new SelectList(Enum.GetValues(typeof(RoomStatusEnum)));
            ViewBag.BedTypeList = new SelectList(Enum.GetValues(typeof(BedTypeEnum)));
            ViewBag.TypeRoomList = new SelectList(Enum.GetValues(typeof(TypeRoomEnum)));

            return View();
        }

        // POST: Rooms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RoomNumber,RoomType,BedType,Rate,RoomStatus")] Room room)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(room);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    ViewBag.MessError = "Room Number does exits!";
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.RoomStatusList = new SelectList(Enum.GetValues(typeof(RoomStatusEnum)));
            ViewBag.BedTypeList = new SelectList(Enum.GetValues(typeof(BedTypeEnum)));
            ViewBag.TypeRoomList = new SelectList(Enum.GetValues(typeof(TypeRoomEnum)));

            return View(room);
        }

        // GET: Rooms/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = _context.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }

            ViewBag.RoomStatusList = new SelectList(Enum.GetValues(typeof(RoomStatusEnum)));
            ViewBag.BedTypeList = new SelectList(Enum.GetValues(typeof(BedTypeEnum)));
            ViewBag.TypeRoomList = new SelectList(Enum.GetValues(typeof(TypeRoomEnum)));

            return View(room);
        }

        // POST: Rooms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("RoomNumber,RoomType,BedType,Rate,RoomStatus")] Room room)
        {
            if (id != room.RoomNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.RoomNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.RoomStatusList = new SelectList(Enum.GetValues(typeof(RoomStatusEnum)));
            ViewBag.BedTypeList = new SelectList(Enum.GetValues(typeof(BedTypeEnum)));
            ViewBag.TypeRoomList = new SelectList(Enum.GetValues(typeof(TypeRoomEnum)));

            return View(room);
        }

        // GET: Rooms/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = _context.Rooms.FirstOrDefault(m => m.RoomNumber == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            if (_context.Rooms == null)
            {
                return Problem("Entity set 'HotelManagementContext.Rooms' is null.");
            }

            var room = _context.Rooms.Find(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(string id)
        {
            return (_context.Rooms?.Any(e => e.RoomNumber == id)).GetValueOrDefault();
        }
    }
}
