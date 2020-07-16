using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitnes_is_just.BL.Controller
{
    public class SerializableDataSaver : IDataSaver
    {
        public T Load<T>(string fileName)
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

        public void Save(string fileName, object item)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
    }
}
