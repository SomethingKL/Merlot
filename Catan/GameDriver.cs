using Catan.Controller.Balancer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan
{
    public class GameDriver
    {
        public static void doTheThing()
        {
            Cartographer cartographer = new Cartographer(50, 70);
            cartographer.Scribe();
        }
    }
}
