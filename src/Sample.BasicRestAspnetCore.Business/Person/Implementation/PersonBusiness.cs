using System.Collections.Generic;
using Sample.BasicRestAspnetCore.Business.Person.Interface;
using Sample.BasicRestAspnetCore.Data.Context;
using Sample.BasicRestAspnetCore.Data.Repositories.Person.Interface;
using Sample.BasicRestAspnetCore.EntitiesDomain;

namespace Sample.BasicRestAspnetCore.Business.Person.Implementation
{
    public class PersonBusiness : IPersonBusiness
    {

        private readonly IPersonRepository _repository;
        public PersonBusiness(IPersonRepository repository)
        {
            _repository = repository;
        }
        public EntitiesDomain.Person Create(EntitiesDomain.Person person)
        {
           return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<EntitiesDomain.Person> FindAll()
        {
           return _repository.FindAll();
        }

        public EntitiesDomain.Person FindById(long id)
        {
           return _repository.FindById(id);
        }

        public EntitiesDomain.Person Update(EntitiesDomain.Person person)
        {
           return _repository.Update(person);
        }
    }
}