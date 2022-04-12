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
        public TabPage ConnectionsTab { get; set; } = new();
        private SplitContainer SplitContainerConnections { get; set; } = new();
        private TableLayoutPanel TableLayoutPanelConnections { get; set; } = new();
        private Label LabelTo { get; set; } = new();
        private SearchStationComponent TextBoxTo { get; set; } = new(0, 0);
        private Label LabelFrom { get; set; } = new();
        private SearchStationComponent TextBoxFrom { get; set; } = new(0, 0);
        private DataGridView DataGridViewConnections { get; set; } = new();
        private DataGridViewTextBoxColumn DataGridViewColumnFrom { get; set; } = new();
        private DataGridViewTextBoxColumn DataGridViewColumnDepartureTime { get; set; } = new();
        private DataGridViewTextBoxColumn DataGridViewColumnTo { get; set; } = new();
        private DataGridViewTextBoxColumn DataGridViewColumnArrivalTime { get; set; } = new();
        private DataGridViewTextBoxColumn DataGridViewColumnDuration { get; set; } = new();
        private DataGridViewTextBoxColumn DataGridViewColumnDelay { get; set; } = new();
        private Label LabelDate { get; set; } = new();
        private DateTimePicker DatePicker { get; set; } = new();
        private Label LabelTime { get; set; } = new();
        private DateTimePicker TimePicker { get; set; } = new();
        private Button SearchButton { get; set; } = new();
        private SearchConnectionController ConnectionController { get; set; }
        private bool DatePickerFilledOut { get; set; } = false;
        private bool TimePickerFilledOut { get; set; } = false;
        private ConnectionModel SelectedConnection { get; set; } = new();
        
        public ConnectionsTableView()
        {
            ConnectionController = new SearchConnectionController();

            InitControls();

            DataGridViewConnections.DataSource = ConnectionController.Connections;
        }
        //
        //Initializing controls
        //
        private void InitControls()
        {
            Font searchBoxFont = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            // 
            // connectionsTab
            // 
            this.ConnectionsTab = new TabPage()
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
            this.SplitContainerConnections = new SplitContainer()
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
            this.TableLayoutPanelConnections = new TableLayoutPanel()
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
            this.LabelTo = new Label()
            {
                Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right))),
                AutoSize = true,
                Location = new Point(427, 0),
                Name = "labelTo",
                Size = new Size(19, 43),
                TabIndex = 5,
                Text = "Nach:",
                TextAlign = ContentAlignment.MiddleCenter,
            };
            // 
            // textBoxTo
            // 
            this.TextBoxTo = new SearchStationComponent(427, 0);
            this.TextBoxTo.TextBoxSearch.Margin = new Padding(0);
            this.TextBoxTo.TextBoxSearch.Font = searchBoxFont;
            // 
            // textBoxFrom
            // 
            this.TextBoxFrom = new SearchStationComponent(116, 2);
            this.TextBoxFrom.TextBoxSearch.Margin = new Padding(0);
            this.TextBoxFrom.TextBoxSearch.Font = searchBoxFont;
            // 
            // labelFrom
            // 
            this.LabelFrom = new Label()
            {
                Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right))),
                AutoSize = true,
                Location = new Point(75, 0),
                Name = "labelFrom",
                Size = new Size(35, 42),
                TabIndex = 4,
                Text = "Von:",
                TextAlign = ContentAlignment.MiddleCenter,
            };
            // 
            // labelDate
            // 
            this.LabelDate = new Label()
            {
                Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right))),
                AutoSize = true,
                Location = new Point(91, 42),
                Name = "labelDate",
                Size = new Size(23, 42),
                TabIndex = 1,
                Text = "Datum:",
                TextAlign = ContentAlignment.MiddleCenter,
            };
            // 
            // labelTime
            // 
            this.LabelTime = new Label()
            {
                Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right))),
                AutoSize = true,
                Location = new Point(427, 0),
                Name = "labelTime",
                Size = new Size(23, 42),
                TabIndex = 1,
                Text = "Uhrzeit:",
                TextAlign = ContentAlignment.MiddleCenter,
            };
            //
            // datePicker
            //
            this.DatePicker = new DateTimePicker()
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(116, 44),
                MaxDate = DateTime.Today.AddDays(14), // in 2 Weeks
                MinDate = DateTime.Today,
                Value = DateTime.Today,
                Anchor = AnchorStyles.Right | AnchorStyles.Left,
            };
            //
            // timePicker
            //
            this.TimePicker = new DateTimePicker()
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
            // searchButton
            // 
            this.SearchButton = new Button()
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
            this.DataGridViewConnections = new DataGridView()
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
            this.DataGridViewColumnFrom = new DataGridViewTextBoxColumn()
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
            this.DataGridViewColumnDepartureTime = new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "FromStationDepartureTime",
                HeaderText = "Abreise",
                Name = "dataGridViewColumnDepartureTime",
                ReadOnly = true,
                DisplayIndex = 1,
            };
            // 
            // dataGridViewColumnTo
            // 
            this.DataGridViewColumnTo = new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "ToStation",
                HeaderText = "Nach",
                Name = "dataGridViewColumnTo",
                ReadOnly = true,
                DisplayIndex = 2,
            };
            // 
            // dataGridViewColumnArrivalTime
            // 
            this.DataGridViewColumnArrivalTime = new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "ToStationArrivalTime",
                HeaderText = "Ankunft",
                Name = "dataGridViewColumnArrivalTime",
                ReadOnly = true,
                DisplayIndex = 3,
            };
            // 
            // dataGridViewColumnDuration
            // 
            this.DataGridViewColumnDuration = new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "Duration",
                HeaderText = "Dauer",
                Name = "dataGridViewColumnDuration",
                ReadOnly = true,
                DisplayIndex = 4,
            };
            // 
            // dataGridViewColumnDelay
            // 
            this.DataGridViewColumnDelay = new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "Delay",
                HeaderText = "Verspätung",
                Name = "dataGridViewColumnDelay",
                ReadOnly = true,
                DisplayIndex = 5,
            };
            //
            // Nesting controls in containers
            //
            this.ConnectionsTab.Controls.Add(this.SplitContainerConnections);
            this.SplitContainerConnections.Panel1.Controls.Add(this.TableLayoutPanelConnections);
            this.SplitContainerConnections.Panel2.Controls.Add(this.DataGridViewConnections);
            this.TableLayoutPanelConnections.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            this.TableLayoutPanelConnections.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            this.TableLayoutPanelConnections.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            this.TableLayoutPanelConnections.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            this.TableLayoutPanelConnections.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            this.TableLayoutPanelConnections.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            this.TableLayoutPanelConnections.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            this.TableLayoutPanelConnections.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            this.TableLayoutPanelConnections.Controls.Add(this.LabelFrom, 0, 0);
            this.TableLayoutPanelConnections.Controls.Add(this.TextBoxFrom.TextBoxSearch, 1, 0);
            this.TableLayoutPanelConnections.Controls.Add(this.LabelTo, 2, 0);
            this.TableLayoutPanelConnections.Controls.Add(this.TextBoxTo.TextBoxSearch, 3, 0);
            this.TableLayoutPanelConnections.Controls.Add(this.LabelDate, 0, 1);
            this.TableLayoutPanelConnections.Controls.Add(this.DatePicker, 1, 1);
            this.TableLayoutPanelConnections.Controls.Add(this.LabelTime, 2, 1);
            this.TableLayoutPanelConnections.Controls.Add(this.TimePicker, 3, 1);
            this.TableLayoutPanelConnections.Controls.Add(this.SearchButton, 4, 0);
            this.DataGridViewConnections.Columns.AddRange(new DataGridViewColumn[] {
                this.DataGridViewColumnFrom,
                this.DataGridViewColumnTo,
                this.DataGridViewColumnDepartureTime,
                this.DataGridViewColumnArrivalTime,
                this.DataGridViewColumnDuration,
                this.DataGridViewColumnDelay,
            });
            this.ConnectionsTab.Controls.Add(this.TextBoxFrom.ListBoxSuggestions);
            this.ConnectionsTab.Controls.Add(this.TextBoxTo.ListBoxSuggestions);

            // Event Handlers
            this.SearchButton.Click += new EventHandler(this.SearchButtonClick);
            this.TextBoxFrom.TextBoxSearch.TextChanged += new EventHandler(this.CheckFieldsCompletion);
            this.TextBoxTo.TextBoxSearch.TextChanged += new EventHandler(this.CheckFieldsCompletion);
            this.TextBoxTo.TextBoxSearch.GotFocus += new EventHandler(this.HideAllOtherAutoSuggestions);
            this.TextBoxFrom.TextBoxSearch.GotFocus += new EventHandler(this.HideAllOtherAutoSuggestions);
            this.DatePicker.ValueChanged += new EventHandler(this.DatePickerValueChange);
            this.TimePicker.ValueChanged += new EventHandler(this.TimePickerValueChange);
        }

        private void HideAllOtherAutoSuggestions(object? sender, EventArgs e)
        {
            TextBox s = (TextBox)sender;

            List<SearchStationComponent> inputFields = new List<SearchStationComponent>();
            inputFields.Add(TextBoxTo);
            inputFields.Add(TextBoxFrom);

            foreach (SearchStationComponent field in inputFields)
            {
                if (nameof(field) != nameof(s.Parent))
                {
                    field.ListBoxSuggestions.Hide();
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
            if (RegexController.IsValidSearchQuery(this.TextBoxFrom.TextBoxSearch.Text) == true
                && RegexController.IsValidSearchQuery(this.TextBoxTo.TextBoxSearch.Text) == true)
            {
                this.SearchButton.Enabled = true;
            }
            else
            {
                this.SearchButton.Enabled = false;
            }
        }

        private void SearchButtonClick(object? sender, EventArgs e)
        {
            try
            {
                if (this.TimePickerFilledOut && this.DatePickerFilledOut && RegexController.IsValidSearchQuery(this.TextBoxFrom.SelectedStation.Name) && RegexController.IsValidSearchQuery(this.TextBoxTo.SelectedStation.Name))
                {
                    ConnectionController.GetConnections(TextBoxFrom.SelectedStation.Name, TextBoxTo.SelectedStation.Name, DatePicker.Value, TimePicker.Value);
                }
                else if (RegexController.IsValidSearchQuery(this.TextBoxFrom.SelectedStation.Name) && RegexController.IsValidSearchQuery(this.TextBoxTo.SelectedStation.Name))
                {
                    ConnectionController.GetConnections(TextBoxFrom.SelectedStation.Name, TextBoxTo.SelectedStation.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to get connection. Error occurred: {ex.Message}");
            }
        }
    }
}
