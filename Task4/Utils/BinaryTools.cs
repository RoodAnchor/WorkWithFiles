using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask.Utils
{
    /// <summary>
    /// Статический класс для работы с бинарными данными
    /// </summary>
    public static class BinaryTools
    {
        /// <summary>
        /// Обобщённый метод сериализует объект и сохраняет файл с данными.
        /// </summary>
        /// <typeparam name="T">Параметр типа объекта</typeparam>
        /// <param name="obj">Объект для сериализации</param>
        /// <param name="fileName">Полный путь к файлу в который сохраняются данные.</param>
        /// <example>Serialize(Student student, @"C:\Folder\FileToCreate.dat");</example>
        public static void Serialize<T>(T obj, String fileName)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fs, obj);
            }
        }

        /// <summary>
        /// Обобщённый метод десереализует бинарные данные в объект
        /// </summary>
        /// <typeparam name="T">Параметр типа объекта в который 
        /// будет осуществляться десериализация</typeparam>
        /// <param name="filePath">Полный путь к файлу в котором хранятся данные для десериализации.</param>
        /// <returns>Десериализованный объект</returns>
        /// <example>Deserialize<Student[]>(@"C:\Folder\Students.dat");</example>
        public static T Deserialize<T>(String filePath) 
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            T obj;

            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                obj = (T)binaryFormatter.Deserialize(fs);
            }

            return obj;
        }
    }
}
