using System;
using TaskApp.Core;

namespace TaskApp.ConsoleUI.Commands
{
    public class ShowAllTasksCommand
    {
        public void Execute(TaskManager manager)
        {
            Console.WriteLine("\nСписок задач:");
            if (manager.TaskCount == 0)
            {
                Console.WriteLine("Список порожній.");
                return;
            }

            for (int i = 0; i < manager.TaskCount; i++)
            {
                if (manager.Tasks[i] != null)
                {
                    Console.WriteLine(manager.Tasks[i].GetInfo());
                }
            }
        }
    }
}