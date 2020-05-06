using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MiniExplorer
{
    public partial class ExplorerPanel : UserControl
    {
        public DirectoryListView View => DirectoryListView;

        public string RootPath
        {
            get => _RootPath;

            set
            {
                _RootPath = value?.Trim();
                TxtRootPath.Text = _RootPath ?? "";
                Refresh();
            }
        }

        private string _RootPath;

        public ExplorerPanel()
        {
            InitializeComponent();
            DirectoryListView.ExplorerPanel = this;
            DoubleBuffered = true;
        }

        public override void Refresh()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(RootPath))
                {
                    DirectoryListView.Load(RootPath);
                    TxtRootPath.Text = DirectoryListView.RootPath;
                    LbFileCount.Text = $"{DirectoryListView.FileCount} Files";
                    LbFolderCount.Text = $"{DirectoryListView.FolderCount} Folders";
                }

                base.Refresh();
            }
            catch (DirectoryNotFoundException)
            {
                Util.Alert("Path not found");
            }
            catch (Exception ex)
            {
                Util.Alert(ex.Message);
            }
        }

        private void TxtRootPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                RootPath = TxtRootPath.Text;
            }
        }
    }
}
