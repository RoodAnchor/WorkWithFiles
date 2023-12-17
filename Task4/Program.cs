namespace FinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataLoader loader = new DataLoader();

            String folderPath = GetArgValue(args, "-path");

            loader.LoadFromFile(folderPath, Enums.WriteModeEnum.Override);
        }

        static String GetArgValue(string[] args, String name)
        {
            for (int i = 0; i < args.Length; i++)
                if (args[i] == name)
                    return args[i + 1];

            return String.Empty;
        }
    }
}