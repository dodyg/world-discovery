using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace WorldDiscovery.Core
{
    public static class Json
    {
        public static string Serializes(object p)
        {
            var json = JsonSerializer.SerializeToUtf8Bytes(p, options: new JsonSerializerOptions { PropertyNamingPolicy = new JsonNamingPolicySnakeCase() });
            return System.Text.Encoding.UTF8.GetString(json);
        }
    }
}
