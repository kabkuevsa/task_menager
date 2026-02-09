using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TaskManager
{
    public class TaskManager
    {
        private List<TaskItem> tasks = new List<TaskItem>();

        public void AddTask(string title)
        {
            // Трассировка в консоль
            Console.WriteLine("[TRACE] Начало операции AddTask.");

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("[WARN] Пользователь ввёл пустое название. Операция add не выполнена.");
                Trace.TraceWarning("Пользователь ввёл пустое название. Операция add не выполнена.");
                Console.WriteLine("Ошибка: название задачи не может быть пустым!");
                Console.WriteLine("[TRACE] Конец операции AddTask (неуспешно).");
                return;
            }

            var task = new TaskItem(title);
            tasks.Add(task);

            Console.WriteLine($"[INFO] Задача \"{title}\" успешно добавлена.");
            Trace.TraceInformation($"Задача \"{title}\" успешно добавлена.");
            Console.WriteLine($"Задача \"{title}\" добавлена.");
            Console.WriteLine("[TRACE] Конец операции AddTask.");
        }

        public void RemoveTask(string title)
        {
            Console.WriteLine("[TRACE] Начало операции RemoveTask.");

            var task = tasks.FirstOrDefault(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (task == null)
            {
                Console.WriteLine($"[ERROR] Задача \"{title}\" не найдена.");
                Trace.TraceError($"Задача \"{title}\" не найдена.");
                Console.WriteLine($"Задача \"{title}\" не найдена.");
                Console.WriteLine("[TRACE] Конец операции RemoveTask (неуспешно).");
                return;
            }

            tasks.Remove(task);
            Console.WriteLine($"[INFO] Задача \"{title}\" успешно удалена.");
            Trace.TraceInformation($"Задача \"{title}\" успешно удалена.");
            Console.WriteLine($"Задача \"{title}\" удалена.");
            Console.WriteLine("[TRACE] Конец операции RemoveTask.");
        }

        public void ListTasks()
        {
            Console.WriteLine("[TRACE] Начало операции ListTasks.");

            if (tasks.Count == 0)
            {
                Console.WriteLine("[INFO] Список задач пуст.");
                Trace.TraceInformation("Список задач пуст.");
                Console.WriteLine("Список задач пуст.");
                Console.WriteLine("[TRACE] Конец операции ListTasks.");
                return;
            }

            Console.WriteLine($"[INFO] Всего задач: {tasks.Count}");
            Trace.TraceInformation($"Всего задач: {tasks.Count}");
            Console.WriteLine($"Всего задач: {tasks.Count}");

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i].Title}");
            }

            Console.WriteLine("[TRACE] Конец операции ListTasks.");
        }

        public int GetTaskCount()
        {
            return tasks.Count;
        }
    }
}