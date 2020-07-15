using Fitnes_is_just.BL.Model;
using System;
using System.Collections.Generic;

namespace Fitnes_is_just.BL.Controller
{
    /// <summary>
    /// Контроллер приёма пищей.
    /// </summary>
    public class EatingController
    {
        private readonly User user;

        public EatingController(User user)
        {

            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));
            Foods = GetAllFoods();
        }

        #region Props
        /// <summary>
        /// Список еды.
        /// </summary>
        public List<Food> Foods { get; }
        #endregion

        private List<Food> GetAllFoods()
        {
            throw new NotImplementedException();
        }
    }
}
