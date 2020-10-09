using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
namespace Potok
{
    class Buffor
    {
        uint[] color;
        float[] depth;
        int width;
        int heigth;
        int lenght;

        public Buffor(int w, int h)
        {
            width = w;
            heigth = h;
            lenght = w * h;
            color = new uint[lenght];
            depth = new float[lenght];
        }

        public void SetColor(uint color)
        {
            for(int i = 0; i < this.color.Length; i++)
            {
                this.color[i] = color;
            }
        }

        public void SetColor(byte R, byte G, byte B)
        {
            for (int i = 0; i < this.color.Length; i++)
            {
                byte[] colors = new byte[4] { 255, R, G, B };
                color[i] = BitConverter.ToUInt32(colors, 0);
            }
        }

        public void ClearColor()
        {
            for (int i = 0; i < this.color.Length; i++)
            {
                this.color[i] = 0xFF000000;
            }
        }

        public void Save(string filname)
        {

            Bitmap bitmap = new Bitmap(width, heigth);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < heigth; j++)
                {
                    byte[] col = BitConverter.GetBytes(color[i * j]);
                    if (i == 0)
                        col = BitConverter.GetBytes(color[j*width]);
                    if (j == 0)
                        col = BitConverter.GetBytes(color[i]);

                    bitmap.SetPixel(i, j, Color.FromArgb(col[0], col[1], col[2], col[3]));
                }
            }
            bitmap.Save(filname);
        }

    }
}
