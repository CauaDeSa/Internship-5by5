int size, result;

int[] results;
int[,] matrix;

char operation;

int[,] initMatrix(int size)
{
    return new int[size, size];
}

int[,] AutoFillMatrix()
{
    int[,] matrix = new int[size, size];

    for (int line = 0; line < size; line++)
        for (int column = 0; column < size; column++)
            matrix[line, column] = new Random().Next(0, 10);

    return matrix;
}

void ShowMatrix(int[,] matrix, int size, string title)
{
    if (title.Length != 0)
        Console.WriteLine($"\n{title}");

    for (int line = 0; line < size; line++)
    {
        for (int column = 0; column < size; column++)
            Console.Write($"{matrix[line, column]:000} ");

        Console.WriteLine();
    }
}

char ShowMenu()
{
    char op;

    do
    {
        Console.Write("\nChoose an operation:\nColumns Sum................( | )" +
                                          "\nLines Sum..................( - )" +
                                          "\nLeft-to-right digaonal sum ( \\ )" +
                                          "\nRight-to-left digaonal sum ( / )" +
                                          "\n\nOperation: ");
        op = char.Parse(Console.ReadLine());
    } while (op != '|' && op != '-' && op != '/' && op != '\\');

    return op;
}

int[] SumColumns(int[,] matrix, int size)
{
    int[] results = new int[size];

    for (int column = 0, result = 0; column < size; column++)
    {
        for (int line = 0; line < size; line++)
            result += matrix[line, column];

        results[column] = result;
        result = 0;
    }

    return results;
}

int[] SumLines(int[,] matrix, int size)
{
    int[] results = new int[size];

    for (int line = 0, result = 0; line < size; line++)
    {
        for (int column = 0; column < size; column++)
            result += matrix[line, column];

        results[line] = result;
        result = 0;
    }

    return results;
}

int SumLeftToRightDiagonal(int[,] matrix, int size)
{
    int diagonalResult = 0;

    for (int line = 0; line < size; line++)
        diagonalResult += matrix[line, line];

    return diagonalResult;
}

int SumRightToLeftDiagnoal(int[,] matrix, int size)
{
    int diagonalResult = 0;

    for (int line = size - 1, column = 0; line >= 0; line--, column++)
        diagonalResult += matrix[column, line];

    return diagonalResult;
}

void ShowResults(int[,] matrix, int[] results, int size, char type)
{
    Console.WriteLine();

    if (type == '|')
    {
        ShowMatrix(matrix, size, "");

        for (int i = 0; i < size; i++)
            Console.Write("----");

        Console.WriteLine();

        for (int i = 0; i < size; i++)
            Console.Write($"{results[i]:000} ");
    }
    else
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
                Console.Write($"{matrix[i, j]} ");

            Console.Write($"| {results[i]}\n");
        }
}

void ShowResult(int[,] matrix, int result, int size, char type)
{
    Console.WriteLine();

    if (type == '\\')
    {
        Console.WriteLine();
        ShowMatrix(matrix, size, "");

        for (int i = 0; i < size; i++)
            Console.Write("    ");
        Console.WriteLine($"{result}");

    }
    else
    {

        Console.WriteLine();

        for (int i = 0; i < size; i++)
            Console.Write("    ");
        Console.WriteLine($"{result}");

        ShowMatrix(matrix, size, "");
    }
}

do
{
    Console.Clear();

    Console.Write("Type matrix size [x, x]: ");
    size = int.Parse(Console.ReadLine());

    matrix = initMatrix(size);
    matrix = AutoFillMatrix();

    ShowMatrix(matrix, size, "Generated matrix");

    operation = ShowMenu();

    switch (operation)
    {
        case '|':
            results = SumColumns(matrix, size);
            ShowResults(matrix, results, size, operation);
            break;

        case '-':
            results = SumLines(matrix, size);
            ShowResults(matrix, results, size, operation);
            break;

        case '\\':
            result = SumLeftToRightDiagonal(matrix, size);
            ShowResult(matrix, result, size, operation);
            break;

        case '/':
            result = SumRightToLeftDiagnoal(matrix, size);
            ShowResult(matrix, result, size, operation);
            break;
    }

    Console.Write("\n\nType 'y' to try again: ");
} while (Console.ReadLine() == "y");