using System;

namespace TaskApp.Models
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