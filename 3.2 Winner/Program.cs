using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); // Считываем количество конов
        Dictionary<string, int> scores = new Dictionary<string, int>(); // Словарь для хранения итоговых очков
        List<(string name, int cumulativeScore)> history = new List<(string, int)>(); // История ходов (для таймлайна)

        for (int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split(); // Делим строку на имя и очки
            string name = parts[0];
            int score = int.Parse(parts[1]);

            if (!scores.ContainsKey(name))
                scores[name] = 0; // Если игрок новый, заводим его в словаре

            scores[name] += score; // Прибавляем очки к общему счету

            // Записываем в историю (важно сохранить момент времени и сумму)
            history.Add((name, scores[name]));
        }

        // Находим максимальное количество очков среди всех игроков
        int maxScore = int.MinValue;
        foreach (var player in scores)
        {
            if (player.Value > maxScore)
                maxScore = player.Value;
        }

        // Проверяем победителя по хронологии (по истории)
        HashSet<string> candidates = new HashSet<string>();
        foreach (var player in scores)
        {
            if (player.Value == maxScore)
                candidates.Add(player.Key); // Все игроки с максимальным итогом
        }

        foreach (var record in history)
        {
            if (candidates.Contains(record.name) && record.cumulativeScore >= maxScore)
            {
                Console.WriteLine(record.name); // Первый, кто достиг максимума
                return;
            }
        }
    }
}
