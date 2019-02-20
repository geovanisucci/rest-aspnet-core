namespace Sample.BasicRestAspnetCore.Data.Repositories.Person.Interface
{
    using System.Collections.Generic;
    using Sample.BasicRestAspnetCore.Data.Context;
    using Sample.BasicRestAspnetCore.Data.Repositories.GenericRepository;
    using Sample.BasicRestAspnetCore.EntitiesDomain;

    public interface IPersonRepository : IRepository<Person>
    {
      
    }
}