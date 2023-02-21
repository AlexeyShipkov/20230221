/*
Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/

int [,] CreateNewArray (int m, int n)  //метод создания нового случайного двумерного массива, размер указывает пользователь
{
    int [,] array = new int[m,n];
    for (int i = 0; i < m; i++)
    {
        for(int j = 0; j < n; j++)
        {    
        array[i,j] = new Random().Next(0, 100); // массив положительных  чисел от 0 до 99
        }
    }
    return array; 
}

int [,] RegulateArray (int [,] array)  //метод упорядочивания массива по строкам
{
    int stringsCount = array.GetLength(0);
    int columnsCount = array.GetLength(1);

    for (int i = 0; i < stringsCount; i++) //цикл по строкам
    {
        for (int j = 0; j < columnsCount ; j++) // цикл в столбце
            {
                  for (int k = j +1; k < columnsCount; k++)
                    {
                        int tmpMaxValue = array[i,j];   // временная перерменная для максимума, берем из первой позиции выборки
                        if (array[i,k] > tmpMaxValue)   // сравнение, начианя со второй позиции выборки, с максимальным значением
                            {
                                array[i,j] = array[i,k];
                                array[i,k] = tmpMaxValue;
                            }        
                    }
            }        
    }
    return array; 
}


void ShowArray (int [,] array)   //  метод вывода двумерного массива 
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

Console.WriteLine("input array size (strings)"); // запрос размера массива
int user_m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("input array size (columns)");
int user_n = Convert.ToInt32(Console.ReadLine());

int [,] newArray = CreateNewArray(user_m, user_n); // создание массива
Console.WriteLine($"The random array {user_m}x{user_n} is:");
ShowArray(newArray); // вывод массива
Console.WriteLine();  // пустая строка
Console.WriteLine($"The regulated array {user_m}x{user_n} is:");
RegulateArray(newArray);  // упорядочивание массива
ShowArray(newArray); // вывод массива