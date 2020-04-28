using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab.Data.Entities;
using lab.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lab.Controllers
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
        public IActionResult Get(Guid id)
        {
            var employee = EmployeeRepository.GetEmployeeById(id);
            return Ok(employee);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Employee entity)
        {
            var IsSuccess = await EmployeeRepository.SaveEmployee(entity);
            return Ok(IsSuccess);   
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]Employee entity)
        {
            var IsSuccess = await EmployeeRepository.UpdateEmployee(id, entity);
            return Ok(IsSuccess);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var IsSuccess = await EmployeeRepository.DeleteEmployee(id);
            return Ok(IsSuccess);
        }
    }
}
