namespace Sample.BasicRestAspnetCore.Authentication.Configuration
{
    using System.Security.Cryptography;
    using Microsoft.IdentityModel.Tokens;

    public class SigningConfiguration
    {
        public SigningConfiguration()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256);
        }
        public SecurityKey Key { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
    }
}