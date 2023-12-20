﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzle
{
    public static class Ext10
    {
        public static bool isin (this int num, int a, int b)
        {
            int min = Math.Min(a, b);
            int max = Math.Max(a, b);
            return (num >= min && num <= max);
        }
    }

    internal class Day11: IDayPuzzle
    {
        public string ExecutePart1()
        {
            List<string> lines = GetInputExpended(1);
            List<Tuple<int, int>> galaxies = GetGalaxies(lines);

            int sum = 0;
            for(int i = 0; i < galaxies.Count - 1; i++)
            {
                for(int j = i+1; j < galaxies.Count; j++)
                {
                    sum += Math.Abs(galaxies[i].Item1 - galaxies[j].Item1);
                    sum += Math.Abs(galaxies[i].Item2 - galaxies[j].Item2);
                }
            }

            return sum.ToString();
        }
        public string ExecutePart2()
        {
            int SPACE = 1000000;
            List<string> lines = GetInputExpended(0);       //Parse seul aurait suffit du coup mais bref :D 
            List<Tuple<int, int>> galaxies = GetGalaxies(lines);

            List<int> horizontals = GetHorizontalSpace(lines);
            List<int> verticals = GetVerticalSpace(lines);

            long sum = 0;
            for (int i = 0; i < galaxies.Count - 1; i++)
            {
                for (int j = i + 1; j < galaxies.Count; j++)
                {
                    int spacesbetweenH = horizontals.Count(x => x.isin(galaxies[i].Item1, galaxies[j].Item1));
                    int spacesbetweenV = verticals.Count(x => x.isin(galaxies[i].Item2, galaxies[j].Item2));

                    sum += Math.Abs(galaxies[i].Item1 - galaxies[j].Item1) + (long)(SPACE - 1) * spacesbetweenH;
                    sum += Math.Abs(galaxies[i].Item2 - galaxies[j].Item2) + (long)(SPACE - 1) * spacesbetweenV;
                }
            }

            return sum.ToString();
        }

        public List<int> GetHorizontalSpace(List<string> lines)
        {
            List<int> spaces = new List<int>();
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].All(c => '.'.Equals(c)))
                {
                    spaces.Add(i);
                }
            }

            return spaces;
        }

        public List<int> GetVerticalSpace(List<string> lines)
        {
            List<int> spaces = new List<int>();
            for (int i = 0; i < lines[0].Length; i++)
            {
                if (lines[0][i] == '.')
                {
                    bool empty = true;
                    for (int j = 0; j < lines.Count; j++)
                    {
                        if (lines[j][i] != '.')
                        {
                            empty = false;
                            break;
                        }
                    }

                    if (empty)
                    {
                        spaces.Add(i);
                    }
                }
            }

            return spaces;
        }

        public List<string> GetInputExpended(int space) {
            List<string> lines = input.Split("\r\n").ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Count(c => '.'.Equals(c)) == lines[i].Length)
                {
                    for(int s = 0; s < space; s++)
                    {
                        lines.Insert(i, string.Join("", Enumerable.Repeat('.', lines[i].Length)));
                    }
                    i += space;
                }
            }

            for (int i = 0; i < lines[0].Length; i++)
            {
                if (lines[0][i] == '.')
                {
                    bool empty = true;
                    for (int j = 0; j < lines.Count; j++)
                    {
                        if (lines[j][i] != '.')
                        {
                            empty = false;
                            break;
                        }
                    }

                    if (empty)
                    {
                        for (int j = 0; j < lines.Count; j++)
                        {
                            for (int s = 0; s < space; s++)
                            {
                                lines[j] = lines[j].Insert(i, ".");
                            }
                        }
                        i += space;
                    }
                }
            }

            return lines;
        }

        List<Tuple<int, int>> GetGalaxies(List<string> inputexp)
        {
            List < Tuple<int, int> > galaxies = new List<Tuple<int, int>>();
            for (int i = 0; i < inputexp.Count; i++)
            {
                for (int j = 0; j < inputexp[i].Length; j++)
                {
                    if (inputexp[i][j] == '#') galaxies.Add(new(i, j));
                }
            }

            return galaxies;
        }

        string input =
