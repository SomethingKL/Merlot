using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Catan.Model.Box.Pieces;

namespace Catan.Model.Board
{
    internal class Dock
    {
        public readonly Resource resource;
        public readonly int cost;

        public Dock(Resource resource, int cost)
        {
            this.resource = resource;
            this.cost = cost;
        }
    }
}
