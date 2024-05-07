using Lesson21_ProductRegister;

internal class Program
{
    static Product CreateProduct()
    {
        Console.WriteLine("\n>>> PRODUCT REGISTER <<<\n");

        Console.Write("Type product id: ");
        var id = int.Parse(Console.ReadLine());

        Console.Write("Type product description: ");
        var description = Console.ReadLine();

        Console.Write("Type product price: $");
        var price = double.Parse(Console.ReadLine());

        Console.Write("Type product quantity: ");
        var quantity = int.Parse(Console.ReadLine());

        return new Product(id, description, price, quantity);
    }

    static void ShowStorage(List<Product> storage)
    {
        Console.WriteLine("\n>>> PRODUCTS <<<\n");
        foreach (var product in storage)
            Console.WriteLine(product);
        Console.WriteLine();
    }

    static bool CheckPathing(string path, string file)
    {
        bool check = false;

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        if (!File.Exists(path + file))
            File.Create(path + file);
        else
            check = true;

        return check;
    }

    static void SaveFile(List<Product> storage, string path, string file)
    {
        if (CheckPathing(path, file))
        {

            StreamWriter writer = new StreamWriter(path + file);

            foreach (var product in storage)
                writer.WriteLine(product);

            writer.Close();
        }
    }

    static List<Product> LoadFile(string path, string file)
    {
        List<Product> storage = new();

        if (CheckPathing(path, file))
        {
            string[] data;

            foreach (var line in File.ReadAllLines(path + file))
            {
                data = line.Split(";");
                storage.Add(new Product(int.Parse(data[0]), data[1], double.Parse(data[2]), int.Parse(data[3])));
            }
        }

        return storage;
    }

    private static void Main(string[] args)
    {
        string path = @"C:\Data\Week-04\Lesson21\";
        string file = "storage.txt";

        List<Product> productStorage = new();

        productStorage.Add(CreateProduct());
        productStorage.Add(CreateProduct());

        ShowStorage(productStorage);

        SaveFile(productStorage, path, file);

        foreach (Product p in LoadFile(path, file))
            Console.WriteLine(p);

        Console.ReadKey();
    }
}