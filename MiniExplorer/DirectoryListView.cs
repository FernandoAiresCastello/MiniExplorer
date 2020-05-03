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
using System.Diagnostics;

namespace MiniExplorer
{
    public partial class DirectoryListView : ListView
    {
        public enum DetailColumn
        {
            Filename, Size, Type
        }

        public enum SortDirection
        {
            Ascending, Descending
        }

        public string RootPath { get; private set; }
        public DirectoryInfo DirectoryInfo { get; private set; }
        public List<DirectoryItem> DirectoryItems { get; private set; }
        public DetailColumn SortBy { set; get; }
        public long FileCount => CountFiles();
        public long FolderCount => CountFolders();

        private readonly ImageList Icons = new ImageList();

        public DirectoryListView()
        {
            View = View.Details;
            DirectoryItems = new List<DirectoryItem>();
            MultiSelect = true;

            MouseDoubleClick += DirectoryListView_MouseDoubleClick;
            ColumnClick += DirectoryListView_ColumnClick;

            SortBy = DetailColumn.Filename;
            AddColumn(DetailColumn.Filename, 200);
            AddColumn(DetailColumn.Size, 100);
            AddColumn(DetailColumn.Type, 50);
        }

        private void AddColumn(DetailColumn detailColumn, int width)
        {
            ColumnHeader column = Columns.Add(detailColumn.ToString(), width, HorizontalAlignment.Left);
            column.Tag = detailColumn;
            //todo
        }

        private void DirectoryListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortBy = (DetailColumn)Columns[e.Column].Tag;
            Sorting = SortOrder.Ascending;
        }

        private void DirectoryListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (SelectedIndices.Count == 0)
                    return;

                int index = SelectedIndices[0];
                DirectoryItem item = DirectoryItems[index];
                Process.Start(item.Path);
            }
            catch (Exception ex)
            {
                Util.Error(ex.Message);
            }
        }

        public void Load(string rootPath)
        {
            if (IsEnvironmentPathVariable(rootPath))
                rootPath = GetEnvironmentPath(rootPath);

            RootPath = rootPath;

            if (!Directory.Exists(rootPath))
                throw new DirectoryNotFoundException();
            
            DirectoryInfo = new DirectoryInfo(rootPath);
            Icons.Images.Clear();
            DirectoryItems.Clear();
            DirectoryItems.AddRange(LoadFiles());
            DirectoryItems.AddRange(LoadFolders());
            UpdateView();
        }

        public void Reload()
        {
            Load(RootPath);
        }

        private void UpdateView()
        {
            Items.Clear();

            foreach (DirectoryItem item in DirectoryItems)
            {
                ListViewItem listItem = Items.Add(item.Name);
                listItem.Tag = item;
                listItem.SubItems.Add(item.SizeAsString);
                listItem.SubItems.Add(item.FileExtension);
            }

            Refresh();
        }

        private List<DirectoryItem> LoadFiles()
        {
            List<DirectoryItem> files = new List<DirectoryItem>();
            int iconIndex = 0;

            foreach (FileInfo fileInfo in DirectoryInfo.EnumerateFiles())
            {
                /*Icon icon = GetAssociatedIcon(fileInfo.FullName);
                if (icon != null)
                    Icons.Images.Add(icon);*/

                DirectoryItem item = new DirectoryItem(fileInfo);
                item.IconIndex = iconIndex++;
                files.Add(item);
            }

            return files;
        }

        private Icon GetAssociatedIcon(string path)
        {
            Icon icon;

            try
            {
                icon = Icon.ExtractAssociatedIcon(path);
            }
            catch
            {
                icon = null;
            }

            return icon;
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
