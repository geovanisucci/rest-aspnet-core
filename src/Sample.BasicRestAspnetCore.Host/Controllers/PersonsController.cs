using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.BasicRestAspnetCore.Host.Models;
using Sample.BasicRestAspnetCore.Host.Services;

namespace Sample.BasicRestAspnetCore.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get([FromServices]IPersonService personService)
        {
            return Ok(personService.FindAll().AsEnumerable());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(long id, [FromServices]IPersonService personService)
        {
            return Ok(personService.FindById(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
