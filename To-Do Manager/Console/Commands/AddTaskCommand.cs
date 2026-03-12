using TaskApp.Core;

namespace TaskApp.ConsoleUI.Commands
{
    public class AddTaskCommand
    {
        public void Execute(TaskManager manager)
        {
            try
            {
                Console.Write("Введіть назву задачі: ");
                string title = Console.ReadLine();

                Console.Write("Введіть пріоритет (1 - Високий, 2 - Низький): ");
                int priority = int.Parse(Console.ReadLine());

                Console.Write("Введіть кількість днів для дедлайну: ");
                int days = int.Parse(Console.ReadLine());

                bool isAdded = manager.AddTask(title, priority, days);
                if (isAdded)
                {
                    Console.WriteLine("Задачу додано!");
                }
                else
                {
                    Console.WriteLine("Ліміт задач вичерпано.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Помилка: потрібно вводити числове значення!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Непередбачена помилка: {ex.Message}");
            }
        }
    }
}