using Sample.BasicRestAspnetCore.Data.Repositories.GenericRepository;
using Sample.BasicRestAspnetCore.EntitiesDomain;

namespace Sample.BasicRestAspnetCore.Data.Repositories.UsersRepository.Interface
{
    public interface IUserRepository 
    {
         Users FindByLogin(string login);
    }
}