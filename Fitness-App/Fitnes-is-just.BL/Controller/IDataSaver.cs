namespace Fitnes_is_just.BL.Controller
{
    public interface IDataSaver
    {
        /// <summary>
        /// Сохранение данных.
        /// </summary>
        /// <param name="fileName">Имя файла.</param>
        /// <param name="item">Объект для сохранения.</param>
        void Save(string fileName, object item);

        /// <summary>
        /// Загрузка данных.
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <returns></returns>
        T Load<T>(string fileName);
    }
}
