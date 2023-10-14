using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ctftools.Socket.Interfaces
{
    public interface ITcpClient
    {
        NetworkStream GetStream();
    }
}
