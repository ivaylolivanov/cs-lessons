int n = int.Parse(Console.ReadLine());
int[] array = new int[n];
bool hasOdds = false;

for (int i = 0; i < n; i++)
{
    array[i] = int.Parse(Console.ReadLine());
    if ((array[i] % 2) != 0)
    {
        hasOdds = true;
        Console.WriteLine(array[i]);
    }
}

if (!hasOdds)
{
    Console.WriteLine("No Odds!");
}
