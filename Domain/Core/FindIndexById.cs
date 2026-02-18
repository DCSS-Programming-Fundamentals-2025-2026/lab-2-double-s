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
        public int FindIndexByIde(int id)
        {
            Tasker tasker = new Tasker();
            for (int i = 0; i < tasker.TaskCount; i++)
            {
                if (tasker.Tasks[i].Id == id)
                    return i;
            }
            return -1;
        }
    }
}
