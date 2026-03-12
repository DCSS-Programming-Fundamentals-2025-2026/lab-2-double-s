using TaskApp.Core;

namespace TaskApp.ConsoleUI.Commands
{
    public class SortTasksCommand
    {
        public void Execute(TaskManager manager)
        {
            manager.SortTasks();
            Console.WriteLine("Відсортовано за пріоритетом.");

            new ShowAllTasksCommand().Execute(manager);
        }
    }
}