using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniExplorer
{
    public enum DirectoryItemType
    {
        Invalid, File, Folder, SpecialFolder
    }

    public class DirectoryItem
    {
        public DirectoryItemType Type { get; private set; }
        public int IconIndex => GetIconIndex();
        public string Path => GetPath();
        public string Name => GetName();
        public string SizeAsString => GetSizeAsString();
        public string FileExtension => GetFileExtension();

        private readonly FileInfo FileInfo;
        private readonly DirectoryInfo DirectoryInfo;
        private readonly SpecialDirectoryInfo SpecialDirectoryInfo;

        public DirectoryItem(FileInfo info)
        {
            Type = DirectoryItemType.File;
            FileInfo = info;
        }

        public DirectoryItem(DirectoryInfo info)
        {
            Type = DirectoryItemType.Folder;
            DirectoryInfo = info;
        }

        public DirectoryItem(SpecialDirectoryInfo info)
        {
            Type = DirectoryItemType.SpecialFolder;
            SpecialDirectoryInfo = info;
        }

        private int GetIconIndex()
        {
            if (Type == DirectoryItemType.Folder)
                return 0;
            else if (Type == DirectoryItemType.File)
                return 1;
            else if (Name == "..")
                return 2;
            if (Type == DirectoryItemType.SpecialFolder)
                return -1;

            return -1;
        }

        private string GetName()
        {
            if (Type == DirectoryItemType.File)
                return FileInfo.Name;
            else if (Type == DirectoryItemType.Folder)
                return DirectoryInfo.Name;
            else if (Type == DirectoryItemType.SpecialFolder)
                return SpecialDirectoryInfo.Name;

            return null;
        }

        private string GetPath()
        {
            if (Type == DirectoryItemType.File)
                return FileInfo.FullName;
            else if (Type == DirectoryItemType.Folder)
                return DirectoryInfo.FullName;
            else if (Type == DirectoryItemType.SpecialFolder)
                return SpecialDirectoryInfo.Path;

            return null;
        }

        private string GetSizeAsString()
        {
            return Type == DirectoryItemType.File ? Util.BytesToString(FileInfo.Length) : "";
        }

        private string GetFileExtension()
        {
            return Type == DirectoryItemType.File ? FileInfo.Extension : "";
        }
    }
}
