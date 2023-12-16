namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DirectorySizeCalculator sizeCalculator = new DirectorySizeCalculator();

            sizeCalculator.Calculate("C:\\Program Files");
        }
    }
}