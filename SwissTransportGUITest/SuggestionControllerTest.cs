using System;
using SwissTransportGUI.Controllers;
using FluentAssertions;
using Xunit;

namespace SwissTransportGUITest
{
    public class SuggestionControllerTest
    {
        private SuggestionController testee;
        public SuggestionControllerTest()
        {
            this.testee = new SuggestionController();
        }

        [Fact]
        public void GetStationSuggestions()
        {
            this.testee.GetNewStationSuggestions("Luzern");
            this.testee.StationSuggestions[0].Name.Should().Contain("Luzern");
        }
    }
}