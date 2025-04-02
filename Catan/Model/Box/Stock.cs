using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Catan.Model.Box.Pieces;

namespace Catan.Model.Box
{
    internal class Stock
    {
        public static readonly Dictionary<Resource, int> resource = new Dictionary<Resource, int>()
        {
            { Resource.BRICK, 24 }, { Resource.WOOD, 24 }, { Resource.SHEEP, 24 },
            { Resource.WHEAT, 24 }, { Resource.ORE,  24 }
        };

        public static readonly Dictionary<Resource, int> tiles = new Dictionary<Resource, int>()
        {
            { Resource.BRICK, 24 }, { Resource.WOOD, 24 }, { Resource.SHEEP, 24 },
            { Resource.WHEAT, 24 }, { Resource.ORE,  24 }
        };

        public static IEnumerator<Terrain> getTerrain(int tileCount)
        {
            List<Terrain> terrain = new List<Terrain>();
            int track = 0;
            Random random = new Random(Guid.NewGuid().GetHashCode());

            Terrain[] order =
            {
                Terrain.SEA,
                Terrain.FORREST, Terrain.PASTURE, Terrain.SEA,
                Terrain.CROPFIELD, Terrain.MOUNTAIN,

                Terrain.FORREST, Terrain.PASTURE, Terrain.SEA,
                Terrain.CROPFIELD, Terrain.MOUNTAIN,
                
                Terrain.FORREST, Terrain.PASTURE, Terrain.SEA,
                Terrain.CROPFIELD, Terrain.MOUNTAIN,
                
                Terrain.FORREST, Terrain.PASTURE, Terrain.SEA,
                Terrain.SEA,
                Terrain.FORREST, Terrain.PASTURE, Terrain.SEA,

                Terrain.DESERT,
                Terrain.FORREST, Terrain.PASTURE, Terrain.SEA,
                Terrain.CROPFIELD, Terrain.MOUNTAIN,

                Terrain.FORREST, Terrain.PASTURE, Terrain.SEA,
                Terrain.CROPFIELD, Terrain.MOUNTAIN,
                Terrain.GOLDMINE
            };

            while(tileCount-- > 0)
                terrain.Add(order[track = (track + 1) % order.Length]);

            return terrain.OrderBy(_ => random.Next()).AsEnumerable().GetEnumerator();
        }

        public static S[] shuffle<S>(S[] toShuffle)
        {
            if (toShuffle is null)
                return toShuffle;

            Random random = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < toShuffle.Length; i++)
            {
                S originalValue = toShuffle[i];
                int randomIndex = random.Next(toShuffle.Length);
                toShuffle[i] = toShuffle[randomIndex];
                toShuffle[randomIndex] = originalValue;
            }
            return toShuffle;
        }
    }
}
