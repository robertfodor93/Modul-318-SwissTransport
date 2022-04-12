using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwissTransportGUI.Controllers;

namespace SwissTransportGUI.Views
{
    public partial class SwissTransport : Form
    {
        private ConnectionsTableView ConnectionsTableView { get; set; }
        private StationTableView StationTableView { get; set; }
        public SwissTransport()
        {
            InitializeComponent();

            ConnectionsTableView = new ConnectionsTableView();
            StationTableView = new StationTableView();

            tabControlNavigation.TabPages.AddRange(new TabPage[] {
            ConnectionsTableView.ConnectionsTab,
            StationTableView.StationBoardTab
        });

            //AllocConsole();
        }

        private void CheckInternetconnection()
        {
            if (!RegexController.IsConnectedToInternet())
            {
                DialogResult r = MessageBox.Show("You appear to be disconnected from the wonders of the web. This application is in need of such a connection to function correctly.", "No active internet connection", MessageBoxButtons.RetryCancel);
                if (r == DialogResult.Cancel)
                {
                    Close();
                }
                else if (r == DialogResult.Retry)
                {
                    MainWindow_Load(new object(), new EventArgs());
                }
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            CheckInternetconnection();
        }
    }
}
