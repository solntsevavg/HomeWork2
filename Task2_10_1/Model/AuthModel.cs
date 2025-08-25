using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_10_1.Model
{
    static class AuthModel
    {
        //Константы для валидных учетных данных
        public const string ValidUsername = "admin";
        public const string ValidPassword = "12345";

        static public bool Authenticate(string username, string password)
        {
            // Проверка на null или пустые строки
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            return username == ValidUsername && password == ValidPassword;

        }
    }
}
