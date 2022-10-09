using File_Management_Application;

internal class Program
{
    private static void Main(string[] args)
    {
        string filePath = "./resources/file.txt";
        try
        {
            FMA fma = new(filePath);
            fma.ReadData();
            var data = fma.ProcessData();
            System.Console.WriteLine(data);
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
        }
    }
}
