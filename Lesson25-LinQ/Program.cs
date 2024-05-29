using Lesson25_LinQ;

namespace LinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = Adm.LoadData();

            //Adm.PrintData(persons);

            //Console.WriteLine("< OVERAGEDS >\n");

            //Adm.PrintData(Adm.FilterOverAgeds(persons));

            //Console.WriteLine("< FILTERED BY LETTER >\n");

            //Adm.PrintData(Adm.FilterByFirstLetterName(persons, "A"));

            //Console.WriteLine("< SORTED BY NAME >");

            //Adm.PrintData(Adm.OrderByName(persons));

            //Console.WriteLine("< SORTED BY NAME (DESCENDING) >");

            //Adm.PrintData(Adm.OrderByName(persons));

            Console.WriteLine("< FILTERED BY LETTER (Name.Length > 3)>\n");

            Adm.PrintData(Adm.FilterByLetterAndLength(persons, "A"));
        }
    }
}