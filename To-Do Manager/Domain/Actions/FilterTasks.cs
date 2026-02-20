using lab_1_double_s.Domain.Tasks;

namespace lab_1_double_s.Domain.Actions
{
    public class FilterTasks
    {
       public void FilterTaskse()
        {
            Tasker tasker = new Tasker();
            Console.WriteLine("1. Показати виконані");
            Console.WriteLine("2. Показати невиконані");
            string choice = Console.ReadLine();
            bool showDone = choice == "1";
            Console.WriteLine($"\n Результати фільтру (Done: {showDone}) ");
            for (int i = 0; i < tasker.TaskCount; i++)
            {
                if (tasker.Tasks[i].IsDone == showDone)
                {
                    Console.WriteLine(tasker.Tasks[i].GetInfo());
                }
            }
        }
    }
}
