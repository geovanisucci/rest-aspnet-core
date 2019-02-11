using System.Collections.Generic;
using Sample.BasicRestAspnetCore.Host.Models;

namespace Sample.BasicRestAspnetCore.Host.Services
{
    public interface IPersonService
    {
         Person Create(Person person); 
         Person FindById(long id); 
         List<Person> FindAll();
         Person Update(Person person);
         void Delete(long id);
    }
}