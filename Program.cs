using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListSum
{
    class Program
    {

        static void Main(string[] args)
        {
            int start_index = 0, end_index = 0;
            List<uint> test_list = new List<uint>();
            ulong sum = 0;
            // Проверка на заданное условие: индексы случайны
            GenerateList(test_list);
            Test(test_list, sum, start_index, end_index, 256, 206870);
            // Проверка на заданное условие: сумма равна всем элементам коллекции
            GenerateList(test_list);
            Test(test_list, sum, start_index, end_index, 0, test_list.Count - 1);
            //Проверка на заданное условие: один элемент коллекции, элемент стоит в самом начале
            GenerateList(test_list);
            Test(test_list, sum, start_index, end_index, 0, 1);
            //Проверка на заданное условие: один элемент коллекции, элемент стоит в конце
            GenerateList(test_list);
            Test(test_list, sum, start_index, end_index, test_list.Count - 1, test_list.Count);


            // Данные из документа
            FindElementsForSum(new List<uint> { 0, 1, 2, 3, 4, 5, 6, 7 }, 11, out start_index, out end_index);
            Console.WriteLine("Начальный индекс: {0}, конечный индекс: {1}", start_index, end_index);
            FindElementsForSum(new List<uint> { 0, 1, 2, 3, 4, 5, 6, 7 }, 88, out start_index, out end_index);
            Console.WriteLine("Начальный индекс: {0}, конечный индекс: {1}", start_index, end_index);
            FindElementsForSum(new List<uint> { 4, 5, 6, 7 }, 18, out start_index, out end_index);
            Console.WriteLine("Начальный индекс: {0}, конечный индекс: {1}", start_index, end_index);
        }

        // Необходимая функция
        public static void FindElementsForSum(List<uint> list, ulong sum, out int start, out int end)
        {
            start = end = 0;
            ulong internal_sum = 0;
            bool success = false;
            internal_sum += list[end];
            while (end < list.Count)
            {
                if (internal_sum > sum)
                {
                    internal_sum -= list[start];
                    start = start + 1;
                }
                else if (internal_sum == sum)
                {
                    success = true;
                    break;
                }
                else if (end == list.Count - 1) 
                    break;
                else
                {
                    end = end + 1;
                    internal_sum += list[end];
                };
            };
            end++;
            if (!success)
                start = end = 0;
        }

        // Функция заполняет коллекцию случайными числами
        public static void GenerateList(List<uint> list)
        {
            list.Clear();
            Random random = new Random();
            int count = random.Next(4000000);
            for (int i = 0; i < count; i++)
                list.Add(((uint)random.Next(int.MaxValue)));
        }

        // Проверочная функция
        public static void Test(List<uint> list, ulong sum, int start, int end, int first_index, int last_index)
        {
            sum = 0;
            for (int i = first_index; i < last_index; i++)
                    sum = sum + list[i];
            FindElementsForSum(list, sum, out start, out end);
            Console.WriteLine("Начальный индекс: {0}, конечный индекс: {1}, сумма: {2}, количество элементов текущей коллекции: {3}", start, end, sum, list.Count);
        }
    }
}
