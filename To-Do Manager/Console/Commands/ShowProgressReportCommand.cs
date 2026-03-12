using TaskApp.Core;

namespace TaskApp.ConsoleUI.Commands
{
    public class ShowProgressReportCommand
    {
        public void Execute(TaskManager manager)
        {
            if (manager.TaskCount == 0)
            {
                Console.WriteLine("Задач немає.");
            }
            else
            {
                int doneCount = 0;
                for (int i = 0; i < manager.TaskCount; i++)
                {
                    if (manager.Tasks[i].IsDone)
                    {
                        doneCount++;
                    }
                }
                double percentage = (double)doneCount / manager.TaskCount * 100;
                Console.WriteLine($"\nЗвіт виконання: {percentage:F2}% (Виконано {doneCount} з {manager.TaskCount})");
            }
        }
    }
}