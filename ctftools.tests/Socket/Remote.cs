using ctftools.Socket;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ctftools.tests.Socket
{
    public class Remote
    {
        [Fact]
        public void ReadLineUntilReturnsOnlyLineWithDelimiter()
        {
            var r = new ctftools.Socket.Remote("tcpbin.com", 4242);
            r.SendLine("This is test\nAssertThis");
            var result = r.ReadLineUntil("Assert");
            Assert.Equal("AssertThis", result);
        }

        [Fact]
        public void ReadLineReturnsFirstLine()
        {
            var r = new ctftools.Socket.Remote("tcpbin.com", 4242);
            r.SendLine("This is test\nAssertThis");
            var result = r.ReadLine();
            Assert.Equal("This is test", result);
        }


        // Test cases for ReadBytes(n)
        [Fact]
        public void ReadBytesReturnsExpectedBytes()
        {
            var r = new ctftools.Socket.Remote("tcpbin.com", 4242);
            r.SendLine("This is a test");
            var expectedBytes = Encoding.ASCII.GetBytes("This is a test");
            byte[] result = r.ReadBytes(expectedBytes.Length);
            Assert.Equal(expectedBytes, result);
        }

        [Fact]
        public void ReadBytesReturnsPartialBytes()
        {
            var r = new ctftools.Socket.Remote("tcpbin.com", 4242);
            r.SendLine("This is a test");
            var expectedBytes = Encoding.ASCII.GetBytes("This");
            byte[] result = r.ReadBytes(expectedBytes.Length);
            Assert.Equal(expectedBytes, result);
        }

        [Fact]
        public void ReadBytesThrowsIfConnectionClosedPrematurely()
        {
            var r = new ctftools.Socket.Remote("tcpbin.com", 4242);
            Assert.Throws<EndOfStreamException>(() => r.ReadBytes(5));
        }

        [Fact]
        public void ReadBytesReturnsEmptyArrayIfNIsZero()
        {
            var r = new ctftools.Socket.Remote("tcpbin.com", 4242);
            byte[] result = r.ReadBytes(0);
            Assert.Empty(result);
        }

        [Fact]
        public void ReadBytesReturnsEmptyArrayIfNIsNegative()
        {
            var r = new ctftools.Socket.Remote("tcpbin.com", 4242);
            byte[] result = r.ReadBytes(-5);
            Assert.Empty(result);
        }

    }
}
