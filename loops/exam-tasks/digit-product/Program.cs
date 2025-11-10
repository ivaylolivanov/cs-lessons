// Задача - Произведение на нечетните цифри в число
// Въведете цяло число от клавиатура. Изведете на екрана произведението от
// нечетните му цифри.

string input = Console.ReadLine();
int num = int.Parse(input);

// Solution 1:
num = Math.Abs(num);
input = num.ToString();

int product = 1;
foreach (char c in input)
{
    // int d = int.Parse(c.ToString());
    int d = c - '0';
    if (d % 2 != 0)
    {
        product = product * d;
    }
}
Console.WriteLine(product);


// Solution 2:
if (num < 0)
    num = num * -1;

int product2 = 1;
while (num != 0)
{
    int digit = num % 10;
    if ((digit % 2) != 0)
        product2 *= digit;

    num /= 10;
}
Console.WriteLine(product2);
