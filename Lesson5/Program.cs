namespace Lesson5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Phonebook p = Phonebook.GetPhonebook();
            p.AddAbonent("fedya", 606060);
            p.AddAbonent("yehor", 434343);
            p.DeleteAbonent("yehor", 434343);
            p.PrintAbonents();
        }
    }
}