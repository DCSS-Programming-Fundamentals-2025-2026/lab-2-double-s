using lab_1_double_s.Domain.Tasks;
public class AddTask()
{
    public static void AddTaske(Tasker tasker, TaskCollection collection, string title, int priority, int days)
    {
        if (tasker.TaskCount >= 200)
            return;
        DateTime date = DateTime.Now.AddDays(days);
        TodoTask newTask = new TodoTask(tasker.TaskCount + 1, title, priority, date);

        tasker.Tasks[tasker.TaskCount] = newTask;
        tasker.TaskCount++;

        collection.Add(newTask);

        Console.WriteLine("Завдання успішно збережено!");
    }
}
