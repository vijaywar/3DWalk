using Assi2.DataLayer;
using Assi2.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi2.Business
{
    class Walk3D
    {
        static int MaxValue, Nexta, Nextb, Nextc, PathTotal;//temporary max value and store temporary array indexs of next move
        static bool Pathend;//static variable that gives path ened or not.

        /// <summary>
        /// Checks the visited list for the given path exists or not
        /// </summary>
        /// <param name="a">x index</param>
        /// <param name="b">y index</param>
        /// <param name="c">z index</param>
        /// <param name="cuboid">Cuboiddata object</param>
        /// <returns>returns bool value visited given cube visited or not </returns>
        private bool Visited(int a,int b,int c,CuboidData cuboid)
        {
            return cuboid.Visited.Contains(CuboidData.GetPath(a,b,c));
        }
       

        /// <summary>
        /// Searches for the path with high value
        /// </summary>
        /// <param name="tempa">x index</param>
        /// <param name="tempb">y index</param>
        /// <param name="tempc">z index</param>
        /// <param name="obj">Cuboiddata object</param>
        private void FindPath(int tempa,int tempb,int tempc,CuboidData obj)
        {
            if (MaxValue < obj.Cuboiddata[tempb, tempc, tempa] && !Visited(tempb, tempc, tempa, obj))
            {
                MaxValue = obj.Cuboiddata[tempb, tempc, tempa];
                Nexta = tempa;
                Nextb = tempb;
                Nextc = tempc;
                Pathend = false;//Path ends or not value
            }
            else if (MaxValue < obj.Cuboiddata[tempb, tempc, tempa]) { 
                MaxValue = obj.Cuboiddata[tempb, tempc, tempa];
                Pathend = true;//sets path ended
            }
            else if (MaxValue == obj.Cuboiddata[tempb, tempc, tempa])
            {
                Pathend = true;//sets path ended
            }
        }
        /// <summary>
        /// This functions finds the 3D max walk
        /// </summary>
        /// <param name="cuboid">Cuboid object to walk</param>
        /// <returns>Total of 3d Max walk</returns>
        public int GetPathSum(CuboidData cuboid)
        {
            Console.WriteLine(Constants.PathNow+CuboidData.GetPath(cuboid.Tempb,cuboid.Tempc,cuboid.Tempa)); //prints the current positon to screen
            PathTotal += cuboid.Cuboiddata[cuboid.Tempb,cuboid.Tempc,cuboid.Tempa];             //adds the current position value to total
            cuboid.Visited.Add(CuboidData.GetPath(cuboid.Tempb,cuboid.Tempc,cuboid.Tempa)); //adds path to the visited list of cuboiddata object
            Pathend= true; //path end or not if path don't exists it will be true else be chaned to false.

            MoveNext(cuboid);
            if (!Pathend)//checkedd is a vaiable that gives true when the walk ends.
            {
                Console.WriteLine(Constants.HighValue+MaxValue +Constants.In + Nextb + "" + Nextc + "" + Nexta);
                cuboid.Tempa = Nexta;
                cuboid.Tempb = Nextb;
                cuboid.Tempc = Nextc;
                MaxValue = 0;
                return GetPathSum(cuboid);
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
        private  void MoveNext(CuboidData obj)
        {
            CheckRightAndLet(obj);
            CheckDeeperAndShallower(obj);
            CheckUpAndDown(obj);
        }
        /// <summary>
        /// Checks above and below the current location for next max value to move and store value in static global variables.
        /// </summary>
        /// <param name="cuboid">Takes cudoid object</param>
         private void CheckUpAndDown(CuboidData cuboid)
        {
           int Incrementer = 1;
            while (cuboid.Tempc + Incrementer < cuboid.Depth)
            {
                FindPath(cuboid.Tempa, cuboid.Tempb, cuboid.Tempc + Incrementer, cuboid);
                Incrementer++;
            }
            Incrementer = 1;
            while (cuboid.Tempc - Incrementer >= 0)
            {
                FindPath(cuboid.Tempa, cuboid.Tempb, cuboid.Tempc - Incrementer, cuboid);
                Incrementer++;
            }
        }
        /// <summary>
        /// checks right and left side of our current position for next highest value and store it in static global variables.
        /// </summary>
        /// <param name="cuboid">Takes cuboid object</param>
        private void CheckRightAndLet(CuboidData cuboid)
        {
            int Incrementer = 1;
            //checks left and right
            while (cuboid.Tempa + Incrementer < cuboid.Width)
            {
                FindPath(cuboid.Tempa + Incrementer, cuboid.Tempb, cuboid.Tempc, cuboid);
                Incrementer++;
            }
            Incrementer = 1;
            while (cuboid.Tempa - Incrementer >= 0)
            {
                FindPath(cuboid.Tempa - Incrementer, cuboid.Tempb, cuboid.Tempc, cuboid);
                Incrementer++;
            }
        }
        /// <summary>
        /// checks deeper and shollower cubes for highest value to move next and store result in global varibales.
        /// </summary>
        /// <param name="cuboid">Takes cuboiddata object</param>
        private void CheckDeeperAndShallower(CuboidData cuboid)
        {
           int Incrementer = 1;
            while (cuboid.Tempb + Incrementer < cuboid.Height)
            {
                FindPath(cuboid.Tempa, cuboid.Tempb + Incrementer, cuboid.Tempc, cuboid);
                Incrementer++;
            }
            Incrementer = 1;
            while (cuboid.Tempb - Incrementer >= 0)
            {
                FindPath(cuboid.Tempa, cuboid.Tempb - Incrementer, cuboid.Tempc, cuboid);
                Incrementer++;
            }
        }

    }
}
