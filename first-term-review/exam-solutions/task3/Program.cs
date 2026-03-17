int n = int.Parse(Console.ReadLine());
int[] numbers = new int[n];
float average = 0;
for (int i = 0; i < n; i++)
{
    numbers[i] = int.Parse(Console.ReadLine());
    average += numbers[i];
}

int count = 0;
average /= n;
for (int i = 0; i < n; i++)
{
    bool isBigger = numbers[i] >= average;
    if (isBigger)
    {
        int duplicates = 0;
        for (int j = 0; j < n; j++)
        {
            bool isDifferent = i != j;
            bool isDup = numbers[i] == numbers[j];
            if (isDifferent && isDup)
            {
                duplicates++;
            }
        }

        if (duplicates > 0)
        {
            count++;
        }
    }
}

Console.WriteLine(count);
