using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Lesson5
{
    internal class ConsoleInterface
    {
        Phonebook phonebook;

        public ConsoleInterface(Phonebook phonebook)
        {
            this.phonebook = phonebook;
            phonebook.AbonentMessage += ConsoleMessage;
            phonebook.DeleteMessage += ConsoleRedMessage;
            phonebook.AddMessage += ConsoleGreenMessage;
        }

        private void ConsoleMessage(string message)
        {

            Console.WriteLine(message);
        }
        private void ConsoleRedMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor= ConsoleColor.Gray;
        }
        private void ConsoleGreenMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor= ConsoleColor.Gray;
        }
        public void ReadAbonents()
        {
            using (var rstream = new StreamReader("C:/Users/fsokl/source/repos/Lesson5/Lesson5/Phonebook.txt"))
            {
                phonebook.ReadAbonentsFromFile(rstream);
                rstream.Close();
            }
        }
        public void WriteAbonents()
        {
            using (var wstream = new StreamWriter("C:/Users/fsokl/source/repos/Lesson5/Lesson5/Phonebook.txt"))
            {
                phonebook.WriteAbonentsToFile(wstream);
                wstream.Close();
            }
        }
        public void InteractionWithUser()
        {
            Console.WriteLine("0 - Add abonent");
            Console.WriteLine("1 - Print abonents");
            Console.WriteLine("2 - Update abonent");
            Console.WriteLine("3 - Delete abonent");
            Console.WriteLine("4 - Clear console");
            Console.WriteLine("5 - Exit");
            while (true)
            {

                string? mode  = Console.ReadLine();
                string? name;
                string? phoneNumber;
                //long number;
                switch (mode)
                {
                    case "0":
                        Console.WriteLine("Name:");
                        name = Console.ReadLine();
                        Console.WriteLine("Phone number:");
                        phoneNumber = Console.ReadLine();
                        phonebook.AddAbonent(name, phoneNumber);
                        break;
                    case "1":
                        int n = phonebook.GetNumberOfAbonents();
                        Abonent[] ab = phonebook.GetAbonents();
                        for(int i = 0;i < n; i++)
                        {
                            Console.WriteLine(ab[i].Name);
                            Console.WriteLine(ab[i].PhoneNumber);
                        }
                        break;
                    case "2":
                        Console.WriteLine("Name:");
                        name = Console.ReadLine();
                        Console.WriteLine("Phone number:");
                        phoneNumber = Console.ReadLine();
                        Console.WriteLine("New name:");
                        string? newName = Console.ReadLine();
                        Console.WriteLine("New phone number:");
                        string? newPhoneNumber = Console.ReadLine();
                        phonebook.UpdateAbonent(name, phoneNumber, newName, newPhoneNumber);
                        break;
                    case "3":
                        Console.WriteLine("Name:");
                        name = Console.ReadLine();
                        Console.WriteLine("Phone number:");
                        phoneNumber = Console.ReadLine();
                        phonebook.DeleteAbonent(name, phoneNumber);
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("0 - Add abonent");
                        Console.WriteLine("1 - Print abonents");
                        Console.WriteLine("2 - Update abonent");
                        Console.WriteLine("3 - Delete abonent");
                        Console.WriteLine("4 - Clear console");
                        Console.WriteLine("5 - Exit");
                        break;
                    case "5":
                        return;
                        break;
                    default:
                        break;
                }
            
            }
        }
    }
}
