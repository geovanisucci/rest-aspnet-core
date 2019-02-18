namespace Sample.BasicRestAspnetCore.Business.Person.Interface
{
    using System.Collections.Generic;
    using Sample.BasicRestAspnetCore.EntitiesDomain;
   
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}