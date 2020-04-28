using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab1.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lab1.Controllers
{
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        // GET: api/values
        [HttpGet]
        [ProducesResponseType(typeof(List<Role>),200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult Get()
        {
            try
            {
                return Ok(null);
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }  
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(typeof(Role), 201)]
        public IActionResult Post([FromBody] string value)
        { 
            throw new NotImplementedException();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
