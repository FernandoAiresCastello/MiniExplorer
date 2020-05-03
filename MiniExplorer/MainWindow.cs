using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniExplorer
{
    public partial class MainWindow : Form
    {
        public readonly string DefaultRootPath;
        public readonly string SystemRootPath = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
        public readonly string TestPath1 = @"C:\Windows";
        public readonly string TestPath2 = @"C:\Windows\System32";

        public MainWindow()
        {
            InitializeComponent();
            Font = EmbeddedFontLoader.Load(Properties.Resources.font_roboto_regular, 12);
            DefaultRootPath = SystemRootPath;
            LeftPanel.RootPath = TestPath1;
            RightPanel.RootPath = TestPath2;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnFont_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Font = dialog.Font;
                Refresh();
            }
        }
    }
}
