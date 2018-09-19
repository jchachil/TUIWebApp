using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TUIBackEnd.Web.Controllers;
using TUIBackEnd.Models;
using System.Collections.Generic;
using System.Web;
using TUIBackEnd.Web;
using TUIBackEnd.DAL;
using System.Data.Entity;
using TUIBackEnd.Test.Helper;
using System.Linq;

namespace TUIBackEnd.Test
{
    /// <summary>
    /// Test the FlightController
    /// </summary>
    [TestClass]
    public class TestFlightController
    {
        private List<Flight> flightsList;

        /// <summary>
        /// Insert data for test
        /// </summary>
        [TestInitialize]
        public void Init_Data()
        {

            using (TUIWebAppEntities dbContext = new TUIWebAppEntities())
            {
                using (DbContextTransaction dbContextTransaction = dbContext.Database.BeginTransaction())
                {
                    flightsList = dbContext.PopulateFlights();
                    dbContextTransaction.Commit();
                }
            }

        }
        /// <summary>
        /// cleanup flights data
        /// </summary>
        [TestCleanup]
        public void Dump_Data()
        {
            using (TUIWebAppEntities dbContext = new TUIWebAppEntities())
            {
                if (flightsList != null)
                {
                    dbContext.DumpFlight(flightsList);
                }

                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Test method: GetFlightList
        /// </summary>
        [TestMethod]
        public void TestGetFlightList()
        {
            AutoMapperConfig.Initialize();

            var controller = new FlightController();
            var result = controller.GetFlightList() as List<FlightModel>;
            Assert.IsNotNull(result);
            Assert.AreEqual(flightsList.Count, result.Count);
            var firstElt = flightsList[0];
            var firstResult = result.First(item => item.Id == firstElt.Id);

            Assert.AreEqual(firstElt.FlightTime, firstResult.FlightTime);
            Assert.AreEqual(firstElt.FuelNeeded, firstResult.FuelNeeded);
            Assert.AreEqual(firstElt.AirCratfFuelComsumpDistance, firstResult.AirCratfFuelComsumpDistance);
            Assert.AreEqual(firstElt.DepartureAirport_Id, firstResult.DepartureAirport_Id);
            Assert.AreEqual(firstElt.DestinationAirport_Id, firstResult.DestinationAirport_Id);




        }

        /// <summary>
        /// Test method: GetFlightById
        /// </summary>
        [TestMethod]
        public void TestGetFlightById()
        {
            AutoMapperConfig.Initialize();

            Flight flightItem = flightsList[0];
            var controller = new FlightController();
            var result = controller.GetFlightById(flightItem.Id) as FlightModel;
            Assert.IsNotNull(result);

            Assert.AreEqual(flightItem.FuelNeeded, result.FuelNeeded);
            Assert.AreEqual(flightItem.AirCratfFuelComsumpDistance, result.AirCratfFuelComsumpDistance);
            Assert.AreEqual(flightItem.DepartureAirport_Id, result.DepartureAirport_Id);
            Assert.AreEqual(flightItem.DestinationAirport_Id, result.DestinationAirport_Id);

        }

        /// <summary>
        /// Test the method AddFlight
        /// </summary>
        [TestMethod]
        public void TestAddFlight()
        {
            Dump_Data();
            Flight flightItem = flightsList.First();
            AutoMapperConfig.Initialize();
            var controller = new FlightController();
            var returnValue = controller.AddFlight(flightItem);
            Assert.IsNotNull(returnValue);
            Assert.AreEqual(returnValue.Code, "OK");
            var result = controller.GetFlightList() as List<FlightModel>;
            Assert.IsNotNull(result);
            var firstItem = result.First();
            Assert.AreEqual(flightItem.FuelNeeded, firstItem.FuelNeeded);
            Assert.AreEqual(flightItem.AirCratfFuelComsumpDistance, firstItem.AirCratfFuelComsumpDistance);
            Assert.AreEqual(flightItem.DepartureAirport_Id, firstItem.DepartureAirport_Id);
            Assert.AreEqual(flightItem.DestinationAirport_Id, firstItem.DestinationAirport_Id);


        }
        [TestMethod]
        public void TestUpdateFlight()
        {
            Flight flightItem = flightsList.First();
            AutoMapperConfig.Initialize();
            var controller = new FlightController();

            flightItem.DepartureAirport_Id = 5;
            flightItem.DestinationAirport_Id = 10;
            flightItem.FlightTime = 2;
            flightItem.AirCratfFuelComsumpDistance = 400;
            flightItem.TakeOffEffort = 50;

            var result = controller.UpdadteFlight(flightItem);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Code, "OK");

            FlightModel model = controller.GetFlightById(flightItem.Id);

            Assert.AreEqual(flightItem.FlightTime, model.FlightTime);
            Assert.AreEqual(flightItem.TakeOffEffort, model.TakeOffEffort);
            Assert.AreEqual(flightItem.AirCratfFuelComsumpDistance, model.AirCratfFuelComsumpDistance);
            Assert.AreEqual(flightItem.DepartureAirport_Id, model.DepartureAirport_Id);
            Assert.AreEqual(flightItem.DestinationAirport_Id, model.DestinationAirport_Id);

        }



    }
}
