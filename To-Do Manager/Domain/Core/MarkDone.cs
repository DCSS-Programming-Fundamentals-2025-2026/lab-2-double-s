using lab_1_double_s.Domain.Tasks;

public class MarkDone
{
    public void ApplyMarkDone(Tasker tasker, int id)
    {
        FindIndexById finder = new FindIndexById();
        int idx = finder.FindIndexByIde(tasker, id);
        if (idx != -1)
        {
            tasker.Tasks[idx].IsDone = true;
        }
    }
    public void MarkDonee(Tasker tasker)
    {
        Console.Write("Введіть ID виконаної задачі: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            ApplyMarkDone(tasker, id);
            Console.WriteLine("Статус оновлено.");
        }
    }
}