using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    internal class Phonebook
    {
        private static Phonebook? phonebook = null;
        private int numberOfAbonents = 0;
        private Abonent[] abonents;
        private Phonebook()
        {
            numberOfAbonents = 0;
            abonents = new Abonent[20];

        }
        private bool CheckName(string name)
        {
            for(int i = 0; i < numberOfAbonents; i++)
            {
                if (abonents[i].Name == name)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Проверка существования абонента с данным номером.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private bool CheckNumber(int number)
        {
            for (int i = 0; i < numberOfAbonents; i++)
            {
                if (abonents[i].PhoneNumber == number)
                    return true;
            }
            return false;
        }
        public void AddAbonent(string name, int phoneNumber) 
        {
            if (!CheckName(name) && !CheckNumber(phoneNumber))
            {
                abonents[numberOfAbonents] = new Abonent(name, phoneNumber);
                numberOfAbonents++;
            }


        }

        public void AddAbonent(Abonent abonent)
        {
            AddAbonent(abonent.Name,abonent.PhoneNumber);

        }

        public void DeleteAbonent(string name, int phoneNumber)
        {

            if (CheckName(name) && CheckNumber(phoneNumber))
            {
                for(int i = 0; i < numberOfAbonents; i++)
                {
                    if (abonents[i].Name == name && abonents[i].PhoneNumber == phoneNumber)
                    {
                        for(int j = i+1; j < numberOfAbonents; j++)
                        {
                            abonents[j - 1] = abonents[j];
                        }

                        numberOfAbonents--;
                        
                        return;
                    }
                }
            }
        }

        public void DeleteAbonent(Abonent abonent)
        {
            DeleteAbonent(abonent.Name,abonent.PhoneNumber);
        }


        public void PrintAbonents()
        {
            //Console.WriteLine(numberOfAbonents);
            for(int i = 0; i < numberOfAbonents; i++)
            {
                Abonent abonent = abonents[i];
                Console.Write(abonent.Name);
                Console.Write(' ');
                Console.WriteLine(abonent.PhoneNumber);
            }
        }
        public static Phonebook GetPhonebook()
        {
            if(phonebook == null)
                phonebook = new Phonebook();
            return phonebook;
        }
    }
}
