using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace TravelAgency.Tests
{
    [TestFixture]
    public class TourScheduleTests
    {
        private TourSchedule sut;

        [SetUp]
       public void Setup()
        {
            this.sut = new TourSchedule();
            sut.CreateTour(
                "Test tour", new DateTime(2013, 1, 2, 10, 15, 0), 99);

        }

        [Test]
       public void CanCreateNewTour()
        {

            var tourdate = new DateTime(2013, 1, 1);
            sut.CreateTour(
                "New years day safari",
                tourdate, 20);
       

        

        Assert.IsInstanceOf<List<Tour>>(sut.GetToursFor(tourdate));


            var resultlist = sut.GetToursFor(tourdate);

            var result = resultlist.FirstOrDefault(x => x.TourDate == tourdate);
            

        Assert.AreSame("New years day safari",result.Name);
          
            Assert.AreEqual(20, result.NumberOfSeats);
            
        }
        [Test]
        public void ToursAreScheduledByDateOnly()
        {
            DateTime tourdate = new DateTime(2013, 1, 1, 10, 15, 0);

            sut.CreateTour(
                "New years day safari", tourdate, 20);

            Assert.IsInstanceOf<List<Tour>>(sut.GetToursFor(tourdate));


            var resultlist = sut.GetToursFor(tourdate);

            var result = resultlist.FirstOrDefault(x => x.TourDate == tourdate);


            Assert.AreSame("New years day safari", result.Name);

            Assert.AreEqual(20, result.NumberOfSeats);





        }
        [Test]
        public void GetToursForGivenDayOnly()
        {
            sut.CreateTour(
                "New years day safari 1", new DateTime(2013, 1, 1, 10, 15, 0), 20);
            sut.CreateTour(
                "New years day safari 2", new DateTime(2013, 1, 1, 12, 15, 0), 30);
            sut.CreateTour(
                "day safari 1", new DateTime(2013, 2, 1, 12, 15, 0), 30);
            sut.CreateTour(
                "day safari 14", new DateTime(2013, 3, 1, 11, 15, 0), 30);
            sut.CreateTour(
                "day safari 16", new DateTime(2013, 4, 1, 11, 15, 0), 30);

            DateTime tourdate = new DateTime(2013, 1, 1, 10, 15, 0);


            Assert.IsInstanceOf<List<Tour>>(sut.GetToursFor(tourdate));


            var resultlist = sut.GetToursFor(tourdate);

            var result = resultlist.FirstOrDefault(x => x.TourDate == tourdate);


            Assert.AreSame("New years day safari 1", result.Name);

            Assert.AreEqual(20, result.NumberOfSeats);






        }
        [Test]
        public void ThrowTourAllocationExceptionTest()
        {
            sut.CreateTour(
                "New years day safari 1", new DateTime(2017, 1, 1, 10, 15, 0), 20);
            sut.CreateTour(
                "New years day safari 2", new DateTime(2017, 1, 1, 11, 15, 0), 30);
            sut.CreateTour(
                "New years day safari 3", new DateTime(2017, 1, 1, 12, 15, 0), 30);

            var ex = Assert.Throws<TourAllocationException>(() =>

            sut.CreateTour(
                "New years day safari 4", new DateTime(2017, 1, 1, 13, 15, 0), 30)
            );
            Assert.That(ex.Message, Is.EqualTo("Max three tours a day!"));





        }

        [Test]
        public void ShouldThrowTourAllocationException()
        {
            sut.CreateTour(
                "New years day safari 1", new DateTime(2017, 1, 1, 10, 15, 0), 20);
            sut.CreateTour(
                "New years day safari 2", new DateTime(2017, 1, 1, 11, 15, 0), 30);
            sut.CreateTour(
                "New years day safari 3", new DateTime(2017, 1, 1, 12, 15, 0), 30);

            Assert.That(() => sut.CreateTour(
                    "New years day safari 4", new DateTime(2017, 1, 1, 13, 15, 0), 30)
                , Throws.TypeOf<TourAllocationException>());



        }

    }

    }
