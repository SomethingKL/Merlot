using Catan.Model.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Catan.Controller.Mover.Tracer;
using static Catan.Model.Board.Intersection;
using static Catan.Model.Box.Pieces;

namespace Catan.Controller.Mover
{
    internal class TileMap
    {
        public int tileCount;
        public Tracer tracer;
        private Tile[][] tiles;
        private Intersection[][] intersections;
        private Route[][] routes;

        public TileMap(int boardHeight, int boardWidth)
        {
            tracer = new Tracer(boardHeight, boardWidth);
            initTiles();
            initIntersections();
            initRoutes();
        }

        public Tile[] this[int row]
        {
            get => tiles[row];
        }

        public Tile this[int row, int col]
        {
            get => tiles[row][col];
            set => tiles[row][col] = value;
        }

        private void initTiles()
        {
            tiles = new Tile[tracer.height][];
            tracer.forEachRow(() =>
            {
                int rowSize = tracer.getRowSize();
                tiles[tracer.row] = new Tile[rowSize];
                tileCount += rowSize;
            });
        }

        private void initIntersections()
        {
            Action<int, Position> initRow = (index, facing) =>
            {
                for (int c = 0; c < intersections[index].Length; c++)
                    intersections[index][c] = new Intersection(facing);
            };

            intersections = new Intersection[tracer.height * 2 + 2][];
            intersections[0] = new Intersection[tracer.getRowSize(0)];
            initRow(0, Position.NORTH);

            tracer.forEachRow(() =>
            {
                int rowSize = tracer.getRowSize();
                intersections[1 + tracer.row * 2] = new Intersection[rowSize + 1];
                initRow(1 + tracer.row * 2, Position.SOUTH);

                intersections[2 + tracer.row * 2] = new Intersection[rowSize + 1];
                initRow(2 + tracer.row * 2, Position.NORTH);
            });

            intersections[intersections.Length - 1] = new Intersection[tracer.getRowSize(tracer.height - 1)];
            initRow(intersections.Length - 1, Position.SOUTH);
        }

        private void initRoutes()
        {
            Action<int> initRow = (index) =>
            {
                for (int c = 0; c < routes[index].Length; c++)
                    routes[index][c] = new Route();
            };

            routes = new Route[tracer.height * 2 + 1][];

            tracer.forEachRow(() =>
            {
                int rowDelta = tracer.compareRowSize(Direction.NORTH), rowSize = tracer.getRowSize();
                routes[tracer.row * 2] = new Route[rowSize * 2 + (rowDelta < 0 ? 0 : rowDelta > 0 ? 2 : 1)];
                initRow(tracer.row * 2);

                routes[1 + tracer.row * 2] = new Route[rowSize + 1];
                initRow(1 + tracer.row * 2);
            });

            routes[routes.Length - 1] = new Route[tracer.getRowSize(tracer.height - 1) * 2];
            initRow(routes.Length - 1);
        }
    }
}
