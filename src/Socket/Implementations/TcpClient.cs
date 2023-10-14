using ctftools.Socket.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctftools.Socket.Implementations
{
    internal class TcpClient : ITcpClient
    {
        private readonly System.Net.Sockets.TcpClient _tcpClient;
        public TcpClient(string url, int port) {
            _tcpClient = new System.Net.Sockets.TcpClient(url, port)
            {
                NoDelay = true
            };
        }
        public System.Net.Sockets.NetworkStream GetStream()
        {
            return _tcpClient.GetStream();
        }
    }
}
