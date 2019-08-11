using System;
using System.Collections.Generic;
using System.Text;

namespace WorldDiscovery.Core
{
    public struct UID
    {
        public long Value { get; set; }

        public static implicit operator long(UID uid) => uid.Value;

        public static implicit operator UID (long uid) => new UID(uid);

        public UID(long val)
        {
            Value = val;
        }
    }
}
