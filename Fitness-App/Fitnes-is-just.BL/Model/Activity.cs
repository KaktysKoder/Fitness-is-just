using System;

namespace Fitnes_is_just.BL.Model
{
    /// <summary>
    /// Активность
    /// </summary>
    [Serializable]
    public class Activity
    {
        public Activity(string name, double caloriesPerMinute)
        {
            //TODO: Проверка

            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException();
            }

            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        #region Props
        /// <summary>
        /// Название активности.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Сжигаемые калории в минуту.
        /// </summary>
        public double CaloriesPerMinute { get; }
        #endregion

        public override string ToString() => Name;
    }
}
