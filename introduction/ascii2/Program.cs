char symbol = '\'';
char strange = '\\';
char newSymbol = (char)(symbol - 7);
int newLineNumber = 10;
Console.WriteLine(symbol * 2);
Console.WriteLine(symbol / 3);
Console.WriteLine(symbol - 7);
Console.WriteLine(symbol + 5);
Console.WriteLine(strange * 3);
Console.Write((char)newLineNumber);
Console.WriteLine("asdfasdf");
string input = Console.ReadLine();
char myLetter = char.Parse(input);
if ((myLetter >= 'A') & (myLetter<= 'Z'))
{
    Console.WriteLine(
        "Your letter is capital");
}

// Task: Calculator
string calcInput = Console.ReadLine();
char operation = char.Parse(calcInput);
// NOTE: It could also be done like this:
// char operation = input[0];
calcInput = Console.ReadLine();
double number = double.Parse(calcInput);
calcInput = Console.ReadLine();
double number2 = double.Parse(calcInput);

if (operation == '+')
{
    Console.WriteLine(number + number2);
}
else if (operation == '-')
{
    Console.WriteLine(number - number2);
}
else if (operation == '*')
{
    Console.WriteLine(number * number2);
}
else if ((operation == '/') || (operation == ':'))
{
    if (number2 != 0)
    {
        Console.WriteLine(number / number2);
    }
    else
    {
        Console.WriteLine("Cannot divide on 0!");
    }
}
else
{
    Console.WriteLine(operation + " is not supported!");
}
