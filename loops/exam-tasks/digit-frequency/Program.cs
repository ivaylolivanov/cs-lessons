int num = int.Parse(Console.ReadLine());
int digit = int.Parse(Console.ReadLine());
int counter = 0;
while (num != 0)
{
    int d = num % 10;
    if (d == digit)
    {
        counter++;
    }

    num = num / 10;
}
Console.WriteLine(counter);
