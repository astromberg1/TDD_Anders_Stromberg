﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
  public  class TourAllocationException: Exception
    {
        public  TourAllocationException()
        {
        }

        public  TourAllocationException(string message)
            : base(message)
        {
        }

      
    }
}
