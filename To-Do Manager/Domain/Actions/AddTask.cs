using lab_1_double_s.Domain.Tasks;
public class AddTask()
{
    public static void AddTaske(Tasker tasker, string title, int priority, int days)
    {
        if (tasker.TaskCount >= 200) 
          return;

        DateTime date = DateTime.Now.AddDays(days);
        tasker.Tasks[tasker.TaskCount] = new TodoTask(tasker.TaskCount + 1, title, priority, date);
        tasker.TaskCount++;
    }
}

