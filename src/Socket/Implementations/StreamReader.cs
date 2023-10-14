using ctftools.Socket.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ctftools.Socket.Implementations
{
    internal class StreamReader : IStreamReader
    {
        private readonly System.IO.StreamReader _streamReader;
        public StreamReader(NetworkStream stream)
        {
            _streamReader = new System.IO.StreamReader(stream);
        }
        public string? ReadLine()
        {
           return _streamReader.ReadLine();
        }
    }
}
