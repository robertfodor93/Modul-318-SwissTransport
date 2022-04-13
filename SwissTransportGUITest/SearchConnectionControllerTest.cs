
using System;
using SwissTransportGUI.Controllers;

namespace SwissTransportGUITest
{
    using FluentAssertions;
    using SwissTransportGUI;
    using Xunit;
    public class SearchConnectionControllerTest
    {
        private SearchConnectionController testee;
        public SearchConnectionControllerTest()
        {
            this.testee = new SearchConnectionController();
        }

        [Fact]
        public void GetConnections()
        {
            this.testee.GetConnections("Luzern", "Z�rich");
            this.testee.Connections[0].FromStation.Should().Contain("Luzern");
            this.testee.Connections[0].ToStation.Should().Contain("Z�rich");
            this.testee.Connections.Count.Should().Be(4);
        }

        [Fact]
        public void GetConnectionsByDateTime()
        {
            this.testee.GetConnections("Luzern", "Z�rich",DateTime.Today.AddDays(2), DateTime.Now.AddDays(2));
            this.testee.Connections[0].FromStation.Should().Contain("Luzern");
            this.testee.Connections[0].ToStation.Should().Contain("Z�rich");
            this.testee.Connections.Count.Should().Be(4);
            this.testee.Connections[0].FromStationDepartureTime.Should().BeAfter(DateTime.Today.AddDays(2));
            this.testee.Connections[0].ToStationArrivalTime.Should().BeAfter(DateTime.Now.AddDays(2));
        }
    }
}