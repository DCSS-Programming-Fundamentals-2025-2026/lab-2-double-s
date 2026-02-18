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
       public void ShowProgressReporte()
        {
            Tasker tasker = new Tasker();
            if (tasker.TaskCount == 0)
            {
                Console.WriteLine("Задач немає.");
                return;
            }
            int doneCount = 0;
            for (int i = 0; i < tasker.TaskCount; i++)
            {
                if (tasker.Tasks[i].IsDone)
                doneCount++;
            }
            double percentage = (double)doneCount / tasker.TaskCount * 100;
            Console.WriteLine($"\nЗвіт виконання: {percentage:F2}% (Виконано {doneCount} з {tasker.TaskCount})");
        }
    }
}
