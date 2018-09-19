using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TUIBackEnd.Models
{
    /// <summary>
    /// Country Model class
    /// </summary>
    public class CountryModel
    {
        public int Id { get; set; }
        public string CountryName { get; set; }

        public  List<AirportModel> Airports { get; set; }
    }
}