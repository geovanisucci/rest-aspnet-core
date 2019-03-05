using System.Collections.Generic;
using AutoMapper;
using Sample.BasicRestAspnetCore.EntitiesDomain;
using Sample.BasicRestAspnetCore.Host.Controllers.v1.BookEndpoints.ValueObjects;
using Sample.BasicRestAspnetCore.Host.Controllers.v1.LoginEndpoints.ValueObjects;
using Sample.BasicRestAspnetCore.Host.Controllers.v1.PersonEndpoints.ValueObjects;

namespace Sample.BasicRestAspnetCore.Host.AutoMapperParser
{
    /// <summary>
    /// AutoMapper profile parser.
    /// </summary>
    public class Parser : Profile
    {
        /// <summary>
        /// Constructor with mapper.
        /// </summary>
        public Parser()
        {
            CreateMap<Person, PersonValue>().ReverseMap();
            CreateMap<Book, BookValue>().ReverseMap();
            CreateMap<Users, UserValue>().ReverseMap();
        }
    }
}