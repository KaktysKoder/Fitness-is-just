using Fitnes_is_just.BL.Controller;
using System;

namespace Fitness_is_just
{
    internal sealed class Start
    {
        private static void Main() => TestingInterfaceApp();

        private static void TestingInterfaceApp()
        {
            Console.WriteLine("♥Добро пожаловать♥. Фитнес это просто.\n");

            Console.Write("►Введите имя пользователя: ");
            string name = Console.ReadLine();

            UserController userController = new UserController(name);

            if(userController.IsNewUser)
            {
                Console.Write("►Введите пол: ");

                var gender   = Console.ReadLine();

                var birthDay = ParsDateTime();
                var weight   = ParseFloat("вес");
                var heigth   = ParseFloat("рост");

                userController.SetNewUserData(gender, birthDay, weight, heigth);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.ReadLine();
        }

        private static DateTime ParsDateTime()
        {
            DateTime birthDay;
            while (true)
            {
                Console.Write("►Введите дату рождения (dd:MM:yyyy): ");

                if (DateTime.TryParse(Console.ReadLine(), out birthDay))
                {
                    break;
                }
                else Console.WriteLine("Неверный формат даты рождения.");
            }

            return birthDay;
        }

        private static float ParseFloat(string name)
        {
            while (true)
            {
                Console.Write($"►Введите {name}: ");

                if (float.TryParse(Console.ReadLine(), out float value))
                {
                    return value;
                }
                else Console.WriteLine($"Неверный формат {name}а.");
            }
        }
    }
}