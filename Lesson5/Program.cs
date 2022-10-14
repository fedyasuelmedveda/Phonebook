namespace Lesson5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Phonebook p = Phonebook.GetPhonebook();
            
            StreamReader streamReader = new StreamReader("C:/Users/fsokl/source/repos/Lesson5/Lesson5/Phonebook.txt");
            p.ReadAbonentsFromFile(streamReader);
            ConsoleInterface consoleInterface = new ConsoleInterface(p);
            consoleInterface.InteractionWithUser();
            streamReader.Close();
            StreamWriter streamWriter = new StreamWriter("C:/Users/fsokl/source/repos/Lesson5/Lesson5/Phonebook.txt");
            p.WriteAbonentsToFile(streamWriter);
            streamWriter.Close();
        }
    }
}