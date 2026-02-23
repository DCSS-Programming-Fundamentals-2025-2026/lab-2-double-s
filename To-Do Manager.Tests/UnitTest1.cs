using lab_1_double_s.Domain.Actions;
using lab_1_double_s.Domain.Tasks;

namespace lab_1_double_s.Tests
{
    [TestFixture]
    public class TodoTests
    {
        private Tasker _tasker;
        private DeleteTask _deleteAction;
        private MarkDone _markDone;
        private FindIndexById _finder;

        [SetUp]
        public void Setup()
        {
            _tasker = new Tasker();
            _deleteAction = new DeleteTask();
            _markDone = new MarkDone();
            _finder = new FindIndexById();
        } 

        [Test]
        public void AddTask_IncreasesCount()
        {
            // Act
            AddTask.AddTaske(_tasker, "Купити хліб", 1, 1);

            // Assert
            Assert.AreEqual(1, _tasker.TaskCount);
            Assert.AreEqual("Купити хліб", _tasker.Tasks[0].Title);
        }

        [Test]
        public void AddTask_LimitReached()
        {
            // Arrange
            _tasker.TaskCount = 200;

            // Act
            AddTask.AddTaske(_tasker, "Зайва задача", 1, 1);

            // Assert
            Assert.AreEqual(200, _tasker.TaskCount);
        }

        [Test]
        public void FindIndex_ReturnsCorrectIndex()
        {
            // Arrange
            _tasker.Tasks[0] = new TodoTask(10, "Задача 10", 1, DateTime.Now);
            _tasker.TaskCount = 1;

            // Act
            int index = _finder.FindIndexByIde(_tasker, 10);

            // Assert
            Assert.AreEqual(0, index);
        }

        [Test]
        public void MarkDone_ChangesStatus()
        {
            // Arrange
            _tasker.Tasks[0] = new TodoTask(1, "Тест", 1, DateTime.Now);
            _tasker.TaskCount = 1;

            // Act
            _tasker.Tasks[0].IsDone = true;

            // Assert
            Assert.IsTrue(_tasker.Tasks[0].IsDone);
        }

        [Test]
        public void DeleteTask_MovesElementsCorrect()
        {
            // Arrange
            _tasker.Tasks[0] = new TodoTask(1, "Перша", 1, DateTime.Now);
            _tasker.Tasks[1] = new TodoTask(2, "Друга", 1, DateTime.Now);
            _tasker.Tasks[2] = new TodoTask(3, "Третя", 1, DateTime.Now);
            _tasker.TaskCount = 3;

            // Act
            int indexToDelete = 1;
            for (int i = indexToDelete; i < _tasker.TaskCount - 1; i++)
            {
                _tasker.Tasks[i] = _tasker.Tasks[i + 1];
            }
            _tasker.TaskCount--;

            // Assert
            Assert.AreEqual(2, _tasker.TaskCount);
            Assert.AreEqual("Третя", _tasker.Tasks[1].Title);
        }

        [Test]
        public void CalculatePercentage_CorrectResult()
        {
            // Arrange
            _tasker.Tasks[0] = new TodoTask(1, "T1", 1, DateTime.Now) { IsDone = true };
            _tasker.Tasks[1] = new TodoTask(2, "T2", 1, DateTime.Now) { IsDone = false };
            _tasker.TaskCount = 2;

            // Act
            int done = 0;
            for (int i = 0; i < _tasker.TaskCount; i++) if (_tasker.Tasks[i].IsDone) done++;
            double percent = (double)done / _tasker.TaskCount * 100;

            // Assert
            Assert.AreEqual(50.0, percent);
        }

        [Test]
        public void Integration()
        {
            // Arrange
            AddTask.AddTaske(_tasker, "Задача 1", 1, 1);
            AddTask.AddTaske(_tasker, "Задача 2", 2, 2);

            // Act
            _tasker.Tasks[0] = _tasker.Tasks[1];
            _tasker.TaskCount--;

            // Assert
            Assert.AreEqual(1, _tasker.TaskCount);
            Assert.AreEqual("Задача 2", _tasker.Tasks[0].Title);
        }

