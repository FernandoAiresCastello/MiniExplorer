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
using System.Collections;
using System.Reflection;

namespace MiniExplorer
{
    public partial class DirectoryListView : ListView
    {
        public string RootPath { get; private set; }
        public DirectoryInfo DirectoryInfo { get; private set; }
        public List<DirectoryItem> DirectoryItems { get; private set; }
        public long FileCount => CountFiles();
        public long FolderCount => CountFolders();

        public DirectoryListView()
        {
            View = View.Details;
            DirectoryItems = new List<DirectoryItem>();
            MultiSelect = true;
            Columns.Add("Filename", 200, HorizontalAlignment.Left);
            Columns.Add("Size", 100, HorizontalAlignment.Left);
            MouseDoubleClick += DirectoryListView_MouseDoubleClick;
        }

        private void DirectoryListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedIndices.Count == 0)
                return;

            int index = SelectedIndices[0];
            DirectoryItem item = DirectoryItems[index];
        }

        public void Load(string rootPath)
        {
            if (IsEnvironmentPathVariable(rootPath))
                rootPath = GetEnvironmentPath(rootPath);

            RootPath = rootPath;

            if (!Directory.Exists(rootPath))
                throw new DirectoryNotFoundException();
            
            DirectoryInfo = new DirectoryInfo(rootPath);
            DirectoryItems.Clear();
            DirectoryItems.AddRange(LoadFiles());
            DirectoryItems.AddRange(LoadFolders());
            UpdateView();
        }

        private void UpdateView()
        {
            Items.Clear();

            foreach (DirectoryItem item in DirectoryItems)
            {
                ListViewItem listItem = Items.Add(item.Name);
                listItem.Tag = item;
                listItem.SubItems.Add(item.SizeAsString);
           }

            Refresh();
        }

        private List<DirectoryItem> LoadFiles()
        {
            List<DirectoryItem> files = new List<DirectoryItem>();

            foreach (FileInfo fileInfo in DirectoryInfo.EnumerateFiles())
                files.Add(new DirectoryItem(fileInfo));

            return files;
        }

        private List<DirectoryItem> LoadFolders()
        {
            List<DirectoryItem> folders = new List<DirectoryItem>();
            return folders;
        }

        private long CountFiles()
        {
            return DirectoryItems.Count((DirectoryItem item) => item.Type == DirectoryItemType.File);
        }

        private long CountFolders()
        {
            return DirectoryItems.Count((DirectoryItem item) => item.Type == DirectoryItemType.Folder);
        }

        private bool IsEnvironmentPathVariable(string path)
        {
            return path.StartsWith("%") && path.EndsWith("%");
        }

        private string GetEnvironmentPath(string variable)
        {
            variable = variable.Replace("%", "");
            string path = Environment.GetEnvironmentVariable(variable);

            if (path != null && !(path.EndsWith("/") || path.EndsWith("\\")))
                path += "\\";

            return path != null ? Path.GetFullPath(path) : null;
        }
    }
}
