namespace Sample.BasicRestAspnetCore.Host.Controllers.v1.LoginEndpoints
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Sample.BasicRestAspnetCore.Business.UserBusiness.Interface;
    using Sample.BasicRestAspnetCore.EntitiesDomain;
    using Sample.BasicRestAspnetCore.Host.Controllers.v1.LoginEndpoints.ValueObjects;

    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class LoginController : ControllerBase
    {
         /// <summary>
        /// Request authorization.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Login/v1
        ///     {}
        ///
        /// </remarks>
        /// <param name="business"></param>
        /// <param name="mapper"></param>
        /// <param name="user"></param>
        /// <returns>The token to use on endpoints requests</returns>
        /// <response code="200">The token to use on endpoints requests</response>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromServices] IUserBusiness business, [FromServices]IMapper mapper, [FromBody]UserValue user)
        {
            if(user == null) return BadRequest();

            var userDomain = mapper.Map<Users>(user);

            var result = business.FindByLogin(userDomain);

            return Ok(result);
        }
    }
}