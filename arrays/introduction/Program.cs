// Array declaration, no value given;
int[] onlyDeclaredArray;

// Array declaration, only length specified, all values are 0;
int[] myFirstArray = new int[10];

// Array declaration, length(7) and values;
int[] myFullArray = { 1, -2, 17, 10, -33, 100, 4 };

// Float array declaration, only length;
float[] myFirstFloatArray = new float[10];
// Setting its 3rd element to 3.14;
myFirstFloatArray[2] = 3.14f;

// Creating and Assigning all elements of an array;
double[] aDoubleArray = new double[4];
aDoubleArray[0] = 3.14;
aDoubleArray[1] = 4.41;
aDoubleArray[2] = -5.67;
aDoubleArray[3] = 19.5;

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
