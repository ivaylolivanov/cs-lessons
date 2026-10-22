int start = int.Parse(Console.ReadLine());
int end   = int.Parse(Console.ReadLine());

Console.WriteLine("So");
if (start > end)
{
    for (int i = start; i >= end; --i)
    {
        Console.WriteLine(i);
    }
}
else if (start == end)
{
    Console.WriteLine("ERROR: No range");
    Console.WriteLine(start);
}
else
{
    for (int i = start; i <= end; ++i)
    {
        Console.WriteLine(i);
    }
}

Console.WriteLine("Scope demonstration");
int p = 0;
while (p < 10)
{
    int number = 7;
    ++p;
}

// We cannot use 'number' outside the loop here

while (p < 15)
{
    Console.WriteLine(p);
    ++p;
}

Console.WriteLine("Solution with while");
int whileStart = int.Parse(Console.ReadLine());
int whileEnd   = int.Parse(Console.ReadLine());
if (whileStart > whileEnd)
{
    while (whileStart >= whileEnd)
    {
        Console.WriteLine(whileStart);
        whileStart--;
    }
}
else if (whileStart == whileEnd)
{
    Console.WriteLine("ERROR: No range");
    Console.WriteLine(whileStart);
}
else
{
    while (whileStart <= whileEnd)
    {
        Console.WriteLine(whileStart);
        whileStart++;
    }
}
