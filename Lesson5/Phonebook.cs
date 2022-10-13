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
            abonents = new Abonent[30];

        }

        /// <summary>
        /// Проверка существования абонента с данным именем.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Проверка существования абонента с данным именем и номером.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        private bool CheckNameAndNumber(string name, int phoneNumber)
        {
            for(int i = 0; i < numberOfAbonents; i++)
            {
                if (abonents[i].Name == name && abonents[i].PhoneNumber == phoneNumber)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Добавляем абонента, если такого ещё нет.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        public void AddAbonent(string name, int phoneNumber) 
        {
            if (!CheckName(name) && !CheckNumber(phoneNumber))
            {
                abonents[numberOfAbonents] = new Abonent(name, phoneNumber);
                numberOfAbonents++;
            }


        }

        /// <summary>
        /// Добавляем абонента, если такого ещё нет.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        public void AddAbonent(Abonent abonent)
        {
            AddAbonent(abonent.Name,abonent.PhoneNumber);

        }


        /// <summary>
        /// Удаляем абонента если такой есть.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        public void DeleteAbonent(string name, int phoneNumber)
        {

            if (CheckNameAndNumber(name, phoneNumber))
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

        /// <summary>
        /// Удаляем абонента если такой есть.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        public void DeleteAbonent(Abonent abonent)
        {
            DeleteAbonent(abonent.Name,abonent.PhoneNumber);
        }

        /// <summary>
        /// Меняем одного абонента на другого.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="newName"></param>
        /// <param name="newPhoneNumber"></param>
        public void UpdateAbonent(string name, int phoneNumber, string newName, int newPhoneNumber)
        {
            if(CheckNameAndNumber(name, phoneNumber))
            {
                for(int i = 0; i < numberOfAbonents; i++)
                {
                    if (abonents[i].Name == name && abonents[i].PhoneNumber == phoneNumber)
                    {
                        abonents[i] = new Abonent (newName,newPhoneNumber);
                        return;
                    }
                }
            }
        }


        /// <summary>
        /// Меняем одного абонента на другого.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="newName"></param>
        /// <param name="newPhoneNumber"></param>
        public void UpdateAbonent(Abonent abonent, Abonent newAbonent)
        {
            UpdateAbonent(abonent.Name, abonent.PhoneNumber, newAbonent.Name, newAbonent.PhoneNumber);
        }

        /// <summary>
        /// Меняем одного абонента на другого.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="newName"></param>
        /// <param name="newPhoneNumber"></param>
        public void UpdateAbonent(Abonent abonent, string newName, int newPhoneNumber)
        {
            UpdateAbonent(abonent.Name, abonent.PhoneNumber, newName, newPhoneNumber);
        }


        /// <summary>
        /// Меняем одного абонента на другого.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="newName"></param>
        /// <param name="newPhoneNumber"></param>
        public void UpdateAbonent(string name, int phoneNumber, Abonent newAbonent)
        {
            UpdateAbonent(name, phoneNumber, newAbonent.Name, newAbonent.PhoneNumber);
        }

        /// <summary>
        /// Выводим всех абонентов в консоль.
        /// </summary>
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

        /// <summary>
        /// Создаем объект класса одиночки.
        /// </summary>
        /// <returns></returns>
        public static Phonebook GetPhonebook()
        {
            if(phonebook == null)
                phonebook = new Phonebook();
            return phonebook;
        }
    }
}
