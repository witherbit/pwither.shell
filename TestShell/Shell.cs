using pwither.shell.Abstract;
using pwither.shell.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TestShell
{
    internal class Shell : ShellBase
    {
        public Shell() : base
            (
            new ShellInfo("pwither shell test"),
            new ShellVersion("0.0.1"),
            new Guid("031e5279-930a-44bf-9c25-b117479d11ad")
            )
        {
            
        }

        public override void OnExit()
        {
            var frame = Contract.ShellProviding as Frame;
            frame.Content = null;
            Contract.ShellMessage("Exit!");
        }

        public override void OnRun()
        {
            var frame = Contract.ShellProviding as Frame;
            frame.Content = new TestPage();
            Contract.ShellMessage("Loaded!");
        }
    }
}
