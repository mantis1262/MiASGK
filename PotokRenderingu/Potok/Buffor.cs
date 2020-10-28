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
        uint[][] color;
        float[][] depth;
        int width;
        int heigth;
        int lenght;
        int minX, minY, maxX, maxY;

        public int Width { get => width;}
        public int Heigth { get => heigth;}
        public int Lenght { get => lenght;}
        public int MinX { get => minX;}
        public int MinY { get => minY;}
        public int MaxX { get => maxX;}
        public int MaxY { get => maxY;}
        public uint[][] Color { get => color; }
        public float[][] Depth { get => depth; }

        public Buffor(int w, int h)
        {
            width = w;
            heigth = h;
            lenght = w * h;
            color = new uint[width][];
            for (int i = 0; i < color.Length; i++)
            {
                color[i] = new uint[heigth];
            }

            depth = new float[width][];
            for (int i = 0; i < depth.Length; i++)
            {
                depth[i] = new float[heigth];
            }
            minX = 0;
            minX = 0;
            minY = 0;
            maxX = width - 1;
            maxY = heigth - 1;
        }

        public void SetSize(int w,int h)
        {
            width = w;
            heigth = h;
            lenght = w * h;
            color = new uint[width][];
            for (int i = 0; i < color.Length; i++)
            {
                color[i] = new uint[heigth];
            }
            depth = new float[width][];
            for (int i = 0; i < depth.Length; i++)
            {
                depth[i] = new float[heigth];
            }
            minX = 0;
            minY = 0;
            maxX = width - 1;
            maxY = heigth - 1;
        }

        public void SetPixel(uint color, int x, int y)
        {
            this.color[x][y] = color;
        }

        public void SetPixel(byte R, byte G, byte B, int x, int y)
        {
            byte[] colors = new byte[4] { B, G, R, 255 };
            color[x][y] = BitConverter.ToUInt32(colors, 0);
        }

        public void SetPixel(uint color, float depth, int x, int y)
        {
            this.depth[x][y] = depth;
            this.color[x][y] = color;
        }

        public void SetPixel(byte R, byte G, byte B, float depth, int x, int y)
        {
            byte[] colors = new byte[4] { B, G, R, 255 };
            color[x][y] = BitConverter.ToUInt32(colors, 0);
            this.depth[x][y] = depth;
        }

        public void SetColor(uint color)
        {
            for(int i = 0; i < this.color.Length; i++)
            {
                for (int j = 0; j < this.color[i].Length; j++)
                {
                    this.color[i][j] = color;
                }
            }
        }

        public void SetColor(byte R, byte G, byte B)
        {
            byte[] colors = new byte[4] { B, G, R, 255 };
            uint col = BitConverter.ToUInt32(colors, 0);
            for (int i = 0; i < this.color.Length; i++)
            {
                for (int j = 0; j < this.color[i].Length; j++)
                {
                    color[i][j] = col; 
                }
            }
        }

        public void SetDepth(float depth)
        {
            for (int i = 0; i < this.depth.Length; i++)
            {
                for (int j = 0; j < this.depth[i].Length; j++)
                {
                    this.depth[i][j] = depth;
                }
            }
        }

        public void ClearColor()
        {
            for (int i = 0; i < color.Length; i++)
            {
                for (int j = 0; j < this.color[i].Length; j++)
                {
                    color[i][j] = 0xFF000000;
                }
            }
        }

        public void ClearDepth()
        {
            for (int i = 0; i < this.depth.Length; i++)
            {
                for (int j = 0; j < this.depth[i].Length; j++)
                {
                    this.depth[i][j] = 2.0f;
                }
            }
        }

        public void Save(string filname)
        {

            Bitmap bitmap = new Bitmap(width, heigth);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < heigth; j++)
                {
                    byte[] col = BitConverter.GetBytes(color[i][j]);
                    bitmap.SetPixel(i, j, System.Drawing.Color.FromArgb(col[3], col[2], col[1], col[0]));
                }
            }
            bitmap.Save(filname);
        }

    }
}
