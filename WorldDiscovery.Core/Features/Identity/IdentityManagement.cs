using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorldDiscovery.Core.Features.Identity
{
    public class IdentityManagement
    {
        Config _cfg;

        public IdentityManagement(Config cfg)
        {
            _cfg = cfg;
        }

        public async Task<Result<UID>> SaveAsync(Person p)
        {
            try
            {
                using var client = DgraphDotNet.Clients.NewDgraphClient();
                client.Connect(_cfg.GraphServer);
                using var txn = client.NewTransaction();

                txn.TransactionState.ToString();

                var mutationResult = await txn.Mutate(Json.Serializer(p));
                var result = await txn.Commit();

                if (!result.IsSuccess)
                    return Result<UID>.False(string.Join(',', result.Reasons));

                return Result<UID>.True(100);
            }
            catch (Exception ex)
            {
                return Result<UID>.False(ex);
            }
        }
    }
}
