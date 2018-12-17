using IPAddressDetector;
using System;
using Xunit;

namespace IPAddressDetectorTest
{
    public class IPv6_IsLocal_Test
    {
        [Fact]
        public void Input_IP_Is_Local()
        {
            var _inputs = new string[] { "::1", "localhost" };

            foreach (var _input in _inputs)
            {
                Assert.True(IPv6.IsLocal(_input));
            }
        }

        [Fact]
        public void Input_IP_IsNot_Local()
        {
            var _inputs = new string[] { "0:0:0:0:0:ffff:dc84:8c66" };

            foreach (var _input in _inputs)
            {
                Assert.False(IPv6.IsLocal(_input));
            }
        }
    }
}
