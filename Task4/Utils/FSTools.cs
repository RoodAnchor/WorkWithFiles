using FinalTask.Enums;

namespace FinalTask.Utils
{
    /// <summary>
    /// Статический класс с методами для работы с файлами/директориями
    /// </summary>
    public static class FSTools
    {
        /// <summary>
        /// Статический метод создаёт директорио на диске
        /// </summary>
        /// <param name="path">Полный путь директории 
        /// которую необходимо создать</param>
        /// <returns>Объект <seealso cref="DirectoryInfo"/> с данными о 
        /// созданной директории</returns>
        /// <example>CreateFolder(@"C:\Folder\FolderToCreate");</example>
        public static DirectoryInfo CreateFolder(String path) 
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            try
            {
                if (!directoryInfo.Exists)
                    directoryInfo.Create();

                return directoryInfo;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        /// <summary>
        /// Статический метод создаёт файл на диске
        /// </summary>
        /// <param name="path">Полный путь к файлу который будет создан</param>
        /// <param name="writeMode">Перечисление метода записи. 
        /// <seealso cref="WriteModeEnum.Append"/> - Добавляет данные в конец файла,
        /// <seealso cref="WriteModeEnum.Override"/> - Перезаписывает файл.</param>
        /// <returns>Объект <seealso cref="FileInfo"/> с данными о 
        /// созданного файла.</returns>
        /// <example>CreateFile(@"C:\Folder\FileToCreate.txt", WriteModeEnum.Override);</example>
        public static FileInfo CreateFile(String path, WriteModeEnum writeMode, ref Int32 createdFilesCount) 
        {
            FileInfo fileInfo = new FileInfo(path);

            try
            {
                if (!fileInfo.Exists)
                {
                    FileStream fs = fileInfo.Create();
                    fs.Close();
                    createdFilesCount++;
                }
                else
                {
                    if (writeMode == WriteModeEnum.Override)
                    {
                        fileInfo.Delete();
                        FileStream fs = fileInfo.Create();
                        fs.Close();
                    }
                }

                return fileInfo;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }
    }
}
