internal class Program
{
    private static void Main(string[] args)
    {
        int value = 0;

        do
        {
            Console.Write("Type an integer value: ");
            try
            {
                value = int.Parse(Console.ReadLine());
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine("This isn't a number.");
                Console.WriteLine($"\nException: {e}\n");
            }

        } while (true);

        Console.WriteLine(value);
    }
}