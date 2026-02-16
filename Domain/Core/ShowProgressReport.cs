using lab_1_double_s.Domain.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1_double_s.Domain.Core
{
    internal class ShowProgressReport
    {
       public static void ShowProgressReporte()
        {
            if (Tasker.taskCount == 0)
            {
                Console.WriteLine("Задач немає.");
                return;
            }
            int doneCount = 0;
            for (int i = 0; i < Tasker.taskCount; i++)
            {
                if (Tasker.tasks[i].IsDone)
                doneCount++;
            }
            double percentage = (double)doneCount / Tasker.taskCount * 100;
            Console.WriteLine($"\nЗвіт виконання: {percentage:F2}% (Виконано {doneCount} з {Tasker.taskCount})");
        }
    }
}
