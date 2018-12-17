using IPAddressDetector;
using System;
using Xunit;

namespace IPAddressDetectorTest
{
    public sealed class IPv4_IsLocal_Test
    {
        [Fact]
        public void Input_IP_Is_EmptyString()
        {
            var _isLocal = IPv4.IsLocal(string.Empty);

            Assert.False(_isLocal);
        }
    
        [Fact]
        public void Input_IP_Is_Local()
        {
            var _address = new string[] { "127.0.0.1", "localhost" };
            bool _actual = false;

            foreach (var item in _address)
            {
                _actual = IPv4.IsLocal(item);

                Assert.True(_actual);
            }
        }

        [Fact]
        public void Input_IP_IsNot_Local()
        {
            var _address = new string[] { "140.137.62.6", "122.151.66.1" };
            bool _actual = false;

            foreach (var item in _address)
            {
                _actual = IPv4.IsLocal(item);

                Assert.False(_actual);
            }
        }
    }

    public sealed class IPv4_IsPrivate_Test
    {
        [Fact]
        public void Input_StringEmpty_Address()
        {
            var _isPrivate = IPv4.IsPrivate(string.Empty);

            Assert.False(_isPrivate);
        }

        [Fact]
        public void Input_Local_Address()
        {
            var _locals = new string[] { "127.0.0.1", "localhost", "::1" };
            var _isPrivate = false;

            foreach (var _local in _locals)
            {
                _isPrivate = IPv4.IsPrivate(_local);

                Assert.True(_isPrivate);
            }
        }

        [Fact]
        public void Input_ClassA_Address()
        {
            var _locals = new string[] { "10.0.0.1", "10.10.126.222" };
            var _isPrivate = false;

            foreach (var _local in _locals)
            {
                _isPrivate = IPv4.IsPrivate(_local);

                Assert.True(_isPrivate);
            }
        }

        [Fact]
        public void Input_ClassB_Address()
        {
            var _locals = new string[] { "172.16.2.6", "172.31.0.1" };
            var _isPrivate = false;

            foreach (var _local in _locals)
            {
                _isPrivate = IPv4.IsPrivate(_local);

                Assert.True(_isPrivate);
            }
        }

        [Fact]  
        public void Input_ClassC_Address()
        {
            var _locals = new string[] { "192.168.0.1", "192.168.254.11" };
            var _isPrivate = false;

            foreach (var _local in _locals)
            {
                _isPrivate = IPv4.IsPrivate(_local);

                Assert.True(_isPrivate);
            }
        }

        [Fact]
        public void Input_Internet_Address()
        {
            var _locals = new string[] { "172.15.0.1", "172.32.254.3" };
            var _isPrivate = false;

            foreach (var _local in _locals)
            {
                _isPrivate = IPv4.IsPrivate(_local);

                Assert.False(_isPrivate);
            }
        }

    }

}
