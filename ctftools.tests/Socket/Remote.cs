using ctftools.Socket;
using ctftools.Socket.Interfaces;
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
        public void VerifyPicoBasedSolveIntegration()
        {
            var r = new ctftools.Socket.Remote("jupiter.challenges.picoctf.org", 29956);
            var question = r.ReadLineUntil("give");
            var questionArr = question.Split(' ');
            List<string> binaryList = new();
            foreach(var item in questionArr) {
                if (int.TryParse(item, out _))
                {
                    binaryList.Add(item);
                }
            }
            var answer = ctftools.Format.Binary.ToText(string.Concat(binaryList));
            r.ReadLineUntil("Input");
            r.SendLine(answer);
            Assert.Contains("Please give me the", r.ReadLine());
        }
    }
}
