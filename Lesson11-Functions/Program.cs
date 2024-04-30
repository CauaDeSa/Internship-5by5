int size;

float[,] matrixA;
float[,] matrixB;
float[,] matrixR;

char operation;
string type = "";
bool canContinue;

void SystemTitle()
{
    Console.Clear();
    Console.WriteLine("___  ___      _        _        _____                      _   _                 \r\n|  \\/  |     | |      (_)      |  _  |                    | | (_)                \r\n| .  . | __ _| |_ _ __ ___  __ | | | |_ __   ___ _ __ __ _| |_ _  ___  _ __  ___ \r\n| |\\/| |/ _` | __| '__| \\ \\/ / | | | | '_ \\ / _ \\ '__/ _` | __| |/ _ \\| '_ \\/ __|\r\n| |  | | (_| | |_| |  | |>  <  \\ \\_/ / |_) |  __/ | | (_| | |_| | (_) | | | \\__ \\\r\n\\_|  |_/\\__,_|\\__|_|  |_/_/\\_\\  \\___/| .__/ \\___|_|  \\__,_|\\__|_|\\___/|_| |_|___/\r\n                                     | |                                         \r\n                                     |_|                                         ");
}

float[,] matrixLength(int size)
{
    return new float[size, size];
}

float[,] AutoFillMatrix()
{
    float[,] matrix = new float[size, size];

    for (int line = 0; line < size; line++)
        for (int column = 0; column < size; column++)
            matrix[line, column] = new Random().Next(0, 100);

    return matrix;
}

float[,] ManuallyFillMatrix(int type)
{
    float[,] matrix = new float[size, size];

    for (int line = 0; line < size; line++)
    {
        Console.WriteLine();

        for (int column = 0; column < size; column++)
        {
            Console.Write($"[Matrix {type}]Type {line + column}° number: ");
            matrix[line, column] = int.Parse(Console.ReadLine());
        }
    }

    return matrix;
}

void ShowMatrix(float[,] matrix, string title, char type)
{
    Console.WriteLine($"\n\n{title}");
    if (type != '/')
    {
        for (int line = 0; line < size; line++)
        {
            Console.WriteLine();

            for (int column = 0; column < size; column++)
                Console.Write($"{matrix[line, column]:000} ");
        }
    }
    else
    {
        Console.WriteLine($"\n\n {title}");

        for (int line = 0; line < size; line++)
        {
            Console.WriteLine();

            for (int column = 0; column < size; column++)
                Console.Write($"{matrix[line, column]:0.00} ");
        }
    }
}

char ShowMenu()
{
    char op;

    do
    {
        Console.Write("Choose an operation:\nSum      (+)" +
                                          "\nSubract  (-)" +
                                          "\nMultiply (x)" +
                                          "\nDivide   (/)" +
                                          "\n\nOperation:  ");
        op = char.Parse(Console.ReadLine());
    } while (op != '+' && op != '-' && op != 'x' && op != '/');

    return op;
}

float[,] MatrixSum(float[,] A, float[,] B)
{
    float[,] R = new float[size, size];

    for (int line = 0; line < size; line++)
    {
        for (int column = 0; column < size; column++)
        {
            R[line, column] = A[line, column] + B[line, column];

        }
    }

    return R;
}

float[,] MatrixSubtract(float[,] A, float[,] B)
{
    float[,] R = new float[size, size];

    for (int line = 0; line < size; line++)
        for (int column = 0; column < size; column++)
            R[line, column] = A[line, column] - B[line, column];

    return R;
}

float[,] MatrixMultiply(float[,] A, float[,] B)
{
    float[,] R = new float[size, size];

    for (int line = 0; line < size; line++)
        for (int column = 0; column < size; column++)
            R[line, column] = A[line, column] * B[line, column];

    return R;
}

float[,] MatrixDivide(float[,] A, float[,] B)
{
    float[,] R = new float[size, size];

    for (int line = 0; line < size; line++)
        for (int column = 0; column < size; column++)
            if (B[line, column] != 0)
                R[line, column] = A[line, column] / B[line, column];
            else
                matrixR[line, column] = float.NaN;

    return R;
}

do
{
    SystemTitle();

    Console.Write("Type matrix size [x, x]: ");

    size = int.Parse(Console.ReadLine());

    matrixA = matrixLength(size);
    matrixB = matrixLength(size);
    matrixR = matrixLength(size);

    SystemTitle();

    do
    {
        Console.Write("\n[1] Autofill\n[2] Manually fill\n\nChoose: ");

        switch (int.Parse(Console.ReadLine()))
        {
            case 1:
                matrixA = AutoFillMatrix();
                matrixB = AutoFillMatrix();

                canContinue = true;
                break;

            case 2:
                matrixA = ManuallyFillMatrix(1);
                matrixB = ManuallyFillMatrix(2);

                canContinue = true;
                break;

            default:
                canContinue = false;
                break;
        }

    } while (!canContinue);

    SystemTitle();
    operation = ShowMenu();

    switch (operation)
    {
        case '+':
            matrixR = MatrixSum(matrixA, matrixB);
            break;

        case '-':
            matrixR = MatrixSubtract(matrixA, matrixB);
            break;

        case 'x':
            matrixR = MatrixMultiply(matrixA, matrixB);
            break;

        case '/':
            matrixR = MatrixDivide(matrixA, matrixB);
            break;
    }

    SystemTitle();

    ShowMatrix(matrixA, "Matrix A", '0');
    ShowMatrix(matrixB, "Matrix B", '0');

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

    ShowMatrix(matrixR, type, operation);

    Console.WriteLine("\n\nPress 'y' to restart");

} while (Console.ReadLine() == "y");