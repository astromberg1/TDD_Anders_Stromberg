using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
  public  class BookingSystem
  {
      private ITourSchedule TourSchedule;
      private List<Booking> bookings = new List<Booking>();

        public BookingSystem(ITourSchedule itour)
        {
            TourSchedule = itour;
        }


      public void CreateBooking(string tourname, DateTime tourdate, Passenger passenger)
      {
          
          
             
          var result = TourSchedule.GetToursFor(tourdate.Date).FirstOrDefault(x => x.Name == tourname);
            if (result==null)
                throw new NonExistentTourException();




         
            if (result.NumberOfSeats == bookings.Count(x=>x.Tour==result))
                throw new NoAvailableSeatsException();
            bookings.Add(new Booking() { Passenger = passenger, Tour = result });
            
         

       
         

      }

      public List<Booking> GetBookingsFor(Passenger passenger)
      {
          return bookings.Where(x => x.Passenger == passenger).ToList();

      }
  }
}
