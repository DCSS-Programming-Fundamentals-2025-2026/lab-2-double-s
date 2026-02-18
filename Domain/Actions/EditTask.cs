using lab_1_double_s.Domain.Core;
using lab_1_double_s.Domain.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1_double_s.Domain.Actions
{
    internal class EditTask
    {
       public void EditTaske()
        {
            Tasker tasker = new Tasker();
            FindIndexById findIndexById = new FindIndexById();
            ShowTask showTask = new ShowTask();
            showTask.ShowTaske();
            Console.WriteLine("Введіть ID задачі для редагування: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            int idx = findIndexById.FindIndexByIde(id);
            if (idx != -1)
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
                        tasker.Tasks[idx].Title = Console.ReadLine();
                        Console.WriteLine("Назву змінено.");
                        break;
                    case "2":
                        Console.Write("Введіть новий пріоритет (1 - Високий, 2 - Низький): ");
                        tasker.Tasks[idx].Priority = int.Parse(Console.ReadLine());
                        Console.WriteLine("Пріоритет змінено.");
                        break;
                    case "3":
                        Console.Write("Введіть нову кількість днів від сьогодні: ");
                        int days = int.Parse(Console.ReadLine());
                        tasker.Tasks[idx].Date = DateTime.Now.AddDays(days);
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
    }
}
