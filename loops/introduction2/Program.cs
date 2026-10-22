int p = 7;
Console.WriteLine(++p); // 7++, print
Console.WriteLine(p);
Console.WriteLine(p++);// Copy 8, print, then 8++
Console.WriteLine(p);

for (int i = 0; i <= 100; ++i)
{
    Console.WriteLine(i);
}

int number = 0;
while (number <= 100)
{
    // NOTE: Alternative notation
    // Console.WriteLine(number++);
    Console.WriteLine(number);
    number++;
}

do
{
    Console.WriteLine(number);
} while (number <= 100);
