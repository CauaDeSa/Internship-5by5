float firstGrade, secondGrade, media;

Console.Write("Type first grade: ");
firstGrade = float.Parse(Console.ReadLine());

if (firstGrade < 0)
    firstGrade = 0;

Console.Write("Type second grade: ");
secondGrade = float.Parse(Console.ReadLine());


if (secondGrade < 0)
    secondGrade = 0;

media = (firstGrade + secondGrade) / 2;

if (media <= 3)
    Console.WriteLine("Reproved!");
else
{
    if (media > 5)
        Console.WriteLine("Aproved!");
    else
        Console.WriteLine("At exam!");
}

Console.Write("Press any key to continue...");
Console.ReadKey();