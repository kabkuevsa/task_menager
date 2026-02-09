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
            // Трассировка с временем
            Trace.WriteLine($"{DateTime.Now:HH:mm:ss} [TRACE] Начало операции AddTask.");

            if (string.IsNullOrWhiteSpace(title))
            {
                Trace.TraceWarning($"{DateTime.Now:HH:mm:ss} [WARN] Пользователь ввёл пустое название. Операция add не выполнена.");
                Console.WriteLine("Ошибка: название задачи не может быть пустым!");
                Trace.WriteLine($"{DateTime.Now:HH:mm:ss} [TRACE] Конец операции AddTask (неуспешно).");
                return;
            }

            var task = new TaskItem(title);
            tasks.Add(task);

            Trace.TraceInformation($"{DateTime.Now:HH:mm:ss} [INFO] Задача \"{title}\" успешно добавлена.");
            Console.WriteLine($"Задача \"{title}\" добавлена.");
            Trace.WriteLine($"{DateTime.Now:HH:mm:ss} [TRACE] Конец операции AddTask.");
        }

        public void RemoveTask(string title)
        {
            Trace.WriteLine($"{DateTime.Now:HH:mm:ss} [TRACE] Начало операции RemoveTask.");

            var task = tasks.FirstOrDefault(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (task == null)
            {
                Trace.TraceError($"{DateTime.Now:HH:mm:ss} [ERROR] Задача \"{title}\" не найдена.");
                Console.WriteLine($"Задача \"{title}\" не найдена.");
                Trace.WriteLine($"{DateTime.Now:HH:mm:ss} [TRACE] Конец операции RemoveTask (неуспешно).");
                return;
            }

            tasks.Remove(task);
            Trace.TraceInformation($"{DateTime.Now:HH:mm:ss} [INFO] Задача \"{title}\" успешно удалена.");
            Console.WriteLine($"Задача \"{title}\" удалена.");
            Trace.WriteLine($"{DateTime.Now:HH:mm:ss} [TRACE] Конец операции RemoveTask.");
        }

        public void ListTasks()
        {
            Trace.WriteLine($"{DateTime.Now:HH:mm:ss} [TRACE] Начало операции ListTasks.");

            if (tasks.Count == 0)
            {
                Trace.TraceInformation($"{DateTime.Now:HH:mm:ss} [INFO] Список задач пуст.");
                Console.WriteLine("Список задач пуст.");
                Trace.WriteLine($"{DateTime.Now:HH:mm:ss} [TRACE] Конец операции ListTasks.");
                return;
            }

            Trace.TraceInformation($"{DateTime.Now:HH:mm:ss} [INFO] Всего задач: {tasks.Count}");
            Console.WriteLine($"Всего задач: {tasks.Count}");

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i].Title}");
            }

            Trace.WriteLine($"{DateTime.Now:HH:mm:ss} [TRACE] Конец операции ListTasks.");
        }

        public int GetTaskCount()
        {
            return tasks.Count;
        }
    }
}
