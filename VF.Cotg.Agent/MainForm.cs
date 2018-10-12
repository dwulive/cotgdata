using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using log4net;

using VF.Cotg.WebServer;

namespace VF.Cotg.Agent
{

    /// <summary>
    /// The MainForm
    /// </summary>
    public partial class MainForm : Form
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(MainForm));

        /// <summary>
        /// The WebServer
        /// </summary>
        WebServer.WebServer _webServer;

        /// <summary>
        /// The Import Service
        /// </summary>
        Services.IImportService _importService;

        /// <summary>
        /// Initialize MainForm
        /// </summary>
        public MainForm()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Intiailizing MainForm", caught);
                throw;
            }
        }

        /// <summary>
        /// Initialize MainForm
        /// </summary>
        /// <param name="webServer">The WebServer</param>
        public MainForm(WebServer.WebServer webServer, Services.IImportService importService) : this()
        {
            try
            {
                _webServer = webServer;
                _importService = importService;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initailizing MainForm", caught);
                throw;
            }
        }

        #region [Form Event Handlers]
        
        /// <summary>
        /// Handle Start WebServer MenuItem Click
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleStartWebServerMenuItemClick(object sender, EventArgs e)
        {
            StartWebServer();
        }

        /// <summary>
        /// Handle Stop WebServer MenuItem CLick
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleStopWebServerMenuItemClick(object sender, EventArgs e)
        {
            StopWebServer();
        }

        #endregion

        #region [Helpers]

        /// <summary>
        /// Check the WebServer RunState, and Update Form Controls Accordingly
        /// </summary>
        private void UpdateFormState_WebServerRunning()
        {
            try
            {
                if (_webServer == null || !_webServer.Running)
                {
                    StartWebServerMenuItem.Enabled = true;
                    StopWebServerMenuItem.Enabled = false;
                    WebServerStatusLabel.Text = "WebServer is NOT Running";
                }
                else
                {
                    StartWebServerMenuItem.Enabled = false;
                    StopWebServerMenuItem.Enabled = true;
                    WebServerStatusLabel.Text = "WebServer is Running";
                }
            }
            catch (Exception caught)
            {
                logger.Error("An Unexpected Error has Occurred Checking WebServer RunState", caught);
            }
        }

        /// <summary>
        /// Start the WebServer
        /// </summary>
        private void StartWebServer()
        {
            try
            {
                _webServer.Start();
                UpdateFormState_WebServerRunning();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Starting WebServer", caught);
                MessageBox.Show("An Unexpected Error has occurred while attempting to start the webserver." +
                    " Review Logs for more information ",
                    "Crown of the Gods - WebServer Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Stop the WebServer
        /// </summary>
        private void StopWebServer()
        {
            try
            {
                _webServer.Stop();
                UpdateFormState_WebServerRunning();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Stopping WebServer", caught);
                MessageBox.Show("An Unexpected Error has occurred while attempting to stop the webserver." +
                    " Review Logs for more information ",
                    "Crown of the Gods - WebServer Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        #endregion

        /// <summary>
        /// TEST METHOD - DELTE ME
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleImportSingleRecordClick(object sender, EventArgs e)
        {
            var effectiveDate = EffectiveDatePicker.Value.ToUniversalTime();
            var playerName = PlayerNameTextbox.Text;
            var score = long.Parse(ScoreTextBox.Text);
            var rank = int.Parse(RankTextBox.Text);
            _importService.TestImportSingleUnitKillsHistory(effectiveDate, playerName, score, rank);
        }

        /// <summary>
        /// TEST METHOD - DELETE ME
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleRefreshRankingsClick(object sender, EventArgs e)
        {
            RankingsListView.Items.Clear();
            var rankings = _importService.GetUnitKillsHistory(EffectiveDatePicker.Value.ToUniversalTime());
            foreach (var ranking in rankings)
            {
                var lvi = new ListViewItem(new string[] { ranking.EffectiveDate.ToShortDateString() + " " + ranking.EffectiveDate.ToLongTimeString(),
                    ranking.PlayerName, Convert.ToString(ranking.Score), Convert.ToString(ranking.Rank) });
                RankingsListView.Items.Add(lvi);
            }
        }
    }
}
