using System;
using System.ComponentModel.DataAnnotations;

namespace lab1.Data.Entities
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
