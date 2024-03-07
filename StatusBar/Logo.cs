namespace Knv.BHS.StatusBar
{
    using System.Windows.Forms;

    class Logo : ToolStripStatusLabel
    {
        public Logo()
        {
            BackColor = System.Drawing.Color.Orange;
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ForeColor = System.Drawing.SystemColors.HotTrack;
            Size = new System.Drawing.Size(103, 19);
            Text = "KONVOLUCIÓ BT";
        }
    }
}
