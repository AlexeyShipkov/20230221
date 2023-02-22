/* 
Задача 57: Составить частотный словарь элементов двумерного массива. Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.
1, 9, 9, 0,
2, 8, 0, 9
0 встречается 2 раза
1 встречается 1 раз
2 встречается 1 раз
8 встречается 1 раз
9 встречается 3 раза
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

int [] Replace2dTo1dArray(int [,] array)  // метод преобразования двумерного массива в одномерный
{
    int stringsCount = array.GetLength(0);
    int columnsCount = array.GetLength(1);
    int [] resArray = new int[stringsCount*columnsCount];
    
    for (int i = 0; i < stringsCount; i++) //цикл по строкам
    {
            for (int j = 0; j < columnsCount ; j++) // цикл в столбце
            {
                resArray[i*columnsCount+j] = array[i,j];                                               
            }     
        
    }
    return resArray; 

}

int [] SortArray(int [] array)   //  метод сортировки массива по возрастанию
{
    int len = array.GetLength(0);
            for (int i = 0; i < len; i++) 
            {
                for (int k = i + 1; k < len; k++)
                {
                    int minArray = array[i];
                    if (array[k] < minArray)
                    {
                        array[i] = array[k];
                        array[k] = minArray;
                    }

                }

            }
            return array;
}

int [,] FrequencyArray(int [] array)  // метод подсчета количества повторов элементов в упорядоченном входном массиве. 
                                    //возвращает двумерный массив: элемент -- количество повтороний
{
    int len = array.GetLength(0);
    int count = 1;
    for (int i = 1; i< len; i++)   // цикл подсчета количества уникальных значений
    {
        if (array[i] != array[i-1]) count++;
    }
    int [,] resArray = new int [count,2];  // выделение результирующего массива
    resArray[0,0] = array[0]; // первый элемент результирующего массива всегда совпадает с первым элементом упорядоченного мссива
    int k = 0;  // индекс результирующего массива
    int frequency = 1; // счетчик частоты встречающегося элемента
        
        for(int i = 1; i < len; i++)
        {
            if (array[i] != array[i-1])  // последующее значение не совпало, сбрасываем частоту на 1 и переходим на следующий индекс результирующего массива
            {
                frequency = 1;
                k++;
            }
            else // значения совпали, увеличиваем частоту на 1
            {
                frequency++;
            }
            resArray[k,0] = array[i]; // заполняем результирующий массив
            resArray[k,1] = frequency;

        }


return  resArray;

}       
void Show2dCustomArray (int [,] array)   //  метод вывода результирующего массива 
{                
        for (int i=0; i < array.GetLength(0); i++)  
    {
        Console.WriteLine($"{array[i,0]} found {array[i,1]} times");   
    }
}

Console.WriteLine("input array size (strings)"); // запрос размера массива
int user_m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("input array size (columns)");
int user_n = Convert.ToInt32(Console.ReadLine());

int [,] newArray = CreateNewArray(user_m, user_n); // создание массива
Console.WriteLine($"The random array {user_m}x{user_n} is:");
Show2dArray(newArray); // вывод массива
Console.WriteLine();  // пустая строка
int [] sumArray = Replace2dTo1dArray(newArray);  // преобразуем двумерный массив в одномерный
int [] sum2Array = SortArray(sumArray); // выполняепм сортировку массива
Show2dCustomArray(FrequencyArray(sum2Array));  //  вывод итогового массива

