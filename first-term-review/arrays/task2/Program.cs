int n = int.Parse(Console.ReadLine());
int[] numbers = new int[n];
for (int i = 0; i < n; i++)
{
    numbers[i] = int.Parse(Console.ReadLine());
}

int sum = 0;
for (int i = n - 1; i >= 0; i--)
{
    if ((numbers.Length % 2) == 0)
    {
        if ((i % 2) != 0)
        {
            sum += numbers[i];
        }
    }
    else
    {
        if ((i % 2) == 0)
        {
            sum += numbers[i];
        }
    }
}

Console.WriteLine(sum);
