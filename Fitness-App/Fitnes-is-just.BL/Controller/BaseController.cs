namespace Fitnes_is_just.BL.Controller
{
    /// <summary>
    /// Общая логика для сериализации и десериализации.
    /// </summary>
    public abstract class BaseController
    {
        protected IDataSaver saver = new SerializableDataSaver();

        /// <summary>
        /// Принемает данные необходимые для сериализазии.
        /// </summary>
        /// <param name="fileName" > Имя файла в который будет сериализованны данные.</param>
        /// <param name="item"     > Данные для сериализазии.                        </param>
        protected void Save(string fileName, object item) => saver.Save(fileName, item);

        /// <summary>
        /// Десериализация данных из файла fileName
        /// </summary>
        /// <param name="fileName"> Имя файла из которого произойдёт десериализация данных.</param>
        /// <returns></returns>
        protected T Load<T>(string fileName) => saver.Load<T>(fileName);
    }
}
