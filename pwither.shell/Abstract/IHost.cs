using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pwither.shell.Abstract
{
    public interface IHost
    {
        object Providing { get; }
        void InvokeNative();
        object Invoke(params object[] parameters);
        void Message(string message);
    }
}
