using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwissTransport.Core;
using SwissTransport.Models;
using SwissTransportGUI.Models;

namespace SwissTransportGUI.Controllers
{
    public class StationBoardController
    {
        public BindingList<StationBoardModel> StationBoardItems { get; set; }
        private ITransport Transport { get; set; }

        public StationBoardController()
        {
            StationBoardItems = new BindingList<StationBoardModel>();

            Transport = new Transport();
        }

        public void GetStationBoard(string stationName)
        {
            Station chosenStation = Transport.GetStations(stationName).StationList[0];
            GetStationBoard(chosenStation.Name, chosenStation.Id);
        }

        public void GetStationBoard(string stationName, string stationId)
        {
            StationBoardRoot stationBoardRoot = Transport.GetStationBoard(stationName, stationId);

            StationBoardItems.Clear();
            foreach (StationBoard item in stationBoardRoot.Entries)
            {
                StationBoardItems.Add(new StationBoardModel()
                {
                    Line = $"{item.Category}{item.Number}",
                    DepartureTime = item.Stop.Departure.ToString("HH:mm"),
                    Direction = item.To,
                    Delays = item.Stop.Delay,
                    Platform = item.Stop.Platform,
                });
            }
        }
    }
}
