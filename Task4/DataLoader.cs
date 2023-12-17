using FinalTask.Enums;
using FinalTask.Utils;

namespace FinalTask
{
    /// <summary>
    /// Класс загрузчик бинарных данных
    /// </summary>
    public class DataLoader
    {
        #region Methods
        /// <summary>
        /// Метод загружает бинарые данные из файла в файловую структуру на диск.
        /// </summary>
        /// <param name="pathToFile">Полный путь к файлу, в котором хранятся данные.</param>
        /// <param name="writeMode">Метод записи на диск</param>
        public void LoadFromFile(
            String pathToFile, 
            WriteModeEnum writeMode)
        {
            try
            {
                Console.WriteLine("Начало загрузки данных.");

                Student[] students = BinaryTools.Deserialize<Student[]>(pathToFile);
                List<String> groups = students.Select(x => x.Group).Distinct().ToList();
                String desktopFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                String studentsFolderPath = Path.Combine(desktopFolderPath, "Students");
                DirectoryInfo directory = FSTools.CreateFolder(studentsFolderPath);

                WriteData(directory, groups, students, writeMode);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Метод записывает данные на диск.
        /// </summary>
        /// <param name="directory">Корневая директория, куда будет осуществляться запись</param>
        /// <param name="groups">Список групп, по которым будет создаваться файлы групп.</param>
        /// <param name="students">Массив с данными о студентах</param>
        /// <param name="writeMode">Метод записи на диск</param>
        private void WriteData(
            DirectoryInfo directory, 
            List<String> groups,
            Student[] students,
            WriteModeEnum writeMode)
        {
            Int32 createdFilesCount = 0;

            if (directory == null || 
                groups == null || 
                students == null) return;

            if (directory.Exists)
            {
                foreach (String group in groups)
                {
                    FSTools.CreateFile(Path.Combine(directory.FullName, $"{group}.txt"), writeMode, ref createdFilesCount);
                }

                foreach (Student student in students)
                {
                    FileInfo file = new FileInfo(Path.Combine(directory.FullName, $"{student.Group}.txt"));                    

                    if (file.Exists)
                    {
                        using (StreamWriter sw = file.AppendText())
                        {
                            sw.WriteLine($"{student.Name}, {student.DateOfBirth.ToShortDateString()}");
                        }
                    }
                }

                Console.WriteLine("Загрузка завершена.");
                Console.WriteLine($"Создано: {createdFilesCount} файл(а\\ов).");
            }
        }
        #endregion Methods
    }
}
