using Fitnes_is_just.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitnes_is_just.BL.Controller
{
    /// <summary>
    /// Пользовательский контроллер.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Получение данных о пользователе приложения.
        /// </summary>
        /// <returns>Пользователя приложения.</returns>
        public UserController()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
            }
        }
        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user">Пользователь приложения.</param>
        public UserController(string userName, string genderName, DateTime birthDay, float weight, float height)
        {
            Gender gender = new Gender(genderName);

            User = new User(userName, gender, birthDay, weight, height);
        }

        /// <summary>
        /// Активный пользователь приложения.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Сохранение данных о пользователе приложения.
        /// </summary>
        public void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
    }
}
