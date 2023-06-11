using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Classes
{
    internal class PossibilityOfVacation
    {
        public int Check(DateTime startDate, List<InfoAboutVacation> clientsList, int vacationCount)
        {
            int vac = 0;

            if (startDate.DayOfWeek >= DayOfWeek.Monday && startDate.DayOfWeek <= DayOfWeek.Friday)
            {
                if (!clientsList.Any(element => element.startVacation >= startDate && element.startVacation <= startDate.AddDays(7)))
                {
                    if (vacationCount >= 14 && !clientsList.Any(element => element.startVacation >= startDate && element.startVacation <= startDate.AddDays(14)))
                    {
                        if (!clientsList.Any(element => element.startVacation.AddDays(14) >= startDate && element.startVacation.AddDays(14) <= startDate.AddDays(14))) vac = 14; 
                    }
                    else
                    {
                        if (!clientsList.Any(element => element.startVacation.AddDays(7) >= startDate && element.startVacation.AddDays(7) <= startDate.AddDays(7))) vac = 7;
                    }
                }
            }

            return vac;
        }

        public void CheckingPossibilityOfVacation()
        {
            List<string> ListOfEmployes = new List<string>()
            {
                "Иванов Иван Иванович",
                "Петров Петр Петрович",
                "Юлина Юлия Юлиановна",
                "Сидоров Сидор Сидорович",
                "Павлов Павел Павлович",
                "Георгиев Георг Георгиевич"
            };

            Random r = new Random();
            for (int i = ListOfEmployes.Count - 1; i >= 1; i--)
            {
                int j = r.Next(i + 1);

                var temp = ListOfEmployes[j];
                ListOfEmployes[j] = ListOfEmployes[i];
                ListOfEmployes[i] = temp;
            }

            List<InfoAboutVacation> vacationList = new List<InfoAboutVacation>();

            DateTime start = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime end = new DateTime(DateTime.Today.Year, 12, 31);

            Random gen = new Random();
            int durOfVac;
            int vacationCount;
            foreach (var t in ListOfEmployes)
            {
                durOfVac = 14;
                vacationCount = 28;
                while (vacationCount > 0)
                {
                    var startDate = start.AddDays(gen.Next((end - start).Days));

                    foreach (var arr in vacationList)
                    {
                        durOfVac = Check(startDate, vacationList, vacationCount);
                    }

                    if (durOfVac != 0)
                    {
                        vacationList.Add(new InfoAboutVacation(t, startDate, startDate.AddDays(durOfVac)));
                        vacationCount -= durOfVac;
                    }
                }
            }

            foreach (var arr in vacationList)
            {
                Console.WriteLine("Дни отпуска " + arr.name + " : ");
                DateTime i = arr.startVacation;
                while (i <= arr.endVacation)
                {
                    Console.WriteLine(i);

                    i = i.AddDays(1);
                }
            }
        }
    }
}
