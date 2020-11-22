using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using Potok.Matematic;

namespace Potok
{
    public class Buffor
    {
        Float3[][] _color;
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
        public Float3[][] Color { get => _color; }
        public float[][] Depth { get => _depth; }

        public Buffor(int w, int h)
        {
            _width = w;
            _heigth = h;
            _lenght = w * h;
            _color = new Float3[_width][];
            for (int i = 0; i < _color.Length; i++)
            {
                _color[i] = new Float3[_heigth];
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
            _color = new Float3[_width][];
            for (int i = 0; i < _color.Length; i++)
            {
                _color[i] = new Float3[_heigth];
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


        public void SetPixel(byte R, byte G, byte B, int x, int y)
        {
            byte[] colors = new byte[4] { B, G, R, 255 };
            _color[x][y] = new Float3(R, G, B);
        }

        public void SetPixel(byte R, byte G, byte B, float depth, int x, int y)
        {
            byte[] colors = new byte[4] { B, G, R, 255 };
            _color[x][y] = new Float3(R, G, B);
            this._depth[x][y] = depth;
        }

        public void SetColor(byte R, byte G, byte B)
        {
            Float3 col = new Float3(R, G, B);
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
            Float3 ClaerColor = new Float3(0, 0, 0);
            for (int i = 0; i < _color.Length; i++)
            {
                for (int j = 0; j < this._color[i].Length; j++)
                {
                    _color[i][j] = ClaerColor;
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
                    bitmap.SetPixel(i, j, System.Drawing.Color.FromArgb((int)Color[i][j].X, (int)Color[i][j].Y, (int)Color[i][j].Z) );
                }
            }
            bitmap.Save(filname);
        }

    }
}
