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
        [Fact]
        public void ReadBytesUntilReturnsBytesUntilDelimiter()
        {
            var r = new ctftools.Socket.Remote("tcpbin.com", 4242);
            r.SendLine("This is test\nAssertThis");
            var result = r.ReadBytesUntil((byte)'A'); 
            byte[] expectedBytes = Encoding.UTF8.GetBytes("This is test\n");
            Assert.Equal(expectedBytes, result);
        }
        [Fact]
        public void ReadBytesUntilReturnsEmptyArrayWhenDelimiterNotFound()
        {
            var r = new ctftools.Socket.Remote("tcpbin.com", 4242);
            r.SendLine("This is test\nAssertThis");
            var result = r.ReadBytesUntil((byte)'X'); 
            Assert.Empty(result);
        }
    }
}
