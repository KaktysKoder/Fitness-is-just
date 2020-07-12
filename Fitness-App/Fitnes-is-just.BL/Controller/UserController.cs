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
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user">Пользователь приложения.</param>
        public UserController(User user)
        {
            User = user ?? throw new ArgumentNullException("Имя пользователя не может быть пустым.", nameof(user));
        }

        /// <summary>
        /// Пользователь приложения.
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

        /// <summary>
        /// Получение данных о пользователе приложения.
        /// </summary>
        /// <returns>Пользователя приложения.</returns>
        public User Load()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                return formatter.Deserialize(fs) as User;
            }
        }

    }
}
