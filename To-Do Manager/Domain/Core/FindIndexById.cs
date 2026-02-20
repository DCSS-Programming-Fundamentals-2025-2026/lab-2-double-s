using lab_1_double_s.Domain.Tasks;
public class FindIndexById()
{
    public int FindIndexByIde(Tasker tasker, int id) 
    {
        for (int i = 0; i < tasker.TaskCount; i++)
        {
            if (tasker.Tasks[i].Id == id) return i;
        }
        return -1;
    }
}