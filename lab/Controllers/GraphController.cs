using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using lab.Data.Interfaces;
using lab.Graph;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lab.Controllers
{
    [Route("api/[controller]")]
    public class GraphController : Controller
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public GraphController(IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> GraphQL([FromBody]GraphDto query)
        {

            var inputs = query.Variables.ToInputs();
            var schema = new Schema()
            {
                Query= new EmployeeQuery(EmployeeRepository)
            };

            var result = await new DocumentExecuter().ExecuteAsync(x =>
            {
                x.Schema = schema;
                x.Query = query.Query;
                x.OperationName = query.OperationName;
                x.Inputs = inputs;
            });

            if (result.Errors?.Count>0)
            {
                return BadRequest(new { errors = result.Errors.Select(x => x.Message) }); 
            }

            return Ok(result.Data);
        }


    }
}
