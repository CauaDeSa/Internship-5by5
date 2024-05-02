using Lesson18_DynamicList;

DynamicList myList = new DynamicList();

myList.Add(new Person("Augsuto", 2));
myList.Add(new Person("Pedro", 21));
myList.Add(new Person("Paulo", 11));
myList.Add(new Person("Joao", 31));
myList.Add(new Person("Rogerio", 15));
myList.Add(new Person("Augusto", 16));
myList.Add(new Person("Caua", 19));
myList.Add(new Person("Edenilson", 20));
myList.Add(new Person("Matheus", 22));

while (!myList.IsEmpty())
{
    Console.WriteLine(myList.Remove());
}