using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitnes_is_just.BL.Controller
{
    /// <summary>
    /// Общая логика для сериализации и десериализации.
    /// </summary>
    public abstract class BaseController
    {
        /// <summary>
        /// Принемает данные необходимые для сериализазии.
        /// </summary>
        /// <param name="fileName" > Имя файла в который будет сериализованны данные.</param>
        /// <param name="item"     > Данные для сериализазии.                        </param>
        protected void Save<T>(string fileName, object item)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }

        /// <summary>
        /// Десериализация данных из файла fileName
        /// </summary>
        /// <param name="fileName"> Имя файла из которого произойдёт десериализация данных.</param>
        /// <returns></returns>
        protected T Load<T>(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                else return default;
            }
        }
    }
}
