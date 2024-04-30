float height, weight;
double bmi;
string sex;

do
{
    Console.Write("\nType your height, weight and sex to calculate your Body Mass Index!\n\n");

    do
    {
        Console.Write("Weight (kilograms): ");
        weight = float.Parse(Console.ReadLine());
    } while (weight <= 0);

    do
    {
        Console.Write("Height (meters): ");
        height = float.Parse(Console.ReadLine());
    } while (height <= 0);

    do
    {
        Console.Write("Sex (m/f): ");
        sex = Console.ReadLine();
    } while (sex != "m" && sex != "f");

    bmi = weight / (Math.Pow(height, 2));

    if ((bmi < 20.7 && sex == "m") || (bmi < 19.1 && sex == "f"))
        Console.WriteLine("Below normal!");
    else if ((bmi < 26.4 && sex == "m") || (bmi < 25.8 && sex == "f"))
        Console.WriteLine("Healthy range!");
    else if ((bmi < 27.8 && sex == "m") || (bmi < 27.3 && sex == "f"))
        Console.WriteLine("A little overweight!");
    else if ((bmi < 32.3 && sex == "m") || (bmi < 31.1 && sex == "f"))
        Console.WriteLine("Overweight!");
    else
        Console.WriteLine("Obesity range!");

    Console.WriteLine($"Your BMI: {bmi:0.00}");

    Console.Write("\nDo you wanna test again? (y/n) : ");
} while (Console.ReadLine() == "y");