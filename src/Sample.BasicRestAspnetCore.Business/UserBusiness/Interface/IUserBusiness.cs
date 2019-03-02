using Sample.BasicRestAspnetCore.EntitiesDomain;

namespace Sample.BasicRestAspnetCore.Business.UserBusiness.Interface
{
    public interface IUserBusiness
    {
         Users FindByLogin(string login);
    }
}