namespace Knv.BHS
{
    using System.Windows.Forms;
    using Controls;
    using System;
    using Events;
    using Properties;
    using IO;

    public interface IMainForm
    {
        event EventHandler Shown;
        event FormClosedEventHandler FormClosed;
        event FormClosingEventHandler FormClosing;
        event EventHandler Disposed;

        bool AlwaysOnTop { get; set; }

        string Text { get; set; }
        ToolStripItem[] MenuBar { set; }
        ToolStripItem[] StatusBar { set; }
        KnvTracingControl Tracing { get; }

        bool TracingVisible { get; set; }
    }

    public partial class MainForm : Form , IMainForm
    {
        public ToolStripItem[] MenuBar
        {
            set { menuStrip1.Items.AddRange(value); }
        }

        public KnvTracingControl Tracing
        {
            get
            {
                return knvTracingControl1;
            }
        }

        public bool AlwaysOnTop
        {
            get { return this.TopMost; }
            set { this.TopMost = value; }
        }

        public ToolStripItem[] StatusBar
        {
            set { statusStrip1.Items.AddRange(value); }
        }

        public bool TracingVisible 
        {
            get { return splitContainer1.Panel2Collapsed; }
            set { splitContainer1.Panel2Collapsed = !value; }
        }

        public MainForm()
        {
            InitializeComponent();

            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)(e =>
            {
                if (e.IsOpen)
                {

                }
            }));


            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)(e =>
            {
                splitContainer1.Panel1.Enabled = e.IsOpen;
            }));

            timerSampling.Start();
        }

        private void timerSampling_Tick(object sender, EventArgs e)
        {
            if (Connection.Instance.IsOpen)
            {
                try
                {

                }
                catch (Exception ex)
                {
                    Connection.Instance.TraceError($"Error:{ex.Message}");
                }
            }
        }

        private void LoadSettings()
        { 

            if (Settings.Default.WindowLocation.X > 0 && Settings.Default.WindowLocation.Y > 0)
                this.Location = Settings.Default.WindowLocation;

            if(Settings.Default.WindowSize.Width > 0 && Settings.Default.WindowSize.Height > 0)
                this.Size = Settings.Default.WindowSize;
        }

        private void SaveSettings()
        {
            Settings.Default.WindowLocation = this.Location;
            Settings.Default.WindowSize = this.Size;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void buttonColckUpdate_Click(object sender, EventArgs e)
        {
            Connection.Instance.SetClock(DateTime.Now);
        }

        private void buttonCurrentDateTime_Click(object sender, EventArgs e)
        {
            Connection.Instance.GetClock();
        }

        private void buttonIrSendCode_Click(object sender, EventArgs e)
        {
            int.TryParse(textBoxIrCode.Text, out int code);
            Connection.Instance.IrSendCode(code);
        }

        private void textBoxIrCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonOnOff_Click(object sender, EventArgs e)
        {
            Connection.Instance.IrSendCode(0x4D);
        }

        private void buttonMute_Click(object sender, EventArgs e)
        {
            Connection.Instance.IrSendCode(0x16);
        }

        private void buttonRoute_Click(object sender, EventArgs e)
        {
            Connection.Instance.IrSendCode(0x54);
        }
    }
}
