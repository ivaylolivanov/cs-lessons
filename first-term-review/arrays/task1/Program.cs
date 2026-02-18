int minValue = int.MaxValue;

short[] temperatures = new short[30];

for (int i = 0; i < temperatures.Length; i++)
{
    temperatures[i] = short.Parse(Console.ReadLine());
    if (temperatures[i] < minValue)
    {
        minValue = temperatures[i];
    }
}

Console.WriteLine($"The lowest temperature: {minValue}");
Console.WriteLine(minValue);
