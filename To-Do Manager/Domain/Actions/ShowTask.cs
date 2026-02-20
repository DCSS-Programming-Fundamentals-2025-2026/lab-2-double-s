using lab_1_double_s.Domain.Tasks;

namespace lab_1_double_s.Domain.Actions
{
    public class ShowTask
    {
       public void ShowTaske(TodoTask[] customList = null)
        {
            Tasker tasker = new Tasker();
            Console.WriteLine("\n    Список задач    ");
            TodoTask[] list;
            int count;
            if (customList == null)
            {
                list = tasker.Tasks;
                count = tasker.TaskCount;
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
