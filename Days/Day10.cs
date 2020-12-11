using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace AdventOfCode.Days
{
    class Day10 : DayExample
    {
        public Day10() : base("InputDay10.txt")
        {
        }

        public override void Run()
        {
            Part2();
        }

        private void Part1()
        {
            ushort[] array = readInputFileSingleString().Split('\n').Select(ushort.Parse).ToArray();
            Array.Sort(array);
            ushort[] counter = new ushort[] {0,0,0};
            counter[array[0]-1]++;
            for (int i = 1; i < array.Length; i++) {
                counter[(array[i] - array[i - 1])-1]++;
            }
            counter[2]++;
            Console.WriteLine(counter[0]*counter[2]);
            Console.ReadKey();
        }

        private void Part2()
        {
            string input = readInputFileSingleString() + "\n0"; //0 is the start
            ushort[] array = readInputFileSingleString().Split('\n').Select(ushort.Parse).ToArray();
            ulong[] preValues = new ulong[4];
            Array.Sort(array);

            for (int j = 0; j < 3 && array[j] <= 3; j++)
            {
                preValues[j] = 1;
            }

            for (int i = 0; i < array.Length; i++)
            {
                preValues[(i+3) % 4] = 0;
                for (int j = 1; j <= 3 && (i + j) < array.Length && array[i + j] - array[i] <= 3; j++)
                {
                    preValues[(i + j)%4] += preValues[(i)%4];
                }
            }
            Console.WriteLine(preValues[(array.Length - 1)%4]);
            Console.ReadKey();
        }
    }

}
