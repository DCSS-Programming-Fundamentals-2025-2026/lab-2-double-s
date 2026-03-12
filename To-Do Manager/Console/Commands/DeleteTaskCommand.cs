using System;
using TaskApp.Core;

namespace TaskApp.ConsoleUI.Commands
{
    public class DeleteTaskCommand
    {
        public void Execute(TaskManager manager)
        {
            try
            {
                new ShowAllTasksCommand().Execute(manager);
                Console.Write("Введіть ID задачі для видалення: ");
                int delId = int.Parse(Console.ReadLine());

                if (manager.DeleteTask(delId))
                {
                    Console.WriteLine("Видалено.");
                }
                else
                {
                    Console.WriteLine("Задачу не знайдено.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Помилка вводу ID. Будь ласка, введіть число.");
            }
        }
    }
}