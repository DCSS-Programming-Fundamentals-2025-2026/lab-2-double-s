using TaskApp.ConsoleUI;
namespace TaskApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            AppRunner runner = new AppRunner();
            runner.Start();
        }
    }
}