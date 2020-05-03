using System;
using System.Collections.Generic;
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
        public DirectoryItemType Type { set; get; }
        public FileInfo FileInfo { set; get; }
        public DirectoryInfo DirectoryInfo { set; get; }
        public string Name => GetName();
        public string SizeAsString => GetSizeAsString();

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

        private string GetSizeAsString()
        {
            return Util.BytesToString(FileInfo.Length);
        }
    }
}
