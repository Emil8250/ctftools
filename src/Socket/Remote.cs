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

    private readonly byte[] _buffer;

    public Remote(string url, int port)
    {
        _tcpClient = new TcpClient(url, port);
        _networkStream = _tcpClient.GetStream();
        _streamReader = new StreamReader(_networkStream);
        _buffer = new byte[1024];
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

    public byte[] ReadBytes(int n)
    {
        if (n <= 0)
        {
            return Array.Empty<byte>();
        }

        byte[] buffer = new byte[n];
        int bytesRead = 0;

        while (bytesRead < n)
        {
            int remainingBytes = n - bytesRead;
            int count = _networkStream.Read(buffer, bytesRead, remainingBytes);

            if (count <= 0)
            {
                throw new EndOfStreamException("Connection closed before reading enough bytes.");
            }

            bytesRead += count;
        }

        return buffer;
    }
}
