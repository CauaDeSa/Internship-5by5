int numero;
int[] numeros = new int[5];
char[] palavra = new char[5];

for (int i = 0; i < palavra.Length; i++)
{
    //Console.Write("Digite um valor: ");
    //numeros[i] = int.Parse(Console.ReadLine());

    Console.Write("Digite um caractere: ");
    palavra[i] = char.Parse(Console.ReadLine());
}

for (int i = 0; i < palavra.Length; i++)
{
    //Console.Write($"{numeros[i]} ");
    Console.Write(palavra[i]);
}

Console.Write("\nPress any key to continue: ");
Console.ReadKey();