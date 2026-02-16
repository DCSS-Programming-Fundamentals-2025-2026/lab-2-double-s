using lab_1_double_s.Domain.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1_double_s.Domain.Core
{
    internal class SortTasks
    {
        public static void SortTaskse()
        {
            for (int i = 0; i < Tasker.taskCount - 1; i++)
            {
                for (int j = 0; j < Tasker.taskCount - 1; j++)
                {
                    if (Tasker.tasks[j].GetPriority() > Tasker.tasks[j + 1].GetPriority())
                    {
                        var temp = Tasker.tasks[j];
                        Tasker.tasks[j] = Tasker.tasks[j + 1];
                        Tasker.tasks[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("Відсортовано за пріоритетом.");
            ShowTask.ShowTaske();
        }
    }
}
