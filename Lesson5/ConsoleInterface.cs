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
                switch (mode)
                {
                    case "0":
                        Console.WriteLine("Name:");
                        string? name = Console.ReadLine();
                        Console.WriteLine("Phone number:");
                        string? phoneNumber = Console.ReadLine();

                        int number = Convert.ToInt32(phoneNumber);
                        Console.WriteLine("Flag");
                        phonebook.AddAbonent(name, number);
                        break;
                    case "1":
                        phonebook.PrintAbonents();
                        break;
                    case "2":
                        Console.WriteLine("Name:");
                        string? name1 = Console.ReadLine();
                        Console.WriteLine("Phone number:");
                        string? phoneNumber1 = Console.ReadLine();
                        int number1 = Convert.ToInt32(phoneNumber1);
                        Console.WriteLine("New name:");
                        string? newName = Console.ReadLine();
                        Console.WriteLine("New phone number:");
                        string? newPhoneNumber = Console.ReadLine();
                        int newNumber = Convert.ToInt32(newPhoneNumber);
                        phonebook.UpdateAbonent(name1, number1, newName, newNumber);
                        break;
                    case "3":
                        Console.WriteLine("Name:");
                        string? name2 = Console.ReadLine();
                        Console.WriteLine("Phone number:");
                        string? phoneNumber2 = Console.ReadLine();
                        int number2 = Convert.ToInt32(phoneNumber2);
                        phonebook.DeleteAbonent(name2, number2);
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
