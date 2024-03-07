namespace Knv.BHS.StatusBar
{
    using System;
    using System.Windows.Forms;
    using Knv.BHS.IO;
    using Knv.BHS.Properties;

    class UpTime : ToolStripStatusLabel
    { 
        public UpTime()
        {
            BorderSides = ToolStripStatusLabelBorderSides.Left;
            BorderStyle = Border3DStyle.Etched;
            Size = new System.Drawing.Size(58, 19);
            Text = "UpTime Counter: " + AppConstants.ValueNotAvailable2;
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Start();

            timer.Tick += (s, e) =>
            {
                if (Settings.Default.UpTimeCounterPolling)
                {
                    if (Connection.Instance.IsOpen)
                    {
                        try
                        {

                            Text = "UpTime Counter: " + Connection.Instance.GetUpTime();
                        }
                        catch (Exception ex)
                        {
                            Connection.Instance.TraceError($"Error:{ex.Message}");
                        }

                    }
                }
            };
        }
    }
}
