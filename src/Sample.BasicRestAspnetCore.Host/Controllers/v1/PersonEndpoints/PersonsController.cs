namespace Sample.BasicRestAspnetCore.Host.Controllers.v1.PersonEndpoints
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Sample.BasicRestAspnetCore.Business.Person.Interface;
    using Sample.BasicRestAspnetCore.EntitiesDomain;
    using Sample.BasicRestAspnetCore.Host.Controllers.v1.PersonEndpoints.ValueObjects;

    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonsController: ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get([FromServices]IPersonBusiness personService, [FromServices]IMapper mapper)
        {
            var resultDomain = personService.FindAll();
            var resultVO = mapper.Map<List<PersonValue>>(resultDomain);
            return Ok(resultVO);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(long id, [FromServices]IPersonBusiness personService, [FromServices]IMapper mapper)
        {
            var resultDomain = personService.FindById(id);
            return Ok(mapper.Map<PersonValue>(resultDomain));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] PersonValue value, [FromServices]IPersonBusiness personService, [FromServices]IMapper mapper)
        {

            var personDomain = mapper.Map<Person>(value);

            var personCreated = personService.Create(personDomain);

            return Ok(mapper.Map<PersonValue>(personCreated));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PersonValue value, 
                                [FromServices]IPersonBusiness personService,
                                [FromServices]IMapper mapper)
        {
            value.Id = id;
            var personDomain = mapper.Map<Person>(value);

            var personUpdated = personService.Update(personDomain);

            return Ok(mapper.Map<PersonValue>(personUpdated));
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