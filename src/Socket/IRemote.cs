using ctftools.Socket.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ctftools.tests")]
namespace ctftools.Socket
{
    internal interface IRemote
    {
        string? ReadLine();
        string? ReadLineUntil(string delimiter);
        void SendLine(string line);
        ITcpClient CreateTcpClient(string url, int port);
        IStreamReader CreateStreamReader(NetworkStream stream);

    }
}
