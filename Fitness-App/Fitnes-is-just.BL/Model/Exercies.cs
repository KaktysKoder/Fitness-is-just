using System;

namespace Fitnes_is_just.BL.Model
{
    /// <summary>
    /// Упражнения
    /// </summary>
    [Serializable]
    public class Exercies
    {
        public Exercies(DateTime start, DateTime finish, Activity activity, User user)
        {
            //TODO: Проверка

            Start    = start;
            Finish   = finish;
            Activity = activity;
            User     = user;
        }

        #region Props
        /// <summary>
        /// Начало упражнения.
        /// </summary>
        public DateTime Start { get; }

        /// <summary>
        /// Окончание упражнение.
        /// </summary>
        public DateTime Finish { get; }

        /// <summary>
        /// Вид активности.
        /// </summary>
        public Activity Activity { get; }

       /// <summary>
       /// Пользователь который занимался активностью.
       /// </summary>
        public User User { get; }
        #endregion
    }
}
