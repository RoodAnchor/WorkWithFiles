namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DirectoryCleaner cleaner = new DirectoryCleaner(10);

            cleaner.ClearDirectory("C:\\Users\\Андрей\\Desktop\\TestDirectory");
            cleaner.Report.PrintReport();
        }
    }
}