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

// =========== DAY 4 - Review tasks ============================================
Console.WriteLine("\n\nDAY 4 - Review tasks\n");

string day4Input = Console.ReadLine();
double num = double.Parse(day4Input);
Console.WriteLine(num);

day4Input = Console.ReadLine();
num = double.Parse(day4Input);
Console.WriteLine(num);

string data = Console.ReadLine();
double numTask2 = double.Parse(data);

data = Console.ReadLine();
double num2Task2 = double.Parse(data);

Console.WriteLine("Sum: "           + (numTask2 + num2Task2));
Console.WriteLine("Diff: "          + (numTask2 - num2Task2));
Console.WriteLine("Product: "       + (numTask2 * num2Task2));

if (num2Task2 == 0)
{
    Console.WriteLine("Cannot divide by zero!");
}
else
{
    Console.WriteLine("Modulo: "   + (numTask2 % num2Task2));
    Console.WriteLine("Division: " + (numTask2 / num2Task2));
}

Console.WriteLine("Concatenation: " + numTask2 + num2Task2);

// =========== DAY 5 - Review tasks 2 ==========================================
Console.WriteLine("\n\nDAY 5 - Review tasks part 2\n\n");
double aDay5;
Console.WriteLine("Rectangle side");
string inputDay5 = Console.ReadLine();
aDay5 = double.Parse(inputDay5);
double bDay5;
Console.WriteLine("Rectangle side");
inputDay5 = Console.ReadLine();
bDay5 = double.Parse(inputDay5);

Console.WriteLine("Result: " + (aDay5 * bDay5));

// =========== DAY 6 - Review tasks 2 ==========================================
Console.WriteLine("\n\nDAY 6 - Review tasks part 2\n\n");
string inputDay6 = Console.ReadLine();
double bDay6Num = double.Parse(inputDay6);

inputDay6 = Console.ReadLine();
double a2Day6Num = double.Parse(inputDay6);
double perimeter = 2 * (bDay6Num + a2Day6Num);

Console.WriteLine(perimeter);

// =========== DAY 7 - Review tasks loop =======================================
// while(<CONDITION>) { <BODY> }

int counter = 10;
while (counter > 0)
{
    Console.WriteLine(counter);
    counter--;
}

// for (<ITERATOR>; <CONDITION>; <STEP>) { <BODY> }
for (int iterator1 = 0; iterator1 < 10; iterator1++)
{
    Console.WriteLine(iterator1);
}

int iterator = 10;
for (; iterator > 0; iterator--)
{
    Console.WriteLine(iterator);
}

Console.WriteLine(iterator);
// NOTE: Example of endless for loop
// for (;;)
// {
//     Console.WriteLine("asdf");
// }

for (; iterator > 0;)
{
    Console.WriteLine(iterator);
    iterator--;
}

/*

do
{
    <BODY>
} while (<CONDITION>);

*/

int iterator2 = 0;
do
{
    Console.WriteLine(">> sadfasdfsadf");
} while (iterator2 > 0);


// Task 16 - Sum of first n numbers
Console.WriteLine("\n\nDAY 7 - Loop \n\n");
string inputLoops = Console.ReadLine();

int n = int.Parse(input);
int sum = 0;
int product = 1;
for (int i = 1; i < n; ++i)
{
    sum += i;
    product *= i;
    Console.WriteLine("Sum: " + i.ToString() + " " + sum.ToString());
    Console.WriteLine("Product: " + i.ToString() + " " + product.ToString());
}

Console.WriteLine(sum);
Console.WriteLine(product);

Console.WriteLine("1 to N: ");
for (int i = 1; i <= n; ++i)
{
    Console.WriteLine(i);
}

// =========== DAY 8 - Review tasks loop =======================================
Console.WriteLine("\n\nDAY 8 - Loop part 2 \n\n");

// Task 19
string numTask19 = Console.ReadLine();
int nTask19 = int.Parse(numTask19);
string output = "";
for (int i = 1; i <= nTask19; i++)
{
    if ((i % 2) == 0)
        output += " " + i;
}

Console.WriteLine(output);
