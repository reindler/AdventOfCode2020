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

    class Day5 : DayExample
    {
        public Day5() : base("InputDay5.txt")
        {
        }

        public override void Run()
        {
            Part2();
        }

        private void Part1()
        {
            string[] lines = readInputFile();
            short maxId = 0;

            foreach (string line in lines) {
                short place = 0;
                foreach (char c in line) {
                    place <<= 1; 
                    if (c == 'B' || c=='R') {
                        place ^= 1;
                    }
                }
                if(maxId<place) maxId = place;
            }
            Console.WriteLine(maxId);
            Console.ReadKey();
        }

        private void Part2()
        {
            string[] lines = readInputFile();
            List<short> list = new List<short>();

            foreach (string line in lines)
            {
                short place = 0;
                foreach (char c in line)
                {
                    place <<= 1;
                    if (c == 'B' || c == 'R')
                    {
                        place ^= 1;
                    }
                }
                list.Add(place);
            }
            list.Sort();

            for (int i = 0; i < list.Count-1; i++) {
                if (list.ElementAt(i) +2 == list.ElementAt(i + 1)) {
                    Console.WriteLine(list.ElementAt(i) + 1);
                    break;
                }
            }
            
            Console.ReadKey();
        }
    }

}
