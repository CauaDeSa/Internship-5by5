int maxLine = 3, maxColumn = 3;

float[,] matrixA = new float[maxLine, maxColumn];
float[,] matrixB = new float[maxLine, maxColumn];
float[,] matrixR = new float[maxLine, maxColumn];

char operation;
string type = "";
bool canContinue;

void ImprimirMatriz(float[,] matrix, string type)
{

    Console.WriteLine($"\n\n {type}");

    for (int line = 0; line < maxLine; line++)
    {
        Console.WriteLine();

        for (int column = 0; column < maxColumn; column++)
            Console.Write($"{matrix[line, column]:0.00} ");
    }
}

do
{
    Console.Clear();

    do
    {
        Console.Write("Comands:\n\n[1] Autofill\n[2] Fill manually\n\nCommand: ");

        switch (int.Parse(Console.ReadLine()))
        {
            case 1:
                for (int line = 0; line < maxLine; line++)
                    for (int column = 0; column < maxColumn; column++)
                    {
                        matrixA[line, column] = new Random().Next(0, 10);
                        matrixB[line, column] = new Random().Next(0, 10);
                    }

                canContinue = true;

                break;

            case 2:
                for (int line = 0; line < maxLine; line++)
                {
                    Console.WriteLine();

                    for (int column = 0; column < maxColumn; column++)
                    {
                        Console.Write($"[Matrix 1]Type {line + column}° number: ");
                        matrixA[line, column] = int.Parse(Console.ReadLine());
                    }
                }

                for (int line = 0; line < maxLine; line++)
                {
                    Console.WriteLine();

                    for (int column = 0; column < maxColumn; column++)
                    {
                        Console.Write($"[Matrix 2]Type {line + column}° number: ");
                        matrixB[line, column] = int.Parse(Console.ReadLine());
                    }
                }

                canContinue = true;

                break;

            default:
                canContinue = false;
                break;
        }
    } while (!canContinue);

    do
    {
        Console.Clear();

        Console.Write("Type operation ('x' or '/' or '+' or '-'):  ");
        operation = char.Parse(Console.ReadLine());

    } while (operation != '+' && operation != '-' && operation != 'x' && operation != '/');

    switch (operation)
    {
        case '+':
            for (int line = 0; line < maxLine; line++)
                for (int column = 0; column < maxColumn; column++)
                    matrixR[line, column] = matrixA[line, column] + matrixB[line, column];

            break;

        case '-':
            for (int line = 0; line < maxLine; line++)
                for (int column = 0; column < maxColumn; column++)
                    matrixR[line, column] = matrixA[line, column] - matrixB[line, column];

            break;

        case 'x':
            for (int line = 0; line < maxLine; line++)
                for (int column = 0; column < maxColumn; column++)
                    matrixR[line, column] = matrixA[line, column] * matrixB[line, column];

            break;

        case '/':
            for (int line = 0; line < maxLine; line++)
                for (int column = 0; column < maxColumn; column++)
                    if (matrixB[line, column] != 0)
                        matrixR[line, column] = matrixA[line, column] / matrixB[line, column];
                    else
                        matrixR[line, column] = float.NaN;

            break;
    }

    Console.Clear();

    ImprimirMatriz(matrixA, "Matrix A");

    ImprimirMatriz(matrixA, "Matrix B");

    switch (operation)
    {
        case '+':
            type = "Summed matrix";
            break;
        case '-':
            type = "Subtracted matrix";
            break;
        case 'x':
            type = "Multiplied matrix";
            break;
        case '/':
            type = "Divided matrix";
            break;
    }

    ImprimirMatriz(matrixR, type);

    Console.WriteLine("\n\nPress 'y' to restart");

} while (Console.ReadLine() == "y");