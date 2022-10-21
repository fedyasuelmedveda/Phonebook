namespace Lesson5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Phonebook p = Phonebook.GetPhonebook();
            
            ConsoleInterface consoleInterface = new ConsoleInterface(p);
            consoleInterface.InteractionWithUser();
        }
    }
}