using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwissTransport.Models;
using GMap.NET;

namespace SwissTransportGUI.Models
{
    internal class MapModel
    {
        public PointLatLng FromStationCoord { get; set; }
        public PointLatLng ToStationCoord { get; set; }
        public string? FromStation { get; set; }
        public string? ToStation { get; set; }
    }
}
