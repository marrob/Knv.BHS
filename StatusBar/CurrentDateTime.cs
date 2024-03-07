namespace Knv.BHS.StatusBar
{
    using System;
    using System.Windows.Forms;
    using Properties;
    using Events;
    using IO;

    class CurrentDateTime : ToolStripStatusLabel
    { 
        public CurrentDateTime()
        {
            BorderSides = ToolStripStatusLabelBorderSides.Left;
            BorderStyle = Border3DStyle.Etched;
            Size = new System.Drawing.Size(58, 19);
            Text = AppConstants.ValueNotAvailable2;
            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)(e =>
            { 
                if(Settings.Default.ReadDateTimeAfterConnected)
                if (e.IsOpen)
                {
                   var dt = Connection.Instance.GetClock();
                  Text = dt.ToShortDateString() + " " + dt.ToShortTimeString();
                }
                else
                {
                    Text = AppConstants.ValueNotAvailable2;
                }
            }));
        }
    }
}
