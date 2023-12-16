namespace Task1.Extensions
{
    public static class IOExtensions
    {
        /// <summary>
        /// Метод расширения который высчитывает 
        /// количество минут с момента последней записи в объект
        /// </summary>
        /// <typeparam name="T">Параметр типа</typeparam>
        /// <param name="objInfo">Объект <seealso cref="DirectoryInfo"/> или <seealso cref="FileInfo"/></param>
        /// <returns>Количество минут</returns>
        public static Double GetIdleMinutes<T>(this T objInfo) where T : FileSystemInfo
        {
            DateTime lastWriteTime = DateTime.Now;

            if (objInfo is DirectoryInfo directoryInfo)
            {
                lastWriteTime = directoryInfo.LastWriteTime;
            }
            else if (objInfo is FileInfo fileInfo)
            {
                lastWriteTime = fileInfo.LastWriteTime;
            }

            return (DateTime.Now - lastWriteTime).TotalMinutes;
        }
    }
}
