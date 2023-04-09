// Задача 57: Составить частотный словарь элементов двумерного массива.
// Частотный словарь содержит информацию о том,
// сколько раз встречается элемент входных данных.
// 1, 2, 3
// 4, 6, 1
// 2, 1, 6
// 1 встречается 3 раз
// 2 встречается 2 раз
// 3 встречается 1 раз
// 4 встречается 1 раз
// 6 встречается 2 раза

int rows = InPut("Введите количество строк: ");
int cols = InPut("Введите количество столбцов: ");
int[,] mass = FillArray(rows, cols, 0, 5);
PrintArray(mass);
System.Console.WriteLine();
CountEl(mass);

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

//-------метод для данной задачи------
void CountEl(int[,] array)
{
    int[] newArray = new int[array.GetLength(0) * array.GetLength(1)];
    int k = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            newArray[k] = array[i, j];
            k++;
        }
    }

    for (int i = 0; i < newArray.Length; i++)
    {
        for (int j = i + 1; j < newArray.Length; j++)
        {
            if (newArray[i] > newArray[j])
            {
                int temp = newArray[i];
                newArray[i] = newArray[j];
                newArray[j] = temp;
            }
        }
    }

    int element = newArray[0];
    int count = 1;
    for (int i = 1; i < newArray.Length; i++)
    {
        if (element != newArray[i])
        {
            System.Console.WriteLine($"{element} встречается {count}");
            element = newArray[i];
            count = 1;
        }
        else
        {
            count++;
        }
    }
    System.Console.WriteLine($"{element} встречается {count}");
}