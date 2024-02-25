using System;
using System.Collections.Generic;
using System.Linq;
using Services.Models;

namespace Services.Repository
{
    public class CustomersRepository
    {
        private readonly HotelManagementContext _context;

        public CustomersRepository(HotelManagementContext context)
        {
            _context = context;
        }

        // Add methods for CRUD operations or other functionalities related to customers
        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(string accountNumber)
        {
            return _context.Customers.FirstOrDefault(c => c.AccountNumber == accountNumber);
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(string accountNumber)
        {
            var customer = _context.Customers.Find(accountNumber);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        // Add more methods as needed
    }
}
