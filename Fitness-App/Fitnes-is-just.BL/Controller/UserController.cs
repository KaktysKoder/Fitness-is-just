using Fitnes_is_just.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitnes_is_just.BL.Controller
{
    /// <summary>
    /// Пользовательский контроллер.
    /// </summary>
    public class UserController : BaseController
    {
        private const string USERS_FALE_NAME = "users.dat";

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="userName">Пользователь приложения.</param>
        public UserController(string userName)
        {
            if(string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Имя пользователь не может быть пустым", nameof(userName));
            }

            Users = GetUsersDate();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);

                Users.Add(CurrentUser);
                IsNewUser = true;

                Save();
            }
        }

        #region Props
        /// <summary>
        /// Список пользователей.
        /// </summary>
        public List<User> Users { get; } //TODO: Использовать в будущем  IEnumerable || IReadOnlyList

        /// <summary>
        ///  Активный пользователь приложения.
        /// </summary>
        public User CurrentUser { get; }

        /// <summary>
        /// Является ли этот пользователь новым или мы получили его из приложения. 
        /// </summary>
        public bool IsNewUser { get; } = false;
        #endregion

        /// <summary>
        /// Установить текущего пользователя.
        /// </summary>
        /// <param name="genderName"> Половая принадлежность.     </param>
        /// <param name="birthDay"  > Дата рождения пользователя. </param>
        /// <param name="weight"    > Вес пользователя.           </param>
        /// <param name="height"    > Рост пользователя.          </param>
        public void SetNewUserData(string genderName, DateTime birthDay, float weight = 31, float height = 101)
        {
            CurrentUser.Gender   = new Gender(genderName);
            CurrentUser.BirthDay = birthDay;
            CurrentUser.Weight   = weight;
            CurrentUser.Height   = height;

            Save();
        }

        /// <summary>
        /// Сохранение данных о пользователе приложения.
        /// </summary>
        public void Save() => Save(USERS_FALE_NAME, Users);

        /// <summary>
        /// Получение сохранённого списока пользователей.
        /// </summary>
        /// <returns>Пользователя приложения.</returns>
        private List<User> GetUsersDate() => Load<List<User>>(USERS_FALE_NAME);
    }
}
