using System;
using System.Collections.Generic;

namespace Catan.Controller.Mover
{
    internal class Tracer
    {
        public enum Direction
        {
            NORTH, NORTH_EAST, EAST, SOUTH_EAST, SOUTH, SOUTH_WEST, WEST, NORTH_WEST
        }

        public int row, col;
        public readonly int height, width;
        private readonly int mid;//, flat;
        private readonly bool evenHeight;
        private Dictionary<int,int> rowSizes;

        public Tracer(int vertical, int horizontal)
        {
            height = vertical < 3 ? 3 : (vertical > 190 ? 190 : vertical);
            int minWidth = getMinWidth(height);
            width = horizontal < minWidth ? minWidth : (horizontal > 270 ? 270 : horizontal);

            evenHeight = height % 2 == 0;
            mid = height / 2 - (evenHeight ? 1 : 0);
            //flat = evenHeight ? height / 12 : height / 7;

            row = 0;
            col = 0;
            rowSizes = new Dictionary<int,int>();
        }

        public void forEachRow(Action action)
        {
            int previousRow = row;
            row = 0;
            while (row < height)
            {
                action();
                row++;
            }
            row = previousRow;
        }

        public void forEachTile(Action action)
        {
            int previousCol = col;
            forEachRow(() =>
            {
                col = 0;
                while(col < getRowSize())
                {
                    action();
                    col++;
                }
            });
            col = previousCol;
        }

        public void forEachCol(Action action)
        {
            int previousCol = col;
            col = 0;
            while (col < getRowSize())
            {
                action();
                col++;
            }
            col = previousCol;
        }

        public void move(Direction direction)
        {
            int delta = mid - row;

            switch (direction)
            {
                case Direction.NORTH:
                    row--;
                    break;
                case Direction.NORTH_EAST:
                    row--;
                    if (delta < 0)
                        col++;
                    break;
                case Direction.EAST:
                    col++;
                    break;
                case Direction.SOUTH_EAST:
                    row++;
                    if (delta > 0)
                        col++;
                    break;
                case Direction.SOUTH:
                    row++;
                    break;
                case Direction.SOUTH_WEST:
                    row++;
                    if (delta <= 0)
                        col--;
                    break;
                case Direction.WEST:
                    col--;
                    break;
                case Direction.NORTH_WEST:
                    row--;
                    if (delta >= 0)
                        col--;
                    break;
            }
        }

        public bool canMove(Direction direction)
        {
            int delta = mid - row;

            switch (direction)
            {
                case Direction.NORTH:
                    return row > 0 && col < getRowSize(row - 1);
                case Direction.NORTH_EAST:
                    return row > 0 && col + (delta < 0 ? 1 : 0) < getRowSize(row - 1);
                case Direction.EAST:
                    return col + 1 < getRowSize();
                case Direction.SOUTH_EAST:
                    return row < height - 1 && col + (delta > 0 ? 1 : 0) < getRowSize(row + 1);
                case Direction.SOUTH:
                    return row < height - 1 && col < getRowSize(row + 1);
                case Direction.SOUTH_WEST:
                    return row < height - 1 && (delta > 0 || col > 0);
                case Direction.WEST:
                    return col > 0;
                case Direction.NORTH_WEST:
                    return row > 0 && (delta < 0 || col > 0);
                default:
                    return true;
            }
        }

        public int compareRowSize(Direction direction)
        {
            switch (direction)
            {
                case Direction.NORTH:
                case Direction.NORTH_EAST:
                case Direction.NORTH_WEST:
                    return getRowSize(row - 1) - getRowSize();
                case Direction.SOUTH_EAST:
                case Direction.SOUTH:
                case Direction.SOUTH_WEST:
                    return getRowSize(row + 1) - getRowSize();
                default:
                    return 0;
            }
        }

        public int getRowOffset()
        {
            int delta = mid - row;
            return delta < 0 ? -delta : delta;
        }

        public int getRowSize()
        {
            return getRowSize(row);
        }

        public int getRowSize(int index)
        {
            if (index < 0 || index >= height)
                return 0;

            if (rowSizes.ContainsKey(index))
                return rowSizes[index];

            int delta = mid - index;
            //int expectedSize = width - (delta < 0 ? (evenHeight ? -delta - 1 : -delta) : delta);
            //return rowSizes[index] = delta < flat && delta > -flat ? expectedSize - 2 * flat : expectedSize;
            return rowSizes[index] = width - (delta < 0 ? (evenHeight ? -delta - 1 : -delta) : delta);
        }

        public int getColSize()  
        {
            return getColSize(col);
        }

        public int getColSize(int index)
        {
            int delta = getRowSize(0) - index - 1;
            return height - (delta < 0 ? -2 * delta : 0);
        }

        public static int getMinWidth(int vertical)
        {
            return vertical / 2 + vertical % 2;
        }
    }
}
