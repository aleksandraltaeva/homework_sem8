// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно выводить массив,
// добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

int[,,] mass = new int[2, 2, 2];
int[,,] resultMass = FillArray(mass, 10, 100);
PrintArray(mass);

//-------заполнение трехмерного массива неповторяющимися двузначными числами------
int[,,] FillArray(int[,,] array, int minValue, int maxValue)
{
    int[] newArray = new int[array.GetLength(0) * array.GetLength(1) * array.GetLength(2)];

    newArray[0] = new Random().Next(minValue, maxValue);
    
    for (int i = 1; i < newArray.Length; i++)
    {
        newArray[i] = new Random().Next(minValue, maxValue);
        int number = newArray[i];
        for (int j = 0; j < i; j++)
        {
            while (newArray[i] == newArray[j])
            {
                newArray[i] = new Random().Next(minValue, maxValue);
                j = 0;
                number = newArray[i];
            }
            number = newArray[i];
        }
    }

    int count = 0;
    for (int a = 0; a < array.GetLength(0); a++)
    {
        for (int b = 0; b < array.GetLength(1); b++)
        {
            for (int c = 0; c < array.GetLength(2); c++)
            {
                array[a, b, c] = newArray[count];
                count++;
            }
        }
    }
    return array;

}

//------вывод трехмерного массива с индексами-----
void PrintArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(1); i++)
    {
        for (int j = 0; j < array.GetLength(2); j++)
        {
            for (int k = 0; k < array.GetLength(0); k++)
            {
                System.Console.Write($"{array[j, k, i]}({j},{k},{i}) ");
            }
            System.Console.WriteLine();
        }
    }
}