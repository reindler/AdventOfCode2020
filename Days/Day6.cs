using AdventOfCode.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace AdventOfCode.Days
{

    class Day6 : DayExample
    {
        public Day6() : base("InputDay6.txt")
        {
        }

        public override void Run()
        {
            Part2();
        }

        private static Regex pattern = new Regex(@"\s\s\s\s");
        private void Part1()
        {
            string input = readInputFileSingleString();
            int count = 0;
            HashSet<char> set = new HashSet<char>();

            foreach (string line in pattern.Split(input))
            {
                set.Clear();
                
                foreach(char c in line) {
                    if (c != '\n' && c != '\r')
                    {
                        set.Add(c);
                    }
                }
                count += set.Count;
            }
            Console.WriteLine(count);
            Console.ReadKey();
        }

        private void Part2()
        {
            string input = readInputFileSingleString();
            int count = 0;
            //MatchCollection matches = pattern.Matches(input);

            HashSet<char> set = new HashSet<char>();
            HashSet<char> fullSet = new HashSet<char>();
            char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            foreach (string line in pattern.Split(input))
            {
                set.Clear();
                fullSet = new HashSet<char>(letters);

                foreach (char c in line)
                {
                    if (c != '\n' && c != '\r')
                    {
                        set.Add(c);
                    }
                    else if (c == '\n')
                    {
                        fullSet.IntersectWith(set);
                        set.Clear();
                    }
                }
                fullSet.IntersectWith(set);
                count += fullSet.Count;
            }
            Console.WriteLine(count);
            Console.ReadKey();
            Console.ReadKey();
        }
    }

}
