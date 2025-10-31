Console.WriteLine("Loops");
// Solution for printing the first N numbers in all loops

Console.WriteLine("Input number for setting a sequence:");
int n = int.Parse(Console.ReadLine());

int iterator = 0;
while (iterator < n)
{
    Console.WriteLine(iterator);
    iterator++;
}

for (int i = 0; i < n; i++)
{
    Console.WriteLine(i);
}

// Reusing the iterator from the while loop, but making sure it is back to 0.
iterator = 0;
do
{
    Console.WriteLine(iterator);
    iterator++;
} while (iterator < n);


// Example of endless while loop:
/*
  while (true)
  {
      Console.WriteLine("I am infinite loop");
  }
*/

// Example of endless while for:
/*
  for (;;)
  {
      Console.WriteLine("I am infinite loop");
  }
*/

// Sum the even numbers that are bigger than 10 until the sum is >= 50
int sum = 0;
for (int i = 0; i < n; i++)
{
    if (i <= 10)
        continue;

    if ((i % 2) == 0)
        sum += i;

    if (sum >= 50)
        break;
}
