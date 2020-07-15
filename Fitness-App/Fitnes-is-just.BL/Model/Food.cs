using System;

namespace Fitnes_is_just.BL.Model
{
    /// <summary>
    /// Продукт питания.
    /// </summary>
    [Serializable]
    public class Food
    {
        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food(string name, double callorie, double proteins, double fats, double carbohydrates)
        {
            //TODO: Сделать проверки.

            Name          = name;
            Callorie      = callorie      / 100.0;
            Proteins      = proteins      / 100.0;
            Fats          = fats          / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }

        #region Props
        /// <summary>
        /// Наименование продукта.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Калории.
        /// </summary>
        public double Callorie { get; }

        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; }
        #endregion

        public override string ToString() => Name;
    }
}
