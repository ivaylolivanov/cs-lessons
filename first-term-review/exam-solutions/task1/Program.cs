int n = int.Parse(Console.ReadLine());
int[] numbers = new int[n];
int sum = 0;
int count = 0;
int average = 0;
for (int i = 0; i < n; i++)
{
    numbers[i] = int.Parse(Console.ReadLine());
    sum += numbers[i];
}
average = sum / n;

for (int i = 0; i < n; i++)
{
    if (average == numbers[i])
    {
        count++;
    }
}
Console.WriteLine(count);

if (count > 0)
{
    int MaxValue = int.MinValue;
    for (int i = 0; i < n; i++)
    {
        if ((numbers[i] > MaxValue)
            && (numbers[i] < count))
        {
            MaxValue = numbers[i];
        }
    }

    Console.WriteLine(MaxValue);
}
