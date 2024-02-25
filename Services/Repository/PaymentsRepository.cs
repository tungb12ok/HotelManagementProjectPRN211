using System;
using System.Collections.Generic;
using System.Linq;
using Services.Models;

namespace Services.Repository
{
    public class PaymentsRepository
    {
        private readonly HotelManagementContext _context;

        public PaymentsRepository(HotelManagementContext context)
        {
            _context = context;
        }

        // Add methods for CRUD operations or other functionalities related to payments
        public List<Payment> GetAllPayments()
        {
            return _context.Payments.ToList();
        }

        public Payment GetPaymentById(int paymentId)
        {
            return _context.Payments.FirstOrDefault(p => p.ReceiptNumber == paymentId);
        }

        public void AddPayment(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }

        public void UpdatePayment(Payment payment)
        {
            _context.Payments.Update(payment);
            _context.SaveChanges();
        }

        public void DeletePayment(int paymentId)
        {
            var payment = _context.Payments.Find(paymentId);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                _context.SaveChanges();
            }
        }

        // Add more methods as needed
    }
}
