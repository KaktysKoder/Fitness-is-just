using Fitnes_is_just.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitnes_is_just.BL.Controller
{
    /// <summary>
    /// Пользовательский контроллер.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Получение сохранённый список пользователей.
        /// </summary>
        /// <returns>Пользователя приложения.</returns>
        private List<User> GtUsersDate()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else return new List<User>();
            }
        }
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

            Users = GtUsersDate();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

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
        public void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }
    }
}
