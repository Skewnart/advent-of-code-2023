﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzle
{
    internal class Day02 : IDayPuzzle
    {
        public string ExecutePart2()
        {
            int sumofgames = 0;

            foreach (string line in input.Split("\r\n"))
            {
                int game = int.Parse(line.Substring(0, line.IndexOf(":")).Split(" ")[1]);
                string linetotest = line.Substring(line.IndexOf(":") + 1).Trim();

                string[] takeoffs = linetotest.Split(";").Select(x => x.Trim()).ToArray();

                Dictionary<string, int> mapping = new Dictionary<string, int>() { { "red", 1 }, { "green", 1 }, { "blue", 1 } };

                foreach (string takeoff in takeoffs)
                {
                    string[] colors = takeoff.Split(",").Select(x => x.Trim()).ToArray();
                    foreach (string color in colors)
                    {
                        var colstr = color.Split(" ");
                        if (mapping[colstr[1]] < int.Parse(colstr[0])) mapping[colstr[1]] = int.Parse(colstr[0]);
                    }
                }

                sumofgames += mapping["red"] * mapping["green"] * mapping["blue"];
            }

            return sumofgames.ToString();
        }
        public string ExecutePart1()
        {
            int r = 12, g = 13, b = 14;
            int sumofgames = 0;

            foreach(string line in input.Split("\r\n"))
            {
                int game = int.Parse(line.Substring(0, line.IndexOf(":")).Split(" ")[1]);
                string linetotest = line.Substring(line.IndexOf(":") + 1).Trim();

                string[] takeoffs = linetotest.Split(";").Select(x => x.Trim()).ToArray();

                bool istocount = true;
                foreach (string takeoff in takeoffs)
                {
                    string[] colors = takeoff.Split(",").Select(x => x.Trim()).ToArray();
                    Dictionary<string, int> mapping = new Dictionary<string, int>();
                    foreach(string color in colors)
                    {
                        var colstr = color.Split(" ");
                        mapping.Add(colstr[1], int.Parse(colstr[0]));
                    }

                    if((mapping.ContainsKey("red") && mapping["red"] > r)
                        || (mapping.ContainsKey("green") && mapping["green"] > g)
                        || (mapping.ContainsKey("blue") && mapping["blue"] > b))
                    {
                        istocount = false;
                    }
                }

                if (istocount)
                {
                    sumofgames += game;
                }
            }

            return sumofgames.ToString();
        }

        string input =
@"Game 1: 4 red, 18 green, 15 blue; 17 green, 18 blue, 9 red; 8 red, 14 green, 6 blue; 14 green, 12 blue, 2 red
Game 2: 6 red, 11 green; 4 blue, 4 green, 5 red; 11 green, 6 blue, 6 red
Game 3: 3 red, 3 green; 3 green, 1 blue, 7 red; 3 green, 5 red, 1 blue; 9 red, 4 green; 1 blue, 2 green, 5 red
Game 4: 2 blue, 5 green, 9 red; 7 red, 10 blue; 2 green, 14 blue, 5 red; 3 blue, 2 green; 4 green, 10 red, 7 blue; 2 green, 15 blue, 7 red
Game 5: 3 red, 2 blue; 5 red, 3 blue; 10 blue, 10 red, 1 green; 4 blue
Game 6: 1 green, 10 blue, 5 red; 8 blue, 9 green; 20 green, 7 red, 10 blue; 12 green, 6 blue, 6 red; 10 blue, 11 green; 8 blue, 17 green, 5 red
Game 7: 7 green, 12 blue, 3 red; 19 red, 12 blue; 8 blue, 8 red, 7 green; 6 red, 7 green, 5 blue
Game 8: 8 blue, 7 red; 13 green, 5 blue, 5 red; 11 blue, 4 green, 7 red; 5 blue, 6 red, 13 green; 7 blue, 12 green, 8 red
Game 9: 3 red, 3 blue, 12 green; 2 red, 1 blue, 9 green; 3 red, 12 green, 3 blue; 2 red, 7 green, 2 blue; 8 green, 4 blue; 2 red, 2 green
Game 10: 16 green, 10 red; 13 green, 7 red; 8 red, 1 blue, 8 green
Game 11: 7 red, 1 blue, 1 green; 6 blue, 1 green, 3 red; 5 blue, 10 red
Game 12: 1 green, 8 red, 5 blue; 6 red, 12 blue; 2 blue, 15 red; 14 blue, 15 red, 1 green; 8 red, 9 blue
Game 13: 1 green, 6 red; 7 blue, 13 red, 1 green; 3 blue, 4 red
Game 14: 11 red, 1 green, 1 blue; 3 blue, 18 red, 15 green; 10 blue, 5 green, 11 red
Game 15: 6 green, 10 blue, 15 red; 6 green, 17 blue, 8 red; 19 red, 7 blue, 2 green; 1 green, 18 red, 4 blue
Game 16: 1 green, 17 red, 7 blue; 12 red, 10 green, 9 blue; 15 red, 3 green, 15 blue
Game 17: 12 blue, 13 green; 16 green, 19 blue, 7 red; 1 green, 2 blue
Game 18: 8 blue, 9 green, 2 red; 9 blue, 7 green; 3 red, 9 green, 10 blue; 1 blue, 7 green, 2 red; 1 green, 8 blue, 4 red
Game 19: 3 green, 2 red, 11 blue; 13 blue, 3 green, 1 red; 1 red, 10 blue
Game 20: 2 red, 4 green, 1 blue; 14 blue, 7 green; 7 blue, 9 green; 4 red, 5 green, 7 blue
Game 21: 4 blue, 20 red, 7 green; 4 green, 6 blue, 14 red; 6 green, 18 red, 5 blue; 2 blue, 4 green, 6 red; 4 green, 16 red, 4 blue
Game 22: 13 red, 2 green; 6 red, 3 blue; 6 red, 2 green; 7 red, 1 green; 6 red, 2 green
Game 23: 5 blue; 6 red, 16 green, 12 blue; 1 blue, 6 green, 2 red; 8 red, 6 blue, 3 green
Game 24: 10 green, 4 blue, 5 red; 1 green, 3 red; 8 red, 3 blue, 6 green; 3 red, 2 blue; 3 red, 10 green, 3 blue
Game 25: 1 red, 2 green; 4 green, 6 red, 1 blue; 3 red; 4 green, 2 red
Game 26: 7 red, 1 blue; 2 red, 1 blue; 9 red, 1 green, 2 blue; 5 red, 2 blue; 4 red, 2 green; 8 red, 1 green, 2 blue
Game 27: 1 green, 2 red, 8 blue; 1 green, 4 red, 9 blue; 16 blue, 12 red, 3 green; 13 blue, 4 green, 5 red
Game 28: 8 blue, 8 green, 3 red; 8 green, 6 blue; 5 green, 6 blue, 4 red
Game 29: 7 red, 11 green, 5 blue; 1 green, 1 blue, 6 red; 6 green, 5 blue, 8 red; 7 blue, 15 green, 2 red; 10 blue, 1 red
Game 30: 7 red, 5 blue, 14 green; 2 blue, 11 red; 17 green, 2 blue, 7 red; 4 blue, 10 red, 5 green
Game 31: 17 blue, 5 red, 2 green; 7 red, 14 blue, 3 green; 13 blue, 5 red, 2 green; 12 green, 8 blue, 8 red
Game 32: 1 red, 7 blue; 1 red, 8 blue; 1 red, 2 green, 13 blue
Game 33: 1 green, 3 blue, 3 red; 4 red, 2 green; 5 blue, 1 red, 1 green; 1 red, 8 blue, 2 green
Game 34: 9 blue, 7 red; 9 green, 11 red, 1 blue; 18 red, 4 blue, 6 green
Game 35: 7 blue, 4 green, 2 red; 1 green, 1 blue, 2 red; 3 green; 3 blue, 7 green, 1 red; 7 blue, 12 green
Game 36: 17 red, 5 blue; 6 red, 5 green, 7 blue; 16 blue, 1 green, 7 red; 7 blue, 5 green, 15 red; 8 blue, 19 red, 1 green
Game 37: 4 blue, 6 red, 1 green; 9 red, 8 green, 4 blue; 1 green, 8 blue, 10 red; 11 green, 6 red, 9 blue
Game 38: 3 red, 4 blue; 5 red, 1 blue; 1 green, 2 red, 5 blue; 2 blue, 8 red; 7 red, 1 blue; 4 blue, 5 red
Game 39: 7 green; 5 green; 3 blue; 12 green, 1 red, 1 blue; 8 green, 1 blue, 1 red
Game 40: 12 red, 11 blue; 6 green, 2 blue, 13 red; 6 green, 7 red, 6 blue
Game 41: 3 green, 1 blue; 5 blue, 7 red, 6 green; 6 red, 14 blue; 9 red, 14 green, 5 blue; 5 blue, 6 green, 3 red; 20 green, 4 blue, 5 red
Game 42: 2 blue, 13 green; 10 red, 6 green; 8 green, 2 red; 7 red
Game 43: 7 green, 3 red; 6 red, 6 green, 13 blue; 7 green, 2 red, 9 blue; 8 blue, 3 green, 1 red; 10 green, 7 red, 13 blue
Game 44: 3 blue, 1 green, 2 red; 10 blue, 9 red; 5 red, 13 blue
Game 45: 11 red, 2 green, 5 blue; 1 green, 6 red, 6 blue; 17 red, 2 green, 6 blue; 14 red, 2 green
Game 46: 5 blue, 7 red, 8 green; 6 green, 1 red, 10 blue; 1 red, 5 blue, 4 green
Game 47: 5 green, 5 red, 1 blue; 11 green, 8 red, 6 blue; 2 green, 16 red, 1 blue; 12 green, 1 red, 7 blue; 2 red, 15 green, 7 blue
Game 48: 3 red, 6 green, 4 blue; 1 blue, 1 green, 2 red; 12 blue, 7 green, 5 red
Game 49: 4 blue, 1 green; 4 red, 2 blue; 3 blue, 2 green; 5 red, 3 blue, 4 green
Game 50: 1 blue, 1 green; 3 blue, 7 red, 1 green; 2 blue, 1 green
Game 51: 17 blue, 1 green, 3 red; 2 green, 1 red, 3 blue; 14 blue, 10 red
Game 52: 8 blue, 1 green; 1 blue, 3 red, 2 green; 2 green, 14 blue
Game 53: 9 green, 3 blue, 9 red; 3 blue, 7 red, 8 green; 2 green, 2 red; 17 green, 3 red; 18 green, 8 red
Game 54: 2 blue, 10 red; 2 green, 2 red; 6 green, 1 blue, 1 red; 3 blue, 6 red, 7 green
Game 55: 3 blue, 1 red; 1 green, 2 red, 1 blue; 4 blue, 3 red; 5 blue, 3 green; 3 green, 1 red, 3 blue; 2 green
Game 56: 10 green, 1 red, 6 blue; 16 green, 1 blue, 10 red; 8 red, 9 green, 2 blue; 3 red, 2 blue
Game 57: 1 blue, 4 green, 1 red; 7 red, 4 green, 8 blue; 9 red, 3 blue, 3 green
Game 58: 15 green, 16 blue, 8 red; 8 blue, 8 red, 2 green; 9 blue, 8 red, 3 green; 20 blue, 15 green, 7 red
Game 59: 13 red, 3 blue; 12 red, 4 green; 9 blue, 5 green, 9 red; 2 red, 12 blue, 1 green
Game 60: 14 green, 16 red; 5 green, 1 blue, 5 red; 14 green, 5 blue, 20 red; 2 blue, 8 green, 1 red
Game 61: 2 green, 10 red, 15 blue; 17 blue, 6 red, 2 green; 2 red, 2 green, 12 blue; 2 red, 2 green
Game 62: 8 blue, 1 green, 3 red; 6 red, 15 blue, 2 green; 5 green, 6 blue; 1 red, 7 green, 8 blue
Game 63: 13 green, 8 red; 8 green, 1 blue, 5 red; 2 green, 8 red, 2 blue
Game 64: 13 red, 12 blue, 4 green; 2 blue, 3 red, 1 green; 4 green, 14 red, 14 blue; 8 red, 4 green; 16 red; 5 blue, 16 red, 4 green
Game 65: 13 red, 2 blue, 3 green; 10 red, 6 blue; 6 blue, 5 red
Game 66: 1 blue, 9 green; 4 green, 5 blue; 8 green, 8 blue; 10 blue, 1 red, 10 green; 18 blue, 1 red, 9 green
Game 67: 12 red, 7 blue; 13 red, 3 blue, 3 green; 7 blue, 6 red, 4 green
Game 68: 3 green, 4 blue, 8 red; 1 green, 2 blue, 13 red; 3 green, 14 red, 4 blue; 6 red, 4 green; 7 blue, 2 red, 1 green; 1 green, 3 blue, 14 red
Game 69: 2 blue, 6 red, 2 green; 7 green, 18 red; 11 green, 1 blue, 13 red; 3 red, 6 green, 1 blue; 19 red, 1 green
Game 70: 13 green; 1 red, 14 green, 2 blue; 9 red, 1 blue, 9 green; 6 green, 5 red, 1 blue; 2 green, 10 red
Game 71: 7 blue, 5 green, 11 red; 4 red, 8 blue, 5 green; 1 green, 1 blue; 6 green, 8 red, 5 blue; 8 red, 7 green, 6 blue
Game 72: 2 blue, 2 green, 1 red; 5 green, 1 red, 3 blue; 4 green
Game 73: 8 green, 3 blue, 3 red; 1 green, 3 red, 9 blue; 3 red, 10 blue, 8 green; 10 green, 3 red, 8 blue; 3 blue, 3 green; 2 green
Game 74: 5 red, 1 green; 1 blue, 5 red; 8 red, 3 blue
Game 75: 5 red, 7 green, 3 blue; 1 red, 5 blue, 4 green; 2 blue, 12 green; 3 blue, 5 red; 8 green, 4 blue, 3 red; 1 green, 2 blue, 1 red
Game 76: 10 green, 5 blue, 1 red; 11 blue, 16 green, 1 red; 12 blue, 2 red, 18 green; 12 green, 10 blue; 5 blue, 5 green, 1 red; 9 green, 1 red, 1 blue
Game 77: 9 blue, 1 red, 2 green; 1 blue, 1 red, 5 green; 5 blue
Game 78: 1 red, 1 blue; 1 blue; 1 red; 1 green, 2 red, 1 blue; 1 blue, 4 red
Game 79: 3 green, 11 red, 4 blue; 7 red, 1 green, 4 blue; 1 green, 3 red, 3 blue; 3 blue, 3 red, 4 green; 3 green, 3 blue, 9 red
Game 80: 11 blue, 10 green, 11 red; 10 green, 9 red, 18 blue; 11 green, 17 blue, 7 red
Game 81: 6 red, 1 blue; 3 blue, 6 red, 2 green; 6 red, 10 green, 1 blue; 5 blue, 3 green, 3 red
Game 82: 6 red, 16 green, 2 blue; 9 green, 6 red, 3 blue; 1 blue, 9 red, 14 green; 8 green, 11 red, 3 blue; 3 red, 5 green; 12 green, 3 blue
Game 83: 7 blue, 5 green, 11 red; 8 red, 9 blue, 13 green; 13 blue, 8 red, 8 green; 2 blue, 9 green, 5 red
Game 84: 9 green, 14 red, 11 blue; 1 green, 12 blue, 6 red; 12 green, 10 red, 7 blue; 15 green, 6 blue; 15 blue, 4 red, 6 green; 16 green, 2 red, 13 blue
Game 85: 7 red, 7 blue, 3 green; 5 green, 1 blue; 6 red, 11 green, 7 blue
Game 86: 9 green, 6 blue, 6 red; 3 red, 2 blue, 7 green; 4 red, 4 green, 7 blue; 10 blue, 10 green, 2 red; 5 green
Game 87: 6 green, 5 blue; 15 blue, 9 green, 1 red; 14 blue, 15 green
Game 88: 3 blue, 2 green, 5 red; 8 blue, 1 green, 2 red; 5 red, 8 blue, 1 green; 1 red, 1 blue; 1 green, 6 red, 2 blue; 1 green, 2 red, 1 blue
Game 89: 4 blue, 3 green; 1 blue, 2 red; 2 red, 1 green, 4 blue; 2 red, 2 blue, 1 green
Game 90: 2 green, 1 red; 3 green, 8 red; 1 blue, 6 red, 4 green
Game 91: 3 red; 1 blue, 6 red; 1 blue, 5 red, 1 green
Game 92: 6 red, 9 green, 7 blue; 9 green, 4 red; 2 green, 5 blue
Game 93: 7 green, 1 red; 3 blue, 3 red; 3 green, 9 red, 4 blue; 2 red, 6 green; 5 red, 3 blue
Game 94: 4 green, 11 red; 13 green, 9 red; 16 green, 11 red; 6 green, 2 blue, 14 red; 17 green, 9 red
Game 95: 7 red, 13 blue, 2 green; 8 green, 13 blue, 3 red; 5 green, 6 red, 13 blue; 8 green, 8 blue, 2 red; 6 blue, 4 green, 8 red; 2 blue, 2 red
Game 96: 10 red, 3 blue, 3 green; 2 blue, 4 green, 5 red; 7 blue, 4 green, 6 red; 1 green, 4 red, 5 blue
Game 97: 5 red, 8 blue; 4 green, 2 red, 14 blue; 10 blue, 7 green
Game 98: 1 red, 2 green, 14 blue; 6 green, 1 blue; 19 blue, 4 red; 18 blue, 4 red, 3 green; 2 red, 1 blue
Game 99: 3 red, 4 blue; 7 red, 5 blue, 3 green; 2 green, 1 blue, 1 red; 4 blue, 2 green, 1 red; 1 green, 1 red, 2 blue; 1 green, 6 blue, 7 red
Game 100: 2 blue, 10 green; 10 green, 14 red; 3 green, 5 red, 2 blue; 1 red, 3 blue, 7 green; 1 blue, 7 red";

    }
}
