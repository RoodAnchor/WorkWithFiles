namespace Task2
{
    /// <summary>
    /// Класс подсчитывающий размер папки (включая подпапки) в байтах
    /// </summary>
    public class DirectorySizeCalculator
    {
        #region Fields
        private Int32 _tries = 0;
        private Int64 _size = 0;
        private Int64 _diff = 0;
        #endregion Fields

        #region Methods
        /// <summary>
        /// Метод вызывает рекурсивный метод для подсчёта размера папки.
        /// Так же высчитывает разницу между предыдущим подсчётом и текущим.
        /// </summary>
        /// <param name="directoryPath">Путь к папке размер которой необходимо подсчитать.</param>
        /// <example>Calculate("C:\Folder\SubFolder")</example>
        public void Calculate(String directoryPath)
        {
            Int64 temp = CalculateRecursive(directoryPath);

            if (_size == 0)
            {
                _size = temp;
            }
            else
            {
                _diff = _size - temp;
                _size = temp;
            }
        }

        /// <summary>
        /// Рекурсивный метод подсчитывает размер всех файлов 
        /// в указанной папке и всех подпапках
        /// </summary>
        /// <param name="directoryPath">Путь к папке размер которой необходимо подсчитать.</param>
        /// <returns>Размер в байтах</returns>
        public Int64 CalculateRecursive(String directoryPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

            Int64 directorySize = 0;

            if (directoryInfo.Exists)
            {
                try
                {
                    DirectoryInfo[] directories = directoryInfo.GetDirectories();
                    FileInfo[] files = directoryInfo.GetFiles();

                    foreach (DirectoryInfo directory in directories)
                        directorySize += CalculateRecursive(directory.FullName);

                    foreach (FileInfo file in files)
                        directorySize += file.Length;
                }
                catch(Exception e)
                {
                    if (e is UnauthorizedAccessException)
                    {
                        Console.WriteLine($"Не удалось подсчитать размер папки {directoryInfo.Name}, т.к. не достаточно прав.");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Папка {directoryPath}, не существует");
            }

            return directorySize;
        }

        /// <summary>
        /// Метод выводит отчёт в консоль.
        /// </summary>
        public void PrintReport()
        {
            String message = _tries == 0 ? "до" : "после";

            Console.WriteLine($"Размер папки {message} чистки: { _size } байт");
            
            if (_tries > 0)
            {
                Console.WriteLine($"Высвобождено: {_diff} байт");
            }

            _tries++;
        }
        #endregion Methods
    }
}
