using TaskApp.Core;

namespace TaskApp.ConsoleUI.Commands
{
    public class FilterTasksCommand
    {
        public void Execute(TaskManager manager)
        {
            Console.WriteLine("1. Показати виконані");
            Console.WriteLine("2. Показати невиконані");
            string filterChoice = Console.ReadLine();
            bool showDone = false;

            if (filterChoice == "1")
            {
                showDone = true;
            }
            else if (filterChoice == "2")
            {
                showDone = false;
            }
            else
            {
                Console.WriteLine("Невірний вибір.");
                return;
            }

            Console.WriteLine($"\nРезультати фільтру:");
            for (int i = 0; i < manager.TaskCount; i++)
            {
                if (manager.Tasks[i].IsDone == showDone)
                {
                    Console.WriteLine(manager.Tasks[i].GetInfo());
                }
            }
        }
    }
}