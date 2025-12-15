int n = int.Parse(Console.ReadLine());
int[] array = new int[n];

for (int index = 0; index < array.Length; index++)
{
    array[index] = int.Parse(Console.ReadLine());
}

// Solution 1:
/*
int firstNumber  = array[0];
int secondNumber = array[1];
for (int i = 2; i < array.Length; i++)
{
    array[i - 2] = array[i];
}

array[array.Length - 2] = firstNumber;
array[array.Length - 1] = secondNumber;

for (int i = 0; i < array.Length; i++)
{
    Console.WriteLine(array[i]);
}
*/

// Solution 2:
for (int repetition = 0; repetition < 2; repetition++)
{
    int firstNumber = array[0];
    int secondNumber = array[1];
    for (int i = 1; i < array.Length; i++)
    {
        array[i - 1] = array[i];
    }
}

for (int i = 0; i < array.Length; i++)
{
    Console.WriteLine(array[i]);
}
