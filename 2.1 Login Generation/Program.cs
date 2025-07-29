using System;

class Program
{
    static void Main()
    {
        // Читаем имя и фамилию
        string[] input = Console.ReadLine().Split();
        string name = input[0];
        string surname = input[1];

        // Минимальный логин — полный префикс имени + первая буква фамилии
        string bestLogin = name[0] + surname[0].ToString();

        // Перебираем все возможные префиксы имени
        for (int i = 1; i <= name.Length; i++)
        {
            string login = name.Substring(0, i) + surname[0];
            if (string.Compare(login, bestLogin) < 0)
            {
                bestLogin = login;
            }
        }

        // Выводим минимальный логин
        Console.WriteLine(bestLogin);
    }
}
