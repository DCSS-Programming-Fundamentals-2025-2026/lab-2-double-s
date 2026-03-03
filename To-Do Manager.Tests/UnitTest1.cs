using lab_1_double_s.Domain.Core;
using NUnit.Framework;

namespace lab_1_double_s.Tests
{
    [TestFixture]
    public class TodoTests
    {
        private TaskManager _manager;

        [SetUp]
        public void Setup()
        {
            _manager = new TaskManager();
        }

        [Test]
        public void AddTask_IncreasesCount()
        {
            // Act
            _manager.AddTask("Купити хліб", 1, 1);

            // Assert
            Assert.AreEqual(1, _manager.TaskCount);
            Assert.AreEqual("Купити хліб", _manager.Tasks[0].Title);
        }

        [Test]
        public void AddTask_LimitReached()
        {
            // Arrange
            _manager.TaskCount = 200;

            // Act
            bool isAdded = _manager.AddTask("Зайва задача", 1, 1);

            // Assert
            Assert.IsFalse(isAdded, "Метод має повернути false, оскільки ліміт досягнуто");
            Assert.AreEqual(200, _manager.TaskCount, "Кількість задач не повинна перевищити 200");
        }

        [Test]
        public void FindIndex_ReturnsCorrectIndex()
        {
            // Arrange
            _manager.AddTask("Задача 1", 1, 1);
            int idToFind = _manager.Tasks[0].Id;

            // Act
            int index = _manager.FindIndexById(idToFind);

            // Assert
            Assert.AreEqual(0, index);
        }

        [Test]
        public void MarkDone_ChangesStatus()
        {
            // Arrange
            _manager.AddTask("Тест", 1, 1);
            int id = _manager.Tasks[0].Id;

            // Act
            _manager.MarkDone(id);

            // Assert
            Assert.IsTrue(_manager.Tasks[0].IsDone);
        }

        [Test]
        public void DeleteTask_MovesElementsCorrect()
        {
            // Arrange
            _manager.AddTask("Перша", 1, 1);
            _manager.AddTask("Друга", 1, 1);
            _manager.AddTask("Третя", 1, 1);
            int idToDelete = _manager.Tasks[1].Id;

            // Act
            _manager.DeleteTask(idToDelete);

            // Assert
            Assert.AreEqual(2, _manager.TaskCount);
            Assert.AreEqual("Третя", _manager.Tasks[1].Title);
        }

        [Test]
        public void EditTask_ChangeTitle()
        {
            // Arrange
            _manager.AddTask("Стара назва", 1, 1);
            int id = _manager.Tasks[0].Id;

            // Act
            _manager.EditTaskTitle(id, "Нова назва");

            // Assert
            Assert.That(_manager.Tasks[0].Title, Is.EqualTo("Нова назва"));
        }

        [Test]
        public void SortTasks_SwapTwoElements()
        {
            // Arrange
            _manager.AddTask("Низький пріоритет", 2, 1);
            _manager.AddTask("Високий пріоритет", 1, 1);

            // Act
            _manager.SortTasks();

            // Assert
            Assert.That(_manager.Tasks[0].Title, Is.EqualTo("Високий пріоритет"));
            Assert.That(_manager.Tasks[0].Priority, Is.EqualTo(1));
        }

        [Test]
        public void FilterTasks_CheckSpecificTaskStatuses()
        {
            // Arrange
            _manager.AddTask("Сходити в магазин", 1, 1);
            _manager.AddTask("Вивчити C#", 1, 1);
            _manager.AddTask("Прибрати в кімнаті", 2, 1);

            // Act
            _manager.MarkDone(_manager.Tasks[0].Id);
            _manager.MarkDone(_manager.Tasks[2].Id);

            // Assert 
            Assert.IsTrue(_manager.Tasks[0].IsDone, "Перша задача має бути виконаною");
            Assert.IsFalse(_manager.Tasks[1].IsDone, "Друга задача має залишитись НЕвиконаною");
            Assert.IsTrue(_manager.Tasks[2].IsDone, "Третя задача має бути виконаною");
        }

        [Test]
        public void DeleteTask_InvalidId()
        { 
   
            // Arrange
            _manager.AddTask("Важлива задача", 1, 1);

            // Act
            _manager.DeleteTask(99);

            // Assert
            Assert.That(_manager.TaskCount, Is.EqualTo(1), "Кількість задач не повинна змінитись");
            Assert.That(_manager.Tasks[0].Title, Is.EqualTo("Важлива задача"));
        }
    }
}