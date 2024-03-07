
namespace Knv.BHS.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    internal interface ITracingControl : IDisposable
    {
        int LineCounter { get; }
        void AppendText(string line);
        void Clear();
    }

    public  partial class KnvTracingControl : UserControl, ITracingControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int LineCounter { get; private set; }
  

        /// <summary>
        /// Konstructor
        /// </summary>
        public KnvTracingControl()
        {
            InitializeComponent();
        }

        public void AppendText(string line)
        {
            if (line.Contains("Rx:"))
                richTextBox1.AppendText(line + "\r\n", Color.DarkGreen, false);
            else if (line.Contains("Tx:"))
                richTextBox1.AppendText(line + "\r\n", Color.Blue);
            else if (line.ToUpper().Contains("ERROR"))
                richTextBox1.AppendText(line + "\r\n", Color.Red);
            else
                richTextBox1.AppendText(line + "\r\n", Color.Black);

            LineCounter++;

            if (Properties.Settings.Default.TraceViewAutoScroll)
            {
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
            }
        }


        /// <summary>
        /// Törlés
        /// </summary>
        public void Clear()
        {
            LineCounter = 0;
            labelLines.Text = @"Lines:na";
            richTextBox1.Text = string.Empty;
        }


        private void buttonToolStripClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonToolStripAutoScroll_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.TraceViewAutoScroll = !Properties.Settings.Default.TraceViewAutoScroll;
        }
    }
}
