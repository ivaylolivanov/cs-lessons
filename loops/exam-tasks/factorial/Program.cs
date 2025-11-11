int num =int.Parse(Console.ReadLine());
if (num < 0)
{
    Console.WriteLine("this number is negative");


}
else
{
    if (num == 0)
    {
        Console.WriteLine(1);
    }
    else
    {
        int product = 1;
        for (int i = 1; i <= num; i++)
        {
            product = product* i;
        }
        Console.WriteLine(product);
    }
}
