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
    /// <summary>
    /// Persons Endpoints.
    /// </summary>
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonsController : ControllerBase
    {
        /// <summary>
        /// Get Persons.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Persons/v1
        ///     {}
        ///
        /// </remarks>
        /// <param name="personService"></param>
        /// <param name="mapper"></param>
        /// <returns>List of persons.</returns>
        /// <response code="200">List of persons.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<PersonValue>), 200)]
        [ProducesResponseType(400)]
        public IActionResult Get([FromServices]IPersonBusiness personService, [FromServices]IMapper mapper)
        {
            var resultDomain = personService.FindAll();
            var resultVO = mapper.Map<List<PersonValue>>(resultDomain);
            return Ok(resultVO);

        }
        /// <summary>
        /// Get a person.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Persons/v1/1
        ///     {}
        ///
        /// </remarks>
        /// <param name="personService"></param>
        /// <param name="mapper"></param>
        /// <param name="id"></param>
        /// <returns>A person returned.</returns>
        /// <response code="200">A person returned.</response>
        /// <response code="401">Person not found.</response>
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
        /// <summary>
        /// Create a person.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Persons/v1
        ///     {}
        ///
        /// </remarks>
        /// <param name="personService"></param>
        /// <param name="mapper"></param>
        /// <param name="value"></param>
        /// <returns>A person created.</returns>
        /// <response code="201">A person created.</response>
        [HttpPost]
        [ProducesResponseType(typeof(PersonValue), 201)]
        [ProducesResponseType(400)]

        public IActionResult Post([FromBody] PersonValue value, [FromServices]IPersonBusiness personService, [FromServices]IMapper mapper)
        {

            var personDomain = mapper.Map<Person>(value);

            var personCreated = mapper.Map<PersonValue>(personService.Create(personDomain));

            return Created("Post:Person", personCreated);

        }

        /// <summary>
        /// Update a person.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Persons/v1/1
        ///     {}
        ///
        /// </remarks>
        /// <param name="personService"></param>
        /// <param name="mapper"></param>
        /// <param name="value"></param>
        /// <param name="id"></param>
        /// <returns>A person updated returned.</returns>
        /// <response code="200">A person updated returned.</response>
        /// <response code="401">Person not found.</response>
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

        /// <summary>
        /// Delete a person.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/Persons/v1/1
        ///     {}
        ///
        /// </remarks>
        /// <param name="personService"></param>
        /// <param name="id"></param>
        /// <response code="200">Ok, deleted.</response>
        /// <response code="401">Person not found.</response>
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