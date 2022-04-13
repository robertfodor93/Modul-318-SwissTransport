using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwissTransport.Models;
using SwissTransportGUI.Controllers;

namespace SwissTransportGUI.Views
{
    internal class SearchUserControl
    {
        public TextBox TextBoxSearch { get; set; } = new();
        public ListBox ListBoxSuggestions { get; private set; } = new();
        public Station SelectedStation { get; private set; }
        public SuggestionController StationSearcher { get; private set; }
        public SearchUserControl(int searchBoxX, int searchBoxY)
        {
            StationSearcher = new SuggestionController();
            SelectedStation = new Station();

            InitControls(searchBoxX, searchBoxY);
        }

        private void InitControls(int searchBoxX, int searchBoxY)
        {
            this.TextBoxSearch = new TextBox()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(searchBoxX, searchBoxY),
                Margin = new Padding(0),
                Name = "SearchBox",
                PlaceholderText = "Station eingeben",
                TabIndex = 0,
            };
            this.ListBoxSuggestions = new ListBox()
            {
                Location = new Point()
                {
                    X = TextBoxSearch.Location.X + 2,
                    Y = TextBoxSearch.Location.Y + TextBoxSearch.Height + 2,
                },
                Width = TextBoxSearch.Width,
                Visible = false,
                DataSource = StationSearcher.StationSuggestions,
                ValueMember = "Id",
                DisplayMember = "Name",
                Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
                | AnchorStyles.Right))),
                IntegralHeight = true,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point),
            };
            //Event handlers
            this.TextBoxSearch.TextChanged += new EventHandler(this.SearchBoxTextChanged);
            this.TextBoxSearch.GotFocus += new EventHandler(this.ShowAutoSuggestions);
            this.TextBoxSearch.Click += new EventHandler(this.ShowAutoSuggestions);
            this.TextBoxSearch.Resize += new EventHandler(this.SearchBoxResize);
            this.TextBoxSearch.KeyDown += new KeyEventHandler(this.SearchBoxHandleKey);
            this.ListBoxSuggestions.Click += new EventHandler(this.AutoSuggestSuggestItem);
        }
        //Event logic
        private void SearchBoxHandleKey(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AutoSuggestSuggestItem(new object(), new EventArgs());
                e.Handled = true;
            }
        }
        private void SearchBoxResize(object? sender, EventArgs e)
        {
            TextBoxSearch.Width = TextBoxSearch.Width;
            TextBoxSearch.Location = new Point()
            {
                X = TextBoxSearch.Location.X + 3,
                Y = TextBoxSearch.Location.Y + TextBoxSearch.Height + 2,
            };
        }
        private void AutoSuggestSuggestItem(object? sender, EventArgs e)
        {
            Station selectedStation = (Station)ListBoxSuggestions.SelectedItem;
            TextBoxSearch.Text = selectedStation.Name;
            ListBoxSuggestions.Hide();
        }
        private void SearchBoxTextChanged(object sender, EventArgs e)
        {
            string stationNameQuery = TextBoxSearch.Text;
            if (RegexController.IsValidSearchQuery(stationNameQuery) == true)
            {
                StationSearcher.GetNewStationSuggestions(stationNameQuery);
                SelectedStation = StationSearcher.StationSuggestions[0];
                ListBoxSuggestions.Show();
                ListBoxSuggestions.BringToFront();
            }

            if (stationNameQuery.Length < 1)
            {
                ListBoxSuggestions.Hide();
            }
        }
        private void ShowAutoSuggestions(object sender, EventArgs e)
        {
            ListBoxSuggestions.Show();
        }

    }
}
