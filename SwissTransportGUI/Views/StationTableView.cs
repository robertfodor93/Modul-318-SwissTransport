using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwissTransport.Models;
using SwissTransportGUI.Controllers;
using SwissTransportGUI.Views;

namespace SwissTransportGUI.Views
{
    internal class StationTableView
    {
        public TabPage StationBoardTab { get; set; } = new();
        private SplitContainer SplitContainerStationBoard { get; set; } = new();
        private SplitContainer SplitContainerStationSearchBox { get; set; } = new();
        private Button ButtonStationSearch { get; set; } = new();
        private DataGridView DataGridViewStationTable { get; set; } = new();
        private DataGridViewTextBoxColumn DataGridViewColumnLine { get; set; } = new();
        private DataGridViewTextBoxColumn DataGridViewColumnDeparture { get; set; } = new();
        private DataGridViewTextBoxColumn DataGridViewColumnDirection { get; set; } = new();
        private DataGridViewTextBoxColumn DataGridViewColumnPlatform { get; set; } = new();
        private DataGridViewTextBoxColumn DataGridViewColumnDelays { get; set; } = new();
        private SearchStationComponent SearchComponent { get; set; } = new(0, 0);

        private StationBoardController StationBoardController { get; }

        public StationTableView()
        {
            StationBoardController = new StationBoardController();

            InitControls();
        }

        private void InitControls()
        {
            // 
            // StationTableTab
            // 
            this.StationBoardTab = new TabPage()
            {
                BackColor = Color.White,
                Location = new Point(4, 29),
                Name = "stationBoardTab",
                Padding = new Padding(3),
                Size = new Size(792, 417),
                TabIndex = 2,
                Text = "Fahrplan",
            };
            // 
            // TimeTableSplitContainer
            // 
            this.SplitContainerStationBoard = new SplitContainer()
            {
                Cursor = Cursors.HSplit,
                Dock = DockStyle.Fill,
                FixedPanel = FixedPanel.Panel1,
                Location = new Point(3, 3),
                Name = "splitContainerStationBoard",
                Orientation = Orientation.Horizontal,
                Size = new Size(786, 411),
                SplitterDistance = 88,
                TabIndex = 1,
                Panel1 =
                {
                    BackColor = Color.White,
                },
                Panel2 =
                {
                    BackColor= Color.White,
                }
            };
            // 
            // SearchBoxSplitContainer
            // 
            this.SplitContainerStationSearchBox = new SplitContainer()
            {
                Cursor = Cursors.VSplit,
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Name = "searchBoxSplitContainer",
                Size = new Size(786, 88),
                FixedPanel = FixedPanel.Panel2, // Search Button always same size
                SplitterDistance = 580,
                TabIndex = 0,
                Panel1 = {
                    Padding = new Padding(25, 27, 0, 25),
                },
                Panel2 =
                {
                    Padding = new Padding(0, 26, 25, 31),
                }
            };
            /// StationSearch Component
            this.SearchComponent = new SearchStationComponent(25, 27);
            this.SearchComponent.TextBoxSearch.Dock = DockStyle.Fill;
            // 
            // SearchButton
            // 
            this.ButtonStationSearch = new Button()
            {
                Cursor = Cursors.Hand,
                Dock = DockStyle.Fill,
                Enabled = false,
                Location = new Point(25, 25),
                Name = "searchButton",
                Size = new Size(152, 38),
                TabIndex = 0,
                Text = "Suchen",
                UseVisualStyleBackColor = false,
                ForeColor = Color.Blue
            };
            // 
            // Station table columns
            // 
            this.DataGridViewStationTable = new DataGridView()
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                AllowUserToOrderColumns = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Cursor = Cursors.Default,
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Margin = new Padding(3, 2, 3, 2),
                Name = "dataGridViewStationTable",
                ReadOnly = true,
                RowHeadersVisible = false, // weird first column
                RowHeadersWidth = 51,
                RowTemplate = {
                    Height = 29
                },
                Enabled = true,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point),
                Size = new Size(686, 215),
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                TabIndex = 0,
                DataSource = StationBoardController.DepartureBoardItems,

            };
            this.DataGridViewColumnLine = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Line",
                HeaderText = "Linie",
                Name = "dataGridViewColumnLine",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                Width = 100,
            };
            this.DataGridViewColumnDeparture = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "DepartureTime",
                HeaderText = "Abfahrt",
                Name = "dataGridViewColumnDeparture",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            this.DataGridViewColumnDirection = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Direction",
                HeaderText = "Nach",
                Name = "DataGridViewColumnDirection",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            this.DataGridViewColumnDelays = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Delays",
                HeaderText = "Verspätung",
                Name = "dataGridViewColumnDelays",
            };
            this.DataGridViewColumnPlatform = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Platform",
                HeaderText = "Platform",
                Name = "dataGridViewColumnPlatform",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                Width = 100,
            };

            this.DataGridViewStationTable.Columns.AddRange(new DataGridViewColumn[] {
                this.DataGridViewColumnLine,
                this.DataGridViewColumnDeparture,
                this.DataGridViewColumnDirection,
                this.DataGridViewColumnPlatform,
                this.DataGridViewColumnDelays,
            });
            this.StationBoardTab.Controls.Add(this.SplitContainerStationBoard);
            this.SplitContainerStationBoard.Panel1.Controls.Add(this.SplitContainerStationSearchBox);
            this.SplitContainerStationBoard.Panel2.Controls.Add(this.DataGridViewStationTable);
            this.SplitContainerStationSearchBox.Panel1.Controls.Add(this.SearchComponent.TextBoxSearch);
            this.SplitContainerStationSearchBox.Panel2.Controls.Add(this.ButtonStationSearch);
            this.StationBoardTab.Controls.Add(this.SearchComponent.ListBoxSuggestions);
            this.StationBoardTab.Paint += new PaintEventHandler(this.StationTableTabPaint);
            this.ButtonStationSearch.Click += new System.EventHandler(this.SearchButtonClick);
            this.SearchComponent.ListBoxSuggestions.Click += new EventHandler(this.AutoSuggestClick);
            this.SearchComponent.TextBoxSearch.TextChanged += new EventHandler(this.CheckInput);
        }

        private void CheckInput(object? sender, EventArgs e)
        {
            if (RegexController.IsValidSearchQuery(this.SearchComponent.TextBoxSearch.Text) == true)
            {
                this.ButtonStationSearch.Enabled = true;
            }
            else
            {
                this.ButtonStationSearch.Enabled = false;
            }
        }

        private void AutoSuggestClick(object? sender, EventArgs e)
        {
            SearchButtonClick(new object(), new EventArgs());
        }

        private void SearchButtonClick(object sender, EventArgs e)
        {
            try
            {
                string stationNameQuery = this.SearchComponent.TextBoxSearch.Text;
                if (RegexController.IsValidSearchQuery(this.SearchComponent.SelectedStation.Name) == true)
                {
                    StationBoardController.GetStationBoard(this.SearchComponent.SelectedStation.Name, this.SearchComponent.SelectedStation.Id);
                }
                else if (RegexController.IsValidSearchQuery(stationNameQuery) == true)
                {
                    StationBoardController.GetStationBoard(stationNameQuery);
                }
                this.SearchComponent.ListBoxSuggestions.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler bei dem laden der Abfahrtstafel: {ex.Message}");
            }

        }

        private void StationTableTabPaint(object sender, PaintEventArgs e)
        {
            this.SearchComponent.TextBoxSearch.Focus();

        }
    }
}
