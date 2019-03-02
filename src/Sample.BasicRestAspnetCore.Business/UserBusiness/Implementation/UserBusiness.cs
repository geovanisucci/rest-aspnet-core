using Sample.BasicRestAspnetCore.Business.UserBusiness.Interface;
using Sample.BasicRestAspnetCore.Data.Repositories.UsersRepository.Interface;
using Sample.BasicRestAspnetCore.EntitiesDomain;

namespace Sample.BasicRestAspnetCore.Business.UserBusiness.Implementation
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;

        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Users FindByLogin(string login)
        {
            return _userRepository.FindByLogin(login);
        }
    }
}