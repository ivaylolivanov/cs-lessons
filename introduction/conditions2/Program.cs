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


// Exercise Task1, basic:
/*
string movie = Console.ReadLine();
int ticketPrice = int.Parse(Console.ReadLine());
int popcornPrice = int.Parse(Console.ReadLine());
bool wantsPopcorn = true;

int total = ticketPrice;
if (wantsPopcorn)
{
    total = total + popcornPrice;
}

Console.WriteLine(movie + ", общо: " + total + " евро.");
*/

// Exercise Task1, bonus condition:
string movie = Console.ReadLine();
int ticketPrice = int.Parse(Console.ReadLine());

string question = Console.ReadLine();
bool wantsPopcorn = false;
if (question == "Yes" || question == "yes" || question == "YES")
    wantsPopcorn = true;

int total = ticketPrice;
if (wantsPopcorn)
{
    int popcornPrice = int.Parse(Console.ReadLine());
    total = total + popcornPrice;
}
