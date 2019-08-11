﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace WorldDiscovery.Core
{
    public class Json
    {
        public static string Serializer(object p)
        {
            var json = JsonSerializer.SerializeToUtf8Bytes(p, options: new JsonSerializerOptions { PropertyNamingPolicy = new JsonNamingPolicySnakeCase() });
            return System.Text.Encoding.UTF8.GetString(json);
        }
    }
}
