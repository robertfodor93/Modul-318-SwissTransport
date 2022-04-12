using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using SwissTransport.Models;
using SwissTransportGUI.Controllers;
using SwissTransportGUI.Views;
using SwissTransportGUI.Models;

namespace SwissTransportGUI.Views
{
    internal class ConnectionsTableView
    {
        public TabPage connectionsTab { get; set; } = new();
        private SplitContainer splitContainerConnections { get; set; } = new();
        private TableLayoutPanel tableLayoutPanelConnections { get; set; } = new();
        private Label labelTo { get; set; } = new();
        private SearchStationComponent textBoxTo { get; set; } = new(0, 0);
        private Label labelFrom { get; set; } = new();
        private SearchStationComponent textBoxFrom { get; set; } = new(0, 0);
        private DataGridView dataGridViewConnections { get; set; } = new();
        private DataGridViewTextBoxColumn dataGridViewColumnFrom { get; set; } = new();
        private DataGridViewTextBoxColumn dataGridViewColumnDepartureTime { get; set; } = new();
        private DataGridViewTextBoxColumn dataGridViewColumnTo { get; set; } = new();
        private DataGridViewTextBoxColumn dataGridViewColumnArrivalTime { get; set; } = new();
        private DataGridViewTextBoxColumn dataGridViewColumnDuration { get; set; } = new();
        private DataGridViewTextBoxColumn dataGridViewColumnDelay { get; set; } = new();
        private Label labelDate { get; set; } = new();
        private DateTimePicker datePicker { get; set; } = new();
        private Label labelTime { get; set; } = new();
        private DateTimePicker timePicker { get; set; } = new();
        private Button searchButton { get; set; } = new();
        private TableLayoutPanel additionalButtonLayoutPanel { get; set; } = new();
        private SearchConnectionController ConnectionController { get; set; }
        private bool DatePickerFilledOut { get; set; } = false;
        private bool TimePickerFilledOut { get; set; } = false;
        private ConnectionModel SelectedConnection { get; set; } = new();
        public ConnectionsTableView()
        {
            ConnectionController = new SearchConnectionController();

            InitControls();

            dataGridViewConnections.DataSource = ConnectionController.Connections;
        }
        private void InitControls()
        {
            Font searchBoxFont = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);

            // 
            // connectionsTab
            // 
            this.connectionsTab = new TabPage()
            {
                BackColor = Color.White,
                BackgroundImageLayout = ImageLayout.Center,
                Location = new Point(4, 24),
                Margin = new Padding(3, 2, 3, 2),
                Name = "connectionsTab",
                Padding = new Padding(3, 2, 3, 2),
                Size = new Size(692, 310),
                TabIndex = 0,
                Text = "Verbindungen Suchen",
            };


            // 
            // splitContainerConnections
            // 
            this.splitContainerConnections = new SplitContainer()
            {
                Cursor = Cursors.Default,
                Dock = DockStyle.Fill,
                FixedPanel = FixedPanel.Panel1,
                IsSplitterFixed = true,
                Location = new Point(3, 2),
                Margin = new Padding(3, 2, 3, 2),
                Name = "splitContainerConnections",
                Orientation = Orientation.Horizontal,
                Panel1 =
                {
                    BackColor = Color.White
                },
                Size = new Size(686, 306),
                SplitterDistance = 125,
                SplitterWidth = 3,
                TabIndex = 0,
            };

