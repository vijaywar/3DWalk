using Assi2.DataLayer;
using Assi2.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi2.Controller
{
    static class DataInput
    {
        /// <summary>
        /// Takes input of cuboid data form user and returns the CuboidData object!
        /// </summary>
        /// <returns>Object of CuboidData</returns>
        public static CuboidData DataIn()
        {
            try {
            string str = Console.ReadLine();
            string[] arr = str.Split(" ");
            int a, b, c;
            if (arr.Length == 3) { //checks 3 Width height and depth provided or not.
                a = Convert.ToInt32(arr[0]);
                b = Convert.ToInt32(arr[1]);
                c = Convert.ToInt32(arr[2]);
            }
            else { throw new InvalidFormatException(Constants.InvalidWHD); }//throw error if the format is not correct.
            CuboidData cuboid = new CuboidData(a,b,c);
            for (int i = 0; i < b; i++)
            {
                string Istr = Console.ReadLine();
                string[] Iarr = Istr.Split(" | ");          //split input with | as seperator
                    if (Iarr.Length != c) throw new InvalidFormatException(Constants.InvalidCuboidFormat);
                for (int j = 0; j < Iarr.Length; j++)
                {
                        string[] Jarr = Iarr[j].Split(" ");  //split input with space as seperator
                        if (Jarr.Length != a) throw new InvalidFormatException(Constants.InvalidCuboidFormat);
                    for (int k = 0; k < Jarr.Length; k++)
                    {
                        cuboid.Cuboiddata[i, j, k] = Convert.ToInt32(Jarr[k]);     //adds data to the Cuboiddata Multidimensional array
                    }
                }

            }
            return cuboid;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Custom Exception for Invalid inputs
        /// </summary>
        public class InvalidFormatException : Exception
        {
            public InvalidFormatException(string message) : base(message)
            {
                Console.WriteLine(message);
            }
        }
    }
}
