namespace Lesson5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleInterface consoleInterface = new ConsoleInterface(Phonebook.GetPhonebook());
            consoleInterface.InteractionWithUser();
        }
    }
}