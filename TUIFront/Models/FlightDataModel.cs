using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TUIFront.Models
{
    public class FlightDataModel
    {

        public int Id { get; set; }
        public string FlightName { get; set; }

        public DateTime? FlightDate { get; set; }

        public int DepartureAirport_Id { get; set; }

        public int DestinationAirport_Id { get; set; }

        public double FlightDistance { get; set; }

        public double AirCratfFuelComsumpDistance { get; set; }

        public double FlightTime { get; set; }

        public double TakeOffEffort { get; set; }


    }
}