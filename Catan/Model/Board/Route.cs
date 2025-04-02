using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Catan.Model.Box.Pieces;

namespace Catan.Model.Board
{
    internal class Route
    {
        public enum AdjacentTiles
        {
            LAND, SEA, BOTH
        }

        public Infrastructure infrastructure;
        public readonly AdjacentTiles between;

        public Route()
        {
            infrastructure = Infrastructure.NONE;
            between = AdjacentTiles.SEA;
        }
    }
}
