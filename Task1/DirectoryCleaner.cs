using System.Security;

using Task1.Extensions;

namespace Task1
{
    /// <summary>
    /// Класс для очистки папки
    /// </summary>
    public class DirectoryCleaner
    {
        #region Fields
        private Int32 _idleMinutes = 0;
        #endregion Fields

        #region Properties
        public DirectoryCleanerReport Report { get; set; }
        #endregion Properties

        #region Constructors
        public DirectoryCleaner(Int32 idlePeriodMinutes) 
        {
            _idleMinutes = idlePeriodMinutes;
            Report = new DirectoryCleanerReport();
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Метод проверяет наличие нужной папки и при успешной проверке
        /// запускает рекурсивный метод который осуществляет чистку.
        /// </summary>
        /// <param name="directoryPath">Полный путь к папке которую необходимо очистить.</param>
        /// <example>ClearDirectory(@"C:\Folder\SubFolder");</example>
        public void ClearDirectory(String directoryPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

            if (directoryInfo.Exists )
            {
                Report = ClearDirectoryRecursive(directoryInfo, 0);
            }
            else
            {
                Console.WriteLine($"Папка {directoryPath} не найдена");
            }
        }

        /// <summary>
        /// Рекурсивный метод который удаляет папку если 
        /// она не изменялась определённое количество минут, 
        /// указанное в приватном поле <seealso cref="_idleMinutes"/>
        /// </summary>
        /// <param name="directoryInfo">Объект содержащий данные о проверяемой папке.</param>
        /// <param name="level">Уровень вложенности. Указывается 0 при вызове метода.</param>
        /// <returns>Объект <seealso cref="DirectoryCleanerReport"/> содержащий 
        /// количество удалённых файлов и директорий</returns>
        /// <remarks>Метод не удалит папку если
        /// в ней будут находиться подпапки или файлы</remarks>
        private DirectoryCleanerReport ClearDirectoryRecursive(
            DirectoryInfo directoryInfo, 
            Int32 level)
        {
            DirectoryCleanerReport report = new DirectoryCleanerReport();

            foreach (DirectoryInfo subDir in directoryInfo.GetDirectories())
            {
                report = ClearDirectoryRecursive(subDir, level + 1);
            }

            report.RemovedFilesCount += DeleteFiles(directoryInfo.GetFiles());

            if (level > 0
                && directoryInfo.GetDirectories().Length == 0
                && directoryInfo.GetFiles().Length == 0
                && directoryInfo.GetIdleMinutes() >= _idleMinutes)
            {
                try
                {
                    directoryInfo.Delete();
                    report.RemovedDirectoriesCount++;
                }
                catch (Exception e)
                {
                    if (e is UnauthorizedAccessException)
                        Console.WriteLine($"Папка {directoryInfo.FullName} содержит файл доступный только для чтения");
                    else if (e is DirectoryNotFoundException)
                        Console.WriteLine($"Папка {directoryInfo.FullName} не найдена");
                    else if (e is SecurityException)
                        Console.WriteLine($"Не хватает прав на удаление папки {directoryInfo.FullName}");
                }
            }

            return report;
        }

        /// <summary>
        /// Метод удаляет файлы которые не изменялись определённое количество минут, 
        /// указанное в приватном поле <seealso cref="_idleMinutes"/>
        /// </summary>
        /// <param name="fileInfos">Массив с объектам содержащими данные о файлах</param>
        /// <returns>Количество удалённыъ файлов</returns>
        private Int32 DeleteFiles(
            FileInfo[] fileInfos)
        {
            Int32 removedCount = 0;
            foreach (FileInfo fileInfo in fileInfos)
            {
                if (fileInfo.GetIdleMinutes() >= _idleMinutes)
                {
                    try
                    {
                        fileInfo.Delete();
                        removedCount++;
                    }
                    catch (Exception e)
                    {
                        if (e is IOException)
                            Console.WriteLine($"Файл {fileInfo.FullName} открыт в другой программе");
                        if (e is SecurityException)
                            Console.WriteLine($"Не хватает прав на удаление файла {fileInfo.FullName}");
                    }
                }
            }

            return removedCount;
        }
        #endregion Methods
    }
}
