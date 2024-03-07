
namespace Knv.BHS.Commands
{
    using Properties;
    using System;
    using System.Windows.Forms;
    using View;

    class SettingsCommand : ToolStripMenuItem
    {
        readonly IMainForm _mainForm;
        public SettingsCommand(IMainForm mainForm)
        {
            Image = Resources.Settings_outline_48;
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            Text = "Settings";
            _mainForm = mainForm;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if(_mainForm.AlwaysOnTop) 
                _mainForm.AlwaysOnTop = false;

            var hiw = new SettingsForm();
            
            hiw.ShowDialog();
        }
    }
}
