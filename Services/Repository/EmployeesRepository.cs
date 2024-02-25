using System;
using System.Collections.Generic;
using System.Linq;
using Services.Models;

namespace Services.Repository
{
    public class EmployeesRepository
    {
        private readonly HotelManagementContext _context;

        public EmployeesRepository(HotelManagementContext context)
        {
            _context = context;
        }

        // Add methods for CRUD operations or other functionalities related to employees
        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(string employeeNumber)
        {
            return _context.Employees.FirstOrDefault(e => e.EmployeeNumber == employeeNumber);
        }

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(string employeeNumber)
        {
            var employee = _context.Employees.Find(employeeNumber);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

        // Add more methods as needed
    }
}
