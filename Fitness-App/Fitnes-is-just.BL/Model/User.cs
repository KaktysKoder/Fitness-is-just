using System;

namespace Fitnes_is_just.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя пользователя не может быть пустым.", nameof(name));
            }

            Name = name;
        }

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name"    > Имя пользователя            </param>
        /// <param name="gender"  > Половая принадлежность.     </param>
        /// <param name="birthDay"> Дата рождения пользователя. </param>
        /// <param name="weight"  > Вес пользователя.           </param>
        /// <param name="height"  > Рост пользователя.          </param>
        public User(string name, Gender gender, DateTime birthDay, float weight, float height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя пользователя не может быть пустым.", nameof(name));
            }

            if(gender == null)
            {
                throw new ArgumentException("Половая принадлежность пользователя не может быть пустой.", nameof(gender));
            }

            if (birthDay < DateTime.Parse("01.01.1900") || birthDay >= DateTime.Now)
            {
                //TODO: Позже заменить на: Невозможная дата рождения
                throw new ArgumentException("Дата рождения пользователя не может быть меньше (01.01.1900) года.", nameof(birthDay));
            }

            if (weight < 30) //30 килограмм
            {
                throw new ArgumentException("Вес пользователя не может 30 килограмм.", nameof(weight));
            }

            if(height < 100) //100 сантиметров
            {
                throw new ArgumentException("Рост пользователя не может быть меньше метра.", nameof(height));
            }
            #endregion

            Name     = name;
            Gender   = gender;
            BirthDay = birthDay;
            Weight   = weight;
            Height   = height;
        }

        #region Свойства
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Половая принадлежность.
        /// </summary>
        public Gender Gender { get; set; }  //TODO: Нарушение защиты. Исправить.

        /// <summary>
        /// Дата рождения пользователя.
        /// </summary>
        public DateTime BirthDay { get; set; }//TODO:  Нарушение защиты. Исправить.

        /// <summary>
        /// Вес пользователя.
        /// </summary>
        public float Weight { get; set; }

        /// <summary>
        /// Рост пользователя.
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// Возраст пользователя.
        /// </summary>
        public int Age { get => DateTime.Now.Year - BirthDay.Year; } //TODO: Переписать вычисления
        #endregion

        public override string ToString() => $"{Name} {Age}";
    }
}
