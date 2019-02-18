namespace Sample.BasicRestAspnetCore.Data.Repositories.Person.Interface
{
    using System.Collections.Generic;
    using Sample.BasicRestAspnetCore.Data.Context;
    using Sample.BasicRestAspnetCore.EntitiesDomain;

    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}