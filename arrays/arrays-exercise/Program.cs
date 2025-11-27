int size = int.Parse(Console.ReadLine());
int[] array = new int[size];
int max = int.MinValue;
int min = int.MaxValue;
int sum = 0;
int search = int.Parse(Console.ReadLine());
bool isFound = false;
for (int i = 0; i < array.Length; i++)
{
    array[i] = int.Parse(Console.ReadLine());
    sum += array[i];
    if (array[i] > max)
    {
        max = array[i];
    }
    if (array[i] < min)
    {
        min = array[i];
    }
    if (search == array[i])
    {
        isFound = true;
    }
}

if (isFound)
{
    Console.WriteLine("Number found");
}

Console.WriteLine(sum / array.Length);
Console.WriteLine(sum);
Console.WriteLine(max + " " + min);

int firstNumber = array[0];
for (int i = 1; i < array.Length; i++)
{
    array[i - 1] = array[i];
}
array[array.Length - 1] = firstNumber;

Console.WriteLine("Rotated array:");
for (int i = 0; i < array.Length; i++)
{
    if (i == array.Length - 1)
        Console.WriteLine(array[i]);
    else
        Console.Write(array[i] + ", ");
}

Console.WriteLine();
