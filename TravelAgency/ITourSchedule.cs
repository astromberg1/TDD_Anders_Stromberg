using System;
using System.Collections.Generic;

namespace TravelAgency
{
    public interface ITourSchedule
    {
        void CreateTour(string name, DateTime tourDate, int numberofseats);

        List<Tour> GetToursFor(DateTime tourDate);

    }
}