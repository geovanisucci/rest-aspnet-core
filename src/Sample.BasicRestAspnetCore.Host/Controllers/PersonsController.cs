using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sample.BasicRestAspnetCore.Business.Person.Interface;
using Sample.BasicRestAspnetCore.EntitiesDomain;


namespace Sample.BasicRestAspnetCore.Host.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get([FromServices]IPersonBusiness personService)
        {
            return Ok(personService.FindAll().AsEnumerable());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(long id, [FromServices]IPersonBusiness personService)
        {
            return Ok(personService.FindById(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Person value, [FromServices]IPersonBusiness personService)
        {
            return Ok(personService.Create(value));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Person value, [FromServices]IPersonBusiness personService)
        {
            value.Id = id;
            return Ok(personService.Update(value));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices]IPersonBusiness personService)
        {
            personService.Delete(id);
            return Ok();
        }
    }
}
