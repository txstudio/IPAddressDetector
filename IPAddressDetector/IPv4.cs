using System;

namespace IPAddressDetector
{
    public sealed class IPv4
    {
        private static readonly StringSplitOptions _splitOptions = StringSplitOptions.RemoveEmptyEntries;
        private static readonly StringComparison _comparison = StringComparison.OrdinalIgnoreCase;
        private static readonly char[] _splitChar = new char[]{'.'};

        public static bool IsLocal(string IPAddress)
        {
            if (string.IsNullOrWhiteSpace(IPAddress) == true)
                return false;

            var _locals = new string[] { "127.0.0.1", "localhost" };

            foreach (var _local in _locals)
            {
                if (string.Equals(_local, IPAddress) == true)
                    return true;
            }

            return false;
        }

        public static bool IsPrivate(string IPAddress)
        {
            if (string.IsNullOrWhiteSpace(IPAddress) == true)
                return false;

            if (IsLocal(IPAddress) == true)
                return true;

            if (IPv6.IsLocal(IPAddress) == true)
                return true;

            var _items = IPAddress.Split(_splitChar, _splitOptions);

            if(_items.Length == 4)
            {
                //class A
                if (string.Equals("10", _items[0], _comparison) == true)
                {
                    return true;
                }

                //class B
                if (string.Equals("172", _items[0], _comparison) == true)
                {
                    var _number = Convert.ToInt32(_items[1]);

                    if (_number >= 16 && _number <= 31)
                        return true;
                }

                //class C
                if (string.Equals("192", _items[0], _comparison) == true
                    && string.Equals("168", _items[1], _comparison) == true)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
