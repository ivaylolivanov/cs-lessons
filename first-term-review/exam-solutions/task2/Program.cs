int n = int.Parse(Console.ReadLine());
int count = 0;
int[] arr = new int[n];

// NOTE: Alternatives
// int i = 0;
// do
// {
// } while (i < n);

// while (i < n)
// {
// }
for (int i = 0; i < n; ++i)
{
    arr[i] = int.Parse(Console.ReadLine());
}

for (int i = 0; i < n; ++i)
{
    bool hasPrev = (i - 1) >= 0;
    bool hasNext = (i + 1) < arr.Length; // n
    bool isOdd = (arr[i] % 2) != 0;
    bool isBiggerThanPrev  = hasPrev && (arr[i] > arr[i-1]);
    bool isSmallerThanNext = hasNext && (arr[i] < arr[i+1]);

    // NOTE: Compare this 'if' with the one below
    // if (((i-1) >= 0) && ((i+1) < n) && ((arr[i] % 2) != 0) && (arr[i] > arr[i-1]) && (arr[i] < arr[i+1]))

    if (isOdd && isBiggerThanPrev && isSmallerThanNext)
        count++;
}
