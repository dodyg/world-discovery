using System;
using System.Collections.Generic;
using System.Text;

namespace WorldDiscovery.Core
{
    public struct Uid
    {
        public long Value { get; set; }

        public static implicit operator long(Uid uid) => uid.Value;

        public static implicit operator Uid (long uid) => new Uid(uid);

        public Uid(long val)
        {
            Value = val;
        }
    }
}
