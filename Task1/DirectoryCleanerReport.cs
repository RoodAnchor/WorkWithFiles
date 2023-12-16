namespace Task1
{
    /// <summary>
    /// Классс предоставляющий доступ к данным о количестве
    /// удалённых файлах и папок
    /// </summary>
    public class DirectoryCleanerReport
    {
        #region Properties
        public Int32 RemovedFilesCount { get; set; }
        public Int32 RemovedDirectoriesCount { get; set; }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Метод выводит в консоль информацию об удалённых файлах/папках
        /// </summary>
        public void PrintReport()
        {
            Console.WriteLine("Очистка папки завершена");
            Console.WriteLine("Удалено:");
            Console.WriteLine($"\tФайлов: {RemovedFilesCount}");
            Console.WriteLine($"\tПапок: {RemovedDirectoriesCount}");
        }
        #endregion Methods
    }
}
