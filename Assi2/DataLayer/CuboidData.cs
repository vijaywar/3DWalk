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
        public  int CurrentX,CurrentY,CurrentZ;//Location coordinates x y z
        public  CuboidData(int x,int y,int z)
        {
            Cuboiddata = new int[y,z,x]; 
            Width = x;
            Height = y;
            Depth = z;
            CurrentX = x / 2;  //x coordinate center value
            CurrentY = y / 2;  //y coordinate center value
            CurrentZ = z / 2;  //z coordinate center value
            Visited.Add(GetPath(CurrentX,CurrentY,CurrentZ));//center of the cube
        }
        public static string GetPath(int x,int y,int z)
        {
            return x.ToString() + y.ToString() + z.ToString();
        }
        
       
    }
}
