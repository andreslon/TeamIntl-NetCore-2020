using System;
using System.Collections.Generic;
using lab1.Data.Entities;

namespace lab1.Data.Interfaces
{
    public interface IEmployeeRepository
    { 
        List<Employee> GetEmployees();
        Employee GetEmployeeById(Guid id);
        bool SaveEmployee(Employee employee);
        bool UpdateEmployee(Guid id,Employee employee);
        bool DeleteEmployee(Guid id); 
    }
}
