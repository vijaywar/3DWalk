using System;
using System.Collections.Generic;
using System.Text;

namespace Assi2.DataLayer
{
    class CuboidData
    {
        public  int[,,] Cuboiddata;
        public int Width, Height, Depth;
        public List<string> Visited = new List<string>();
        public  int Tempa,Tempb,Tempc;//Location coordinates x y z
        public  CuboidData(int a,int b,int c)
        {
            Cuboiddata = new int[b,c,a]; 
            Width = a;
            Height = b;
            Depth = c;
            Tempa = a / 2;  //x coordinate center value
            Tempb = b / 2;  //y coordinate center value
            Tempc = c / 2;  //z coordinate center value
            Visited.Add(GetPath(Tempa,Tempb,Tempc));//center of the cube
        }
        public static string GetPath(int a,int b,int c)
        {
            return a.ToString() + b.ToString() + c.ToString();
        }
        
       
    }
}
