using SpacePark;
using System;
using Xunit;

namespace SpaceParkTestProject
{
    public class UnitTest1
    {
      
        [Fact]
        public void Test1()
        {
            var id = 15;
            var personMock = new Person 
            {
                Id = id,
                FirstName = "Anders",
                LastName = "Johansson"
                
            };
            var context = new Context();
           

        }
    }
}
