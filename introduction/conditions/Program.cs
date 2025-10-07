﻿string input = Console.ReadLine();
int year = int.Parse(input);

bool isDivisibleBy4      = (year % 4) == 0;
bool isNotDivisibleBy100 = (year % 100) != 0;
bool isDivisibleBy400    = (year % 400) == 0;
if ((isDivisibleBy4 && isNotDivisibleBy100) || isDivisibleBy400)
    Console.WriteLine("Leap year");
else
    Console.WriteLine("Normal year");
