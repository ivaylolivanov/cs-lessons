/*
  Направете програма, която чете 2 реални числа от конзолата -
a и b. Изведете на екрана резултата от сумата, разликата,
произведението и делението на a с b. Съобразете ограниченията
на операциите и ако дадена операция е невъзможна, изведете
съобщение "Operation Impossible!".
*/
double a = double.Parse(Console.ReadLine());
double b = double.Parse(Console.ReadLine());
Console.WriteLine(a + b);
Console.WriteLine(a - b);
Console.WriteLine(a * b);
if (b != 0)
{
    Console.WriteLine(a / b);
}
else
{
    Console.WriteLine("Operation impossible");
}


/*
  Прочетете число от клавиатура, което ще бележи край на
  числова редица. Съберете всички числа от 1 (включително)
  до N(включително; числото, което е въведено), които са
  кратни на 3.
 */
int n = int.Parse(Console.ReadLine());
int sum = 0;
for (int i = 1; i <= n; i++)
{
    if ((i % 3) == 0)
    {
        sum = sum + i;
    }
}

Console.WriteLine(sum);
