

namespace Knv.BHS.View
{
    using System;
    using System.Windows.Forms;
    using Properties;

    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            checkBoxUpTimeCounterPolling.Checked = Settings.Default.UpTimeCounterPolling;
            checkBoxUpTimeCounterPolling.CheckedChanged += (o, ey) => Settings.Default.UpTimeCounterPolling = checkBoxUpTimeCounterPolling.Checked;

            checkBoxReadDateTime.Checked = Settings.Default.ReadDateTimeAfterConnected;
            checkBoxReadDateTime.CheckedChanged += (o, ey) => Settings.Default.ReadDateTimeAfterConnected = checkBoxReadDateTime.Checked;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.OK;
        }
    }
}
