﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using lab.Data.Entities;

namespace lab.Data.Interfaces
{
    public interface IEmployeeRepository
    { 
        List<Employee> GetEmployees();
        Employee GetEmployeeById(Guid id);
        Task<bool> SaveEmployee(Employee employee);
        Task<bool> UpdateEmployee(Guid id,Employee employee);
        Task<bool> DeleteEmployee(Guid id); 
    }
}
