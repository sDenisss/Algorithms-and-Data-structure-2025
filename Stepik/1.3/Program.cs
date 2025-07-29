using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class MainClass
{
    static void Main(string[] args)
    {
        string[] firstLine = Console.ReadLine().Split();
        int size = int.Parse(firstLine[0]);
        int n = int.Parse(firstLine[1]);

        if (n == 0)
        {
            // Если пакетов нет, ничего не выводим
            return;
        }

        Queue<int> buffer = new Queue<int>();
        int currentTime = 0;

        for (int i = 0; i < n; i++)
        {
            string[] packet = Console.ReadLine().Split();
            int arrival = int.Parse(packet[0]);
            int duration = int.Parse(packet[1]);

            // Удаляем из очереди пакеты, которые уже обработаны к моменту прибытия текущего пакета
            while (buffer.Count > 0 && buffer.Peek() <= arrival)
            {
                buffer.Dequeue();
            }

            if (buffer.Count < size)
            {
                // Время начала обработки текущего пакета
                int startTime = Math.Max(currentTime, arrival);
                Console.WriteLine(startTime);

                // Время завершения обработки текущего пакета
                int finishTime = startTime + duration;
                buffer.Enqueue(finishTime);

                // Обновляем текущее время
                currentTime = finishTime;
                
            }
            else
            {
                // Буфер заполнен, пакет отбрасывается
                Console.WriteLine(-1);
            }
        }
    }
}