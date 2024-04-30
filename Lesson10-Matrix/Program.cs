int maxLine = 3, maxColumn = 3;

int[,] matrixA = new int[maxLine, maxColumn];
int[,] matrixB = new int[maxLine, maxColumn];
int[,] matrixR = new int[maxLine, maxColumn];

do
{
    Console.Clear();
    for (int line = 0; line < maxLine; line++)
        for (int column = 0; column < maxColumn; column++)
            matrixA[line, column] = new Random().Next(0, 10);

    for (int line = 0; line < maxLine; line++)
        for (int column = 0; column < maxColumn; column++)
            matrixB[line, column] = new Random().Next(0, 10);

    for (int line = 0; line < maxLine; line++)
        for (int column = 0; column < maxColumn; column++)
            matrixR[line, column] = matrixA[line, column] + matrixB[line, column];

    Console.WriteLine("Matrix A\n");
    for (int line = 0; line < maxLine; line++)
    {
        for (int column = 0; column < maxColumn; column++)
            Console.Write($"{matrixA[line, column]:00} ");
        Console.WriteLine();
    }

    Console.WriteLine("\nMatrix B\n");
    for (int line = 0; line < maxLine; line++)
    {
        for (int column = 0; column < maxColumn; column++)
            Console.Write($"{matrixB[line, column]:00} ");
        Console.WriteLine();
    }

    Console.WriteLine("\nMatrix summed\n");
    for (int line = 0; line < maxLine; line++)
    {
        for (int column = 0; column < maxColumn; column++)
            Console.Write($"{matrixR[line, column]:00} ");
        Console.WriteLine();
    }

    Console.WriteLine("\nType 'y' to do again");
} while (Console.ReadLine() == "y");