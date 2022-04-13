namespace SwissTransport.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SwissTransport.Models;

    public interface ITransport
    {
        Stations GetStations(string query);

        StationBoardRoot GetStationBoard(string station, string id);

        Connections GetConnections(string fromStation, string toStation, int connectionLimit, DateTime departureDate, DateTime departureTime);

        Stations GetStationLocation(double latitude, double longitude);
    }
}