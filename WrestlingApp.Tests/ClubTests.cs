using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrestlingApp.Domain.Entities;

namespace WrestlingApp.Tests
{
    public class ClubTests
    {
        [Fact]
        public void Club_WhenInitialized_ShouldSetPropertiesCorrectly()
        {
            var expectedName = "Garabagh Wrestling Club";
            var expectedAddress = "Fuzuli, Azerbaijan";

            var club = new Club
            {
                Name = expectedName,
                Address = expectedAddress
            };

            Assert.Equal(expectedName, club.Name);
            Assert.Equal(expectedAddress, club.Address);
        }
    }
}
