/*
Задача 60.(дополнительная) ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/

int [,,] CreateNewArray (int n, int m, int p)  //метод создания нового случайного трехмерного массива, размер указывает пользователь
{
    int [,,] array = new int[n,m,p];
    if(m*n*p > 90)
    {
        Console.WriteLine($"array {n}x{m}x{p} can't be created:"); //проверка, что массив с неповторяющимися числами может существовать, всего двузначных чисел 90
    }
    else
    {
    for (int i = 0; i < n; i++)
    {
        for(int j = 0; j < m; j++)
        {    
            for(int k = 0; k < p; k++)
            {                
                array[i,j,k] = new Random().Next(10, 100); // массив положительных  чисел от 10 до 99
                Repeat:               // проверка на отсутствие повторов
                for(int i1 = 0; i1 < i; i1++)
                {
                    for(int j1 = 0; j1 < j; j1++)
                    {
                        for(int k1=0; k1 < k; k1++)
                        {
                            while(array[i,j,k] == array[i1,j1,k1])
                            {                                
                                array[i,j,k] = new Random().Next(10, 100); // если повтор - переприсваеваем 
                                goto Repeat;  //уходим на перепроверку отсутствия повторов
                            }                            
                        }
                    }
                }
            
            }        
        }
    }
    }
    return array; 
}

void Show3dArray (int [,,] array)   //  метод вывода трехмерного массива 
{
    for (int i = 0; i < array.GetLength(0); i++) 
    {
        for (int j =0; j < array.GetLength(1); j++) 
        {
            for (int k = 0; k< array.GetLength(2); k++)
        Console.Write($"{array[i,j,k]} ({i},{j},{k}) ");   // вывод значения        
        Console.WriteLine();
        }
        
    }
}
Console.WriteLine("input array size (dim0)"); // запрос размера массива
int user_n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("input array size (dim1)");
int user_m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("input array size (dim2)");
int user_p = Convert.ToInt32(Console.ReadLine());

int [,,] newArray = CreateNewArray(user_n, user_m, user_p); // создание массива
Console.WriteLine($"The random array {user_n}x{user_m}x{user_p} is:");
Show3dArray(newArray); // вывод массива