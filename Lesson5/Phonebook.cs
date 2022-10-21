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
        private StreamReader sr;
        private StreamWriter sw;
        private Phonebook()
        {
            numberOfAbonents = 0;
            abonents = new Abonent[30];
            sr = new StreamReader("C:/Users/fsokl/source/repos/Lesson5/Lesson5/Phonebook.txt");
            ReadAbonentsFromFile();
        }

        /// <summary>
        /// Проверка существования абонента с данным именем и абонента с данным номером.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool CheckAbonentExists(string name, string number)
        {
            for(int i = 0; i < numberOfAbonents; i++)
            {
                if (abonents[i].Name == name)
                    return true;
            }
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
        private bool CheckNameAndNumber(string name, string phoneNumber)
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
        public void AddAbonent(string name, string phoneNumber) 
        {
            if (!CheckAbonentExists(name,phoneNumber))
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
        /// Получить абонентов.
        /// </summary>
        /// <returns></returns>
        public Abonent[] GetAbonents()
        {
            return abonents;
        }

        public int GetNumberOfAbonents()
        {
            return numberOfAbonents;
        }
        /// <summary>
        /// Удаляем абонента если такой есть.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        public void DeleteAbonent(string name, string phoneNumber)
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
        public void UpdateAbonent(string name, string phoneNumber, string newName, string newPhoneNumber)
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
        public void UpdateAbonent(Abonent abonent, string newName, string newPhoneNumber)
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
        public void UpdateAbonent(string name, string phoneNumber, Abonent newAbonent)
        {
            UpdateAbonent(name, phoneNumber, newAbonent.Name, newAbonent.PhoneNumber);
        }


        /// <summary>
        /// Читаем абонентов из файла.
        /// </summary>
        public void ReadAbonentsFromFile()
        {
            string name = sr.ReadLine();
            string phoneNumber = sr.ReadLine();
            while (name != null)
            {
                AddAbonent(name, phoneNumber);
                name = sr.ReadLine();
                phoneNumber = sr.ReadLine();
            }
            
        }

        /// <summary>
        /// Пишем абонентов в файл.
        /// </summary>
        private void WriteAbonentsToFile()
        {
            for (int i = 0; i < numberOfAbonents; i++)
            {
                sw.WriteLine(abonents[i].Name);
                sw.WriteLine(abonents[i].PhoneNumber);
            }
        }

        /// <summary>
        /// Что нужно сделать при выходе.
        /// </summary>
        public void Exit()
        {
            sr.Close();
            sw = new StreamWriter("C:/Users/fsokl/source/repos/Lesson5/Lesson5/Phonebook.txt");
            WriteAbonentsToFile();
            sw.Close();
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
