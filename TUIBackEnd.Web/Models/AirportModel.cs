using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TUIBackEnd.Models
{
    /// <summary>
    /// Airport Model class
    /// </summary>
    public class AirportModel
    {
        public int Id { get; set; }
        public string AirportName { get; set; }
        public string AirportCode { get; set; }
        public int Country_Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }


    }
}