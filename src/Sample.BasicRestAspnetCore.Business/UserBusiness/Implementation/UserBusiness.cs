using System;
using Sample.BasicRestAspnetCore.Authentication.Configuration;
using Sample.BasicRestAspnetCore.Business.UserBusiness.Interface;
using Sample.BasicRestAspnetCore.Data.Repositories.UsersRepository.Interface;
using Sample.BasicRestAspnetCore.EntitiesDomain;
using System.Security.Claims;
using System.Security.Principal;
using System.IdentityModel.Tokens.Jwt;

namespace Sample.BasicRestAspnetCore.Business.UserBusiness.Implementation
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;
        private SigningConfiguration _signingConfigurations;
        private TokenConfiguration _tokenConfiguration;

        public UserBusiness(IUserRepository userRepository,
                            SigningConfiguration signingConfiguration,
                            TokenConfiguration tokenConfiguration)
        {
            _userRepository = userRepository;
            _signingConfigurations = signingConfiguration;
            _tokenConfiguration = tokenConfiguration;
        }
        public object FindByLogin(Users login)
        {
            bool isvalid = false;

            if (login != null && !string.IsNullOrEmpty(login.Login))
            {
                var baseUser = _userRepository.FindByLogin(login.Login);

                isvalid = (baseUser != null && login.Login == baseUser.Login && login.AccessKey == baseUser.AccessKey);


            }

            if (isvalid)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(login.Login, "Login"),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                            new Claim(JwtRegisteredClaimNames.UniqueName, login.Login)
                        }
                    );

                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createDate, expirationDate, handler);

                return SuccessObject(createDate, expirationDate, token);
            }
            else
            {
                return ExceptionObject();
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object ExceptionObject()
        {
            return new
            {
                autenticated = false,

                message = "Unauthorized"
            };
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token)
        {
            return new
            {
                autenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "Authenticated"
            };
        }
    }
}