using Task1;
using Task2;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String folderPath = "C:\\Users\\Андрей\\Desktop\\TestDirectory";

            DirectoryCleaner cleaner = new DirectoryCleaner(10);
            DirectorySizeCalculator sizeCalculator = new DirectorySizeCalculator();

            sizeCalculator.Calculate(folderPath);
            sizeCalculator.PrintReport();

            cleaner.ClearDirectory(folderPath);
            cleaner.Report.PrintReport();

            sizeCalculator.Calculate(folderPath);
            sizeCalculator.PrintReport();

            Console.ReadLine();
        }
    }
}