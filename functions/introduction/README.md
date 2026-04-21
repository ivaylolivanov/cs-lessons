# Функции - Въведение

## Цел

Тази практическа сесия демонстрира основните видове функции: без връщана стойност (`void`), с връщана стойност (`bool`, масив) и с параметри.

## Примерни функции

### Функция без връщана стойност

Функцията `PrintNumbers` приема начало и край и извежда всички числа в диапазона.

``` c#
void PrintNumbers(int start, int end)
{
    for (int i = start; i <= end; i++)
    {
        Console.WriteLine(i);
    }
}
```

### Функция с булева връщана стойност

Функцията `IsEven` приема число и връща `true` ако е четно, `false` ако е нечетно.

``` c#
bool IsEven(int number)
{
    bool result = (number % 2) == 0;
    return result;
}
```

### Функция, която връща масив

Функцията `ReadNumbers` приема размер, чете толкова числа от клавиатура и връща масива.

``` c#
int[] ReadNumbers(int size)
{
    int[] numbers = new int[size];
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = int.Parse(Console.ReadLine());
    }

    return numbers;
}
```

## Извикване

``` c#
PrintNumbers(27, 38);
Console.WriteLine("Is 7 an even number: " + IsEven(7));

int[] myNumbers = ReadNumbers(7);
Console.WriteLine(myNumbers[2]);
```
