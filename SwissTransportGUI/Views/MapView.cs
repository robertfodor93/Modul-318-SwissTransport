using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using SwissTransport.Core;
using SwissTransport.Models;
using SwissTransportGUI.Controllers;


namespace SwissTransportGUI.Views
{
    internal class MapView
    {
        private readonly string InitialMapLocation = "Luzern, Schweiz";

        public TabPage MapTab { get; set; } = new();
        private TableLayoutPanel TableLayoutPanelLocationSearch { get; set; } = new();
        private Label LabelLocation { get; set; } = new();
        private SearchUserControl SearchLocation { get; set; } = new(0, 0);
        private Button ButtonSearchLocation { get; set; } = new();
        private GMapControl MapControl { get; set; } = new();
        private GMapOverlay MapMarkers { get; set; } = new();

        private ITransport Transport { get; set; }

        public MapView()
        {
            Transport = new Transport();

            InitControls();
        }

        private void InitControls()
        {
            Font searchBoxFont = new ("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            // StationTableTab
            this.MapTab = new TabPage()
            {
                BackColor = Color.White,
                Location = new Point(4, 29),
                Name = "MapTab",
                Padding = new Padding(3),
                Size = new Size(792, 417),
                TabIndex = 2,
                Text = "Kartenansicht",
            };
            // Table for the search bar
            this.TableLayoutPanelLocationSearch = new TableLayoutPanel()
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Top,
                Dock = DockStyle.Top,
                ColumnCount = 3,
                Location = new Point(0, 0),
                Margin = new Padding(3, 2, 3, 2),
                Name = "TableLayoutPanelStationSearch",
                Size = new (798, 125),
                RowCount = 3,
                TabIndex = 0,
            };
            // Search section controls
            this.LabelLocation = new Label()
            {
                Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right))),
                AutoSize = true,
                Location = new Point(75, 0),
                Name = "labelStation",
                Size = new Size(35, 42),
                TabIndex = 4,
                Text = "Station:",
                TextAlign = ContentAlignment.MiddleCenter,
            };
            this.SearchLocation = new SearchUserControl(88, 43);
            this.SearchLocation.TextBoxSearch.Dock = DockStyle.Fill;
            this.SearchLocation.TextBoxSearch.Margin = new Padding(5);
            this.SearchLocation.TextBoxSearch.Font = searchBoxFont;
            this.ButtonSearchLocation = new Button()
            {
                Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right))),
                Cursor = Cursors.Hand,
                Dock = DockStyle.Fill,
                Enabled = false,
                Location = new Point(25, 0),
                Name = "buttonSearchStation",
                Size = new Size(152, 25),
                TabIndex = 0,
                Text = "Suchen",
                UseVisualStyleBackColor = false,
            };
            // Map
            this.MapControl = new GMapControl()
            {
                Dock = DockStyle.Fill,
                MinZoom = 2, // below no data
                MaxZoom = 18,
                Zoom = 13,
                ShowCenter = false,
            };
            // Map markers
            this.MapMarkers = new GMapOverlay("markers");
            this.MapControl.MapProvider = OpenStreetMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            this.MapControl.SetPositionByKeywords(this.InitialMapLocation);
            this.MapControl.Overlays.Add(MapMarkers);
            // Adding controls to containers
            this.TableLayoutPanelLocationSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            this.TableLayoutPanelLocationSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            this.TableLayoutPanelLocationSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            this.TableLayoutPanelLocationSearch.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            this.TableLayoutPanelLocationSearch.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            this.TableLayoutPanelLocationSearch.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            this.TableLayoutPanelLocationSearch.Controls.Add(this.LabelLocation, 0, 1);
            this.TableLayoutPanelLocationSearch.Controls.Add(this.SearchLocation.TextBoxSearch, 1, 1);
            this.TableLayoutPanelLocationSearch.Controls.Add(this.ButtonSearchLocation, 2, 1);
            this.MapTab.Controls.Add(this.MapControl);
            this.MapTab.Controls.Add(this.TableLayoutPanelLocationSearch);
            this.MapTab.Controls.Add(this.SearchLocation.ListBoxSuggestions);
            // Event handlers
            this.MapTab.Paint += new PaintEventHandler(this.StationsNearbyTabPaint);
            this.SearchLocation.ListBoxSuggestions.Click += new EventHandler(this.AutoSuggestClick);
            this.SearchLocation.TextBoxSearch.TextChanged += new EventHandler(this.CheckInput);
            this.ButtonSearchLocation.Click += new EventHandler(this.SearchButtonClick);

        }
        // Event logic
        private void StationsNearbyTabPaint(object? sender, PaintEventArgs e)
        {
            this.SearchLocation.TextBoxSearch.Focus();
        }
        private void SearchButtonClick(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.SearchLocation.SelectedStation.Name) == false)
                {
                    PointLatLng newLocation = new PointLatLng((double)this.SearchLocation.SelectedStation.Coordinate.XCoordinate,
                        (double)this.SearchLocation.SelectedStation.Coordinate.YCoordinate);
                    this.MapControl.Position = newLocation;

                    MapMarkers.Clear();

                    Stations nearbyStations = Transport.GetStationLocation((double)this.SearchLocation.SelectedStation.Coordinate.XCoordinate,
                        (double)this.SearchLocation.SelectedStation.Coordinate.YCoordinate);
                    this.AddMapMarkers(nearbyStations, newLocation);
                }
                this.SearchLocation.ListBoxSuggestions.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to find station. Error occurred: {ex.Message}");
            }
        }
        private void AddMapMarkers(Stations nearbyStations, PointLatLng currentLocation)
        {
            foreach (Station station in nearbyStations.StationList)
            {
                if (station.Coordinate.XCoordinate != null && station.Coordinate.YCoordinate != null)
                {
                    MapControl.Zoom = 16;
                    PointLatLng newMarkerLocation = new PointLatLng((double)station.Coordinate.XCoordinate, (double)station.Coordinate.YCoordinate);
                    GMapMarker newMarker = new GMarkerGoogle(newMarkerLocation, GMarkerGoogleType.red);
                    newMarker.ToolTipText = station.Name;
                    newMarker.ToolTip.Fill = Brushes.Black;
                    newMarker.ToolTip.Foreground = Brushes.White;
                    newMarker.ToolTip.Stroke = Pens.Black;
                    newMarker.ToolTip.TextPadding = new Size(20, 20);

                    MapMarkers.Markers.Add(newMarker);

                    Console.WriteLine($"Marker {station.Name} X {newMarkerLocation.Lat} Y {newMarkerLocation.Lng}");
                }
            }
            MapMarkers.Markers.Add(new GMarkerGoogle(currentLocation, GMarkerGoogleType.blue_dot));
        }

        private void CheckInput(object? sender, EventArgs e)
        {
            if (RegexController.IsValidSearchQuery(this.SearchLocation.TextBoxSearch.Text) == true)
            {
                this.ButtonSearchLocation.Enabled = true;
            }
            else
            {
                this.ButtonSearchLocation.Enabled = false;
            }
        }

        private void AutoSuggestClick(object? sender, EventArgs e)
        {
            SearchButtonClick(new object(), new EventArgs());
        }
    }
}
