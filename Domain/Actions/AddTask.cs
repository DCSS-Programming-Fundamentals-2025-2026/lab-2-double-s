using lab_1_double_s.Domain.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1_double_s.Domain.Actions
{
    internal class AddTask
    {
       public void AddTaske()
        {
            Tasker tasker = new Tasker();
            if (tasker.TaskCount >= 200)
            {
                Console.WriteLine("Помилка: Список переповнений ");
                return;
            }
            Console.Write("Назва задачі: ");
            string title = Console.ReadLine();
            int priority;
            while (true)
            {
                Console.Write("Введіть пріоритет (1 - Високий, 2 - Низький): ");
                if (int.TryParse(Console.ReadLine(), out priority) && (priority == 1 || priority == 2))
                {
                    break;
                }
                Console.WriteLine("Помилка.Введіть тільки 1 або 2.");
            }
            Console.Write("Введіть кількість днів на виконання: ");
            int days = int.Parse(Console.ReadLine());
            DateTime date = DateTime.Now.AddDays(days);
            tasker.Tasks[tasker.TaskCount] = new TodoTask(tasker.TaskCount + 1, title, priority, date);
            tasker.TaskCount++;

            Console.WriteLine("Задачу додано ");
        }
    }
}
