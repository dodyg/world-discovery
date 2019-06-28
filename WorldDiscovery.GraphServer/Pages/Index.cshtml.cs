using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorldDiscovery.GraphServer.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            using var client = DgraphDotNet.Clients.NewDgraphClient();
            client.Connect("127.0.0.1:9080");
            using var txn = client.NewTransaction();

            var p = new Person
            {
                Uid = Guid.NewGuid().ToString(),
                Name = "Dody Gunawinata"
            };

            var payload = Utf8Json.JsonSerializer.ToJsonString(p);
            txn.Mutate(payload);
            txn.Commit();
        }
    }
}