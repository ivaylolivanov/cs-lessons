void PrintNumbers(int start, int end)
{
    for (int i = start; i <= end; i++)
    {
        Console.WriteLine(i);
    }
}

bool IsEven(int number)
{
    bool result = (number % 2) == 0;
    return result;
}

int[] ReadNumbers(int size)
{
    int[] numbers = new int[size];
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = int.Parse(Console.ReadLine());
    }

    return numbers;
}

Console.WriteLine("Function:");
PrintNumbers(27, 38);
Console.WriteLine(
    "Is 7 an even number: " + IsEven(7));

int[] myNumbers = ReadNumbers(7);
Console.WriteLine(myNumbers[2]);
