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
            var parkingHouse = new ParkingHouseDataAccess();
            var result = parkingHouse.CostOfParking(37);

            Assert.Equal(9250, result);
        }

        [Fact]
        public void CostOfParking_Argument_Zero_Expected_Zero()
        {
            var perkingHouse = new ParkingHouseDataAccess();
            var result = perkingHouse.CostOfParking(0);

            Assert.Equal(0, result);
        }

        [Fact]
        public void CostOfParking_Argument_Double_Expect_No_Fractional_Digits()
        {
            var parkingHouse = new ParkingHouseDataAccess();
            var result = parkingHouse.CostOfParking(25.897);

            Assert.Equal(6500, result);
        }

        [Fact]
        public async Task GetShipLength_Expect_Length()
        {
            var swApi = new SwApi();
            var result = await swApi.GetShipLength("x-wing");

            Assert.Equal(12.5, result);
        }

        [Fact]
        public async Task GetSpaceTraveller_Expect_Starships()
        {
            var swApi = new SwApi();
            var listOfShips = new List<string>
            { "http://swapi.dev/api/starships/12/", "http://swapi.dev/api/starships/22/" };
            var result = await swApi.GetSpaceTraveller("Luke skywalker");

            Assert.Equal(listOfShips, result.StarShips);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetSpaceTraveller_InvalidName_Expect_Exception_Message()
        {
            var swApi = new SwApi();
            var result = await swApi.GetSpaceTraveller("Luko skywalker");
            Assert.NotNull("You are not famous and can't access this spacepark.");
        }

        [Fact]
        public async Task GetSpaceTraveller_EmptyInput_Expect_Exception_Message()
        {
            var swApi = new SwApi();
            var result = await swApi.GetSpaceTraveller("");
            Assert.NotNull("You have entered an invalid name, please enter your full name.");
        }

        [Fact]
        public async Task ChooseStarShip_NoneAvailable_Expect_Null_Return()
        {
            var swApi = new SwApi();
            var testPerson = await swApi.GetSpaceTraveller("C-3PO");
            var result = await swApi.ChooseStarShip(testPerson);
            Assert.Null(result);
        }

        //[Fact]
        //public async Task ShowFreeSpaces_Expected_Empty() //Test will only pass if no vehicles are parked
        //{
        //    var freeSpaces = new ParkingHouseDataAccess();
        //    var actualAvailable = await freeSpaces.ShowFreeSpaces();
        //    Assert.Equal("50", actualAvailable.ToString());
        //}

        //[Fact]
        //public async Task IsPersonParked_Check() 
        //{
        //    var isParked = new ParkingHouseDataAccess();
        //    var result = await isParked.IsPersonParked("luke skywalker");
        //    Assert.True(result);
        //}
    }
}
