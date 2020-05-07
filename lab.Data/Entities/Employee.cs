using System;
using System.ComponentModel.DataAnnotations;

namespace lab.Data.Entities
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