        [Test]
        public void EditTask_ChangeTitle()
        {
            // Arrange 
            _tasker.Tasks[0] = new TodoTask(1, "Стара назва", 1, DateTime.Now);
            _tasker.TaskCount = 1;

            // Act 
            _tasker.Tasks[0].Title = "Нова назва";

            // Assert 
            Assert.That(_tasker.Tasks[0].Title, Is.EqualTo("Нова назва"));
            Assert.That(_tasker.Tasks[0].Id, Is.EqualTo(1)); 
        }
        [Test]
        public void SortTasks_SwapTwoElements()
        {
            // Arrange 
            _tasker.Tasks[0] = new TodoTask(1, "Низький пріоритет", 2, DateTime.Now);
            _tasker.Tasks[1] = new TodoTask(2, "Високий пріоритет", 1, DateTime.Now);
            _tasker.TaskCount = 2;

            // Act 
            if (_tasker.Tasks[0].Priority > _tasker.Tasks[1].Priority)
            {
                var temp = _tasker.Tasks[0]; 
                _tasker.Tasks[0] = _tasker.Tasks[1];
                _tasker.Tasks[1] = temp; 
            }

            // Assert 
            Assert.That(_tasker.Tasks[0].Title, Is.EqualTo("Високий пріоритет"));
            Assert.That(_tasker.Tasks[0].Priority, Is.EqualTo(1));
        }

        [Test]
        public void FilterTasks_ShowOnlyDone()
        {
            // Arrange 
            _tasker.Tasks[0] = new TodoTask(1, "Сходити в магазин", 1, DateTime.Now) { IsDone = true };
            _tasker.Tasks[1] = new TodoTask(2, "Вивчити C#", 1, DateTime.Now) { IsDone = false };
            _tasker.Tasks[2] = new TodoTask(3, "Прибрати в кімнаті", 2, DateTime.Now) { IsDone = true };
            _tasker.TaskCount = 3;

            // Act 
            int foundDoneTasks = 0; 
            bool showDone = true;

            for (int i = 0; i < _tasker.TaskCount; i++)
            {
                if (_tasker.Tasks[i].IsDone == showDone)
                {
                    foundDoneTasks++; 
                }
            }

            // Assert 
            Assert.That(foundDoneTasks, Is.EqualTo(2), "Потрібно знайти рівно 2 виконані задачі");
        }

        [Test]
        public void DeleteTask_InvalidId()
        {
            // Arrange 
            _tasker.Tasks[0] = new TodoTask(1, "Важлива задача", 1, DateTime.Now);
            _tasker.TaskCount = 1;

            // Act 
            int idToDelete = 99;
            int idx = _finder.FindIndexByIde(_tasker, idToDelete);

            if (idx != -1) 
            {
                for (int i = idx; i < _tasker.TaskCount - 1; i++)
                {
                    _tasker.Tasks[i] = _tasker.Tasks[i + 1];
                }
                _tasker.TaskCount--;
            }

            // Assert 
            Assert.That(_tasker.TaskCount, Is.EqualTo(1), "Кількість задач не повинна змінитись");
            Assert.That(_tasker.Tasks[0].Title, Is.EqualTo("Важлива задача"), "Задачу не потрібно видаляти");
        }
        [Test]
        public void Integration_Scenario()
        {
            // Arrange
            AddTask.AddTaske(_tasker, "Купити молоко", 1, 1);
            AddTask.AddTaske(_tasker, "Прибрати", 2, 1);

            // Act
            _tasker.Tasks[0].IsDone = true;

            // Assert
            int done = 0;
            for (int i = 0; i < _tasker.TaskCount; i++) if (_tasker.Tasks[i].IsDone) done++;

            Assert.AreEqual(2, _tasker.TaskCount);
            Assert.AreEqual(1, done);
        }
    }
}