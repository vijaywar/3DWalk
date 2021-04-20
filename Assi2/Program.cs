using System;
using System.Collections.Generic;
using System.Linq;
using Assi2.Controller;
using Assi2.DataLayer;
using Assi2.Business;
namespace Assi2
{
    using Utility;
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(Constants.GreetingsMessage);
                CuboidData Cuboid  = DataInput.DataIn();        //Takes data of cube 
                Walk3D Walk = new Walk3D();
                int PathWalkSum = Walk.GetPathSum(Cuboid);
                Console.WriteLine(Constants.ResultMessage+PathWalkSum);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorFirstMessage + ex.StackTrace + Constants.ErrorMessage+ ex.Message);
            }
        }
    }
}
     