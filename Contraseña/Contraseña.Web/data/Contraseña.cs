using System;
using System.Text;

namespace Contraseña.Web.data
{
    public class PasswordGenerator
    {
        public int Length { get; set; }
        public string GeneratedPassword { get; private set; }

        public void GenerateRandomPassword()
        {
            const string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowerCase = "abcdefghijklmnopqrstuvwxyz";
            const string digits = "0123456789";
            const string specialChars = "!@#$%^&*()-_=+<>?";

            string allChars = upperCase + lowerCase + digits + specialChars;
            StringBuilder password = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < Length; i++)
            {
                int index = random.Next(allChars.Length);
                password.Append(allChars[index]);
            }

            GeneratedPassword = password.ToString();
        }
    }
}
