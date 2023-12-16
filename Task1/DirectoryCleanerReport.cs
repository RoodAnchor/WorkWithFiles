namespace Task1
{
    /// <summary>
    /// Классс предоставляющий доступ к данным о количестве
    /// удалённых файлах и папок
    /// </summary>
    internal class DirectoryCleanerReport
    {
        internal Int32 RemovedFilesCount { get; set; }
        internal Int32 RemovedDirectoriesCount { get; set; }

        internal DirectoryCleanerReport(
            Int32 removedFilesCount, 
            Int32 removedDirectoriesCount) 
        {
            RemovedDirectoriesCount = removedDirectoriesCount;
            RemovedFilesCount = removedFilesCount;
        }

        /// <summary>
        /// Метод выводит в консоль информацию об удалённых файлах/папках
        /// </summary>
        internal void PrintReport()
        {
            Console.WriteLine("Очистка папки завершена");
            Console.WriteLine("Удалено:");
            Console.WriteLine($"\tФайлов: {RemovedFilesCount}");
            Console.WriteLine($"\tПапок: {RemovedDirectoriesCount}");
            Console.WriteLine($"Для завершения нажмите «Enter»");
            Console.ReadLine();
        }
    }
}
