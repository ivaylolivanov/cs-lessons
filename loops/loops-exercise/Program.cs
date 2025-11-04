/*
  Задача:
  Въведете число от клавиатура.
  Това число ще е броя на числата, от които ще търсим
  максималното.
  Изход:
  Максималното число.
 */
int num = int.Parse(Console.ReadLine());
int max = int.MinValue;
for (int i = 0; i < num; i++)
{
    int n = int.Parse(Console.ReadLine());
    if (n > max)
    {
        max = n;
    }
}

Console.WriteLine(max);

// 2ра Задача
Console.WriteLine("Task 2");
int number = int.Parse(Console.ReadLine());
while(number > 10)
{
    Console.WriteLine(number % 10);
    number = number / 10;
}
Console.WriteLine(number);

// 3та Задача
Console.WriteLine("Task 3");
int primeNumber = int.Parse(Console.ReadLine());
for (int i = 2; i < primeNumber; i++)
{
    if (primeNumber % i == 0)
    {
        Console.WriteLine(i + " is not a prime number");
        break;
    }
}
