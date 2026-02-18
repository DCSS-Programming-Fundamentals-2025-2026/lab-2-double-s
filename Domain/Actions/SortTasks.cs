using lab_1_double_s.Domain.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1_double_s.Domain.Actions
{
    internal class SortTasks
    {
        public void SortTaskse()
        {
            Tasker tasker = new Tasker();
            ShowTask showTask = new ShowTask();
            for (int i = 0; i < tasker.TaskCount - 1; i++)
            {
                for (int j = 0; j < tasker.TaskCount - 1; j++)
                {
                    if (tasker.Tasks[j].GetPriority() > tasker.Tasks[j + 1].GetPriority())
                    {
                        var temp = tasker.Tasks[j];
                        tasker.Tasks[j] = tasker.Tasks[j + 1];
                        tasker.Tasks[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("Відсортовано за пріоритетом.");
            showTask.ShowTaske();
        }
    }
}
