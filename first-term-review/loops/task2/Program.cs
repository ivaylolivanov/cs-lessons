int number = 0;
int lastNumber = number;
int diff = 0;
int length = 0;
int maxLength = 0;

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
        if (length > maxLength)
        {
            maxLength = length;
        }

        diff = 0;
        length = 0;
    }

    lastNumber = number;
} while (number != 0);

Console.WriteLine(maxLength + 1);
