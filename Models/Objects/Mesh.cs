using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok
{
    public class Mesh
    {
        public string Name;
        public List<Triangle> Triangles;
        public string Group;
        public string MtlLib;
        public string Mtl;

        public Mesh()
        {
            Name = string.Empty;
            Triangles = new List<Triangle>();
            Group = string.Empty;
            MtlLib = string.Empty;
            Mtl = string.Empty;
        }

        public Mesh(List<Triangle> triangles)
        {
            Name = string.Empty;
            Triangles = triangles;
            Group = string.Empty;
            MtlLib = string.Empty;
            Mtl = string.Empty;
        }

        public Mesh(string name, string group, List<Triangle> triangles, string mtlLib, string mtl)
        {
            Name = name;
            Group = group;
            Triangles = triangles;
            MtlLib = mtlLib;
            Mtl = mtl;
        }
    }
}
