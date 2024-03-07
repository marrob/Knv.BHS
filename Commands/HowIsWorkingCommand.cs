
namespace Knv.BHS.Commands
{
    using System;
    using System.Windows.Forms;
    using View;

    class HowIsWorkingCommand : ToolStripMenuItem
    {
        public HowIsWorkingCommand()
        {
           // Image = Resources.dictionary48;
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            Text = "How is Working?";
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            var hiw = new HowIsWorkingForm();
            hiw.ShowDialog();
        }
    }
}
