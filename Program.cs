﻿using AdventOfCode.Puzzle;
using System.Diagnostics;

namespace AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDayPuzzle puzzle = new Day20();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string result = puzzle.ExecutePart1();
            sw.Stop();

            Console.WriteLine($"Le résultat du jour ({puzzle.GetType().Name}) est : {result}\n\n");
            Console.WriteLine($"Durée d'exécution : {sw.ElapsedMilliseconds} ms");
        }
    }
}