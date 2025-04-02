using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.Box
{
    internal static class Pieces
    {
        public enum Resource
        {
            BRICK, WOOD, SHEEP, WHEAT, ORE, GOLD
        }

        public enum Terrain
        {
            SEA, CLAYPIT, FORREST, PASTURE, CROPFIELD, MOUNTAIN, DESERT, GOLDMINE
        }

        public static readonly IReadOnlyDictionary<Terrain,string> TerrainEncoding = new Dictionary<Terrain,string>()
        {
            { Terrain.SEA, "~  " }, { Terrain.CLAYPIT, "CLY" }, { Terrain.FORREST, "FOR" }, { Terrain.PASTURE, "PAS" },
            { Terrain.CROPFIELD, "CRP" }, { Terrain.MOUNTAIN, "MNT" }, { Terrain.DESERT, "DES" }, { Terrain.GOLDMINE, "GLD" }
        };

        public enum Infrastructure
        {
            NONE, ROAD, BOAT
        }

        public enum Structure
        {
            NONE, SETTLEMENT, CITY
        }

        public class Yield
        {
            public readonly int roll, pips;

            public Yield(int roll)
            {
                this.roll = roll;
                this.pips = YieldToken[roll];
            }
        }

        private static readonly IReadOnlyDictionary<int,int> YieldToken = new Dictionary<int,int>()
        {
            {  2, 1 }, {  3, 2 }, {  4, 3 }, { 5, 4 }, { 6, 5 },
            { 12, 1 }, { 11, 2 }, { 10, 3 }, { 9, 4 }, { 8, 5 }, {-1, -1}
        };
    }
}
