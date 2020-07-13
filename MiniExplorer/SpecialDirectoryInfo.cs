using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniExplorer
{
    public class SpecialDirectoryInfo
    {
        public string Name { get; private set; }
        public string Path { get; private set; }

        public SpecialDirectoryInfo(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
}
