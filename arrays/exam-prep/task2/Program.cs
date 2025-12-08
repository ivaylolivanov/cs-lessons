int n = int.Parse(Console.ReadLine());
int[] array = new int[n];
int max = int.MinValue;
int min = int.MaxValue;

for (int i = 0; i < n; i++)
{
    array[i] = int.Parse(Console.ReadLine());
    if (array[i] > max)
    {
        max = array[i];
    }

    if (array[i] < min)
    {
        min = array[i];
    }
}

int maxPosition = -1;
int minPosition = -1;
int[] newArray = new int[n];
int p = 0;
int newArrayCount = n;
for (int i = 0; i < n; i++)
{
    if (array[i] == max)
    {
        maxPosition = i;
    }

    if (array[i] == min)
    {
        minPosition = i;
    }

    if ((array[i] != min) && (array[i] != max))
    {
        newArray[p] = array[i];
        p++;
        --newArrayCount;
    }
}

Console.WriteLine("Max: " + max + ", index:  " + maxPosition);
Console.WriteLine("Max: " + max + ", index:  " + minPosition);
for (int i = 0; i < newArrayCount; i++)
{
    Console.Write(newArray[i]);
    if (i < (newArrayCount - 1))
        Console.Write(", ");
}
Console.WriteLine();
