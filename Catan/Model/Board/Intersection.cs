using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Catan.Model.Box.Pieces;

namespace Catan.Model.Board
{
    internal class Intersection
    {
        public enum Position
        {
            NORTH, SOUTH
        }

        public readonly Position facing;
        public bool isBuildable;
        public Structure structure;

        public Intersection(Position facing)
        {
            this.facing = facing;
            isBuildable = true;
            structure = Structure.NONE;
        }
    }
}
