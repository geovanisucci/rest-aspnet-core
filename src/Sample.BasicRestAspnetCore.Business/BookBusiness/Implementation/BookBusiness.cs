using System.Collections.Generic;
using Sample.BasicRestAspnetCore.Business.BookBusiness.Interface;
using Sample.BasicRestAspnetCore.Data.Repositories.BookRepository.Interface;
using Sample.BasicRestAspnetCore.EntitiesDomain;

namespace Sample.BasicRestAspnetCore.Business.BookBusiness.Implementation
{
    public class BookBusiness : IBookBusiness
    {
        private readonly IBookRepository _repository;
        public BookBusiness(IBookRepository repository)
        {
            _repository = repository;
        }
        public Book Create(Book person)
        {
            return 
            _repository
            .Create(person);
        }

        public void Delete(long id)
        {
           _repository
           .Delete(id);
           
        }

        public List<Book> FindAll()
        {
           return 
           _repository
           .FindAll();
        }

        public Book FindById(long id)
        {
          return
          _repository
          .FindById(id);
        }

        public Book Update(Book person)
        {
            return
            _repository
            .Update(person);
        }
    }
}