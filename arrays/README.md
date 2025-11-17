# Масиви

## Защо?

В програмиранет, а често и в живота, се налага да запазваме поредица от информация, която е от един и същ тип на едно място.

## Какво са масивите?

Масивите са наредена, еднотиппна колекция от данни с краен брой елементи.
Можем да мислим за масива като променлива, която държи други променлви.
Ако ползваме аналогията с кутиите (променливи), то тогава можем да кажем, че масива е кутия с кутии.

Например:
"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
5, 14, 16, 18, 20, 21, 100

## Как се създаа

Създаване на масив с 4 целочислени елемента.

``` c#
int[] numbers = new int [4];
```

Създаване на масив със 7 текстови елемента заложени при самото създаване.

``` c#
string[] days = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
```

## Как да използваме масивите
Важно е да помним, че масивите започват да броят елементите си от 0. Тоест на индекс 1 е вторият елемент ако има такъв.

### Задаване на стойност

``` c#
numbers[0] = 3;
...
numbers[4] = 27;
```

### Операции с елементи на масив

``` c#
// Събиране
numbers[0] + numbers[2];

// Събиране и присвояване
numbers[1] = numbers[0] + numbers[2];
```

## Обхождане на масив с цикъл

``` c#
// Traverse an array with for loop;
for (int i = 0; i < aDoubleArray.Length; ++i)
{
    Console.WriteLine(aDoubleArray[i]);
}

// Traverse an array with while loop;
int j = 0;
while (j < myFullArray.Length)
{
    Console.WriteLine(myFullArray[j]);
    ++j;
}

// Traverse an array with do-while loop;
int p = 0;
do
{
    Console.WriteLine(myFirstArray[p]);
    p++;
} while (p < myFirstArray.Length);

// Traversing an array with foreach loop;
Console.WriteLine("foreach loop:");
foreach (int element in myFullArray)
{
    Console.WriteLine(element);
}
```

## Кога използваме масиви

- Когато ни трябват повече от една стойност.
- Всички стойности са от един и същ тип данни.
- Искаме да обработим повече от 1 стойност.
