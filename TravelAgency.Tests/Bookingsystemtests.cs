using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace TravelAgency.Tests
{
    [TestFixture]
    class BookingsystemTests
    {
        
        private BookingSystem sut;
        private TourScheduleStub torschedulestub;

        [SetUp]
        public void Setup()
        {
            torschedulestub= new TourScheduleStub();
            sut = new BookingSystem(torschedulestub);

        }

        [Test]
        [Category("Exercise4")]
        public void CanCreateBooking()
        {
            
            torschedulestub.Tours= new List<Tour>();
            torschedulestub.Tours.Add(new Tour("kalle resor",new DateTime(2017,01,01),30));
            var passenger = new Passenger(){FirstName = "per",LastName = "Larsson"};
            sut.CreateBooking("kalle resor", new DateTime(2017, 01, 01), passenger);
           var bookings = sut.GetBookingsFor(passenger);
            
            Assert.That(bookings[0].Tour.Name, Is.EqualTo("kalle resor"));
            Assert.That(bookings[0].Passenger, Is.EqualTo(passenger));
           
        }
        //20.	Write and get another test to pass which asserts that when trying to book someone on a non-existent tour, an exception gets thrown.
        [Test]
        [Category("Exercise4")]
        public void ShouldThrowExceptionIfTourNotExists()
        {
            torschedulestub.Tours = new List<Tour>();
            var passenger = new Passenger() { FirstName = "per", LastName = "Larsson" };
            Assert.Throws<NonExistentTourException>(() =>
            sut.CreateBooking("kalle resor", new DateTime(2017, 01, 01), passenger));
            

        }

        //21.	Finally, repeat with a third test that makes sure that when you try to book more passengers than there are seats available, an exception is thrown.
        [Test]
        [Category("Exercise4")]
        public void ShouldThrowExceptionIfTourNoSeatsAvailable()
        {
            torschedulestub.Tours = new List<Tour>();

            torschedulestub.Tours.Add(new Tour("kalle resor", new DateTime(2017, 01, 01), 1));

            var passenger = new Passenger() { FirstName = "per", LastName = "Larsson" };
            sut.CreateBooking("kalle resor", new DateTime(2017, 01, 01), new Passenger() { FirstName = "per", LastName = "Jonnson" });

            Assert.Throws<NoAvailableSeatsException>(() =>
                sut.CreateBooking("kalle resor", new DateTime(2017, 01, 01), passenger));


        }





    }
}
      