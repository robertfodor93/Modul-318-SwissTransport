using System;
using FluentAssertions;
using SwissTransportGUI.Models;
using SwissTransportGUI.Controllers;
using Xunit;

namespace SwissTransportGUITest
{
    public class StationBoardControllerTest
    {
        private StationBoardController testee;
        public StationBoardControllerTest()
        {
            this.testee = new StationBoardController();
        }

        [Fact]
        public void GetStationBoard()
        {
            this.testee.GetStationBoard("Luzern");
            this.testee.StationBoardItems.Should().AllBeOfType<StationBoardModel>();
            this.testee.StationBoardItems[0].Direction.Should().NotStartWithEquivalentOf("Luzern");
        }

        [Fact]
        public void GetStationBoardWId()
        {
            this.testee.GetStationBoard("Luzern", "8505000");
            this.testee.StationBoardItems.Should().AllBeOfType<StationBoardModel>();
            this.testee.StationBoardItems[0].Direction.Should().NotStartWithEquivalentOf("Luzern");
        }
    }
}
