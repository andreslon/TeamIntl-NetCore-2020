using System;
using lab.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace lab.Data
{
    public class TeamDbContext: DbContext
    {
        public TeamDbContext(DbContextOptions<TeamDbContext> options) : base(options)
        {

        }


        public DbSet<Employee> Employees { get; set; } 
    }
}
