using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok
{
    public class MyColor
    {
        private uint _alfa;
        private uint _red;
        private uint _green;
        private uint _blue;

        public uint Alfa { get => _alfa; set => _alfa = value; }
        public uint Red { get => _red; set => _red = value; }
        public uint Green { get => _green; set => _green = value; }
        public uint Blue { get => _blue; set => _blue = value; }

        public MyColor(uint red, uint green, uint blue)
        {
            _red = red;
            _green = green;
            _blue = blue;
            _alfa = 255;
        }

        public MyColor(Color color)
        {
            _red = color.R;
            _green = color.G;
            _blue = color.B;
            _alfa = color.A;
        }

        public MyColor(uint alfa, uint red, uint green, uint blue)
        {
            _alfa = alfa;
            _red = red;
            _green = green;
            _blue = blue;
        }

        public MyColor(MyColor color)
        {
            _red = color.Red;
            _green = color.Green;
            _blue = color.Blue;
            _alfa = color.Alfa;
        }

        public Color ToColor()
        {
            return Color.FromArgb((int)_alfa, (int)_red, (int)_green, (int)_blue);
        }
    }
}
