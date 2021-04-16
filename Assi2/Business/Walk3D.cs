using Assi2.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi2.Business
{
    static class Walk3D
    {
        static int MaxValue, Nexta, Nextb, Nextc, PathTotal;//temporary max value and store temporary array indexs of next move
        static bool checkedd;//static variable that gives path ened or not.

        /// <summary>
        /// Checks the visited list for the given path exists or not
        /// </summary>
        /// <param name="a">x index</param>
        /// <param name="b">y index</param>
        /// <param name="c">z index</param>
        /// <param name="obj">Cuboiddata object</param>
        /// <returns>returns bool value visited given cube visited or not </returns>
        public static bool Visited(int a,int b,int c,CuboidData obj)
        {
            return obj.Visited.Contains(CuboidData.GetPath(a,b,c));
        }
       

        /// <summary>
        /// Searches for the path with high value
        /// </summary>
        /// <param name="tempa">x index</param>
        /// <param name="tempb">y index</param>
        /// <param name="tempc">z index</param>
        /// <param name="obj">Cuboiddata object</param>
        public static void FindPath(int tempa,int tempb,int tempc,CuboidData obj)
        {
            if (MaxValue < obj.Cuboiddata[tempb, tempc, tempa] && !Visited(tempb, tempc, tempa, obj))
            {
                MaxValue = obj.Cuboiddata[tempb, tempc, tempa];
                Nexta = tempa;
                Nextb = tempb;
                Nextc = tempc;
                checkedd = false;//Path ends or not value
            }
            else if (MaxValue < obj.Cuboiddata[tempb, tempc, tempa]) { 
                MaxValue = obj.Cuboiddata[tempb, tempc, tempa];
                checkedd = true;//sets path ended
            }
            else if (MaxValue == obj.Cuboiddata[tempb, tempc, tempa])
            {
                checkedd = true;//sets path ended
            }
        }
        public static int GetPathSum(CuboidData obj)
        {
            Console.WriteLine("path now is "+CuboidData.GetPath(obj.Tempb,obj.Tempa,obj.Tempc)); //prints the current positon to screen
            PathTotal += obj.Cuboiddata[obj.Tempb,obj.Tempc,obj.Tempa];             //adds the current position value to total
            obj.Visited.Add(CuboidData.GetPath(obj.Tempb,obj.Tempc,obj.Tempa)); //adds path to the visited list of cuboiddata object
            checkedd= true; //path end or not if path don't exists it will be true else be chaned to false.

            MoveNext(obj);
            if (!checkedd)//checkedd is a vaiable that gives true when the walk ends.
            {
                Console.WriteLine("High value :"+MaxValue + " in " + Nextb + "" + Nexta + "" + Nextc);
                obj.Tempa = Nexta;
                obj.Tempb = Nextb;
                obj.Tempc = Nextc;
                MaxValue = 0;
                return GetPathSum(obj);
            }
            else
            {
                return PathTotal;
            }

        }
        /// <summary>
        /// serches all 6 cubes corresponding to our inital cube for max value and it is visited or not 
        /// and sets the global temporary values to the available options.
        /// </summary>
        /// <param name="obj">Cuboid object</param>
        public static void MoveNext(CuboidData obj)
        {
            CheckRightAndLet(obj);
            CheckDeeperAndShallower(obj);
            CheckUpAndDown(obj);
        }
        public static void CheckUpAndDown(CuboidData obj)
        {
            ///bbelow 2 if blocks checks for up and down has max value and not visited
           int Incrementer = 1;
            while (obj.Tempc + Incrementer < obj.Depth)
            {
                FindPath(obj.Tempa, obj.Tempb, obj.Tempc + Incrementer, obj);
                Incrementer++;
            }
            Incrementer = 1;
            while (obj.Tempc - Incrementer >= 0)
            {
                FindPath(obj.Tempa, obj.Tempb, obj.Tempc - Incrementer, obj);
                Incrementer++;
            }
        }
        public static void CheckRightAndLet(CuboidData obj)
        {
            int Incrementer = 1;
            //checks left and right
            while (obj.Tempa + Incrementer < obj.Width)
            {
                FindPath(obj.Tempa + Incrementer, obj.Tempb, obj.Tempc, obj);
                Incrementer++;
            }
            Incrementer = 1;
            while (obj.Tempa - Incrementer >= 0)
            {
                FindPath(obj.Tempa - Incrementer, obj.Tempb, obj.Tempc, obj);
                Incrementer++;
            }
        }
        public static void CheckDeeperAndShallower(CuboidData obj)
        {
           int Incrementer = 1;
            //checks for deeper and shallower
            while (obj.Tempb + Incrementer < obj.Height)
            {
                FindPath(obj.Tempa, obj.Tempb + Incrementer, obj.Tempc, obj);
                Incrementer++;
            }
            Incrementer = 1;
            while (obj.Tempb - Incrementer >= 0)
            {
                FindPath(obj.Tempa, obj.Tempb - Incrementer, obj.Tempc, obj);
                Incrementer++;
            }
        }

    }
}
