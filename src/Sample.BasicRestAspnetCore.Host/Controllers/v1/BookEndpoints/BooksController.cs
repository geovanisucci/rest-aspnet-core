namespace Sample.BasicRestAspnetCore.Host.Controllers.v1.BookEndpoints
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Sample.BasicRestAspnetCore.Business.BookBusiness.Interface;
    using Sample.BasicRestAspnetCore.Business.Person.Interface;
    using Sample.BasicRestAspnetCore.EntitiesDomain;
    using Sample.BasicRestAspnetCore.Host.Controllers.v1.BookEndpoints.ValueObjects;

    /// <summary>
    /// Books endpoints.
    /// </summary>

    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BooksController : ControllerBase
    {
        /// <summary>
        /// Get books.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Books/v1
        ///     {}
        ///
        /// </remarks>
        /// <param name="bookBusiness"></param>
        /// <param name="mapper"></param>
        /// <returns>List of books.</returns>
        /// <response code="200">List of books.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<BookValue>), 200)]
        [ProducesResponseType(400)]
        [Authorize("Bearer")]
        public IActionResult Get([FromServices]IBookBusiness bookBusiness, [FromServices]IMapper mapper)
        {
            var resultDomain = bookBusiness.FindAll();
            var resultVO = mapper.Map<List<BookValue>>(resultDomain);
            return Ok(resultVO);
        }
        /// <summary>
        /// Get a book.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Books/v1/1
        ///     {}
        ///
        /// </remarks>
        /// <param name="bookBusiness"></param>
        /// <param name="mapper"></param>
        /// <param name="id"></param>
        /// <returns>A book returned.</returns>
        /// <response code="200">A book returned.</response>
        /// <response code="401">Book not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BookValue), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        public IActionResult Get(long id, [FromServices]IBookBusiness bookBusiness, [FromServices]IMapper mapper)
        {
            var resultDomain = bookBusiness.FindById(id);
            if (resultDomain != null)
            {
                return Ok(mapper.Map<BookValue>(resultDomain));

            }
            else
            {
                return NotFound();
            }
        }
        /// <summary>
        /// Create a book.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Books/v1
        ///     {}
        ///
        /// </remarks>
        /// <param name="bookBusiness"></param>
        /// <param name="mapper"></param>
        /// <param name="value"></param>
        /// <returns>A book created.</returns>
        /// <response code="201">A book created.</response>
        [HttpPost]
        [ProducesResponseType(typeof(BookValue), 201)]
        [ProducesResponseType(400)]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody] BookValue value, [FromServices]IBookBusiness bookBusiness, [FromServices]IMapper mapper)
        {
            var bookDomain = mapper.Map<Book>(value);

            var bookCreated = mapper.Map<BookValue>(bookBusiness.Create(bookDomain));

            return Created("Post:Book", bookCreated);
        }
        /// <summary>
        /// Update a book.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Books/v1/1
        ///     {}
        ///
        /// </remarks>
        /// <param name="bookBusiness"></param>
        /// <param name="mapper"></param>
        /// <param name="value"></param>
        /// <param name="id"></param>
        /// <returns>A book returned.</returns>
        /// <response code="200">A book updated returned.</response>
        /// <response code="401">Book not found.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BookValue), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        public IActionResult Put(long id, [FromBody] BookValue value, [FromServices]IBookBusiness bookBusiness, [FromServices]IMapper mapper)
        {
            value.Id = id;
            var bookDomain = mapper.Map<Book>(value);

            var bookUpdated = bookBusiness.Update(bookDomain);

            if (bookUpdated != null)
            {
                return Ok(mapper.Map<BookValue>(bookUpdated));
            }
            else
            {
                return NotFound();
            }
        }
         /// <summary>
        /// Delete a book.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/Books/v1/1
        ///     {}
        ///
        /// </remarks>
        /// <param name="bookBusiness"></param>
        /// <param name="id"></param>
        /// <response code="200">Ok, deleted.</response>
        /// <response code="401">Book not found.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        public IActionResult Delete(int id, [FromServices]IBookBusiness bookBusiness)
        {
            bookBusiness.Delete(id);
            return Ok();
        }
    }
}