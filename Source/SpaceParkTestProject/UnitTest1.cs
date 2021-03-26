using SpacePark;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SpaceParkTestProject
{
    public class UnitTest1
    {
        [Fact]
        public void CostOfParking_Expected_Cost()
        {
            var hej = new ParkingHouseDataAccess();
            var result = hej.CostOfParking(37);

            Assert.Equal(9250, result);
        }

        [Fact]
        public void CostOfParking_Argument_Zero_Expected_Zero()
        {
            var hej = new ParkingHouseDataAccess();
            var result = hej.CostOfParking(0);

            Assert.Equal(0, result);
        }

        // Något parkingtest till

        [Fact]
        public async Task Get_Lengt_Of_StarShip()
        {
            var swApi = new SwApi();
            var result = await swApi.GetShipLength("x-wing");

            Assert.Equal(12.5, result);
        }

        // Test ++

        [Fact]
        public async Task Get_Startravellers_Starships()
        {
            var swApi = new SwApi();
            var listOfShips = new List<string>
            { "http://swapi.dev/api/starships/12/", "http://swapi.dev/api/starships/22/" };
            var result = await swApi.GetSpaceTraveller("Luke skywalker");

            Assert.Equal(listOfShips, result.StarShips);
            Assert.NotNull(result);
        }

        // Test ++
    }
}
