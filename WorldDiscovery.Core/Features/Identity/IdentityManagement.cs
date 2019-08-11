using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldDiscovery.Core.Features.Identity
{
    public class IdentityManagement
    {
        readonly Config _cfg;

        public IdentityManagement(Config cfg)
        {
            _cfg = cfg;
        }

        public async Task<Result<Uid>> SaveAsync(PersonNewInput p)
        {
            try
            {
                using var client = DgraphDotNet.Clients.NewDgraphClient();
                client.Connect(_cfg.GraphServer);
                using var txn = client.NewTransaction();

                string json = Json.Serializes(p);

                var mutationResult = await txn.Mutate(json);

                var result = await txn.Commit();

                if (!result.IsSuccess)
                    return Result<Uid>.False(string.Join(',', result.Reasons));

                Uid uid = mutationResult.Value["blank-0"];

                return Result<Uid>.True(uid);
            }
            catch (Exception ex)
            {
                return Result<Uid>.False(ex);
            }
        }
    }
}
