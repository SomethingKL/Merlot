using Catan.Controller.Mover;
using Catan.Controller.Printer;
using Catan.Model.Board;
using Catan.Model.Box;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Catan.Model.Box.Pieces;

namespace Catan.Controller.Balancer
{
    internal class Cartographer
    {
        private TileMap map;

        public Cartographer(int boardHeight, int boardWidth)
        {
            map = new TileMap(boardHeight, boardWidth);
            shuffleTiles();
        }

        public void Scribe()
        {
            BoardPrinter.Print(map);
        }

        public void shuffleTiles()
        {
            IEnumerator<Terrain> terrain = Stock.getTerrain(map.tileCount);
            map.tracer.forEachTile(() =>
            {
                map[map.tracer.row][map.tracer.col] = new Tile(terrain.Current, terrain.Current == Terrain.DESERT ? -1 : 3);
                terrain.MoveNext();
            });
        }
    }
}