            // 
            // tableLayoutPanelConnections
            // 
            this.tableLayoutPanelConnections = new TableLayoutPanel()
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Top,
                Dock = DockStyle.Fill,
                ColumnCount = 5,
                Location = new Point(0, 0),
                Margin = new Padding(3, 2, 3, 2),
                Name = "tableLayoutPanelConnections",
                RowCount = 3,
                //Size = new Size(681, 85),
                TabIndex = 0,
            };
            // 
            // labelTo
            // 
            this.labelTo = new Label()
            {
                Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right))),
                AutoSize = true,
                Location = new Point(91, 42),
                Name = "labelTo",
                Size = new Size(19, 43),
                TabIndex = 5,
                Text = "To",
                TextAlign = ContentAlignment.MiddleCenter,
            };
            // 
            // textBoxTo
            // 
            this.textBoxTo = new SearchStationComponent(116, 44);
            this.textBoxTo.textBoxSearch.Margin = new Padding(0);
            this.textBoxTo.textBoxSearch.Font = searchBoxFont;
            // 
            // textBoxFrom
            // 
            this.textBoxFrom = new SearchStationComponent(116, 2);
            this.textBoxFrom.textBoxSearch.Margin = new Padding(0);
            this.textBoxFrom.textBoxSearch.Font = searchBoxFont;

            // 
            // labelFrom
            // 
            this.labelFrom = new Label()
            {
                Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right))),
                AutoSize = true,
                Location = new Point(75, 0),
                Name = "labelFrom",
                Size = new Size(35, 42),
                TabIndex = 4,
                Text = "From",
                TextAlign = ContentAlignment.MiddleCenter,
            };

            // 
            // labelDate
            // 
            this.labelDate = new Label()
            {
                Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right))),
                AutoSize = true,
                Location = new Point(427, 0),
                Name = "labelDate",
                Size = new Size(23, 42),
                TabIndex = 1,
                Text = "Date",
                TextAlign = ContentAlignment.MiddleCenter,
            };

            // 
            // labelTime
            // 
            this.labelTime = new Label()
            {
                Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right))),
                AutoSize = true,
                Location = new Point(427, 0),
                Name = "labelTime",
                Size = new Size(23, 42),
                TabIndex = 1,
                Text = "Time",
                TextAlign = ContentAlignment.MiddleCenter,
            };

            //
            // datePicker
            //
            this.datePicker = new DateTimePicker()
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(0, 0),
                MaxDate = DateTime.Today.AddDays(14), // in 2 Weeks
                MinDate = DateTime.Today,
                Value = DateTime.Today,
                Anchor = AnchorStyles.Right | AnchorStyles.Left,
            };

            //
            // timePicker
            //
            this.timePicker = new DateTimePicker()
            {
                Format = DateTimePickerFormat.Time,
                Location = new Point(0, 0),
                ShowUpDown = true,
                MaxDate = new DateTime(2022, 1, 1, 23, 59, 59),
                MinDate = new DateTime(2022, 1, 1, 0, 0, 0),
                Value = new DateTime(2022, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                Anchor = AnchorStyles.Right | AnchorStyles.Left,
            };

            // 
            // additionalButtonLayoutPanel
            // 
            this.additionalButtonLayoutPanel = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                Location = new Point(0, 0),
                Margin = new Padding(3, 2, 3, 2),
                Name = "additionalButtonLayoutPanel",
                RowCount = 1,
            };

            // 
            // searchButton
            // 
            this.searchButton = new Button()
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
            // dataGridViewConnections
            // 
            this.dataGridViewConnections = new DataGridView()
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                CausesValidation = false,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Cursor = Cursors.Default,
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Margin = new Padding(3, 2, 3, 2),
                Name = "dataGridViewConnections",
                ReadOnly = true,
                RowHeadersVisible = false,
                RowHeadersWidth = 51,
                RowTemplate = { Height = 29, },
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Size = new Size(686, 214),
                TabIndex = 0,
            };


            // 
            // dataGridViewColumnFrom
            // 
            this.dataGridViewColumnFrom = new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "FromStation",
                HeaderText = "Von",
                Name = "dataGridViewColumnFrom",
                ReadOnly = true,
                DisplayIndex = 0,
            };

            // 
            // dataGridViewColumnDepartureTime
            // 
            this.dataGridViewColumnDepartureTime = new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "FromStationDepartureTime",
                HeaderText = "Departure",
                Name = "dataGridViewColumnDepartureTime",
                ReadOnly = true,
                DisplayIndex = 1,
            };

            // 
            // dataGridViewColumnTo
            // 
            this.dataGridViewColumnTo = new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "ToStation",
                HeaderText = "To",
                Name = "dataGridViewColumnTo",
                ReadOnly = true,
                DisplayIndex = 2,
            };

            // 
            // dataGridViewColumnArrivalTime
            // 
            this.dataGridViewColumnArrivalTime = new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "ToStationArrivalTime",
                HeaderText = "Arrival",
                Name = "dataGridViewColumnArrivalTime",
                ReadOnly = true,
                DisplayIndex = 3,
            };

            // 
            // dataGridViewColumnDuration
            // 
            this.dataGridViewColumnDuration = new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "Duration",
                HeaderText = "Duration",
                Name = "dataGridViewColumnDuration",
                ReadOnly = true,
                DisplayIndex = 4,
            };

            // 
            // dataGridViewColumnDelay
            // 
            this.dataGridViewColumnDelay = new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "Delay",
                HeaderText = "Delay",
                Name = "dataGridViewColumnDelay",
                ReadOnly = true,
                DisplayIndex = 5,
            };

            // Adding Elements to Containers
            this.connectionsTab.Controls.Add(this.splitContainerConnections);
            this.splitContainerConnections.Panel1.Controls.Add(this.tableLayoutPanelConnections);
            this.splitContainerConnections.Panel2.Controls.Add(this.dataGridViewConnections);

            this.tableLayoutPanelConnections.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            this.tableLayoutPanelConnections.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            this.tableLayoutPanelConnections.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            this.tableLayoutPanelConnections.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            this.tableLayoutPanelConnections.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            this.tableLayoutPanelConnections.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            this.tableLayoutPanelConnections.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            this.tableLayoutPanelConnections.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            this.tableLayoutPanelConnections.Controls.Add(this.labelFrom, 0, 0);
            this.tableLayoutPanelConnections.Controls.Add(this.textBoxFrom.textBoxSearch, 1, 0);
            this.tableLayoutPanelConnections.Controls.Add(this.labelTo, 0, 1);
            this.tableLayoutPanelConnections.Controls.Add(this.textBoxTo.textBoxSearch, 1, 1);
            this.tableLayoutPanelConnections.Controls.Add(this.labelDate, 2, 0);
            this.tableLayoutPanelConnections.Controls.Add(this.labelTime, 2, 1);
            this.tableLayoutPanelConnections.Controls.Add(this.datePicker, 3, 0);
            this.tableLayoutPanelConnections.Controls.Add(this.timePicker, 3, 1);
            this.tableLayoutPanelConnections.Controls.Add(this.searchButton, 4, 2);


            this.dataGridViewConnections.Columns.AddRange(new DataGridViewColumn[] {
                this.dataGridViewColumnFrom,
                this.dataGridViewColumnTo,
                this.dataGridViewColumnDepartureTime,
                this.dataGridViewColumnArrivalTime,
                this.dataGridViewColumnDuration,
                this.dataGridViewColumnDelay,
            });

            this.connectionsTab.Controls.Add(this.textBoxFrom.listBoxSuggestions);
            this.connectionsTab.Controls.Add(this.textBoxTo.listBoxSuggestions);

            // Event Handler
            this.connectionsTab.Paint += new PaintEventHandler(this.ConnectionsTabPaint);
            this.searchButton.Click += new EventHandler(this.SearchButtonClick);
            this.textBoxFrom.textBoxSearch.TextChanged += new EventHandler(this.CheckFieldsCompletion);
            this.textBoxTo.textBoxSearch.TextChanged += new EventHandler(this.CheckFieldsCompletion);
            this.textBoxTo.textBoxSearch.GotFocus += new EventHandler(this.HideAllOtherAutoSuggestions);
            this.textBoxFrom.textBoxSearch.GotFocus += new EventHandler(this.HideAllOtherAutoSuggestions);
            this.datePicker.ValueChanged += new EventHandler(this.DatePickerValueChange);
            this.timePicker.ValueChanged += new EventHandler(this.TimePickerValueChange);
        }

        private void HideAllOtherAutoSuggestions(object? sender, EventArgs e)
        {
            TextBox s = (TextBox)sender;

            List<SearchStationComponent> inputFields = new List<SearchStationComponent>();
            inputFields.Add(textBoxTo);
            inputFields.Add(textBoxFrom);

            foreach (SearchStationComponent field in inputFields)
            {
                if (nameof(field) != nameof(s.Parent))
                {
                    field.listBoxSuggestions.Hide();
                }
            }
        }
        
        private void TimePickerValueChange(object? sender, EventArgs e)
        {
            TimePickerFilledOut = true;
        }

        private void DatePickerValueChange(object? sender, EventArgs e)
        {
            DatePickerFilledOut = true;
        }

        private void CheckFieldsCompletion(object? sender, EventArgs e)
        {
            // Enable Search Button, if from and to filled out
            if (RegexController.IsValidSearchQuery(this.textBoxFrom.textBoxSearch.Text) == true
                && RegexController.IsValidSearchQuery(this.textBoxTo.textBoxSearch.Text) == true)
            {
                this.searchButton.Enabled = true;
            }
            else
            {
                this.searchButton.Enabled = false;
            }
        }

        private void SearchButtonClick(object? sender, EventArgs e)
        {
            try
            {
                if (this.TimePickerFilledOut && this.DatePickerFilledOut && RegexController.IsValidSearchQuery(this.textBoxFrom.SelectedStation.Name) && RegexController.IsValidSearchQuery(this.textBoxTo.SelectedStation.Name))
                {
                    ConnectionController.GetConnections(textBoxFrom.SelectedStation.Name, textBoxTo.SelectedStation.Name, datePicker.Value, timePicker.Value);
                }
                else if (RegexController.IsValidSearchQuery(this.textBoxFrom.SelectedStation.Name) && RegexController.IsValidSearchQuery(this.textBoxTo.SelectedStation.Name))
                {
                    ConnectionController.GetConnections(textBoxFrom.SelectedStation.Name, textBoxTo.SelectedStation.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to get connection. Error occurred: {ex.Message}");
            }
        }

        private void ConnectionsTabPaint(object sender, PaintEventArgs e)
        {
            this.textBoxFrom.textBoxSearch.Focus();
            AdjustColumnOrder();
        }

        private void AdjustColumnOrder()
        {
            dataGridViewConnections.Columns["FromStation"].DisplayIndex = 0;
            dataGridViewConnections.Columns["FromStationDepartureTime"].DisplayIndex = 1;
            dataGridViewConnections.Columns["ToStation"].DisplayIndex = 2;
            dataGridViewConnections.Columns["ToStationArrivalTime"].DisplayIndex = 3;
            dataGridViewConnections.Columns["Duration"].DisplayIndex = 4;
            dataGridViewConnections.Columns["Delay"].DisplayIndex = 5;
        }

    }
}
