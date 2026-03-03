using lab_1_double_s.Domain.Interface;
using lab_1_double_s.Domain.Item;

namespace lab_1_double_s.Domain.Item
{
    public abstract class BaseItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public BaseItem(int id, string title)
        {
            Id = id;
            Title = title;
        }
        public abstract string GetInfo();
    }
}

namespace lab_1_double_s.Domain.Interface
{
    public interface ISortable
    {
        double GetPriority();
    }
}


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