/* Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

Например, задан массив:

1 4 7 2

5 9 2 3

8 4 2 4

5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/ 

void Show2dArray (int [,] array)   //  метод вывода двумерного массива 
{
    for (int i = 0; i < array.GetLength(0); i++) // цикл по строкам
    {
        for (int j =0; j < array.GetLength(1); j++) // цикл по столбцам
        {
        Console.Write(array[i,j] + " ");   // вывод значения + пробел
        }
        Console.WriteLine();
    }
}

int [,] CreateNewArray (int m, int n)  //метод создания нового случайного двумерного массива, размер указывает пользователь
{
    int [,] array = new int[m,n];
    for (int i = 0; i < m; i++)
    {
        for(int j = 0; j < n; j++)
        {    
        array[i,j] = new Random().Next(0, 10); // массив положительных  чисел от 0 до 9
        }
    }
    return array; 
}

int [] SumByStringsInArray (int [,] array)  // метод получения одномерного массива из сумм строк двумерного массива
{
    int stringsCount = array.GetLength(0);
    int columnsCount = array.GetLength(1);
    int [] sumArray = new int[stringsCount];

    for (int i = 0; i < stringsCount; i++) //цикл по строкам
    {
        int sumByStrng = 0;
        for (int j = 0; j < columnsCount ; j++) // цикл в столбце
            {
                  sumByStrng = sumByStrng + array[i,j];
            }        
        sumArray[i] = sumByStrng;
    }
    return sumArray; 
}

int FindMinValue (int [] array)          // метод поиска наименьшего значения в массиве, возвращаем позицию наименьшего элемента массива
{
    int minPosition = 0;
    int minValue = array[0];
    for(int i = 1; i < array.GetLength(0); i++)
    {
        if (array[i] < minValue) 
        {
            minPosition = i;
            minValue = array[i];
        }        
    }
    return minPosition;
}

Console.WriteLine("input array size (strings)"); // запрос размера массива
int user_m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("input array size (columns)");
int user_n = Convert.ToInt32(Console.ReadLine());

int [,] newArray = CreateNewArray(user_m, user_n); // создание массива
Console.WriteLine($"The random array {user_m}x{user_n} is:");
Show2dArray(newArray); // вывод массива
Console.WriteLine();  // пустая строка
int [] sumArray = SumByStringsInArray(newArray);  // вычисляем одномерный массив из сумм строк двумерного массива
Console.WriteLine("The min string (count by 1) is :");
Console.WriteLine(FindMinValue(sumArray)+1);  //  вывод номера наименьшего элемента

