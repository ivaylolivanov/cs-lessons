# Масиви - Въведение

## Цел

Тази практическа сесия въвежда основните операции с масиви в C# - деклариране, инициализиране, достъп до елементи и обхождане.

## Декларация и инициализация

``` c#
// Само декларация, без стойност
int[] onlyDeclaredArray;

// Декларация с фиксирана дължина, всички елементи са 0
int[] myFirstArray = new int[10];

// Декларация с дължина и стойности наведнъж
int[] myFullArray = { 1, -2, 17, 10, -33, 100, 4 };

// Float масив - само дължина
float[] myFirstFloatArray = new float[10];
// Задаване на 3-тия елемент
myFirstFloatArray[2] = 3.14f;

// Double масив с ръчно зададени всички елементи
double[] aDoubleArray = new double[4];
aDoubleArray[0] = 3.14;
aDoubleArray[1] = 4.41;
aDoubleArray[2] = -5.67;
aDoubleArray[3] = 19.5;
```

## Обхождане

Масив може да се обходи с различни видове цикли. Свойството `Length` дава броя на елементите.

``` c#
// С for цикъл
for (int i = 0; i < aDoubleArray.Length; ++i)
{
    Console.WriteLine(aDoubleArray[i]);
}

// С while цикъл
int j = 0;
while (j < myFullArray.Length)
{
    Console.WriteLine(myFullArray[j]);
    ++j;
}

// С do-while цикъл
int p = 0;
do
{
    Console.WriteLine(myFirstArray[p]);
    p++;
} while (p < myFirstArray.Length);

// С foreach цикъл
foreach (int element in myFullArray)
{
    Console.WriteLine(element);
}
```

## Задача

Въведете 10 числа от клавиатура. Добавете 2 към всяко число и го запазете в масив. Накрая изведете масива в обратен ред.
