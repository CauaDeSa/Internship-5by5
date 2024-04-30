const int actualYear = 2024;
int yearOfBirth;
int age;

Console.Write("Type your year of birth: ");
yearOfBirth = int.Parse(Console.ReadLine());

age = actualYear - yearOfBirth;

Console.WriteLine($"You have {age} years old!");
Console.ReadKey();