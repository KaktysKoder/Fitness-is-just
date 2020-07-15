﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Fitnes_is_just.BL.Model
{
    /// <summary>
    /// Приём пищи.
    /// </summary>
    [Serializable]
    public class Eating
    {
        public Eating(User user)
        {
            User   = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));
            Moment = DateTime.UtcNow;
            Foods  = new Dictionary<Food, double>();
        }

        #region Props
        /// <summary>
        /// Момент приёма пищи.
        /// </summary>
        public DateTime Moment { get; }

        /// <summary>
        /// Список продуктов.
        /// </summary>
        public Dictionary<Food, double> Foods { get; } //TODO: Вынести в отдельный класс

        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; }
        #endregion

        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if(product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}
