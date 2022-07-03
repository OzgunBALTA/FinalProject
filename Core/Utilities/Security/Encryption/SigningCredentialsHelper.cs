using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    class SigningCredentialsHelper
    { 
        //JWT servisini yöneteceksin.
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            //Güvenlik anahtarın SecurityKeyHelperda oluşturduğumuz securtiyKeydir. Şifreleme algoritman da HmacSha512 algoritmasıdır. 
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
