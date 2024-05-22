internal class Program
{
    private static void Main(string[] args)
    {
        string path = @"C:\Data\Week-04\Lesson23\test.txt";
        string line; 

        try
        {
            StreamWriter writer = new(path);
            writer.WriteLine("Hello World");
            writer.WriteLine("-----------");
            writer.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


        try
        {
            StreamReader reader = new(path);
            line = reader.ReadLine();

            while (line != null)
            {
                Console.WriteLine(line);
                line = reader.ReadLine();
            }

            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}