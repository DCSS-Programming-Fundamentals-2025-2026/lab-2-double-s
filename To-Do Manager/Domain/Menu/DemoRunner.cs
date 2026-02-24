using lab_1_double_s.Domain.Actions;
using lab_1_double_s.Domain.Core;
using lab_1_double_s.Domain.Tasks;
using System;

namespace lab_1_double_s.Domain.Menu
{
    public class DemoRunner
    {
        private Tasker _sharedTasker = new Tasker();
        private TaskCollection _sharedCollection = new TaskCollection();

        public bool DemoRunnere()
        {
            AddTask addTask = new AddTask();
            ShowTask showTask = new ShowTask();
            EditTask editTask = new EditTask();
            DeleteTask deleteTask = new DeleteTask();
            MarkDone markDone = new MarkDone();
            FilterTasks filterTasks = new FilterTasks();
            SortTasks sortTasks = new SortTasks();
            ShowProgressReport showProgressReport = new ShowProgressReport();

            string choice = Console.ReadLine()!;
            switch (choice)
            {
                case "1":
                    Console.Write("Введіть назву завдання: ");
                    string userTitle = Console.ReadLine() ?? "Нова задача";

                    Console.Write("Введіть пріоритет (1 - Високий, 2 - Середній, 3 - Низький): ");
                    if (!int.TryParse(Console.ReadLine(), out int userPriority))
                    {
                        userPriority = 2;
                    }
                    Console.Write("Введіть кількість днів до дедлайну: ");
                    if (!int.TryParse(Console.ReadLine(), out int userDays))
                    {
                        userDays = 7;
                    }
                    AddTask.AddTaske(_sharedTasker, _sharedCollection, userTitle, userPriority, userDays);
                    break;
                case "2":
                    showTask.ShowTaske();
                    break;
                case "3":
                    editTask.EditTaske();
                    break;
                case "4":
                    deleteTask.DeleteTaske();
                    break;
                case "5":
                    markDone.MarkDonee(_sharedTasker);
                    break;
                case "6":
                    filterTasks.FilterTaskse();
                    break;
                case "7":
                    sortTasks.SortTaskse();
                    break;
                case "8":
                    showProgressReport.ShowProgressReporte();
                    break;
                case "9":
                    Console.Clear();
                    var it = _sharedCollection.GetEnumerator();
                    int total = 0;
                    while (it.MoveNext())
                    {
                        TodoTask current = (TodoTask)it.Current;
                        Console.WriteLine(current.GetInfo());
                        total++;
                    }
                    Console.WriteLine($"\nСума елементів у колекції: {total}");
                    break;
                case "10":
                    _sharedCollection.Sort();
                    Console.WriteLine("Сортування за назвою виконано.");
                    break;
                case "11":
                    _sharedCollection.Sort(new lab_1_double_s.Domain.Comparers.PriorityComparer());
                    Console.WriteLine("Сортування за пріоритетом виконано.");
                    break;
                case "0":
                    return false;
                default:
                    Console.WriteLine("Невірний вибір ");
                    break;
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу...");
            Console.ReadKey();
            return true;
        }
    }
}

