using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Catan.Model.Box.Pieces;

namespace Catan.Model.Board
{
    internal class Tile
    {
        public readonly Terrain terrain;
        public readonly Yield yield;
        public bool hasRobber;

        public Tile(Terrain terrain, int yield)
        {
            this.terrain = terrain;
            this.yield = new Yield(yield);
            hasRobber = false;
        }
    }
}
