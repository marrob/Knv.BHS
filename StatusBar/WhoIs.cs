namespace Knv.BHS.StatusBar
{
    using System;
    using System.Windows.Forms;
    using Properties;
    using Events;
    using IO;
    class WhoIs : ToolStripStatusLabel
    { 
        public WhoIs()
        {
            BorderSides = ToolStripStatusLabelBorderSides.Left;
            BorderStyle = Border3DStyle.Etched;
            Size = new System.Drawing.Size(58, 19);
            Text =  AppConstants.ValueNotAvailable2;

            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)(e =>
            {
                if (e.IsOpen)
                    Text = Connection.Instance.WhoIs();

            }));
        }
    }
}
