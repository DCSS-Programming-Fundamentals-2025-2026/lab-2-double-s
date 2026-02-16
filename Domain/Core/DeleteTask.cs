using lab_1_double_s.Domain.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1_double_s.Domain.Core
{
    internal class DeleteTask
    {
       public static void DeleteTaske()
        {
            ShowTask.ShowTaske();
            Console.Write("Введіть ID задачі для видалення: ");
            int id = int.Parse(Console.ReadLine());

            int idx = FindIndexById.FindIndexByIde(id);
            if (idx != -1)
            {
                for (int i = idx; i < Tasker.taskCount - 1; i++)
                {
                    Tasker.tasks[i] = Tasker.tasks[i + 1];

                }
                Tasker.tasks[Tasker.taskCount - 1] = null;
                Tasker.taskCount--;
                Console.WriteLine("Видалено.");
            }
            else
            {
                Console.WriteLine("Задачу не знайдено.");
            }

        }
    }
}
