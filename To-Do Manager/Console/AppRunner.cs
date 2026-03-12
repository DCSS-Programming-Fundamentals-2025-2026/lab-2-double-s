namespace TaskApp.ConsoleUI
{
    public class AppRunner
    {
        public void Start()
        {
            MainMenu appMenu = new MainMenu();
            appMenu.Run();
        }
    }
}