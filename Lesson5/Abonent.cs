using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    internal class Abonent
    {
        public int PhoneNumber{ get; }
        public string Name { get; }

        public Abonent(string name, int phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
            this.Name = name;
        }
    }
}
