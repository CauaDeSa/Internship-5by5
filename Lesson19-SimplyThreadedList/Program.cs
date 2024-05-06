using Lesson19_SimplyThreadedList;

internal class Program
{
    private static void Main(string[] args)
    {
        ContactList list = new ContactList();
        Contact aux;
        string name;

        list.Add(new Contact("Bernado", "123"));
        list.Add(new Contact("Ana", "321"));
        list.Add(new Contact("Caue", "456"));
        list.Add(new Contact("Aatrox", "122"));
        list.Add(new Contact("Guiven", "111"));
        list.Add(new Contact("Bardo", "111"));
        list.Add(new Contact("Marcos", "111"));
        list.Add(new Contact("Chinchila", "111"));

        do
        {
            list.Show();

            Console.Write("\n\tType a name to find: ");
            aux = list.RemoveByName(Console.ReadLine());

            if (aux != null)
                Console.WriteLine($"\t{aux.GetName()}: {aux.GetPhone()} ");
            else
                Console.WriteLine("\tNão existe!");
            Console.WriteLine("\n\tPress any key to continue...");
            Console.ReadKey();
            Console.Clear();

        } while (!list.IsEmpty());

        Console.WriteLine("\n\tLista vazia!");
    }
}