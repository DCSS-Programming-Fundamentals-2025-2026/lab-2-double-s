using lab_1_double_s.Domain.Actions;
using lab_1_double_s.Domain.Core;
using lab_1_double_s.Domain.Tasks;

namespace lab_1_double_s.Domain.Menu
{
    public class DemoRunner
    {
        private Tasker _sharedTasker = new Tasker();
        public void DemoRunnere()
        {
            AddTask addTask = new AddTask();
            ShowTask showTask = new ShowTask();
            EditTask editTask = new EditTask();
            DeleteTask deleteTask = new DeleteTask();
            MarkDone markDone = new MarkDone();
            FilterTasks filterTasks = new FilterTasks();
            SortTasks sortTasks = new SortTasks();
            ShowProgressReport showProgressReport = new ShowProgressReport();
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddTask.AddTaske(_sharedTasker, "Назва завдання", 1, 10);
                    break;
                case "2":
                    showTask.ShowTaske();
                    break;
                case "3":
                    editTask.EditTaske();
                    break;
                case "4":
                    deleteTask.DeleteTaske();
                    break;
                case "5":
                    markDone.MarkDonee(_sharedTasker);
                    break;
                case "6":
                    filterTasks.FilterTaskse();
                    break;
                case "7":
                    sortTasks.SortTaskse();
                    break;
                case "8":
                    showProgressReport.ShowProgressReporte();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Невірний вибір ");
                    break;
            }
            Console.ReadKey();
        }
    }
}
