using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("ctftools.tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace ctftools.Socket;
public class Remote
{
    private readonly TcpClient _tcpClient;
    private readonly NetworkStream _networkStream;
    private readonly StreamReader _streamReader;
    public Remote(string url, int port)
    {
        _tcpClient = new TcpClient(url, port);
        _networkStream = _tcpClient.GetStream();
        _streamReader = new StreamReader(_networkStream);
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
}
