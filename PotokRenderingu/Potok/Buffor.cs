using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
namespace Potok
{
    public class Buffor
    {
        uint[][] _color;
        float[][] _depth;
        int _width;
        int _heigth;
        int _lenght;
        int _minX, _minY, _maxX, _maxY;

        public int Width { get => _width;}
        public int Heigth { get => _heigth;}
        public int Lenght { get => _lenght;}
        public int MinX { get => _minX;}
        public int MinY { get => _minY;}
        public int MaxX { get => _maxX;}
        public int MaxY { get => _maxY;}
        public uint[][] Color { get => _color; }
        public float[][] Depth { get => _depth; }

        public Buffor(int w, int h)
        {
            _width = w;
            _heigth = h;
            _lenght = w * h;
            _color = new uint[_width][];
            for (int i = 0; i < _color.Length; i++)
            {
                _color[i] = new uint[_heigth];
            }

            _depth = new float[_width][];
            for (int i = 0; i < _depth.Length; i++)
            {
                _depth[i] = new float[_heigth];
            }
            _minX = 0;
            _minX = 0;
            _minY = 0;
            _maxX = _width - 1;
            _maxY = _heigth - 1;
        }

        public void SetSize(int w,int h)
        {
            _width = w;
            _heigth = h;
            _lenght = w * h;
            _color = new uint[_width][];
            for (int i = 0; i < _color.Length; i++)
            {
                _color[i] = new uint[_heigth];
            }
            _depth = new float[_width][];
            for (int i = 0; i < _depth.Length; i++)
            {
                _depth[i] = new float[_heigth];
            }
            _minX = 0;
            _minY = 0;
            _maxX = _width - 1;
            _maxY = _heigth - 1;
        }

        public void SetPixel(uint color, int x, int y)
        {
            this._color[x][y] = color;
        }

        public void SetPixel(byte R, byte G, byte B, int x, int y)
        {
            byte[] colors = new byte[4] { B, G, R, 255 };
            _color[x][y] = BitConverter.ToUInt32(colors, 0);
        }

        public void SetPixel(uint color, float depth, int x, int y)
        {
            this._depth[x][y] = depth;
            this._color[x][y] = color;
        }

        public void SetPixel(byte R, byte G, byte B, float depth, int x, int y)
        {
            byte[] colors = new byte[4] { B, G, R, 255 };
            _color[x][y] = BitConverter.ToUInt32(colors, 0);
            this._depth[x][y] = depth;
        }

        public void SetColor(uint color)
        {
            for(int i = 0; i < this._color.Length; i++)
            {
                for (int j = 0; j < this._color[i].Length; j++)
                {
                    this._color[i][j] = color;
                }
            }
        }

        public void SetColor(byte R, byte G, byte B)
        {
            byte[] colors = new byte[4] { B, G, R, 255 };
            uint col = BitConverter.ToUInt32(colors, 0);
            for (int i = 0; i < this._color.Length; i++)
            {
                for (int j = 0; j < this._color[i].Length; j++)
                {
                    _color[i][j] = col; 
                }
            }
        }

        public void SetDepth(float depth)
        {
            for (int i = 0; i < this._depth.Length; i++)
            {
                for (int j = 0; j < this._depth[i].Length; j++)
                {
                    this._depth[i][j] = depth;
                }
            }
        }

        public void ClearColor()
        {
            for (int i = 0; i < _color.Length; i++)
            {
                for (int j = 0; j < this._color[i].Length; j++)
                {
                    _color[i][j] = 0xFF000000;
                }
            }
        }

        public void ClearDepth()
        {
            for (int i = 0; i < this._depth.Length; i++)
            {
                for (int j = 0; j < this._depth[i].Length; j++)
                {
                    this._depth[i][j] = 2.0f;
                }
            }
        }

        public void Save(string filname)
        {

            Bitmap bitmap = new Bitmap(_width, _heigth);
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _heigth; j++)
                {
                    byte[] col = BitConverter.GetBytes(_color[i][j]);
                    bitmap.SetPixel(i, j, System.Drawing.Color.FromArgb(col[3], col[2], col[1], col[0]));
                }
            }
            bitmap.Save(filname);
        }

    }
}
