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
                CuboidData obj = DataInput.DataIn();        //Takes data of cube 
                Console.WriteLine(Constants.ResultMessage+Walk3D.GetPathSum(obj));
            }
            catch (Exception e)
            {
                Console.WriteLine(Constants.ErrorFirstMessage + e.StackTrace + Constants.ErrorMessage+ e.Message);
            }
        }
    }
}
     