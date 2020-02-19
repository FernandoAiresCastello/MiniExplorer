using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniExplorer
{
    public class FilesystemEntry
    {
        public static readonly string CurrentFolder = ".";
        public static readonly string ParentFolder = "..";

        public string FullPath { set; get; }
        public string Name { set; get; }
        public FilesystemEntryType Type { set; get; }

        public FilesystemEntry()
        {
        }

        public FilesystemEntry(string path)
        {
            if (path.Equals(CurrentFolder))
            {
                Type = FilesystemEntryType.CurrentFolder;
            }
            else if (path.Equals(ParentFolder))
            {
                Type = FilesystemEntryType.ParentFolder;
            }

            FullPath = Path.GetFullPath(path);
            Name = Path.GetFileName(path);
        }
    }
}
