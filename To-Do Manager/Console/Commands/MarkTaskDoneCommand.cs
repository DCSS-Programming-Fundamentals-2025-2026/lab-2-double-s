using TaskApp.Core;

namespace TaskApp.ConsoleUI.Commands
{
    public class MarkTaskDoneCommand
    {
        public void Execute(TaskManager manager)
        {
            try
            {
                Console.Write("Введіть ID виконаної задачі: ");
                if (int.TryParse(Console.ReadLine(), out int doneId))
                {
                    if (manager.MarkDone(doneId))
                    {
                        Console.WriteLine("Статус оновлено.");
                    }
                    else
                    {
                        Console.WriteLine("Задачу не знайдено.");
                    }
                }
                else
                {
                    Console.WriteLine("Невірний формат ID.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}