using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pwither.shell.Objects
{
    public struct ShellInfo
    {
        public string Name { get; }
        public string Description { get; }
        public string Author { get; }

        public ShellInfo(string name, string description = null, string author = null)
        {
            Name = name;
            Description = description;
            Author = author;
        }
    }
}
