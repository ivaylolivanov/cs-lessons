int[] array = new int[7];
int max = int.MinValue;
int min = int.MaxValue;
int sum = 0;
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
}
Console.WriteLine(sum);
Console.WriteLine(max + " " + min);
