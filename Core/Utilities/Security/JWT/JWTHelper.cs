using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration) //appsettingsten gelen bilgileri okuduk.
        {
            Configuration = configuration;
            _accessTokenExpiration = DateTime.Now.AddMinutes(Convert.ToDouble(Configuration["TokenOptions:AccessTokenExpiration"]));
        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {           
            var securityKey = SecurityKeyHelper.CreateSecurityKey(Configuration["TokenOptions:SecurityKey"]);
            //securityKey oluştu.
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            //security ile Hmac algoritması kullanarak imza oluşturduk.
            var jwt = CreateJwtSecurityToken(user, signingCredentials, operationClaims);
            // jwt token oluşturuldu.
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            //Token yazdırıldı

            return new AccessToken //Oluşturulan token'i döndürüyoruz.
            {
                Token = token, //Token değeri
                Expiration = _accessTokenExpiration, //Geçerlilik değeri
                RefreshToken = GenerateRefreshToken() //Yenilenme özelliği 
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
            //kullanıcı bilgisi, oluşan imza ve izinleri kullanarak güvenlik anahtarı oluştur.
        {
            var jwt = new JwtSecurityToken(
                issuer: Configuration["TokenOptions:Issuer"],
                audience: Configuration["TokenOptions:Audience"],
                expires: _accessTokenExpiration, //Geçerlilik süresi
                notBefore: DateTime.Now, // eğer expiration bilgisi şimdiden önceyse geçerli değil
                claims: SetClaims(user, operationClaims), //Yetkiler
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        public string GenerateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
            //Yetkileri derliyoruz.
            //Metot extension edildi
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
