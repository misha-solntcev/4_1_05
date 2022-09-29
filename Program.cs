using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Вариант 5
Дана целочисленная прямоугольная матрица. Определить количество столбцов, не
содержащих ни одного нулевого элемента.
Характеристикой строки целочисленной матрицы назовем сумму ее положительных
четных элементов. Переставляя строки заданной матрицы, расположить их в
соответствии с ростом характеристик. */

namespace _4_1_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[,]
            {
                { 8, 0, 6, -4, 8 },
                { 4, 1, 6, 7, 8 },
                { 7, 8, 9, 0, 2 },
                { 12, 0, 3, -4, 5 },
            };

            // Количество столбцов, не содержащих ни одного нулевого элемента.
            int count = 0;
            for (int j = 0; j < array.GetLength(1); j++)
            {                
                bool flag = true;
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    if (array[i, j] == 0)
                        flag = false;
                }
                if (flag)
                    count++;
            }
            Console.WriteLine($"Количество столбцов = {count}.");
                        
            // Записываем характеристики строк в список.
            List<int> properties = new List<int>();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int property = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if ((array[i,j] % 2 == 0) && (array[i,j] > 0))
                        property += array[i, j];
                }
                properties.Add(property);
            }
            Console.Write($"Характеристики строк: ");
            foreach (int property in properties)
                Console.Write($"{property}, ");
            Console.WriteLine();

            // Записываем индексы характеристик в порядке возрастания.            
            List<int> sortedProperties = new List<int>();
            sortedProperties.AddRange(properties);
            sortedProperties.Sort();

            List<int> indexes = new List<int>();            
            for (int i = 0; i < sortedProperties.Count; i++)
            {
                for (int j = 0; j < properties.Count; j++)
                {
                    if (sortedProperties[i] == properties[j])
                        indexes.Add(j);
                }                    
            }
            Console.Write($"Порядок строк: ");
            foreach (int index in indexes)
                Console.Write($"{index}, ");
            Console.WriteLine();

            // Формирование отсортированного массива.
            int[,] newArray = new int[array.GetLength(0), array.GetLength(1)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    newArray[i, j] = array[indexes[i], j];
                }
            }

            // Вывод в консоль начального массива.
            Console.WriteLine($"Исходный массив: ");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($" {array[i, j]}, ");
                }
                Console.WriteLine();
            }            

            // Вывод в консоль отсортированного массива.
            Console.WriteLine($"Отсортированный массив: ");
            for (int i = 0; i < newArray.GetLength(0); i++)
            {
                for (int j = 0; j < newArray.GetLength(1); j++)
                {
                    Console.Write($" {newArray[i, j]}, ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
