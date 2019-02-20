using System.Collections.Generic;
using AutoMapper;
using Sample.BasicRestAspnetCore.EntitiesDomain;
using Sample.BasicRestAspnetCore.Host.Controllers.v1.BookEndpoints.ValueObjects;
using Sample.BasicRestAspnetCore.Host.Controllers.v1.PersonEndpoints.ValueObjects;

namespace Sample.BasicRestAspnetCore.Host.AutoMapperParser
{
    public class Parser : Profile
    {
        public Parser()
        {
            CreateMap<Person, PersonValue>().ReverseMap();
            CreateMap<Book, BookValue>().ReverseMap();
        }
    }
}