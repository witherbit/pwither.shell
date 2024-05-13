using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pwither.shell.Objects
{
    public struct ShellVersion
    {
        public short Major { get; }
        public short Minor { get; }
        public short Maintenance { get; }

        public ShellVersion(string version) 
        {
            try
            {
                var splitted = version.Split('.');
                Major = Convert.ToInt16(splitted[0]);
                Minor = Convert.ToInt16(splitted[1]);
                Maintenance = Convert.ToInt16(splitted[2]);
            }
            catch 
            {
                throw new Exception("Unsupported version format");
            }
        }

        public ShellVersion(short major, short minor, short maintenance = 0)
        {
            Major = major;
            Minor = minor;
            Maintenance = maintenance;
        }

        public override string ToString()
        {
            return $"{Major}.{Minor}.{Maintenance}";
        }
    }
}
