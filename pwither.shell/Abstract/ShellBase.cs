using pwither.shell.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pwither.shell.Abstract
{
    public abstract class ShellBase
    {
        public ShellInfo ShellInfo { get; }

        public ShellVersion Version { get; }

        public Guid Id { get; }

        public bool IsRun { get; private set; }
        public Contract Contract { get; internal set; }

        public event EventHandler<Contract> ShellRun;
        public event EventHandler<Contract> ShellExit;

        public ShellBase(ShellInfo info, ShellVersion version, Guid id)
        {
            ShellInfo = info;
            Version = version;
            Id = id;
        }

        public int Exit(int exitCode = 0)
        {
            if (IsRun)
            {
                OnExit();
                IsRun = false;
                ShellExit?.Invoke(this, Contract);
                return exitCode;
            }
            return int.MinValue;
        }

        public void Run()
        {
            if (!IsRun)
            {
                IsRun = true;
                ShellRun?.Invoke(this, Contract);
                OnRun();
            }
        }

        public abstract void OnRun();
        public abstract void OnExit();
    }
}
