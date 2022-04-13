
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
            this.testee.GetConnections("Luzern", "Zürich");
            this.testee.Connections[0].FromStation.Should().Contain("Luzern");
            this.testee.Connections[0].ToStation.Should().Contain("Zürich");
            this.testee.Connections.Count.Should().Be(4);
        }

        [Fact]
        public void GetConnectionsByDateTime()
        {
            this.testee.GetConnections("Luzern", "Zürich",DateTime.Today.AddDays(2), DateTime.Now.AddDays(2));
            this.testee.Connections[0].FromStation.Should().Contain("Luzern");
            this.testee.Connections[0].ToStation.Should().Contain("Zürich");
            this.testee.Connections.Count.Should().Be(4);
            this.testee.Connections[0].FromStationDepartureTime.Should().BeAfter(DateTime.Today.AddDays(2));
            this.testee.Connections[0].ToStationArrivalTime.Should().BeAfter(DateTime.Now.AddDays(2));
        }
    }
}