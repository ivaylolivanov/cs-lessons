/*Въведете положително цяло число от клавиатура и изведете
  на екрана всички негови делители, които са по-малки от него
  на един ред, разделени с запетая и празно място след нея.*/
int num = int.Parse(Console.ReadLine());
string dividers = "";
for (int i = 1; i < num; i++)
{
    if (num % i == 0)
    {
        if (dividers != "")
            dividers += ", ";

        dividers += i;
    }
}
Console.WriteLine(dividers);
