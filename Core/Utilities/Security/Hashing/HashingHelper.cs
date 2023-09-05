using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePassHash(string password,
             out byte[] passHash, out byte[] passSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPassHash(string password, byte[] passHash, byte[] passSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passSalt))
            {
                var compHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < compHash.Length; i++)
                {
                    if (compHash[i]!= passHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
