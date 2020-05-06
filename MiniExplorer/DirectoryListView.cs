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
using Microsoft.VisualBasic.FileIO;

namespace MiniExplorer
{
    public partial class DirectoryListView : ListView
    {
        public ExplorerPanel ExplorerPanel { set; get; }

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

        public DirectoryListView()
        {
            View = View.Details;
            DirectoryItems = new List<DirectoryItem>();
            MultiSelect = true;

            MouseDoubleClick += DirectoryListView_MouseDoubleClick;
            ColumnClick += DirectoryListView_ColumnClick;
            KeyDown += DirectoryListView_KeyDown;

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
            EnterSelectedDirectory();
        }

        private void DirectoryListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EnterSelectedDirectory();
            }
            else if (e.KeyCode == Keys.Back)
            {
                EnterParentDirectory();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectedItems();
            }
        }

        private void EnterSelectedDirectory()
        {
            try
            {
                if (SelectedIndices.Count == 0)
                    return;

                int index = SelectedIndices[0];
                DirectoryItem item = DirectoryItems[index];
                if (item.Type == DirectoryItemType.File)
                    Process.Start(item.Path);
                else if (item.Type == DirectoryItemType.Folder || item.Type == DirectoryItemType.SpecialFolder)
                    ExplorerPanel.RootPath = item.Path;
            }
            catch (Exception ex)
            {
                Util.Error(ex.Message);
            }
        }

        private void EnterParentDirectory()
        {
            DirectoryInfo parent = Directory.GetParent(RootPath);
            if (parent != null)
                ExplorerPanel.RootPath = parent.FullName;
        }

        private void DeleteSelectedItems()
        {
            if (SelectedIndices.Count == 0)
                return;

            List<string> paths = new List<string>();
            foreach (int index in SelectedIndices)
                paths.Add(DirectoryItems[index].Path);

            Util.DeleteFilesOrFolders(paths);
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
            DirectoryItems.AddRange(GetSpecialDirectoryItems());
            DirectoryItems.AddRange(LoadFiles());
            DirectoryItems.AddRange(LoadFolders());
            SortItems();
            UpdateView();
        }

        private void SortItems()
        {
            DirectoryItems.Sort(new Comparison<DirectoryItem>
            (
                (item1, item2) => 
                {
                    if (item1.Type == item2.Type)
                    {
                        return item1.Name.CompareTo(item2.Name);
                    }
                    if (item1.Type == DirectoryItemType.Folder && item2.Type == DirectoryItemType.File)
                    {
                        return -1;
                    }
                    if (item1.Type == DirectoryItemType.File && item2.Type == DirectoryItemType.Folder)
                    {
                        return 1;
                    }

                    return 0;
                }
            ));
        }

        public void Reload()
        {
            Load(RootPath);
        }

        private void UpdateView()
        {
            SmallImageList = ExplorerPanel.Icons;
            Items.Clear();

            foreach (DirectoryItem item in DirectoryItems)
            {
                ListViewItem listItem;

                listItem = Items.Add(item.Name);
                listItem.ImageIndex = item.IconIndex;
                listItem.Tag = item;
                listItem.SubItems.Add(item.SizeAsString);
                listItem.SubItems.Add(item.FileExtension);
            }

            Refresh();
        }

        private List<DirectoryItem> LoadFiles()
        {
            List<DirectoryItem> files = new List<DirectoryItem>();

            foreach (FileInfo fileInfo in DirectoryInfo.EnumerateFiles())
            {
                DirectoryItem item = new DirectoryItem(fileInfo);
                files.Add(item);
            }

            return files;
        }

        private List<DirectoryItem> LoadFolders()
        {
            List<DirectoryItem> folders = new List<DirectoryItem>();

            foreach (DirectoryInfo dirInfo in DirectoryInfo.EnumerateDirectories())
            {
                DirectoryItem item = new DirectoryItem(dirInfo);
                folders.Add(item);
            }

            return folders;
        }

        private List<DirectoryItem> GetSpecialDirectoryItems()
        {
            List<DirectoryItem> items = new List<DirectoryItem>();
            DirectoryInfo parent = Directory.GetParent(RootPath);

            if (parent != null)
            {
                SpecialDirectoryInfo parentFolderInfo = new SpecialDirectoryInfo("..", parent.FullName);
                items.Add(new DirectoryItem(parentFolderInfo));
            }

            return items;
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
