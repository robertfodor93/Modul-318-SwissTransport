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
    internal class ConnectionsView
    {
        public TabPage ConnectionsTab { get; set; } = new();
        private SplitContainer SplitContainerConnections { get; set; } = new();
        private TableLayoutPanel TableLayoutPanelSearchElement { get; set; } = new();
        private Label LabelTo { get; set; } = new();
        private SearchUserControl SearchTo { get; set; } = new(0, 0);
        private Label LabelFrom { get; set; } = new();
        private SearchUserControl SearchFrom { get; set; } = new(0, 0);
        private ConnectionsModel SelectedConnection { get; set; } = new();
        private Label LabelDate { get; set; } = new();
        private DateTimePicker DatePicker { get; set; } = new();
        private bool DatePickerFilledOut { get; set; } = false;
        private bool TimePickerFilledOut { get; set; } = false;
        private Label LabelTime { get; set; } = new();
        private DateTimePicker TimePicker { get; set; } = new();
        private Button ButtonSearchConnections { get; set; } = new();
        private DataGridView DataGridViewConnections { get; set; } = new();
        private DataGridViewTextBoxColumn DataGridViewColumnFrom { get; set; } = new();
        private DataGridViewTextBoxColumn DataGridViewColumnDepartureTime { get; set; } = new();
        private DataGridViewTextBoxColumn DataGridViewColumnTo { get; set; } = new();
        private DataGridViewTextBoxColumn DataGridViewColumnArrivalTime { get; set; } = new();
        private DataGridViewTextBoxColumn DataGridViewColumnDuration { get; set; } = new();
        private DataGridViewTextBoxColumn DataGridViewColumnDelay { get; set; } = new();
        private SearchConnectionController ConnectionController { get; set; }
        
        public ConnectionsView()
        {
            ConnectionController = new SearchConnectionController();

            InitControls();

            DataGridViewConnections.DataSource = ConnectionController.Connections;
        }
        private void InitControls()
        {
            Font searchBoxFont = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
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
            // Connections split container
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
            // Table for the search bar
            this.TableLayoutPanelSearchElement = new TableLayoutPanel()
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Top,
                Dock = DockStyle.Fill,
                ColumnCount = 5,
                Location = new Point(0, 0),
                Margin = new Padding(3, 2, 3, 2),
                Name = "tableLayoutPanelSearchElement",
                RowCount = 3,
                TabIndex = 0,
            };
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
            this.SearchTo = new SearchUserControl(436, 0);
            this.SearchTo.TextBoxSearch.Margin = new Padding(0);
            this.SearchTo.TextBoxSearch.Font = searchBoxFont;
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
            this.SearchFrom = new SearchUserControl(88, 0);
            this.SearchFrom.TextBoxSearch.Margin = new Padding(0);
            this.SearchFrom.TextBoxSearch.Font = searchBoxFont;
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
            this.DatePicker = new DateTimePicker()
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(116, 44),
                MaxDate = DateTime.Today.AddDays(14), // in 2 Weeks
                MinDate = DateTime.Today,
                Value = DateTime.Today,
                Anchor = AnchorStyles.Right | AnchorStyles.Left,
            };
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
            this.ButtonSearchConnections = new Button()
            {
                Cursor = Cursors.Hand,
                Dock = DockStyle.Fill,
                Enabled = false,
                Location = new Point(25, 25),
                Name = "buttonSearchConnections",
                Size = new Size(152, 38),
                TabIndex = 0,
                Text = "Suchen",
                UseVisualStyleBackColor = false,
                ForeColor = Color.Blue
            };
            // Data table for connections
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
            this.DataGridViewColumnFrom = new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "FromStation",
                HeaderText = "Von",
                Name = "dataGridViewColumnFrom",
                ReadOnly = true,
                DisplayIndex = 0,
            };
            this.DataGridViewColumnDepartureTime = new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "FromStationDepartureTime",
                HeaderText = "Abreise",
                Name = "dataGridViewColumnDepartureTime",
                ReadOnly = true,
                DisplayIndex = 1,
            };
            this.DataGridViewColumnTo = new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "ToStation",
                HeaderText = "Nach",
                Name = "dataGridViewColumnTo",
                ReadOnly = true,
                DisplayIndex = 2,
            };
            this.DataGridViewColumnArrivalTime = new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "ToStationArrivalTime",
                HeaderText = "Ankunft",
                Name = "dataGridViewColumnArrivalTime",
                ReadOnly = true,
                DisplayIndex = 3,
            };
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
            this.SplitContainerConnections.Panel1.Controls.Add(this.TableLayoutPanelSearchElement);
            this.TableLayoutPanelSearchElement.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            this.TableLayoutPanelSearchElement.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            this.TableLayoutPanelSearchElement.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            this.TableLayoutPanelSearchElement.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            this.TableLayoutPanelSearchElement.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            this.TableLayoutPanelSearchElement.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            this.TableLayoutPanelSearchElement.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            this.TableLayoutPanelSearchElement.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            this.TableLayoutPanelSearchElement.Controls.Add(this.LabelFrom, 0, 0);
            this.TableLayoutPanelSearchElement.Controls.Add(this.SearchFrom.TextBoxSearch, 1, 0);
            this.TableLayoutPanelSearchElement.Controls.Add(this.LabelTo, 2, 0);
            this.TableLayoutPanelSearchElement.Controls.Add(this.SearchTo.TextBoxSearch, 3, 0);
            this.TableLayoutPanelSearchElement.Controls.Add(this.LabelDate, 0, 1);
            this.TableLayoutPanelSearchElement.Controls.Add(this.DatePicker, 1, 1);
            this.TableLayoutPanelSearchElement.Controls.Add(this.LabelTime, 2, 1);
            this.TableLayoutPanelSearchElement.Controls.Add(this.TimePicker, 3, 1);
            this.TableLayoutPanelSearchElement.Controls.Add(this.ButtonSearchConnections, 4, 0);
            this.SplitContainerConnections.Panel2.Controls.Add(this.DataGridViewConnections);
            this.DataGridViewConnections.Columns.AddRange(new DataGridViewColumn[] {
                this.DataGridViewColumnFrom,
                this.DataGridViewColumnTo,
                this.DataGridViewColumnDepartureTime,
                this.DataGridViewColumnArrivalTime,
                this.DataGridViewColumnDuration,
                this.DataGridViewColumnDelay,
            });
            this.ConnectionsTab.Controls.Add(this.SearchFrom.ListBoxSuggestions);
            this.ConnectionsTab.Controls.Add(this.SearchTo.ListBoxSuggestions);
            // Event handlers
            this.ButtonSearchConnections.Click += new EventHandler(this.ButtonSearchConnectionsClick);
            this.SearchFrom.TextBoxSearch.TextChanged += new EventHandler(this.CheckFieldsCompletion);
            this.SearchTo.TextBoxSearch.TextChanged += new EventHandler(this.CheckFieldsCompletion);
            this.SearchTo.TextBoxSearch.GotFocus += new EventHandler(this.HideAllOtherAutoSuggestions);
            this.SearchFrom.TextBoxSearch.GotFocus += new EventHandler(this.HideAllOtherAutoSuggestions);
            this.DatePicker.ValueChanged += new EventHandler(this.DatePickerValueChange);
            this.TimePicker.ValueChanged += new EventHandler(this.TimePickerValueChange);
        }
        //Event logic
        private void HideAllOtherAutoSuggestions(object? sender, EventArgs e)
        {
            TextBox? s = sender as TextBox;

            List<SearchUserControl> inputFields = new List<SearchUserControl>();
            inputFields.Add(SearchTo);
            inputFields.Add(SearchFrom);

            foreach (SearchUserControl field in inputFields)
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
            if (RegexController.IsValidSearchQuery(this.SearchFrom.TextBoxSearch.Text) == true
                && RegexController.IsValidSearchQuery(this.SearchTo.TextBoxSearch.Text) == true)
            {
                this.ButtonSearchConnections.Enabled = true;
            }
            else
            {
                this.ButtonSearchConnections.Enabled = false;
            }
        }
        private void ButtonSearchConnectionsClick(object? sender, EventArgs e)
        {
            try
            {
                if (this.TimePickerFilledOut && this.DatePickerFilledOut && RegexController.IsValidSearchQuery(this.SearchFrom.SelectedStation.Name) && RegexController.IsValidSearchQuery(this.SearchTo.SelectedStation.Name))
                {
                    ConnectionController.GetConnections(SearchFrom.SelectedStation.Name, SearchTo.SelectedStation.Name, DatePicker.Value, TimePicker.Value);
                }
                else if (RegexController.IsValidSearchQuery(this.SearchFrom.SelectedStation.Name) && RegexController.IsValidSearchQuery(this.SearchTo.SelectedStation.Name))
                {
                    ConnectionController.GetConnections(SearchFrom.SelectedStation.Name, SearchTo.SelectedStation.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to get connection. Error occurred: {ex.Message}");
            }
        }
    }
}
