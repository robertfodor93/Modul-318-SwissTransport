using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwissTransport.Models;
using SwissTransportGUI.Controllers;

namespace SwissTransportGUI.Views
{
    internal class SearchStationComponent
    {
        public TextBox textBoxSearch { get; set; } = new();
        public ListBox listBoxSuggestions { get; private set; } = new();

        public Station SelectedStation { get; private set; }

        public SearchStationController StationSearcher { get; private set; }

        public SearchStationComponent(int SearchBoxX, int SearchBoxY)
        {
            StationSearcher = new SearchStationController();
            SelectedStation = new Station();

            InitControls(SearchBoxX, SearchBoxY);
        }

        private void InitControls(int SearchBoxX, int SearchBoxY)
        {
            // 
            // SearchBox
            // 
            this.textBoxSearch = new TextBox()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(SearchBoxX, SearchBoxY),
                Margin = new Padding(0),
                Name = "SearchBox",
                PlaceholderText = "Search for a station ...",
                TabIndex = 0,
            };

            //
            // AutoSuggestList
            //
            this.listBoxSuggestions = new ListBox()
            {
                Location = new Point()
                {
                    X = textBoxSearch.Location.X + 3,
                    Y = textBoxSearch.Location.Y + textBoxSearch.Height + 2,
                },
                Width = textBoxSearch.Width,
                Visible = false,
                DataSource = StationSearcher.StationSuggestions,
                ValueMember = "Id",
                DisplayMember = "Name",
                Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
                | AnchorStyles.Right))),
                IntegralHeight = true,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point),
            };

            this.textBoxSearch.TextChanged += new EventHandler(this.SearchBox_TextChanged);
            this.textBoxSearch.GotFocus += new EventHandler(this.ShowAutoSuggestions);
            this.textBoxSearch.Click += new EventHandler(this.ShowAutoSuggestions);
            this.textBoxSearch.Resize += new EventHandler(this.SearchBox_Resize);
            this.textBoxSearch.KeyDown += new KeyEventHandler(this.SearchBox_HandleKey);
            this.listBoxSuggestions.Click += new EventHandler(this.AutoSuggest_SuggestItem);
        }

        private void SearchBox_HandleKey(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AutoSuggest_SuggestItem(new object(), new EventArgs());
                e.Handled = true;
            }
        }

        private void SearchBox_Resize(object? sender, EventArgs e)
        {
            textBoxSearch.Width = textBoxSearch.Width;
            textBoxSearch.Location = new Point()
            {
                X = textBoxSearch.Location.X + 3,
                Y = textBoxSearch.Location.Y + textBoxSearch.Height + 2,
            };
        }

        private void AutoSuggest_SuggestItem(object? sender, EventArgs e)
        {
            Station selectedStation = (Station)listBoxSuggestions.SelectedItem;
            textBoxSearch.Text = selectedStation.Name;
            listBoxSuggestions.Hide();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string stationNameQuery = textBoxSearch.Text;
            if (RegexController.IsValidSearchQuery(stationNameQuery) == true)
            {
                StationSearcher.GetNewStationSuggestions(stationNameQuery);
                SelectedStation = StationSearcher.StationSuggestions[0];
                listBoxSuggestions.Show();
                listBoxSuggestions.BringToFront();
            }

            if (stationNameQuery.Length < 1)
            {
                listBoxSuggestions.Hide();
            }
        }

        private void ShowAutoSuggestions(object sender, EventArgs e)
        {
            listBoxSuggestions.Show();
        }

    }
}
