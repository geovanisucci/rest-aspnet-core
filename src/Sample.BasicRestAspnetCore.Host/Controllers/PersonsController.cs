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
        public IActionResult Get([FromServices]IPersonService personService)
        {
            return Ok(personService.FindAll().AsEnumerable());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(long id, [FromServices]IPersonService personService)
        {
            return Ok(personService.FindById(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Person value, [FromServices]IPersonService personService)
        {
            return Ok(personService.Create(value));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Person value, [FromServices]IPersonService personService)
        {
            value.Id = id;
            return Ok(personService.Update(value));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices]IPersonService personService)
        {
            personService.Delete(id);
            return Ok();
        }
    }
}
