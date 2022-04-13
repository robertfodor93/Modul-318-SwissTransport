namespace SwissTransport.Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using SwissTransport.Models;

    public class Transport : ITransport, IDisposable
    {
        private const string OpenDataApiHost = "https://transport.opendata.ch/v1/";
        private const string SearchApiHost = "https://timetable.search.ch/api/";
        private readonly HttpClient httpClient = new HttpClient();

        public Stations GetStations(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentNullException(nameof(query));
            }

            var uri = new Uri($"{OpenDataApiHost}locations?query={query}");
            return this.GetObject<Stations>(uri);
        }

        public StationBoardRoot GetStationBoard(string station, string id)
        {
            if (string.IsNullOrEmpty(station))
            {
                throw new ArgumentNullException(nameof(station));
            }

            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            var uri = new Uri($"{OpenDataApiHost}stationboard?station={station}&id={id}");
            return this.GetObject<StationBoardRoot>(uri);
        }

        public Connections GetConnections(string fromStation, string toStation, int connectionLimit, DateTime departureDate, DateTime departureTime)
        {
            if (string.IsNullOrEmpty(fromStation))
            {
                throw new ArgumentNullException(nameof(fromStation));
            }

            if (string.IsNullOrEmpty(toStation))
            {
                throw new ArgumentNullException(nameof(toStation));
            }

            if (connectionLimit < 1 || connectionLimit > 16)
            {
                throw new ArgumentOutOfRangeException(nameof(connectionLimit));
            }

            var uri = new Uri($"{OpenDataApiHost}connections?from={fromStation}&to={toStation}&limit={connectionLimit}&date={departureDate.ToString("yyyy-MM-dd")}&time={departureTime.ToString("HH:mm")}");
            return this.GetObject<Connections>(uri);
        }

        public Stations GetStationLocation(double latitude, double longitude)
        {
            if (latitude <= 0 && longitude <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(latitude));
            }

            var uri = new Uri($"{SearchApiHost}completion.json?latlon={latitude.ToString("G", CultureInfo.InvariantCulture)},{longitude.ToString("G", CultureInfo.InvariantCulture)}&show_coordinates=1&accuracy=500");

            List<SearchCHLocations> stationList = this.GetObject<List<SearchCHLocations>>(uri);
            List<Station> resultStations = new List<Station>();

            foreach (SearchCHLocations sta in stationList)
            {
                Station station = new Station()
                {
                    Id = sta.Name,
                    Name = sta.Name,
                    Distance = sta.Distance,
                    Coordinate = new Coordinate()
                    {
                        Type = "coordinate",
                        XCoordinate = sta.XCoordinate,
                        YCoordinate = sta.YCoordinate,
                    },
                };
                resultStations.Add(station);
            }

            Stations result = new Stations()
            {
                StationList = resultStations,
            };
            return result;
        }
        public void Dispose()
        {
            this.httpClient?.Dispose();
        }

        private T GetObject<T>(Uri uri)
        {
            HttpResponseMessage response = this.httpClient
                .GetAsync(uri)
                .GetAwaiter()
                .GetResult();
            string content = response.Content
                .ReadAsStringAsync()
                .GetAwaiter()
                .GetResult();

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}