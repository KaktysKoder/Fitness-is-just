using System;

namespace Fitnes_is_just.BL.Model
{
    /// <summary>
    /// Пол пользователя.
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Создать новый пол пользователя.
        /// </summary>
        /// <param name="name"></param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Пол не может быть пустыл", nameof(name));
            }

            Name = name;
        }

        /// <summary>
        /// Тип пола пользователя.
        /// </summary>
        public string Name { get; }

        public override string ToString() => Name;
    }
}
