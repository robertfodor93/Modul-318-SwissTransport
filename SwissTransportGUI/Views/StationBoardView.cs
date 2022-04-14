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
    internal class StationBoardView
    {
        public TabPage StationBoardTab { get; set; } = new();
        private SplitContainer SplitContainerStationBoard { get; set; } = new();
        private TableLayoutPanel TableLayoutPanelStationSearch { get; set; } = new();
        private Label LabelStation { get; set; } = new();
        private SearchUserControl SearchStation { get; set; } = new(0, 0);
        private Button ButtonSearchStation { get; set; } = new();
        private DataGridView DataGridViewStationTable { get; set; } = new();
        private DataGridViewTextBoxColumn DataGridViewColumnLine { get; set; } = new();
        private DataGridViewTextBoxColumn DataGridViewColumnDeparture { get; set; } = new();
        private DataGridViewTextBoxColumn DataGridViewColumnDirection { get; set; } = new();
        private DataGridViewTextBoxColumn DataGridViewColumnPlatform { get; set; } = new();
        private DataGridViewTextBoxColumn DataGridViewColumnDelays { get; set; } = new();
        private StationBoardController StationBoardController { get; }

        public StationBoardView()
        {
            StationBoardController = new StationBoardController();

            InitControls();
        }

        private void InitControls()
        {
            Font searchBoxFont = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            this.StationBoardTab = new TabPage()
            {
                BackColor = Color.White,
                Location = new Point(4, 29),
                Name = "stationBoardTab",
                Padding = new Padding(3),
                Size = new Size(792, 417),
                TabIndex = 1,
                Text = "Fahrplan",
            };
            // Station board split container
            this.SplitContainerStationBoard = new SplitContainer()
            {
                Cursor = Cursors.Default,
                Dock = DockStyle.Fill,
                FixedPanel = FixedPanel.Panel1,
                IsSplitterFixed = true,
                Location = new Point(3, 2),
                Margin = new Padding(3, 2, 3, 2),
                Name = "splitContainerStationBoard",
                Orientation = Orientation.Horizontal,
                Panel1 =
                {
                    BackColor = Color.White
                },
                Size = new Size(686, 306),
                SplitterDistance = 125,
                SplitterWidth = 3,
            };
            // Table for the search bar
            this.TableLayoutPanelStationSearch = new TableLayoutPanel()
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Top,
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                Location = new Point(0, 0),
                Margin = new Padding(3, 2, 3, 2),
                Name = "tableLayoutPanelStationSearch",
                RowCount = 3,
            };
            this.LabelStation = new Label()
            {
                Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right))),
                AutoSize = true,
                Location = new Point(75, 0),
                Name = "labelStation",
                Size = new Size(35, 42),
                Text = "Station:",
                TextAlign = ContentAlignment.MiddleCenter,
            };
            this.SearchStation = new SearchUserControl(88, 43);
            this.SearchStation.TextBoxSearch.Margin = new Padding(0);
            this.SearchStation.TextBoxSearch.Font = searchBoxFont;
            this.ButtonSearchStation = new Button()
            {
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
            // Data table for station board
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
                RowHeadersVisible = false,
                RowHeadersWidth = 51,
                RowTemplate = {
                    Height = 29
                },
                Enabled = true,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point),
                Size = new Size(686, 215),
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                TabIndex = 1,
                DataSource = StationBoardController.StationBoardItems,
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
                Name = "dataGridViewColumnDirection",
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

            //Adding controls to elements
            this.StationBoardTab.Controls.Add(this.SplitContainerStationBoard);
            this.SplitContainerStationBoard.Panel1.Controls.Add(this.TableLayoutPanelStationSearch);
            this.TableLayoutPanelStationSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            this.TableLayoutPanelStationSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            this.TableLayoutPanelStationSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            this.TableLayoutPanelStationSearch.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            this.TableLayoutPanelStationSearch.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            this.TableLayoutPanelStationSearch.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            this.TableLayoutPanelStationSearch.Controls.Add(this.LabelStation, 0, 1);
            this.TableLayoutPanelStationSearch.Controls.Add(this.SearchStation.TextBoxSearch, 1, 1);
            this.TableLayoutPanelStationSearch.Controls.Add(this.ButtonSearchStation, 2, 1);
            this.StationBoardTab.Controls.Add(this.SearchStation.ListBoxSuggestions);
            this.SplitContainerStationBoard.Panel2.Controls.Add(this.DataGridViewStationTable);
            this.DataGridViewStationTable.Columns.AddRange(new DataGridViewColumn[] {
                this.DataGridViewColumnLine,
                this.DataGridViewColumnDeparture,
                this.DataGridViewColumnDirection,
                this.DataGridViewColumnPlatform,
                this.DataGridViewColumnDelays,
            });

            //Event handlers
            this.StationBoardTab.Paint += new PaintEventHandler(this.StationTableTabPaint);
            this.ButtonSearchStation.Click += new System.EventHandler(this.ButtonSearchStationClick);
            this.SearchStation.ListBoxSuggestions.Click += new EventHandler(this.AutoSuggestClick);
            this.SearchStation.TextBoxSearch.TextChanged += new EventHandler(this.CheckInput);
        }

        //Event logic
        private void CheckInput(object? sender, EventArgs e)
        {
            if (RegexController.IsValidSearchQuery(this.SearchStation.TextBoxSearch.Text) == true)
            {
                this.ButtonSearchStation.Enabled = true;
            }
            else
            {
                this.ButtonSearchStation.Enabled = false;
            }
        }
        private void AutoSuggestClick(object? sender, EventArgs e)
        {
            ButtonSearchStationClick(new object(), new EventArgs());
        }
        private void ButtonSearchStationClick(object sender, EventArgs e)
        {
            try
            {
                string stationNameQuery = this.SearchStation.TextBoxSearch.Text;
                if (RegexController.IsValidSearchQuery(this.SearchStation.SelectedStation.Name) == true)
                {
                    StationBoardController.GetStationBoard(this.SearchStation.SelectedStation.Name, this.SearchStation.SelectedStation.Id);
                }
                else if (RegexController.IsValidSearchQuery(stationNameQuery) == true)
                {
                    StationBoardController.GetStationBoard(stationNameQuery);
                }
                this.SearchStation.ListBoxSuggestions.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler bei dem laden der Abfahrtstafel: {ex.Message}");
            }

        }
        private void StationTableTabPaint(object sender, PaintEventArgs e)
        {
            this.SearchStation.TextBoxSearch.Focus();

        }
    }
}
