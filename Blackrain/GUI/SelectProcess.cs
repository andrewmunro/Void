using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using BlackRain.Common.Objects;

namespace BlackRain.GUI
{
    /// <summary>
    /// Basic form to select a Wow process.
    /// </summary>
    public partial class SelectProcess : Form
    {
        private readonly List<Process> _processes = new List<Process>();

        /// <summary>
        /// Ctor.
        /// </summary>
        public SelectProcess()
        {
            InitializeComponent();
        }

        new void Refresh()
        {
            if (_processes.Count > 0)
                _processes.Clear();

            var proc = Process.GetProcessesByName("Wow");

            foreach (var p in proc)
            {
                cmb_Processes.Items.Add(string.Format("Process ID: {0} | Name: {1}", p.Id, p.ProcessName));
                _processes.Add(p);
            }
        }

        private void btn_Refresh_Click(object sender, System.EventArgs e)
        {
            Refresh();
        }

        private void btn_Attach_Click(object sender, System.EventArgs e)
        {
            if (cmb_Processes.SelectedIndex != 0 && _processes.Count != 0)
            {
                ObjectManager.Initialize(_processes[cmb_Processes.SelectedIndex]);
            }
        }
    }
}
