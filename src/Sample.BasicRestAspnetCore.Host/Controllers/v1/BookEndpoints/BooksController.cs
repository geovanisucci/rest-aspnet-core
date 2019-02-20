namespace Sample.BasicRestAspnetCore.Host.Controllers.v1.BookEndpoints
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Sample.BasicRestAspnetCore.Business.BookBusiness.Interface;
    using Sample.BasicRestAspnetCore.Business.Person.Interface;
    using Sample.BasicRestAspnetCore.EntitiesDomain;
    using Sample.BasicRestAspnetCore.Host.Controllers.v1.BookEndpoints.ValueObjects;

    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BooksController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get([FromServices]IBookBusiness bookBusiness, [FromServices]IMapper mapper)
        {
            var resultDomain = bookBusiness.FindAll();
            return Ok(mapper.Map<List<BookValue>>(resultDomain));
        }


        [HttpGet("{id}")]
        public IActionResult Get(long id, [FromServices]IBookBusiness bookBusiness, [FromServices]IMapper mapper)
        {
            var resultDomain = bookBusiness.FindById(id);
            return Ok(mapper.Map<BookValue>(resultDomain));
        }


        [HttpPost]
        public IActionResult Post([FromBody] BookValue value, [FromServices]IBookBusiness bookBusiness, [FromServices]IMapper mapper)
        {
            var bookDomain = mapper.Map<Book>(value);
            var bookVO = mapper.Map<BookValue>(bookBusiness.Create(bookDomain));
            return Ok(bookVO);
        }


        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] BookValue value, [FromServices]IBookBusiness bookBusiness, [FromServices]IMapper mapper)
        {
            value.Id = id;
            var bookDomain = mapper.Map<Book>(value);
            var bookVO = mapper.Map<BookValue>(bookBusiness.Update(bookDomain));

            return Ok(bookVO);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices]IBookBusiness bookBusiness)
        {
            bookBusiness.Delete(id);
            return Ok();
        }
    }
}