using ctftools.Socket.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ctftools.tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace ctftools.Socket;
public class Remote: IRemote
{
    private readonly ITcpClient _tcpClient;
    private readonly NetworkStream _networkStream;
    private readonly IStreamReader _streamReader;
    public Remote(string url, int port)
    {
        _tcpClient = CreateTcpClient(url, port);
        _networkStream = _tcpClient.GetStream();
        _streamReader = CreateStreamReader(_networkStream);
    }

    public string? ReadLine()
    {
        return _streamReader.ReadLine();
    }
    public string? ReadLineUntil(string delimiter)
    {
        var delimiterHit = false;
        var line = "";
        while (!delimiterHit)
        {
            line = _streamReader.ReadLine();
            if (line == null || line.Contains(delimiter))
                delimiterHit = true;
        }
        return line;
    }
    public void SendLine(string line)
    {
        Byte[] data = Encoding.ASCII.GetBytes(line + '\n');
        _networkStream.Write(data, 0, data.Length);
    }

    public ITcpClient CreateTcpClient(string url, int port)
    {
        return new Implementations.TcpClient(url, port);
    }

   public IStreamReader CreateStreamReader(NetworkStream stream)
    {
        return new Implementations.StreamReader(stream);
    }
}
