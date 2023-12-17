namespace FinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataLoader loader = new DataLoader();

            String folderPath = @"C:\Users\Андрей\Documents\Repos\SkillFactory\WorkWithFiles\Task4\misc\Students.dat";

            foreach (String arg in args)
            {
                if (arg.StartsWith("-path:"))
                    folderPath = arg.Remove(0, 6);
            }

            loader.LoadFromFile(folderPath, Enums.WriteModeEnum.Override);
        }
    }
}