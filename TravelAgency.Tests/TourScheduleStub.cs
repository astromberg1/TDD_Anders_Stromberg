using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Tests
{
public class TourScheduleStub:ITourSchedule
{
    public List<Tour> Tours = new List<Tour>();

   public void CreateTour(string name, DateTime tourDate, int numberofseats)
    {
        throw new NotImplementedException();

    }

    public List<Tour> GetToursFor(DateTime tourDate)
    {

        return Tours.Where(x => x.TourDate.Date == tourDate.Date).ToList();
    }


    }
}
