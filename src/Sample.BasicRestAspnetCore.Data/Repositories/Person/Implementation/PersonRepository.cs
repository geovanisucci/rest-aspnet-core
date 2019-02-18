using System.Collections.Generic;
using System.Linq;
using Sample.BasicRestAspnetCore.Data.Context;
using Sample.BasicRestAspnetCore.Data.Repositories.Person.Interface;
using Sample.BasicRestAspnetCore.EntitiesDomain;

namespace Sample.BasicRestAspnetCore.Data.Repositories.Person.Implementation
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MySqlContext _mySqlContext;

        public PersonRepository(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }
        public Sample.BasicRestAspnetCore.EntitiesDomain.Person Create(Sample.BasicRestAspnetCore.EntitiesDomain.Person person)
        {
            try
            {
                _mySqlContext.Add(person);
                _mySqlContext.SaveChanges();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

            return person;
        }

        public void Delete(long id)
        {
            try
            {
                var personResult = FindById(id);
                if (personResult != null)
                {
                    _mySqlContext.Persons.Remove(personResult);
                    _mySqlContext.SaveChanges();
                }
               

            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public List<Sample.BasicRestAspnetCore.EntitiesDomain.Person> FindAll()
        {
            return _mySqlContext.Persons.ToList();
        }

        public Sample.BasicRestAspnetCore.EntitiesDomain.Person FindById(long id)
        {
            return _mySqlContext.Persons.Find(id);
        }

        public Sample.BasicRestAspnetCore.EntitiesDomain.Person Update(Sample.BasicRestAspnetCore.EntitiesDomain.Person person)
        {
            try
            {
                var personResult = FindById(person.Id);
                if (personResult != null)
                {
                    _mySqlContext.Entry(personResult).CurrentValues.SetValues(person);
                    _mySqlContext.SaveChanges();
                }
                else
                {
                    return new Sample.BasicRestAspnetCore.EntitiesDomain.Person();
                }

            }
            catch (System.Exception ex)
            {

                throw ex;
            }


            return person;

        }
    }
}