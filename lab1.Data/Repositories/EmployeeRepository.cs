using System;
using System.Collections.Generic;
using System.Linq;
using lab1.Data.Entities;
using lab1.Data.Interfaces;

namespace lab1.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public TeamDbContext DbContext { get; set; }
        public EmployeeRepository(TeamDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public bool DeleteEmployee(Guid id)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployees()
        {
            var employees = DbContext.Employees.ToList();
            return employees;
        }

        public bool SaveEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEmployee(Guid id, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
