using System;

namespace IPAddressDetector
{
    public sealed class IPv6
    {
        private static readonly StringSplitOptions _splitOptions = StringSplitOptions.RemoveEmptyEntries;
        private static readonly StringComparison _comparison = StringComparison.OrdinalIgnoreCase;
        private static readonly char[] _splitChar = new char[] { '.' };

        public static bool IsLocal(string IPAddress)
        {
            if (string.IsNullOrWhiteSpace(IPAddress) == true)
                return false;

            var _locals = new string[] { "::1", "localhost" };

            foreach (var _local in _locals)
            {
                if (string.Equals(_local, IPAddress) == true)
                    return true;
            }

            return false;
        }
    }
}
