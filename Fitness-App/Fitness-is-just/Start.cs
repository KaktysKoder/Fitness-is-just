using Fitnes_is_just.BL.Controller;
using Fitnes_is_just.BL.Model;
using System;

namespace Fitness_is_just
{
    internal sealed class Start
    {
        private static void Main()
        {
            TestingInterfaceApp();
        }

        //TODO: переписать
        private static void TestingInterfaceApp()
        {
            Console.WriteLine("♥Добро пожаловать♥. Фитнес это просто.\n");

            Console.Write("►Введите имя пользователя: ");
            string name = Console.ReadLine();

            Console.Write("►Введите пол: ");
            string gender = Console.ReadLine();

            Console.Write("►Введите дату рождения: ");
            DateTime birthDay = DateTime.Parse(Console.ReadLine());

            Console.Write("►Введите вес: ");
            float weight = float.Parse(Console.ReadLine());

            Console.Write("►Введите рост: ");
            float heigth = float.Parse(Console.ReadLine());


            UserController controller = new UserController(name, gender, birthDay, weight, heigth);
            controller.Save();
        }
    }
}