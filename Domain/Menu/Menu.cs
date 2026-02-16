using lab_1_double_s.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1_double_s.Domain.Menu
{
    public class Menu
    {
       public static void Menue()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("To-Do Manager");
                Console.WriteLine("1. Додати задачу");
                Console.WriteLine("2. Показати всі задачі ");
                Console.WriteLine("3. Редагувати задачу ");
                Console.WriteLine("4. Видалити задачу ");
                Console.WriteLine("5. Відмітити як виконане ");
                Console.WriteLine("6. Фільтр (Виконані / Невиконані)");
                Console.WriteLine("7. Сортувати за пріоритетністю");
                Console.WriteLine("8. Звіт по прогресу ");
                Console.WriteLine("0. Вихід");
                Console.Write("\n Оберіть дію: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddTask.AddTaske(); 
                        break;
                    case "2":
                        ShowTask.ShowTaske();
                        break;
                    case "3":
                        EditTask.EditTaske();
                        break;
                    case "4":
                        DeleteTask.DeleteTaske();
                        break;
                    case "5":
                        MarkDone.MarkDonee();
                        break;
                    case "6":
                        FilterTasks.FilterTaskse();
                        break;
                    case "7":
                        SortTasks.SortTaskse();
                        break;
                    case "8":
                        ShowProgressReport.ShowProgressReporte();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір ");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
