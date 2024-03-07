
namespace Knv.BHS.Commands
{
    using Properties;
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Events;

    class AlwaysOnTopCommand : ToolStripMenuItem
    {
        readonly IMainForm _mainForm;

        public AlwaysOnTopCommand(IMainForm mainForm)
        {
            _mainForm = mainForm;
            Image = Resources.Top_Arrow_32;
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            Text = "Always On Top";
            _mainForm.AlwaysOnTop = Settings.Default.AlwaysOnTop;
            Checked = Settings.Default.AlwaysOnTop;


            EventAggregator.Instance.Subscribe((Action<ShowAppEvent>)(e =>
            {
                if (Checked)
                {
                    BackColor = Color.Orange;
                    _mainForm.AlwaysOnTop = true;
                }
                else
                {
                    BackColor = SystemColors.Control;
                    _mainForm.AlwaysOnTop = false;
                }
            }));
        }

        protected override void OnClick(EventArgs e)
        {    
            base.OnClick(e);
            _mainForm.AlwaysOnTop = !_mainForm.AlwaysOnTop; 
            Settings.Default.AlwaysOnTop = _mainForm.AlwaysOnTop;
            Checked = _mainForm.AlwaysOnTop;

            if (Checked)
            {
                BackColor = Color.Orange;
            }
            else
            {
                BackColor = SystemColors.Control;
            }
        }
    }
}
