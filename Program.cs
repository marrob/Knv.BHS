namespace Knv.BHS
{
    using System;
    using System.Collections.Generic;
    using System.IO.Ports;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Events;
    using IO;
    using Knv.BHS.Properties;

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new App();
        }
        class App
        {
            readonly IMainForm _mainForm;
            Timer _timer;

            public App()
            {

                _mainForm = new MainForm();
                _mainForm.Text = AppConstants.SoftwareTitle;
                _mainForm.Shown += MainForm_Shown;
                _mainForm.FormClosed += MainForm_FormClosed;

                Connection.Instance.TracingEnable = true;

                _mainForm.TracingVisible = true;

                _timer = new Timer();
                _timer.Interval = 250;
                _timer.Start();

                Connection.Instance.ConnectionChanged += (o, e) =>
                {
                    EventAggregator.Instance.Publish(new ConnectionChangedAppEvent(Connection.Instance.IsOpen));
                };

                /*** Tracing Update ***/
                _timer.Tick += (o, e) =>
                {
                    for (int i = 0; Connection.Instance.TraceQueue.Count != 0; i++)
                    {
                        string str = Connection.Instance.TraceQueue.Dequeue();
                        _mainForm.Tracing?.AppendText(str);
                    }
                };


                /*** Main Menu ***/
                #region Main Menu
                _mainForm.MenuBar = new ToolStripItem[]
                {
                    new Commands.ComPortSelectCommand(),
                    new Commands.ConnectCommand(),
                    new Commands.AlwaysOnTopCommand(_mainForm),
                    new Commands.TraceingEnableCommand(_mainForm),
                    new Commands.SettingsCommand(_mainForm),
                    new Commands.HowIsWorkingCommand(),
                };
                #endregion

                /*** StatusBar ***/
                #region StatusBar
                _mainForm.StatusBar = new ToolStripItem[]
                {
                    new StatusBar.WhoIs(),
                    new StatusBar.FwVersion(),
                    new StatusBar.CurrentDateTime(),
                    new StatusBar.UpTime(),
                    new StatusBar.EmptyStatus(),
                    new StatusBar.Version(),
                    new StatusBar.Logo(),
                };
                #endregion 
                
                /*** Run ***/
                Application.Run((MainForm)_mainForm);
            }

            private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
            {
                Settings.Default.Save();
            }

            private void MainForm_Shown(object sender, EventArgs e)
            {
                EventAggregator.Instance.Publish(new ShowAppEvent());

                /*** Auto connect ***/
                if (Settings.Default.SeriaPortName != null)
                {
                    if (SerialPort.GetPortNames().Contains(Settings.Default.SeriaPortName))
                    {
                        Connection.Instance.Open(Settings.Default.SeriaPortName);
                    }
                }
            }
        }
    }
}
