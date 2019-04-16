using MiniProject.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProject.Models
{
    public interface IPasswordEncrypter
    {
        string HashPassword(string password);
        bool ValidatePassword(string password, string hash);
    }
    public class Pbkdf2Encrypter : IPasswordEncrypter
    {
        public string HashPassword(string password)
        {
            var encrypted = Pbkdf2HashPassword.CreateHash(password);

            return encrypted;
        }

        public bool ValidatePassword(string password, string hash)
        {
            return Pbkdf2HashPassword.ValidatePassword(password, hash);
        }
    }
}
