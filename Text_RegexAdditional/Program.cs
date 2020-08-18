using System;
using System.Text.RegularExpressions;

namespace Text_RegexAdditional
{
    class Program
    {
        static void Main(string[] args)
        {
            string login, password;
            Regex regLog = new Regex(@"^([a-z]|[A-Z])+$");
            Regex regPas = new Regex(@"^([1-9]|\W)+$");

            while (true)
            {
                Console.Write("enter login ");
                login = Console.ReadLine();

                if (regLog.IsMatch(login ?? string.Empty))
                {
                    Console.WriteLine("login correct");
                    break;
                }

                Console.WriteLine("login is not correct");
            }

            while (true)
            {
                Console.Write("enter password ");
                password = Console.ReadLine();

                if (regPas.IsMatch(password ?? string.Empty))
                {
                    Console.WriteLine("password correct");
                    break;
                }
                Console.WriteLine("password is not correct");
            }
        }
    }
}


