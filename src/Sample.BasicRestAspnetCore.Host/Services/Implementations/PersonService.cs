using System.Collections.Generic;
using System.Linq;
using Sample.BasicRestAspnetCore.Host.Models;
using Sample.BasicRestAspnetCore.Host.Models.Context;

namespace Sample.BasicRestAspnetCore.Host.Services.Implementations
{
    public class PersonService : IPersonService
    {

        private readonly MySqlContext _mySqlContext;

        public PersonService(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }
        public Person Create(Person person)
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

        public List<Person> FindAll()
        {
            return _mySqlContext.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _mySqlContext.Persons.Find(id);
        }

        public Person Update(Person person)
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
                    return new Person();
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