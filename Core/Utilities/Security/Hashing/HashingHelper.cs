using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //Şifre oluşturma ve sorgulama için yazdığımız kodlar.
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte [] passwordSalt)
            //String bir password girer, byte passwordSalt ve passwordHash çıkar.
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) 
                //Hashleme algoritması olarak HMACSHA512 algoritmasını kullandık.
            {
                passwordSalt = hmac.Key; 
                //Tuzlama olarak ilgili algoritmanın Key değerini kullandık. Başka birşeyini de kullanabiliriz.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); 
                //Hash oluşturduk. string türde password'ü Encoding ile byte olarak dönüştürdük.
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
            // Login olurken parolayı doğruladığımız kısım
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) //Şifreyi çözerken bu saltı kullan.
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
