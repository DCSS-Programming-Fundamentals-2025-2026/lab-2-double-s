using System;
using TaskApp.Core;

namespace TaskApp.ConsoleUI.Commands
{
    public class EditTaskCommand
    {
        public void Execute(TaskManager manager)
        {
            try
            {
                new ShowAllTasksCommand().Execute(manager);
                Console.Write("Введіть ID задачі для редагування: ");

                if (!int.TryParse(Console.ReadLine(), out int editId))
                {
                    Console.WriteLine("Невірний формат ID.");
                    return;
                }

                if (manager.FindIndexById(editId) != -1)
                {
                    Console.WriteLine("Що ви хочете змінити?");
                    Console.WriteLine("1. Назву");
                    Console.WriteLine("2. Пріоритет");
                    Console.WriteLine("3. Кількість днів (дедлайн)");
                    Console.WriteLine("0. Скасувати");
                    Console.Write("Ваш вибір: ");

                    string subChoice = Console.ReadLine();
                    switch (subChoice)
                    {
                        case "1":
                            Console.Write("Введіть нову назву: ");
                            manager.EditTaskTitle(editId, Console.ReadLine());
                            Console.WriteLine("Назву змінено.");
                            break;
                        case "2":
                            Console.Write("Введіть новий пріоритет (1 - Високий, 2 - Низький): ");
                            manager.EditTaskPriority(editId, int.Parse(Console.ReadLine()));
                            Console.WriteLine("Пріоритет змінено.");
                            break;
                        case "3":
                            Console.Write("Введіть нову кількість днів від сьогодні: ");
                            manager.EditTaskDate(editId, int.Parse(Console.ReadLine()));
                            Console.WriteLine("Дату змінено.");
                            break;
                        default:
                            Console.WriteLine("Редагування скасовано.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Задачу з таким ID не знайдено.");
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