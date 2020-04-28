using System;
using lab1.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace lab1.Data
{
    public class TeamDbContext: DbContext
    {
        public TeamDbContext(DbContextOptions<TeamDbContext> options) : base(options)
        {

        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
