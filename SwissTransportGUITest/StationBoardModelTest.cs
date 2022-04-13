using System;
using SwissTransportGUI.Models;
using FluentAssertions;
using GMap.NET;
using Xunit;

namespace SwissTransportGUITest
{
    public class StationBoardModelTest
    {

        [Fact]
        public void StationBoardModel()
        {
            StationBoardModel test1 = new StationBoardModel()
            {
                Direction = "Zürich",
                Platform = "2",
                DepartureTime = "20:00:00",
                Line = "S1"
            };
            test1.Should().BeOfType<StationBoardModel>();
        }
    }
}