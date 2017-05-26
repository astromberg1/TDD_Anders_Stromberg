using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class Tour
    {
        public string Name { get; set; }

        public DateTime TourDate { get; set; }

        public int NumberOfSeats { get; set; }

        public Tour(string name, DateTime tourDate, int numberofseats)
        {
            this.Name = name;
            this.TourDate = tourDate;
            this.NumberOfSeats = numberofseats;
        }



    }

    public class TourSchedule
    {
        private Dictionary<DateTime,List<Tour>> Tours = new Dictionary<DateTime, List<Tour>>();
       
       public void CreateTour(string name, DateTime tourDate, int numberofseats)
       {
           Tour tour = new Tour(name, tourDate, numberofseats);
           var list = new List<Tour>();
           var lista = GetToursFor(tourDate.Date);

           if (lista == null)
           {
               list.Add(tour);
               Tours[tourDate.Date] = list;
           }
           else
           {


               if (lista.Count == 0)
               {
                   list.Add(tour);
                   Tours.Add(tourDate.Date, list);

               }
               else
               {
                    if (lista.Count>2)
                        throw new TourAllocationException("Max three tours a day!");
                    lista.Add(tour);
                   Tours[tourDate.Date] = lista;
               }
           }


       }

        public List<Tour> GetToursFor(DateTime tourDate)
        {
             if (!Tours.ContainsKey(tourDate.Date))
            {
                return null;
            }
             else
            return Tours[tourDate.Date].ToList();
        }




    }
}
