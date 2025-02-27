using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore
{
    public class CustomPasswordHasher : ICustomPasswordHasher
    {

        private const int SaltSize = 128 / 8;
        private const int KeySize = 256 / 8;
        private const int Iterations = 10000;
        private static readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256;
        private const char Delimiter = ';';
        public string Hash(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt,Iterations, _hashAlgorithmName,KeySize);
            return string.Join(Delimiter,Convert.ToBase64String(salt), Convert.ToBase64String(hash)); 
        }

        public bool VerifyPassword(string passwordHashed, string inputPassword)
        {
            var elements = passwordHashed.Split(Delimiter);
            var salt = Convert.FromBase64String(elements[0]);
            var hash= Convert.FromBase64String(elements[1]);
            var hashInput = Rfc2898DeriveBytes.Pbkdf2(inputPassword, salt, Iterations, _hashAlgorithmName, KeySize);
            return CryptographicOperations.FixedTimeEquals(hash, hashInput);
        }
    }
}
