using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using SwissTransport.Core;
using SwissTransport.Models;

namespace SwissTransportGUI.Controllers
{
    public class SearchStationController
    {
        private ITransport Transport { get; set; }
        public BindingList<Station> StationSuggestions { get; internal set; }

        public SearchStationController()
        {
            Transport = new Transport();

            StationSuggestions = new BindingList<Station>();
        }
        public void GetNewStationSuggestions(string stationNameQuery)
        {
            StationSuggestions.Clear();
            List<Station> stations = Transport.GetStations(stationNameQuery).StationList;
            foreach (Station station in stations)
            {
                StationSuggestions.Add(station);
            }
        }
    }
}
