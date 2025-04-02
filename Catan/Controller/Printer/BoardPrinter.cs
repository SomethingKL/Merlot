using Catan.Controller.Mover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Catan.Model.Box.Pieces;
using static Catan.Controller.Mover.Tracer;

namespace Catan.Controller.Printer
{
    internal class BoardPrinter
    {
        public static void Print(TileMap map)
        {
            List<string> toPrint = new List<string>();
            string[] lines;
            map.tracer.forEachRow(() =>
            {
                int rowOffset = map.tracer.getRowOffset(), rowDelta = map.tracer.compareRowSize(Direction.NORTH);
                lines = new string[]
                {
                    new string(' ', rowOffset * 3 + 1) + (rowDelta < 0 ? ' ' : '\\'),
                    new string(' ', rowOffset * 3 + 2) + (rowDelta < 0 ? ' ' : '\\'),
                    new string(' ', (rowOffset + 1) * 3),
                    new string(' ', (rowOffset + 1) * 3)
                };

                map.tracer.forEachCol(() =>
                {
                    lines[0] += "   / \\";
                    lines[1] += " /   \\";
                    lines[2] += "| " + TerrainEncoding[map[map.tracer.row][map.tracer.col].terrain] + ' ';
                    
                    if(map[map.tracer.row][map.tracer.col].terrain == Terrain.SEA)
                        lines[3] += "|   ~ ";
                    else if(map[map.tracer.row][map.tracer.col].yield.roll < 0)
                        lines[3] += "|  -  ";
                    else
                        lines[3] += "|  " + map[map.tracer.row][map.tracer.col].yield.roll.ToString() + "  ";
                });

                if (rowDelta > 0)
                {
                    lines[0] += "   /";
                    lines[1] += " /";
                }
                lines[2] += '|';
                lines[3] += '|';
                toPrint.AddRange(lines);
            });

            map.tracer.row = map.tracer.height - 1;
            lines = new string[]
            {
                new string(' ', map.tracer.getRowOffset() * 3 + 3),
                new string(' ', map.tracer.getRowOffset() * 3 + 2)
            };

            map.tracer.forEachCol(() =>
            {
                lines[0] += " \\   /";
                lines[1] += "   \\ /";
            });

            toPrint.AddRange(lines);
            toPrint.ForEach(line => Console.WriteLine(line));
        }
    }
}
