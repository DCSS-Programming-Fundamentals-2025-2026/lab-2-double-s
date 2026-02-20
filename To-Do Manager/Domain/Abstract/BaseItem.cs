namespace lab_1_double_s.Domain.Item
{
    public abstract class BaseItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public BaseItem(int id, string title)
        {
            Id = id;
            Title = title;
        }
        public abstract string GetInfo();
    }
}
