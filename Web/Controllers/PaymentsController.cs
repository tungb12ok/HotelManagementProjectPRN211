using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Services.Models;

namespace Web.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly HotelManagementContext _context;

        public PaymentsController(HotelManagementContext context)
        {
            _context = context;
        }

        // GET: Payments
        public IActionResult Index()
        {
            var payments = _context.Payments
                .Include(p => p.AccountNumberNavigation)
                .Include(p => p.EmployeeNumberNavigation)
                .ToList();

            return View(payments);
        }

       

        // GET: Payments/Create
        public IActionResult Create(int id)
        {
            var customersList = _context.Customers.Select(c => new SelectListItem
            {
                Value = c.AccountNumber.ToString(),
                Text = $"{c.LastName} {c.FirstName}"
            }).ToList();

            var employeesList = _context.Employees.Select(e => new SelectListItem
            {
                Value = e.EmployeeNumber.ToString(),
                Text = $"{e.LastName} {e.FirstName}"
            }).ToList();

            ViewData["AccountNumber"] = new SelectList(customersList, "Value", "Text");
            ViewData["EmployeeNumber"] = new SelectList(employeesList, "Value", "Text");
            ViewData["RoomId"] = id;
            return View();
        }

        // POST: Payments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ReceiptNumber,EmployeeNumber,AccountNumber,AmountCharged,TaxRate")] Payment payment)
        {
            payment.PaymentDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(payment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountNumber"] = new SelectList(_context.Customers, "AccountNumber", "AccountNumber", payment.AccountNumber);
            ViewData["EmployeeNumber"] = new SelectList(_context.Employees, "EmployeeNumber", "EmployeeNumber", payment.EmployeeNumber);
            return View(payment);
        }

       

        // GET: Payments/Delete/5
        public IActionResult Delete(int? id)
        {
            if (_context.Payments == null)
            {
                return Problem("Entity set 'HotelManagementContext.Payments'  is null.");
            }
            var payment = _context.Payments.Find(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

      

        private bool PaymentExists(int id)
        {
            return (_context.Payments?.Any(e => e.ReceiptNumber == id)).GetValueOrDefault();
        }
    }
}
