using pwither.shell.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pwither.shell.Objects
{
    public class ContractStore
    {
        public List<Contract> Contracts { get; }
        public List<RevokeTokenInfo> RevokeTokens { get; }

        public ContractStore()
        {
            Contracts = new List<Contract>();
            RevokeTokens = new List<RevokeTokenInfo>();
        }

        public (Contract Contract, RevokeTokenInfo RevokeTokenInfo) Register(ShellBase shell, IHost host)
        {
            if (shell != null)
            {
                var revokeTokenInfo = new RevokeTokenInfo(host, shell);
                var contract = new Contract(revokeTokenInfo);
                Contracts.Add(contract);
                RevokeTokens.Add(revokeTokenInfo);
                contract.Register(shell);
                return (contract, revokeTokenInfo);
            }
            return (null, null);
        }
        public void Revoke(ShellBase shell)
        {
            var revokeTokenInfo = RevokeTokens.FirstOrDefault(x => x.ShellId == shell.Id);
            if (revokeTokenInfo != null)
            {
                revokeTokenInfo.Revoke();
                RevokeTokens.Remove(revokeTokenInfo);
                revokeTokenInfo = null;
            }
            var contract = Contracts.FirstOrDefault(x => x.DestinationShellId == shell.Id);
            if (contract != null)
            {
                Contracts.Remove(contract);
                contract = null;
            }
        }
        public (Contract Contract, RevokeTokenInfo RevokeTokenInfo) GetFromStore(ShellBase shell)
        {
            var revokeTokenInfo = RevokeTokens.FirstOrDefault(x => x.ShellId == shell.Id);
            var contract = Contracts.FirstOrDefault(x => x.DestinationShellId == shell.Id);
            return (contract, revokeTokenInfo);
        }
    }
}
