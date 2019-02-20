using System.Collections.Generic;
using System.Linq;
using Sample.BasicRestAspnetCore.Data.Context;
using Sample.BasicRestAspnetCore.Data.Repositories.GenericRepository;
using Sample.BasicRestAspnetCore.Data.Repositories.Person.Interface;
using Sample.BasicRestAspnetCore.EntitiesDomain;

namespace Sample.BasicRestAspnetCore.Data.Repositories.Person.Implementation
{
    public class PersonRepository : GenericRepository<Sample.BasicRestAspnetCore.EntitiesDomain.Person>, IPersonRepository
    {
        public PersonRepository(MySqlContext context) : base(context)
        {
        }
    }
}