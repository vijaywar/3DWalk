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
                Console.WriteLine(Constants.ResultMessage+Walk3D.GetPathSum(Cuboid));
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorFirstMessage + ex.StackTrace + Constants.ErrorMessage+ ex.Message);
            }
        }
    }
}
     