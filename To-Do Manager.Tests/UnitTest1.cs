using NUnit.Framework;
using lab_1_double_s.Domain.Actions;
using lab_1_double_s.Domain.Core;
using lab_1_double_s.Domain.Tasks;
namespace To_Do_Manager.Tests
{
    
    public class TodoTests
    {
        [Test]
        public void AddTask_IncreaseCount()
        {
            // Arrange 
            Tasker tasker = new Tasker();
            AddTask action = new AddTask();

            // Act 
            AddTask.AddTaske(tasker, "Тестова задача", 1, 5);

            // Assert 
            Assert.AreEqual(1, tasker.TaskCount);
            Assert.AreEqual("Тестова задача", tasker.Tasks[0].Title);
        }

        [Test]
        public void MarkDone_ChangeStatus()
        {
            // Arrange
            Tasker tasker = new Tasker();
            tasker.Tasks[0] = new TodoTask(1, "Купити хліб", 1, DateTime.Now);
            tasker.TaskCount = 1;
            MarkDone markAction = new MarkDone();

            // Act
            markAction.ApplyMarkDone(tasker, 1);

            // Assert
            Assert.IsTrue(tasker.Tasks[0].IsDone);
        }

        [Test]
        public void FindIndex_ReturnIndex()
        {
            // Arrange
            Tasker tasker = new Tasker();
            tasker.Tasks[0] = new TodoTask(10, "Задача 10", 1, DateTime.Now);
            tasker.TaskCount = 1;
            FindIndexById finder = new FindIndexById();

            // Act
            int index = finder.FindIndexByIde(tasker, 10);

            // Assert
            Assert.AreEqual(0, index);
        }

        [Test]
        public void ShowProgress_CalculatePercentage()
        {
            // Arrange
            Tasker tasker = new Tasker();
            tasker.Tasks[0] = new TodoTask(1, "T1", 1, DateTime.Now) { IsDone = true };
            tasker.Tasks[1] = new TodoTask(2, "T2", 1, DateTime.Now) { IsDone = false };
            tasker.TaskCount = 2;

            // Act
            int doneCount = 0;
            for (int i = 0; i < tasker.TaskCount; i++)
                if (tasker.Tasks[i].IsDone) doneCount++;

            double percentage = (double)doneCount / tasker.TaskCount * 100;

            // Assert
            Assert.AreEqual(50.0, percentage);
        }
    }
}