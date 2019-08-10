using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.IO;

namespace WorldDiscovery.GraphServer.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }

        public bool IsSuccess { get; set; }

        public string TransactionState { get; set; }

        public string Json { get; set; }

        public string MutationMessage { get; set; }

        public async Task OnGet()
        {
            using var client = DgraphDotNet.Clients.NewDgraphClient();
            client.Connect("localhost:9280");
            using var txn = client.NewTransaction();

            TransactionState = txn.TransactionState.ToString();

            var p = new Person
            {
                Name = "Anne Mishkind Gunawinata",
                DOB = DateTime.Parse("1978-04-20")
            };

            var json = JsonSerializer.SerializeToUtf8Bytes(p, options: new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            Json = System.Text.Encoding.UTF8.GetString(json);

            var mutationResult = await txn.Mutate(Json);

            MutationMessage = string.Join(',', mutationResult.Reasons);

            var result = await txn.Commit();

            IsSuccess = result.IsSuccess;

            if (!IsSuccess)
            {
                Message = string.Join(',', result.Reasons);
            }
        }
    }
}