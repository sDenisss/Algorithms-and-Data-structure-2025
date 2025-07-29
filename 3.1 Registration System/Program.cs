using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); // Считываем количество запросов
        Dictionary<string, int> users = new Dictionary<string, int>(); // Словарь для хранения пользователей

        for (int i = 0; i < n; i++)
        {
            string name = Console.ReadLine(); // Считываем имя пользователя

            if (!users.ContainsKey(name))
            {
                // Имя свободно
                users[name] = 0; // Помечаем, что имя занято (без числовых хвостов)
                Console.WriteLine("OK");
            }
            else
            {
                // Имя уже занято, нужно искать новое
                users[name]++; // Увеличиваем счётчик для этого имени
                string newName = name + users[name]; // Формируем новое имя

                // Проверяем, вдруг newName тоже занят
                while (users.ContainsKey(newName))
                {
                    users[name]++;
                    newName = name + users[name];
                }

                users[newName] = 0; // Добавляем новое имя в базу
                Console.WriteLine(newName);
            }
        }
    }
}
