int number = int.Parse(Console.ReadLine());
int sum = 0;
// while(number != 0)
for (; number != 0;)
{
    int digit = number % 10;
    number = number / 10;

    if ((digit % 2) == 0)
    {
        sum = sum + digit;
    }
}

Console.WriteLine(sum);
