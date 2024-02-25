using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Services.Models;
using System.Linq;
using Web.Models;

namespace Web.Controllers
{
    public class OccupanciesController : Controller
    {
        private readonly HotelManagementContext _context;

        public OccupanciesController(HotelManagementContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var hotelManagementContext = _context.Occupancies
                .Include(o => o.AccountNumberNavigation)
                .Include(o => o.EmployeeNumberNavigation)
                .Include(o => o.RoomNumberNavigation);

            return View(hotelManagementContext.ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null || _context.Occupancies == null)
            {
                return NotFound();
            }

            var occupancy = _context.Occupancies
                .Include(o => o.AccountNumberNavigation)
                .Include(o => o.EmployeeNumberNavigation)
                .Include(o => o.RoomNumberNavigation)
                .FirstOrDefault(m => m.OccupancyNumber == id);

            if (occupancy == null)
            {
                return NotFound();
            }

            return View(occupancy);
        }

        public IActionResult Create(int id)
        {
            ViewData["AccountNumber"] = new SelectList(_context.Customers, "AccountNumber", "AccountNumber");
            ViewData["EmployeeNumber"] = new SelectList(_context.Employees, "EmployeeNumber", "EmployeeNumber");
            ViewData["RoomNumber"] = id;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("OccupancyNumber,EmployeeNumber,DateOccupied,AccountNumber,RoomNumber,RateApplied,PhoneCharge")] Occupancy occupancy)
        {
            if (ModelState.IsValid)
            {
                Room r = _context.Rooms.FirstOrDefault(x => x.RoomNumber == occupancy.RoomNumber);
                r.RoomStatus = RoomStatusEnum.Occupied.ToString();
                occupancy.DateOccupied = DateTime.Now;
                _context.Add(occupancy);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MessSuccess = "Asign Room successfuly!";
            return View("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Occupancies == null)
            {
                return NotFound();
            }

            var occupancy = _context.Occupancies
                .Include(o => o.AccountNumberNavigation)
                .Include(o => o.EmployeeNumberNavigation)
                .Include(o => o.RoomNumberNavigation)
                .FirstOrDefault(m => m.OccupancyNumber == id);

            if (occupancy == null)
            {
                return NotFound();
            }

            return View(occupancy);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Occupancies == null)
            {
                return Problem("Entity set 'HotelManagementContext.Occupancies'  is null.");
            }

            var occupancy = _context.Occupancies.Find(id);

            if (occupancy != null)
            {
                _context.Occupancies.Remove(occupancy);
            }

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private bool OccupancyExists(int id)
        {
            return (_context.Occupancies?.Any(e => e.OccupancyNumber == id)).GetValueOrDefault();
        }
    }
}
