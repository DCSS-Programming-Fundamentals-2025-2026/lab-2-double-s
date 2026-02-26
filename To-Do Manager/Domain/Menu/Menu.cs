namespace lab_1_double_s.Domain.Menu
{
    public class Menu
    {
        public void Menue()
        {
            DemoRunner demoRunner = new DemoRunner();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("To-Do Manager");
                Console.WriteLine("1. Додати задачу");
                Console.WriteLine("2. Показати всі задачі ");
                Console.WriteLine("3. Редагувати задачу ");
                Console.WriteLine("4. Видалити задачу ");
                Console.WriteLine("5. Відмітити як виконане ");
                Console.WriteLine("6. Фільтр (Виконані / Невиконані)");
                Console.WriteLine("7. Сортувати за пріоритетністю");
                Console.WriteLine("8. Звіт по прогресу ");
                Console.WriteLine("9.Статистика колекції (Enumerator)");
                Console.WriteLine("10. Сортувати за назвою (IComparable)");
                Console.WriteLine("11. Сортувати за пріоритетом (IComparer)");
                Console.WriteLine("0. Вихід");
                Console.Write("\n Оберіть дію: ");

                demoRunner.DemoRunnere();
            }
        }
    }
}
