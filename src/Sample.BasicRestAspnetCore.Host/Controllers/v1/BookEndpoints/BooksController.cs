namespace Sample.BasicRestAspnetCore.Host.Controllers.v1.BookEndpoints
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Sample.BasicRestAspnetCore.Business.BookBusiness.Interface;
    using Sample.BasicRestAspnetCore.Business.Person.Interface;
    using Sample.BasicRestAspnetCore.EntitiesDomain;

    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BooksController : ControllerBase
    {
       
        [HttpGet]
        public IActionResult Get([FromServices]IBookBusiness bookBusiness)
        {
            return Ok(bookBusiness.FindAll().AsEnumerable());
        }

      
        [HttpGet("{id}")]
        public IActionResult Get(long id, [FromServices]IPersonBusiness personService)
        {
            return Ok(personService.FindById(id));
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] Person value, [FromServices]IPersonBusiness personService)
        {
            return Ok(personService.Create(value));
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Person value, [FromServices]IPersonBusiness personService)
        {
            value.Id = id;
            return Ok(personService.Update(value));
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices]IPersonBusiness personService)
        {
            personService.Delete(id);
            return Ok();
        }
    }
}