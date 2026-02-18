using lab_1_double_s.Domain.Core;
using lab_1_double_s.Domain.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1_double_s.Domain.Actions
{
    internal class DeleteTask
    {
       public void DeleteTaske()
        {
            Tasker tasker = new Tasker();
            FindIndexById findIndexById = new FindIndexById();
            ShowTask showTask = new ShowTask();
            showTask.ShowTaske();
            Console.Write("Введіть ID задачі для видалення: ");
            int id = int.Parse(Console.ReadLine());

            int idx = findIndexById.FindIndexByIde(id);
            if (idx != -1)
            {
                for (int i = idx; i < tasker.TaskCount - 1; i++)
                {
                    tasker.Tasks[i] = tasker.Tasks[i + 1];

                }
                tasker.Tasks[tasker.TaskCount - 1] = null;
                tasker.TaskCount--;
                Console.WriteLine("Видалено.");
            }
            else
            {
                Console.WriteLine("Задачу не знайдено.");
            }

        }
    }
}
