int number = 0;
int lastNumber = number;
int diff = 0;
int length = 0;

do
{
    number = int.Parse(Console.ReadLine());

    diff = number - lastNumber;
    if ((diff == 1) || (diff == number))
    {
        length++;
    }
    else
    {
    }

    lastNumber = number;
} while (number != 0);
