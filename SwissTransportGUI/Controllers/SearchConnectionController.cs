using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using SwissTransport.Core;
using SwissTransport.Models;
using SwissTransportGUI.Models;

namespace SwissTransportGUI.Controllers
{
    public class SearchConnectionController
    {
        private ITransport Transport { get; set; }
        private static readonly int displayLimit = 4;

        public BindingList<ConnectionsModel> Connections { get; set; }

        public SearchConnectionController()
        {
            Transport = new Transport();
            Connections = new BindingList<ConnectionsModel>();
        }
        public void GetConnections(string fromStation, string toStation)
            => GetConnections(fromStation, toStation, DateTime.Now, DateTime.Now);
        public void GetConnections(string fromStation, string toStation, DateTime departureDate, DateTime departureTime)
        {
            Connections.Clear();
            Connections connections = Transport.GetConnections(fromStation, toStation, displayLimit, departureDate, departureTime);
            foreach (Connection connection in connections.ConnectionList)
            {
                Connections.Add(new ConnectionsModel()
                {
                    FromStation = connection.From.Station.Name,
                    ToStation = $"{connection.To.Station.Name}",
                    FromStationDepartureTime = connection.From.Departure,
                    ToStationArrivalTime = connection.To.Arrival,
                    Duration = connection.Duration,
                    Delay = connection.To.Delay
                });
            }
        }
    }
}
