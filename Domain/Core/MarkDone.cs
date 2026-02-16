using lab_1_double_s.Domain.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1_double_s.Domain.Core
{
    internal class MarkDone
    {
       public static void MarkDonee()
        {
            ShowTask.ShowTaske();
            Console.Write("Введіть ID виконаної задачі: ");
            int id = int.Parse(Console.ReadLine());
            int idx = FindIndexById.FindIndexByIde(id);
            if (idx != -1)
            {
                Tasker.tasks[idx].IsDone = true;
                Console.WriteLine("Виконано.");
            }
            else
            {
                Console.WriteLine("Задачу не знайдено.");
            }
        }
    }
}
