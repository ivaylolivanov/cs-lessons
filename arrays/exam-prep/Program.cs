int n  = int.Parse(Console.ReadLine());
int[] Array = new int[n];
int Max = int.MinValue;
int sum = 0;
int negative = 0;
for (int i = 0; i < n; i++)
{
    Array[i] = int.Parse(Console.ReadLine());
    if (Array[i] > 0)
    {
        sum = sum + Array[i];
    }
    else
    {
        negative = negative + Array[i];
    }
}
Console.WriteLine(sum);
Console.WriteLine(negative);
Console.WriteLine(sum + negative / n);
