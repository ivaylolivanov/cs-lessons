// Does not work: "13" + "15";
string num1 = "13";
string num2 = "15";
string result = num1 + num2;

Console.WriteLine(result);
Console.WriteLine("13" + "15");

int number  = 13;
int number2 = 15;
Console.WriteLine(number + number2);

// Introduction code snippet:
int age = 32;
string name = Console.ReadLine();
string favoriteFood = Console.ReadLine();
string hobby = Console.ReadLine();
Console.WriteLine("I am " + name);

name = Console.ReadLine();
Console.WriteLine("I am " + name);
Console.WriteLine("I am " + name);
Console.WriteLine("I am " + age + " years old");
Console.WriteLine("My favorite food is: " + favoriteFood);
Console.WriteLine("My hobby is: " + hobby);

name = Console.ReadLine();
hobby = Console.ReadLine();
// GOAL:
// But Sasho's hobby is: swimming
Console.WriteLine(
    "But " + name "'s hobby is: " + hobby);
