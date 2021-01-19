using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok
{
    public class Buffer
    {
        private uint _width;
        private uint _height;
        private uint _minx, _maxx, _miny, _maxy;
        private MyColor[,] _color;
        private float[,] _depth;

        public uint Width { get => _width; set => _width = value; }
        public uint Heigth { get => _height; set => _height = value; }
        public uint MinX { get => _minx; }
        public uint MaxX { get => _maxx; }
        public uint MinY { get => _miny; }
        public uint MaxY { get => _maxy; }

        public MyColor[,] Color { get => _color; set => _color = value; }
        public float[,] Depth { get => _depth; set => _depth = value; }

        public Buffer(uint width, uint height)
        {
            _width = width;
            _height = height;
            _minx = 0;
            _maxx = _width - 1;
            _miny = 0;
            _maxy = height - 1;
            _color = new MyColor[_width, _height];
            _depth = new float[_width, _height];
        }



        public void ClearColor()
        {
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    _color[i, j] = new MyColor(0,0,0);
                }
            }
        }

        public void SetColor(MyColor color)
        {
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    _color[i, j] = new MyColor(color);
                }
            }
        }

        public void ClearDepth()
        {
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    _depth[i, j] = 2.0f;
                }
            }
        }

        public void SetDepth(float depth)
        {
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    _depth[i, j] = depth;
                }
            }
        }

        public void SetPixel(LightIntensity c, float depth, int x, int y)
        {
            _color[x, y] = new MyColor((uint)c.R, (uint)c.G, (uint)c.B);
            _depth[x, y] = depth;
        }

        public void Save(string name)
        {
            Bitmap bitmap = new Bitmap((int)_width, (int)_height);
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    bitmap.SetPixel(i, j, _color[i, j].ToColor());
                }
            }
            
            bitmap.Save(name);
        }


        public void Load(string path)
        {
            Bitmap bitmap = new Bitmap(path);
            for(int i = 0; i<bitmap.Width ; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    _color[i, j] = new MyColor(bitmap.GetPixel(i, j));
                }
            }

        }
    }
}
