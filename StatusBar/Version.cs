

namespace Knv.BHS.StatusBar
{
    using System.Windows.Forms;

    class Version : ToolStripStatusLabel
    {
        public Version()
        {
            BorderSides = ToolStripStatusLabelBorderSides.Left;
            BorderStyle = Border3DStyle.Etched;
            Size = new System.Drawing.Size(58, 19);
            Text = Application.ProductVersion;
        }
    }
}