@".....................#......#...................#...............#........................................#..................................
...........................................................#.............................................................#..................
.....................................................................#.........#......#...........#.............#...........................
.....................................................#.......................................#..............................................
......#.................................#..........................................................................................#........
....................#.........#.............................................................................#...............................
..#.........................................................#.............................................................................#.
........................................................................................#...........#..................#....................
........#....................................#........................#.........................................................#...........
..............................................................................#................................#............................
..................................................#............#............................................................................
.........................#......#........#................................................#..........................................#......
......#..............................................................................#...............#......................................
...................................................................#........................................................................
....................#...........................#............................................................#..............#.....#.........
..................................#....................#.........................................#......#..............................#....
.#..........................................................................................................................................
........#.....#........................#...........#.............#.....................#....................................................
..........................#.................................#.....................#.........................................................
.............................................................................................................................#.............#
...................................#......................................................#....................#............................
.....................#...................#............#..................#.............................................#...........#........
..............................................................................................#.............................................
....#..........#...............#..........................................................................#.................................
.............................................#..............................................................................................
...................................................................#..............#.................................#.......................
..................#........................................................#................................................................
..#.................................#...................#..............................#.........................................#.......#..
...............................................................#...............#.....................#..........#.........#.................
.........#......................#.............................................................#.............................................
..............#...............................#.............................................................................................
........................................#.................................#............................................................#....
..............................................................................................................#......#......#...............
.........................#..........#.............................................#........#................................................
....................................................................#.....................................#.................................
....#...............#........#...............................#........................#........................................#............
........................................................#...................................................................................
............................................#...........................#......................#.....#......................................
.........................................................................................#.............................................#....
...........#....................#..................................#.................................................#...........#..........
.#..........................................................................................................................................
................#........................#..........#.......................................................................................
........................#........................................................................................#..........................
........................................................................#.........#...................#...................#.................
........................................................#......................................................................#............
.....#.....................................................................................#................................................
...............#...................................#.................#..............................................................#.......
.........#..................#..................................#..................................................#.........................
......................................#.......#....................................#......................................................#.
..........................................................................................................#......................#..........
...#..............#.......................#.....................................................#...........................................
................................#...............................................#..........#................................................
..........................#......................#......................#...................................................................
..................................................................#................................#........................................
......................................................#.................................#.........................#...................#.....
..............#..........................#..................................................................................#...............
......#......................#.................................................................#...........#................................
.............................................................................#..............................................................
.......................#..........................#......................................................................#..........#.......
.#.................................#................................................................#....................................#..
........#......#................................................#...............................................#...........................
..........................................................................#.....#.........................#...........#.....#...............
............................#..............#..........#....................................#................................................
............................................................................................................................................
............#..........#....................................................................................................................
............................................................#.......................#..............#........................................
.....................................#...............................#...................................#..................................
.........#.....................................................................#.....................................#...............#.....#
#.............#.............................................................................................................................
......................................................#....................................#....................................#...........
...................................................................#............................................#...........................
............................................................................................................................................
....................#............................#................................................#......................................#..
.............................#...................................................#..........................................................
.........................................................................#...............#.................#................................
.............#.........#.........#.....#......................#............................................................#................
............................................................................................................................................
.............................................#..........#.....................#..................................#..........................
............................................................................................................................................
...................................#.............#................#.....#.....................................................#.............
....#.....................#..................................#..............................................................................
............................................................................................................................................
#.....................................#...................................................................................#.................
...............................................#......................#.....#...................................#...........................
.........#...................#.....................................................#.................#......................................
.......................#...............................#........................................#..............................#............
...#.....................................#..................................................................#...............................
...................................................#......................................#...........................................#.....
.................#..........................................................................................................................
...................................................................................................................#......#.................
.................................#..............#.....#......................#.................#.........#..................................
#....................................................................#........................................#...........................#.
............................................................................................................................................
.........................#..................................................................................................................
...............................#.......................................................................................#....................
..........#...................................#..................#.....................#....................#...............................
............................................................................#.....#.........................................................
....#............#............................................................................#.......#..........#..........................
..................................................................................................................................#.........
...................................#...........................................#............................................................
.............................#..........................#.................................#........#........................................
..............#....................................................#........................................#.............#...........#.....
...............................................#.............#.......................................................#......................
........#..............................................................#....................................................................
.......................................................................................#........#...........................................
......................#........#.........................#..................#........................#......................#...............
.#.........#.....#..............................................#........................................................................#..
.....................................................#......................................................................................
.........................................#...........................#..............................................#.......................
.............................................................#................................................#................#............
......#.......................................#.......................................#...............#.....................................
....................#.......#............................#................#...........................................................#.....
...........#.....................................................................................................#..........................
..........................................................................................#..............#..................................
..................................................#..........................................................................#..............
...............#............................................#.....................................................................#.........
........................#...........................................#............................#..................#.......................
................................................................................#..............................#.......................#....
......................................#...................................#..............#..............#...................................
..#............................................#..............#...........................................................#.................
.........#........................#...................#.....................................................................................
.............................#..............................................................................................................
....................................................................................#.......................................................
.........................#.............#............................................................#......#......#.........#......#........
...................#...........................................................................#...........................................#
.......#...............................................#.....#........#..........#..........................................................
..............#....................#........................................................................................................
........................................................................................................#.................#...........#.....
..#...............................................................#.........#.......#.......................................................
.........#......................#..........................#.....................................#............#.............................
...................#.................................#.................................................................#....................
....................................#.......................................................................................................
...........................#......................................................................................................#.........
............................................#.................#............#...................#.......#...................#................
............#.....................................#.........................................................................................
...........................................................................................................#......#.........................
.....................................#..............................................#......#................................................
.........................................................................#..............................................#...................
#....................#........#...................................................................#.....................................#...
.....#........................................#.........#........................#..........................................................";

    }
}