/*
 * Създайте променлива с цяло число по ваш избор (не се въвежда от
 клавиатура, а
 * се задава стойност в самия код). Приемайте догадки от потребителя
 докато той
 * не познае това число. Ако числото, въведено от потребителя е по-малко
 от
 * стойността на променливата, изведете насочващо съобщение -
 * “Your guess is lower”. Съответно ако числото на потребителя е
 по-голямо -
 * “Your guess is higher”. Когато числото е познато изведете
 съобщение “You win!”.
 */
int num = 14;
int guess;
do
{
    guess = int.Parse(Console.ReadLine());
    if (guess > num)
    {
        Console.WriteLine("Your guess is higher");
    }
    else if (guess < num)
    {
        Console.WriteLine("Your guess is lower");
    }
} while (guess != num);
Console.WriteLine("You win");
