using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniExplorer
{
    public partial class MainWindow : Form
    {
        private readonly int MinimumDoubleWidth = 650;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MiSingleMode_Click(object sender, EventArgs e)
        {
            SplitContainer.Panel2Collapsed = true;
        }

        private void MiDoubleMode_Click(object sender, EventArgs e)
        {
            SplitContainer.Panel2Collapsed = false;

            if (Width < MinimumDoubleWidth)
                Width = MinimumDoubleWidth;

            SplitContainer.SplitterDistance = Width / 2;
        }

        private void MiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
