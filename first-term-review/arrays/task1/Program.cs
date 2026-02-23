int minValue = int.MaxValue;
int maxValue = int.MinValue;

short[] temperatures = new short[5];
double average = 0;
for (int i = 0; i < temperatures.Length; i++)
{
    temperatures[i] = short.Parse(Console.ReadLine());
    average += temperatures[i];
    if (temperatures[i] < minValue)
    {
        minValue = temperatures[i];
    }

    if (temperatures[i] > maxValue)
    {
        maxValue = temperatures[i];
    }
}

average = Math.Round(average / temperatures.Length, 2);
short count = 0;
for (int i = 0; i < temperatures.Length; i++)
{
    if (temperatures[i] < average)
    {
        count++;
    }
}

Console.WriteLine($"The lowest temperature:     {minValue}");
Console.WriteLine($"The highest temperature:    {maxValue}");
Console.WriteLine($"The average temperature:    {average}");
Console.WriteLine($"Temperatures below average: {count}");
