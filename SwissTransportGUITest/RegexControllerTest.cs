using System;
using SwissTransportGUI.Controllers;
using FluentAssertions;
using Xunit;

namespace SwissTransportGUITest
{
    public class RegexControllerTest
    {
        [Fact]
        public void IsValidSearchQuery()
        {
            RegexController.IsValidSearchQuery("**, Luzern").Should().BeFalse();
            RegexController.IsValidSearchQuery("$nake$ ar# c&&l").Should().BeFalse();
            RegexController.IsValidSearchQuery("Luzern, Bahnhof").Should().BeTrue();
            RegexController.IsValidSearchQuery("Zürich HB").Should().BeTrue();
            RegexController.IsValidSearchQuery("Neuchâtel").Should().BeTrue();
        }
    }
}