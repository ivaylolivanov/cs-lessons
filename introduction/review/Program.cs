// TASKS: Operations and variables
int a = 3;
int b = 7;
Console.WriteLine(a + b);
Console.WriteLine(a - b);

double c = 3.1415;
Console.WriteLine(c + a);
Console.WriteLine(c * a);

string name = "pencho";
Console.WriteLine(name);

float d = 2.51f;

// double + double
Console.WriteLine(d + c);

// float * int
Console.WriteLine(d * 2);
// float * (float)cast
Console.WriteLine(d * (float)2);
// float * float
Console.WriteLine(d * 2f);

// Translate sentence to C#:
// I want to create a float variable with value 5.1234.
float neshto = 5.1234f;

// =============================================================================

// Example:
int number = 5;

string text = Console.ReadLine();
Console.WriteLine(text);

// ===========DAY 2=============================================================
double number1 = 0;
double number2 = 0;

string input = Console.ReadLine();
number1 = double.Parse(input);

input = Console.ReadLine();
number2 = double.Parse(input);

Console.WriteLine(number1);
Console.WriteLine(number2);

if (number1 > 0)
{
    Console.WriteLine("Positive");
}
else
{
    Console.WriteLine("Negative");
}

// ===========DAY 3=============================================================
Console.WriteLine("Number:");
string day3Input = Console.ReadLine();

int age = int.Parse(day3Input);
if (age < 0)
    Console.WriteLine("Not born yet!");
else if (age < 18)
    Console.WriteLine("Still a minor!");
else
    Console.WriteLine("Now a senior!");
