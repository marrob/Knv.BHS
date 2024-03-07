
namespace Knv.BHS.Commands
{
    using System;
    using System.Windows.Forms;
    using Properties;
    using Events;
    using System.Drawing;
    using IO;

    class ConnectCommand : ToolStripMenuItem
    {
        public ConnectCommand(/*App app*/)
        {
            Text = "Connect";
            //Image = Resources.Play_Hot48;
            ShortcutKeys = Keys.F7;
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            Enabled = true;
            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)(e =>
            {
                if (e.IsOpen)
                {
                    Text = "Disconnect";
                    BackColor = Color.Orange;
                    Image = Resources.Network_Connected_32;
                }
                else
                {
                    Text = "Connect";
                    BackColor = SystemColors.Control;
                    Image = Resources.Network_Disconnected_32;
                }
            }));
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if(Connection.Instance.IsOpen)
                 Connection.Instance.Close();
            else
                Connection.Instance.Open(Settings.Default.SeriaPortName);
               
        }
    }
}
