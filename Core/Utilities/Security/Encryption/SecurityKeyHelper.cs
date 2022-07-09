using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        //İşin içinde şifreleme varsa herşeyi Byte dizilerine çevirmemiz gerekir. ASP.Net JWT string ifadeleri anlamaz o yüzden dönüştürmeliyiz.
        //SecurityKeyHelper WebApi içinde yazdığımız SecurtyKey stringini byte diziye dönüştürür.
        //SigningCredential için string ifadeyi byte dizilerine dönüştürür.
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)); //SecurityKey oluşturduk.
        }

    }
}
