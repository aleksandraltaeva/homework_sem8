// Задача 58: Задайте две матрицы. Напишите программу, которая будет
// находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18
int rows1 = InPut("Введите количество строк для первой матрицы: ");
int cols1 = InPut("Введите количество столбцов для первой матрицы: ");

int rows2 = InPut("Введите количество строк для второй матрицы: ");
int cols2 = InPut("Введите количество столбцов для второй матрицы: ");

int[,] mass1 = FillArray(rows1, cols1, 0, 10);
int[,] mass2 = FillArray(rows2, cols2, 0, 10);

PrintArray(mass1);
System.Console.WriteLine();
PrintArray(mass2);
System.Console.WriteLine();

if (cols1 == rows2)
{
    PrintArray(MultiplyMatrix(mass1, mass2));
}
else
{
    System.Console.WriteLine("Данные матрицы невозможно перемножить.");
}

//---------заполнение массива--------
int[,] FillArray(int m, int n, int minValue, int maxValue)
{
    int[,] array = new int[m, n];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return array;
}

//--------вывод массива---------
void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} "); ;
        }
        Console.WriteLine();
    }
}

//-------приглашение ко вводу числа-----
int InPut(string text)
{
    Console.Write(text);
    int num = int.Parse(Console.ReadLine()!);
    return num;
}

//-------метод для данной задачи-----
int[,] MultiplyMatrix(int[,] array1, int[,] array2)
{
    int[,] newArray = new int[array1.GetLength(0), array2.GetLength(1)];

    for (int i = 0; i < array1.GetLength(0); i++)
    {
        for (int j = 0; j < array2.GetLength(1); j++)
        {
            for (int k = 0; k < array1.GetLength(1); k++)
            {
                newArray[i, j] += array1[i, k] * array2[k, j];
            }
        }
    }
    return newArray;
}