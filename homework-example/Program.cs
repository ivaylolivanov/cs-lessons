Console.WriteLine("Input the amount of numbers that will follow:");
string input = Console.ReadLine();
int count = int.Parse(input);

double sum = 0;
for (int i = 0; i < count; ++i)
{
    input = Console.ReadLine();
    double number = double.Parse(input);

    sum += number;
}

Console.WriteLine("Average sum:");
Console.WriteLine(sum / count);
