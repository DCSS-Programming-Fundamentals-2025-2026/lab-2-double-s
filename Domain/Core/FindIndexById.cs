using lab_1_double_s.Domain.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1_double_s.Domain.Core
{
    internal class FindIndexById
    {
        public static int FindIndexByIde(int id)
        {
            for (int i = 0; i < Tasker.taskCount; i++)
            {
                if (Tasker.tasks[i].Id == id)
                    return i;
            }
            return -1;
        }
    }
}
