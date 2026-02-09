/*
 * Numbers from 0 100, including.
 * Print each 10 numbers on new line.
 *
 * Example:
 * 0  1  2  3  4  5  6  7  8  9
 * 10 11 12 13 14 15 16 17 18 19
 *              ...
 * 100
 */

Console.WriteLine("This is made with for:");
for (int i = 0; i <= 100; i++)
{
    Console.Write(i + " ");

    if (i % 10 == 9)
    {
        Console.WriteLine();
    }
}
Console.WriteLine();

Console.WriteLine("This is made with while:");
int num = 0;
while (num <= 100)
{
    Console.Write(num + " ");

    if (num % 10 == 9)
    {
        Console.WriteLine();
    }

    num++;
}
Console.WriteLine();

Console.WriteLine("This is made with do-while:");
num = 0;
do
{
    Console.Write(num + " ");
    if (num % 10 == 9)
    {
        Console.WriteLine();
    }

    num++;
} while (num <= 100);
Console.WriteLine();
