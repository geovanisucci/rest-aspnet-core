using Sample.BasicRestAspnetCore.Data.Context;
using Sample.BasicRestAspnetCore.Data.Repositories.BookRepository.Interface;
using Sample.BasicRestAspnetCore.Data.Repositories.GenericRepository;
using Sample.BasicRestAspnetCore.EntitiesDomain;

namespace Sample.BasicRestAspnetCore.Data.Repositories.BookRepository.Implementation
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(MySqlContext context) : base(context)
        {
        }
    }
}