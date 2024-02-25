using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Models;

namespace Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly HotelManagementContext _context;

        public CustomersController(HotelManagementContext context)
        {
            _context = context;
        }

        // GET: Customers
        public IActionResult Index()
        {
            return _context.Customers != null
                ? View(_context.Customers.ToList())
                : Problem("Entity set 'HotelManagementContext.Customers' is null.");
        }

        // GET: Customers/Details/5
        public IActionResult Details(string id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = _context.Customers.FirstOrDefault(m => m.AccountNumber == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("AccountNumber,FirstName,LastName,PhoneNumber,EmergencyName,EmergencyPhone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(customer);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    ViewBag.MessError = "Customer Number does exits!";
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("AccountNumber,FirstName,LastName,PhoneNumber,EmergencyName,EmergencyPhone")] Customer customer)
        {
            if (id != customer.AccountNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.AccountNumber))
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

            return View(customer);
        }

        // GET: Customers/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = _context.Customers.FirstOrDefault(m => m.AccountNumber == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'HotelManagementContext.Customers' is null.");
            }

            var customer = _context.Customers.Find(id);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(string id)
        {
            return (_context.Customers?.Any(e => e.AccountNumber == id)).GetValueOrDefault();
        }
    }
}
