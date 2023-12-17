namespace FinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataLoader loader = new DataLoader();

            loader.LoadFromFile(@"C:\Users\Андрей\Documents\Repos\SkillFactory\WorkWithFiles\Task4\misc\Students.dat", Enums.WriteModeEnum.Override);
        }
    }
}