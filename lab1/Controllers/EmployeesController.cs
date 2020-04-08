using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab1.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lab1.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var employees = EmployeeRepository.GetEmployees();

            return Ok(employees);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
