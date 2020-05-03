using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniExplorer
{
    public enum DirectoryItemType
    {
        Invalid, File, Folder
    }

    public class DirectoryItem
    {
        public DirectoryItemType Type { get; private set; }
        public int IconIndex { set; get; }
        public string Path => GetPath();
        public string Name => GetName();
        public string SizeAsString => GetSizeAsString();
        public string FileExtension => GetFileExtension();

        private readonly FileInfo FileInfo;
        private readonly DirectoryInfo DirectoryInfo;

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

        private string GetName()
        {
            if (Type == DirectoryItemType.File)
                return FileInfo.Name;
            else if (Type == DirectoryItemType.Folder)
                return DirectoryInfo.Name;

            return null;
        }

        private string GetPath()
        {
            if (Type == DirectoryItemType.File)
                return FileInfo.FullName;
            else if (Type == DirectoryItemType.Folder)
                return DirectoryInfo.FullName;

            return null;
        }

        private string GetSizeAsString()
        {
            return Util.BytesToString(FileInfo.Length);
        }

        private string GetFileExtension()
        {
            return Type == DirectoryItemType.File ? FileInfo.Extension : "";
        }
    }
}
