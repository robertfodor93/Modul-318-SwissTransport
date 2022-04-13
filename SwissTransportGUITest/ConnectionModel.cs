using System;
using SwissTransportGUI.Models;
using FluentAssertions;
using GMap.NET;
using Xunit;

namespace SwissTransportGUITest
{
    public class ConnectionModel
    {

        [Fact]
        public void ConnectionsModel()
        {
            ConnectionsModel test1 = new ConnectionsModel()
            {
                Duration = "30.05M",
                FromStation = "Zürich",
                FromStationDepartureTime = DateTime.Now,
                ToStation = "luzern",
                ToStationArrivalTime = DateTime.Now.AddHours(2),

            };
            test1.Should().BeOfType<ConnectionsModel>();
        }
    }
}