using Fitnes_is_just.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitnes_is_just.BL.Controller
{
    /// <summary>
    /// Контроллер приёма пищей.
    /// </summary>
    public class EatingController : BaseController
    {
        private const string FOODS_FILE_NAME   = "foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";

        private readonly User user;

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));

            Foods   = GetAllFoods();
            Eatings = GetEating();
        }

        #region Props
        /// <summary>
        /// Список еды.
        /// </summary>
        public List<Food> Foods { get; }

        /// <summary>
        /// Список приёма пищи.
        /// </summary>
        public Eating Eatings { get; }
        #endregion

        /// <summary>
        /// Добавление еды. (приём пищи)
        /// </summary>
        public void Add(Food food, double weight)
        {
            //Получаем еду из списка существующих продуктов.
            var product = Foods.FirstOrDefault(f => f.Name == food.Name);

            if (product  == null)
            {
                Foods.Add(food);
                Eatings.Add(food, weight);
                Save();
            }
            else
            {
                Eatings.Add(product, weight);
                Save();
            }
        }

        private void Save()
        {
            //Сохранить в файл"foods.dat", список еды.
            Save(FOODS_FILE_NAME, Foods);

            //Сохранить в "eatings.dat", список приёма пищи.
            Save(EATINGS_FILE_NAME, Eatings);
        }

        /// <summary>
        /// Получить полный список пищи. 
        /// </summary>
        /// <returns>Список пищи.</returns>
        private List<Food> GetAllFoods() => Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();

        /// <summary>
        /// Получить список съеденой пищи. 
        /// </summary>
        /// <returns>Список съеденой пищи</returns>
        private Eating GetEating()       => Load<Eating>(EATINGS_FILE_NAME)   ?? new Eating(user);
    }
}
