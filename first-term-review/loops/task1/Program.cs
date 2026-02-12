int number = 0;
int negative = 0;

do
{
    number = int.Parse(Console.ReadLine());
    if (number < 0)
    {
        int digits = 0;
        int numberCopy = number;
        while (numberCopy != 0)
        {
            numberCopy = numberCopy / 10;
            digits++;
        }

        if ((digits % 2) == 0)
        {
            negative = number;
            break;
        }
    }

} while (number != 0);

if (negative == 0)
{
    Console.WriteLine("No suitable number found!");
}
else
{
    Console.WriteLine(negative);
}
