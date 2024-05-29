using System.Net.Sockets;

namespace Lesson25_LinQ
{
    public class Adm
    {
        public static List<Person> LoadData()
        {
            List<Person> people = new();

            people.Add(new() { Id = 1, Name = "Cauã R. Sá", Age = 19, Telephone = "16 99633 7792" });
            people.Add(new() { Id = 2, Name = "Sophia L. Sá", Age = 18, Telephone = "16 99133 7545" });
            people.Add(new() { Id = 3, Name = "Yasmin L. Sá", Age = 15, Telephone = "16 99133 4555" });
            people.Add(new() { Id = 4, Name = "Arthur R. Sá", Age = 13, Telephone = "16 99133 4325" });
            people.Add(new() { Id = 5, Name = "Carmo A. Sá", Age = 53, Telephone = "16 99612 7123" });
            people.Add(new() { Id = 6, Name = "Elisangela R. Sá", Age = 42, Telephone = "16 99634 1122" });
            people.Add(new() { Id = 7, Name = "Weverson N. Sá", Age = 35, Telephone = "16 99643 7342" });
            people.Add(new() { Id = 8, Name = "Josiele N. Sá", Age = 33, Telephone = "16 99343 7334" });
            people.Add(new() { Id = 9, Name = "Wederson N. Sá", Age = 30, Telephone = "16 99234 7322" });
            people.Add(new() { Id = 10, Name = "Karina N. Sá", Age = 29, Telephone = "16 99342 7412" });
            people.Add(new() { Id = 11, Name = "Ana", Age = 20, Telephone = "16 99455 7232" });

            return people;
        }

        public static List<Person> FilterOverAgeds(List<Person> people) => people.Where(p => p.Age >= 18).ToList();

        public static List<Person> FilterByFirstLetterName(List<Person> people, string letter) => people.Where(p => p.Name.StartsWith(letter, StringComparison.OrdinalIgnoreCase)).ToList();

        public static List<Person> FilterByLetterAndLength(List<Person> people, string letter) => people.Where(p => p.Name.Contains(letter, StringComparison.OrdinalIgnoreCase) && p.Name.Length > 3).ToList();

        public static List<Person> OrderByName(List<Person> persons) => persons.OrderBy(p => p.Name).ToList();

        public static List<Person> OrderByNameDescending(List<Person> persons) => persons.OrderByDescending(p => p.Name).ToList();

        public static void PrintData(List<Person> people) {
            foreach (var p in people)
                Console.WriteLine(p + "\n");
        }
    }
}