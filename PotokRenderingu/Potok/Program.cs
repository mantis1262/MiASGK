using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffor buffor = new Buffor(256, 256);
            buffor.SetColor(255,0,0);
           // buffor.SetColor(0xFFFF0000);
            buffor.Save("Result.png");
        }
    }
}
