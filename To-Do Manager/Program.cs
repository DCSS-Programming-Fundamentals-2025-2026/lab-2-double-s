using lab_1_double_s;
using lab_1_double_s.Domain.Menu;

class Program
{
    static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Menu menu = new Menu();
        menu.Menue();
    }
}
           