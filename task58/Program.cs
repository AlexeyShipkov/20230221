/*
Задача 58:(дополнительная) Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
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

int [,] CreateNewArray (int n, int m)  //метод создания нового случайного двумерного массива, размер указывает пользователь
{
    int [,] array = new int[n,m];
    for (int i = 0; i < n; i++)
    {
        for(int j = 0; j < m; j++)
        {    
        array[i,j] = new Random().Next(0, 10); // массив положительных  чисел от 0 до 9
        }
    }
    return array; 
}

int [,] MultiplyArray (int [,] array1, int [,] array2)  //метод умножения матриц
{
    int strings1 = array1.GetLength(0);
    int columns1 = array1.GetLength(1);
    int strings2 = array2.GetLength(0);
    int columns2 = array2.GetLength(1);
    int [,] resArray = new int [strings1,columns2];
    if (strings2 != columns1) Console.WriteLine("Multyply impossible");
    else
    {
        for (int i = 0; i < strings1; i++)
        {            
            for (int j = 0; j < columns2; j++)
            {
                resArray[i,j] = 0;
                for(int k = 0; k < columns1; k++)
                {
                    resArray[i,j] = resArray[i,j] + array1[i,k]*array2[k,j];
                }                         
            }            
        }
    }   
    return resArray;
}

Console.WriteLine("input array1 size (strings)"); // запрос размера массива
int user_n1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("input array1 size (columns)");
int user_m1 = Convert.ToInt32(Console.ReadLine());
int [,] newArray1 = CreateNewArray(user_n1, user_m1); // создание массива

Console.WriteLine("input array2 size (strings)"); // запрос размера массива
int user_n2 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("input array2 size (columns)");
int user_m2 = Convert.ToInt32(Console.ReadLine());
int [,] newArray2 = CreateNewArray(user_n2, user_m2); // создание массива


Console.WriteLine($"The random array1 {user_n1}x{user_m1} is:");
Show2dArray(newArray1); // вывод массива
Console.WriteLine();  // пустая строка
Console.WriteLine($"The random array2 {user_n2}x{user_m2} is:");
Show2dArray(newArray2); // вывод массива
Console.WriteLine();  // пустая строка
Console.WriteLine($"The multiply array (array1*array2) {user_n1}x{user_m2} is:");
Show2dArray(MultiplyArray(newArray1,newArray2));
