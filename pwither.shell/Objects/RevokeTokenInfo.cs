using pwither.shell.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pwither.shell.Objects
{
    public class RevokeTokenInfo
    {
        internal IHost _host { get; set; }
        public Guid ShellId { get; }
        public CancellationToken RevokeToken { get; }
        private CancellationTokenSource _tokenSource { get; set; }
        public RevokeTokenInfo(IHost host, ShellBase shell) 
        {
            _host = host;
            ShellId = shell.Id;
            _tokenSource = new CancellationTokenSource();
            RevokeToken = _tokenSource.Token;
        }
        public void Revoke()
        {
            _tokenSource.Cancel();
        }
    }
}
