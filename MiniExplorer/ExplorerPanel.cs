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
        private readonly List<FilesystemEntry> Entries = new List<FilesystemEntry>();

        public string CurrentPath
        {
            get { return TxtPath.Text.Trim(); }
            set { SetPath(value); }
        }

        public ExplorerPanel()
        {
            InitializeComponent();
            SetDefaultState();

            FileListBox.DisplayMember = "Name";
            FileListBox.DrawMode = DrawMode.OwnerDrawFixed;
            FileListBox.DrawItem += FileListBox_DrawItem;
        }

        private void SetDefaultState()
        {
            CurrentPath = Path.GetPathRoot(Application.StartupPath);
        }

        private void SetPath(string path)
        {
            TxtPath.Text = path;
            TxtPath.Select(path.Length, 0);
            UpdateEntries();
            UpdateFileListBox();
        }

        private void UpdateFileListBox()
        {
            FileListBox.DataSource = Entries;
            FileListBox.Refresh();
        }

        private void UpdateEntries()
        {
            IEnumerable<string> entries = Directory.EnumerateFileSystemEntries(
                CurrentPath, "*", SearchOption.TopDirectoryOnly);

            Entries.Clear();
            Entries.Add(new FilesystemEntry(FilesystemEntry.CurrentFolder));
            Entries.Add(new FilesystemEntry(FilesystemEntry.ParentFolder));

            foreach (string entry in entries)
                Entries.Add(new FilesystemEntry(entry));
        }

        private void FileListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            DrawItem(e);
            e.DrawFocusRectangle();
        }

        private void DrawItem(DrawItemEventArgs e)
        {
            FilesystemEntry entry = Entries[e.Index];
            Graphics g = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.Black);

            g.DrawString(entry.Name, e.Font, brush, e.Bounds, StringFormat.GenericDefault);

            brush.Dispose();
        }
    }
}
