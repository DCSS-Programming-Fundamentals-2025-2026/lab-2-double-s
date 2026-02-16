using lab_1_double_s.Domain.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1_double_s.Domain.Core
{
    public class ShowTask
    {
       public static void ShowTaske(TodoTask[] customList = null)
        {
            Console.WriteLine("\n    Список задач    ");
            TodoTask[] list;
            int count;
            if (customList == null)
            {
                list = Tasker.tasks;
                count = Tasker.taskCount;
            }
            else
            {
                list = customList;
                count = customList.Length;
            }
            if (count == 0)
            {
                Console.WriteLine("Список порожній.");
                return;
            }
            for (int i = 0; i < count; i++)
            {
                if (list[i] != null)
                {
                    Console.WriteLine(list[i].GetInfo());
                }
            }
        }
    }
}
