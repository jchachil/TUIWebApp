using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TUIBackEnd.DAL;
using TUIBackEnd.Models;

namespace TUIBackEnd.Web
{
    /// <summary>
    /// Automapper configuration class
    /// </summary>
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Country, CountryModel>().ReverseMap();
                config.CreateMap<Airport, AirportModel>().ReverseMap();

                config.CreateMap<Flight, FlightModel>().ReverseMap();
            });
        }
    }
}