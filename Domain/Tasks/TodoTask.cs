using lab_1_double_s.Domain.Interface;
using lab_1_double_s.Domain.Item;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1_double_s.Domain.Tasks
{
    public class TodoTask : BaseItem, ISortable
    {
        public bool IsDone { get; set; }
        public int Priority { get; set; }

        public DateTime Date { get; set; }



        public TodoTask(int id, string title, int priority, DateTime date) : base(id, title)
        {
            Priority = priority;
            Date = date;
            IsDone = false;
        }



        public double GetPriority()
        {
            return Priority;
        }

        public override string GetInfo()
        {
            string status;

            if (IsDone == true)
            {
                status = "[done]";
            }
            else
            {
                status = "[undone ]";
            }

            return $"{Id}. {status} {Title} | Пріоритет: {Priority} | Дедлайн: {Date.ToShortDateString()}";


        }

    }
}


