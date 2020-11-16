using Potok.Figury;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Potok
{
    public class Rasteryzer
    {

        Buffor _buffor;
        private List<Triangle> _triangleList;
        public List<Triangle> TriangleList { get => _triangleList; set => _triangleList = value; }

        public Rasteryzer(Buffor buffor)
        {
            _buffor = buffor;
            _triangleList = new List<Triangle>() ;
        }

        public Rasteryzer(Buffor buffor, List<Triangle> triangles)
        {
            _buffor = buffor;
            _triangleList = triangles;
        }


        public void Draw()
        {
            foreach (Triangle triangle in _triangleList)
                    triangle.Draw(_buffor);
        }  
        

        public void Clean()
        {
            _triangleList.Clear();
        }
    }
}
