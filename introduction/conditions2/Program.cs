Console.WriteLine(
    "What is your name?");
string input = Console.ReadLine();
string name = input;

Console.WriteLine(
    "How old are you?");
input = Console.ReadLine();
int age = int.Parse(input);
if (age >= 18)
{
    Console.WriteLine(
        name + " will party!");
}
else if ((age < 18) && (age >= 0))
{
    Console.WriteLine(
        "Go home, " + name + "!");
}
else
{
    Console.WriteLine(
        "Invalid input!");
}
