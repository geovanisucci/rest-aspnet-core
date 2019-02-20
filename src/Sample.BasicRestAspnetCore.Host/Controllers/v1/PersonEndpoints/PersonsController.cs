namespace Sample.BasicRestAspnetCore.Host.Controllers.v1.PersonEndpoints
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Sample.BasicRestAspnetCore.Business.Person.Interface;
    using Sample.BasicRestAspnetCore.EntitiesDomain;
    using Sample.BasicRestAspnetCore.Host.Controllers.v1.PersonEndpoints.ValueObjects;
    using System;

    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonsController : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(typeof(List<PersonValue>), 200)]
        [ProducesResponseType(400)]
        public IActionResult Get([FromServices]IPersonBusiness personService, [FromServices]IMapper mapper)
        {
            var resultDomain = personService.FindAll();
            var resultVO = mapper.Map<List<PersonValue>>(resultDomain);
            return Ok(resultVO);

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PersonValue), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id, [FromServices]IPersonBusiness personService, [FromServices]IMapper mapper)
        {
            var resultDomain = personService.FindById(id);
            if (resultDomain != null)
            {
                return Ok(mapper.Map<PersonValue>(resultDomain));

            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [ProducesResponseType(typeof(PersonValue), 201)]
        [ProducesResponseType(400)]
        
        public IActionResult Post([FromBody] PersonValue value, [FromServices]IPersonBusiness personService, [FromServices]IMapper mapper)
        {

            var personDomain = mapper.Map<Person>(value);

            var personCreated = mapper.Map<PersonValue>(personService.Create(personDomain));

            return Created("Post:Person", personCreated);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PersonValue), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put(int id, [FromBody] PersonValue value,
                                [FromServices]IPersonBusiness personService,
                                [FromServices]IMapper mapper)
        {
            value.Id = id;
            var personDomain = mapper.Map<Person>(value);

            var personUpdated = personService.Update(personDomain);

            if (personUpdated != null)
            {
                return Ok(mapper.Map<PersonValue>(personUpdated));
            }
            else
            {
                return NotFound();
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int id, [FromServices]IPersonBusiness personService)
        {
            personService.Delete(id);
            return Ok();
        }
    }
}