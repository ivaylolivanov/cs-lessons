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
