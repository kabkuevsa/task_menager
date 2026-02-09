using System;
using System.Diagnostics;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // Настраиваем логирование System.Diagnostics для записи в консоль
            SetupConsoleLogging();

            // Старт программы
            Console.WriteLine("[INFO] Программа TaskManager запущена.");
            Trace.TraceInformation("Программа TaskManager запущена.");

            Console.WriteLine("=== Task Manager ===");
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("add    - добавить задачу");
            Console.WriteLine("remove - удалить задачу");
            Console.WriteLine("list   - показать список задач");
            Console.WriteLine("exit   - выход из программы");
            Console.WriteLine("help   - показать справку");
            Console.WriteLine(new string('=', 30));

            var taskManager = new TaskManager();
            bool isRunning = true;

            while (isRunning)
            {
                Console.Write("\nВведите команду: ");
                string command = Console.ReadLine()?.Trim().ToLower();

                switch (command)
                {
                    case "add":
                        Console.Write("Введите название задачи: ");
                        string taskTitle = Console.ReadLine()?.Trim();
                        taskManager.AddTask(taskTitle);
                        break;

                    case "remove":
                        Console.Write("Введите название задачи для удаления: ");
                        string removeTitle = Console.ReadLine()?.Trim();
                        taskManager.RemoveTask(removeTitle);
                        break;

                    case "list":
                        taskManager.ListTasks();
                        break;

                    case "exit":
                        Console.WriteLine("[INFO] Завершение работы программы.");
                        Trace.TraceInformation("Завершение работы программы.");
                        Console.WriteLine("Завершение работы...");
                        isRunning = false;
                        break;

                    case "help":
                        ShowHelp();
                        break;

                    default:
                        Console.WriteLine($"Неизвестная команда: {command}. Введите 'help' для списка команд.");
                        break;
                }
            }

            // Закрываем трассировку
            Trace.Flush();

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void SetupConsoleLogging()
        {
            // Очищаем стандартные слушатели
            Trace.Listeners.Clear();

            // Добавляем слушатель для вывода в консоль
            Trace.Listeners.Add(new ConsoleTraceListener());

            // Настраиваем автоматическую запись
            Trace.AutoFlush = true;
        }

        static void ShowHelp()
        {
            Console.WriteLine("\n=== Справка по командам ===");
            Console.WriteLine("add    - Добавить новую задачу");
            Console.WriteLine("remove - Удалить задачу по названию");
            Console.WriteLine("list   - Показать все задачи");
            Console.WriteLine("exit   - Выйти из программы");
            Console.WriteLine("help   - Показать эту справку");
            Console.WriteLine(new string('=', 30));
        }
    }
}