using pwither.shell.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pwither.shell.Objects
{
    public sealed class Contract
    {
        private IHost _host { get; set; }

        private ShellBase _shell { get; set; }

        public Guid ContractId { get; }

        public Guid DestinationShellId { get; }

        public CancellationToken RevokeToken { get; }

        public Contract(RevokeTokenInfo revokeTokenInfo)
        {
            _host = revokeTokenInfo._host;
            ContractId = Guid.NewGuid();
            DestinationShellId = revokeTokenInfo.ShellId;
            RevokeToken = revokeTokenInfo.RevokeToken;
            RevokeToken.Register(() => Revoke());
        }

        private void Revoke()
        {
            if(_shell != null)
            {
                var exitCode = _shell.Exit();
                _host = null;
                _shell.Contract = null;
            }
        }

        internal void Register(ShellBase shell)
        {
            if(shell.Contract == null)
            {
                _shell = shell;
                _shell.Contract = this;
            }
            else
            {
                throw new Exception("Contract already exist");
            }
        }

        public object ShellProviding { get => _host.Providing; }
        public void ShellInvokeNative()
        {
            _host.InvokeNative();
        }
        public object ShellInvoke(params object[] parameters)
        {
            return _host.Invoke(parameters);
        }
        public void ShellMessage(string message)
        {
            _host.Message(message);
        }
    }
}
