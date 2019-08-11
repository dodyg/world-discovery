using System;
using System.Collections.Generic;
using System.Text;

namespace WorldDiscovery.Core
{
    public struct Uid
    {
        public ulong Value { get; set; }

        public static implicit operator ulong(Uid uid) => uid.Value;

        public static implicit operator Uid (ulong uid) => new Uid(uid);

        public static implicit operator Uid(string uid)
        {
            return new Uid(UInt64.Parse(uid[2..]!, System.Globalization.NumberStyles.HexNumber));
        }

        public Uid(ulong val)
        {
            Value = val;
        }

    }
}
