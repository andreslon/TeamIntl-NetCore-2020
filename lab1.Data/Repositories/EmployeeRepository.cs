﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab1.Data.Entities;
using lab1.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab1.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public TeamDbContext DbContext { get; set; }
        public EmployeeRepository(TeamDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<bool> DeleteEmployee(Guid id)
        {
            try
            {
                var entity = GetEmployeeById(id);
                DbContext.Remove(entity);
                await DbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Employee GetEmployeeById(Guid id)
        { 
            Employee employee = DbContext.Employees.FirstOrDefault(x => x.Id == id);
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            var employees = DbContext.Employees.Include(x=> x.Role).ToList();
            return employees;
        }

        public async Task<bool> SaveEmployee(Employee employee)
        {
            try
            {
                await DbContext.AddAsync(employee);
                DbContext.Entry(employee).State = EntityState.Added;
                await DbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            } 
        }

        public async Task<bool> UpdateEmployee(Guid id, Employee employee)
        {
            var entity = GetEmployeeById(id);
            entity.Age = employee.Age;
            entity.BirthDate = employee.BirthDate;
            entity.LastName = employee.LastName;
            entity.Name = employee.Name;

            try
            {
                DbContext.Update(entity);
                await DbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}