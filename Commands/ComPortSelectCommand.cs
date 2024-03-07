
namespace Knv.BHS.Commands
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using Properties;
    using Events;
    using System.IO.Ports;

    class ComPortSelectCommand : ToolStripComboBox
    {
        public ComPortSelectCommand()
        {
            Text = "Válaszd ki a megfelelő COM portot a listából...";
            Enabled = true;
            BackColor = System.Drawing.SystemColors.Control;
            DropDownStyle = ComboBoxStyle.DropDownList;


            DropDown += (o, e) =>
            {
                Items.Clear();
                Items.AddRange(SerialPort.GetPortNames());
            };

            DropDownClosed += (o, e) =>{
                Control p;
                p = ((ToolStripComboBox)o).Control;
                p.Parent.Focus();

                Settings.Default.SeriaPortName = Text;
                Settings.Default.Save();
            };

            EventAggregator.Instance.Subscribe((Action<ShowAppEvent>)(e =>
            {               
                Items.Clear();
                Items.AddRange(SerialPort.GetPortNames());

                if (!string.IsNullOrWhiteSpace(Settings.Default.SeriaPortName))
                {
                    Text = Settings.Default.SeriaPortName;
                }
            }));

            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)(e =>
            {
                Enabled = !e.IsOpen;       
            }));
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Debug.WriteLine(this.GetType().Namespace + "." + this.GetType().Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
        }
    }
}
