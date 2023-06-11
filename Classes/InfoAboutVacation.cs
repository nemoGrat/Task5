using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Classes
{
    internal class InfoAboutVacation
    {
        public string name;
        public DateTime startVacation;
        public DateTime endVacation;

        public InfoAboutVacation(string name, DateTime startVacation, DateTime endVacation)
        {
            this.name = name;
            this.startVacation = startVacation;
            this.endVacation = endVacation;
        }
    }
}
