using System.Linq;
using Sample.BasicRestAspnetCore.Data.Context;
using Sample.BasicRestAspnetCore.Data.Repositories.UsersRepository.Interface;
using Sample.BasicRestAspnetCore.EntitiesDomain;

namespace Sample.BasicRestAspnetCore.Data.Repositories.UsersRepository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly MySqlContext _context;

        public UserRepository(MySqlContext context)
        {
            _context = context;
        }
        public Users FindByLogin(string login)
        {
            return _context.Users.SingleOrDefault(u => u.Login == login);
        }
    }
}