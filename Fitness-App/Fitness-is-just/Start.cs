using Fitnes_is_just.BL.Controller;
using Fitnes_is_just.BL.Model;
using System;

using System.Globalization;
using System.Resources;

using Fitness_is_just.Languages;

namespace Fitness_is_just
{
    internal sealed class Start
    {

        #region Loanguage
        private const string RU_LANGUAGE = "Ru-ru";
        private const string EN_LANGUAGE = "En-ru";

        private const string _RU_LANGUAGE = "Fitness_is_just.Languages.MessagesRu-ru";
        private const string _EN_LANGUAGE = "Fitness_is_just.Languages.MessagesEn-ru";
        //TODO: Реализовать выбор и переключение культуры
        #endregion

        private static void Main() => TestingInterfaceApp();

        private static void TestingInterfaceApp()
        {
            var culture = CultureInfo.CreateSpecificCulture(RU_LANGUAGE);
            var resourceManager = new ResourceManager(_RU_LANGUAGE, typeof(Start).Assembly);

            Console.WriteLine($"{resourceManager.GetString("Greeting", culture)}\n");

            Console.Write("►Введите имя пользователя: ");
            string name = Console.ReadLine();

            var userController     = new UserController(name);
            var eatingController   = new EatingController(userController.CurrentUser);
            var exerciesController = new ExerciesController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write("►Введите пол: ");

                var gender = Console.ReadLine();

                var birthDay = ParsDateTime("дата рожнения");
                var weight = ParseDouble("вес");
                var heigth = ParseDouble("рост");

                userController.SetNewUserData(gender, birthDay, weight, heigth);
            }

            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E - ввести приём пищи");
                Console.WriteLine("A - ввести упражнения");
                Console.WriteLine("Q - выход");

                var key = Console.ReadKey();

                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eatings.Foods)
                        {
                            Console.WriteLine($"\n{item.Key} - {item.Value}");
                        }
                        break;

                    case ConsoleKey.A:
                        var exe = EnterExercies();
                        //  var exercise = new Exercies(exe.Begin, exe.End, exe.Activity, userController.CurrentUser);
                        exerciesController.Add(exe.Activity, exe.Begin, exe.End);

                        foreach (var item in exerciesController.Exercises)
                        {
                            Console.WriteLine($"\n{item.Activity} с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }

                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadLine();
            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercies()
        {
            Console.Write($"Введите название упражнения: ");
            var name = Console.ReadLine();

            var energy = ParseDouble("расход энергии в минуту");
            var begin = ParsDateTime("начало упражнения");
            var end = ParsDateTime("окончание упражнения");

            Activity activity = new Activity(name, energy);

            return (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();


            var weight = ParseDouble("вес порции");
            var callorie = ParseDouble("калории");
            var proteins = ParseDouble("белоки");
            var fats = ParseDouble("жиры");
            var carbohydrates = ParseDouble("углеводы");

            var product = new Food(food, callorie, proteins, fats, carbohydrates);

            return (product, weight);
        }

        private static DateTime ParsDateTime(string valie)
        {
            DateTime birthDay;
            while (true)
            {
                Console.Write($"►Введите {valie} (dd:MM:yyyy): ");

                if (DateTime.TryParse(Console.ReadLine(), out birthDay))
                {
                    break;
                }
                else Console.WriteLine($"Неверный формат {valie}.");
            }

            return birthDay;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"►Введите {name}: ");

                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else Console.WriteLine($"Неверный формат элемента {name}.");
            }
        }
    }
}