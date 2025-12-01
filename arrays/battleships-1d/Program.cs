Random rnd = new Random();
int fieldSize = rnd.Next(10, 21);
char[] field = new char[fieldSize];
int ships = 0;

for (int i = 0; i < fieldSize; i++)
{
    int chance = rnd.Next(0, 101);
    if ((chance < 30) && (ships < 3))
    {
        field[i] = 'I';
        ships++;
    }
    else
    {
        field[i] = '~';
    }
}

for (int i = 0; i < fieldSize; i++)
{
    if (field[i] == 'I')
    {
        Console.Write('~');
    }
    else
    {
        Console.Write(field[i]);
    }
}
Console.WriteLine();

while (ships > 0)
{
    int position = int.Parse(Console.ReadLine());
    if ((position < 0) || (position > fieldSize))
    {
        continue;
    }

    if (field[position] == 'I')
    {
        field[position] = 'X';
        ships--;
    }

    for (int i = 0; i < fieldSize; i++)
    {
        if (field[i] == 'I')
        {
            Console.Write('~');
        }
        else
        {
            Console.Write(field[i]);
        }
    }
    Console.WriteLine();
}
