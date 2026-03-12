using TaskApp.Core;
using TaskApp.ConsoleUI.Commands;

namespace TaskApp.ConsoleUI
{
    public class MainMenu
    {
        private TaskManager _manager = new TaskManager();

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Менеджер Задач");
                Console.WriteLine("1. Додати задачу");
                Console.WriteLine("2. Показати всі задачі");
                Console.WriteLine("3. Редагувати задачу");
                Console.WriteLine("4. Видалити задачу");
                Console.WriteLine("5. Відмітити як виконане");
                Console.WriteLine("6. Фільтр (Виконані / Невиконані)");
                Console.WriteLine("7. Сортувати за пріоритетністю");
                Console.WriteLine("8. Звіт по прогресу");
                Console.WriteLine("0. Вихід");
                Console.Write("\nОберіть дію: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        new AddTaskCommand().Execute(_manager);
                        break;
                    case "2":
                        new ShowAllTasksCommand().Execute(_manager);
                        break;
                    case "3":
                        new EditTaskCommand().Execute(_manager);
                        break;
                    case "4":
                        new DeleteTaskCommand().Execute(_manager);
                        break;
                    case "5":
                        new MarkTaskDoneCommand().Execute(_manager);
                        break;
                    case "6":
                        new FilterTasksCommand().Execute(_manager);
                        break;
                    case "7":
                        new SortTasksCommand().Execute(_manager);
                        break;
                    case "8":
                        new ShowProgressReportCommand().Execute(_manager);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
                Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
            }
        }
    }
}