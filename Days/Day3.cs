using AdventOfCode.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Numerics;

namespace AdventOfCode.Days
{

    class Day3 : DayExample
    {

        private char emptyField = '.', treeField = '#';

        public Day3() : base("InputDay3.txt")
        {
        }

        public override void Run()
        {
            Part2();
        }

        private void Part1()
        {
            int vertMov = 1, horMov = 3;
            int tree = 0, empty = 0, other = 0;

            string[] lines = readInputFile();
            Parallel.ForEach(lines, (line, pls, rownumber) =>
            {
                if (rownumber % vertMov == 0)
                {
                    char element = line.ElementAt((int)rownumber * horMov % line.Length);
                    if (element == emptyField)
                    {
                        empty++;
                    }
                    else if (element == treeField)
                    {
                        tree++;
                    }
                    else
                    {
                        other++;
                    }
                }
            });
            Console.WriteLine("empty: " + empty);
            Console.WriteLine("tree: " + tree);
            Console.WriteLine("other: " + other);
            Console.ReadKey();
        }

        private void Part2()
        {
            /*
                Right 1, down 1.
                Right 3, down 1. (This is the slope you already checked.)
                Right 5, down 1.
                Right 7, down 1.
                Right 1, down 2.
            */
            DateTime time = System.DateTime.Now;

            int val1 = getTrees(1, 1);
            int val2 = getTrees(1, 3);
            int val3 = getTrees(1, 5);
            int val4 = getTrees(1, 7);
            int val5 = getTrees(2, 1);

            System.Numerics.BigInteger result = val1;
            result *= val2;
            result *= val3;
            result *= val4;
            result *= val5;

            double asd = (System.DateTime.Now-time).TotalMilliseconds;
            Console.WriteLine("Result: " + val1 + " * " + val2 + " * " + val3 + " * " + val4 + " * " + val5 + " = " + result);
            Console.WriteLine("ms needed: "+asd);
            Console.ReadKey();
        }

        private int getTrees(int vertMov, int horMov) {

            int tree = 0, empty = 0, other = 0;

            string[] lines = readInputFile();
            Parallel.ForEach(lines, (line, pls, rownumber) =>
            {
                if (rownumber % vertMov == 0)
                {
                    char element = line.ElementAt((int)(rownumber/ (vertMov * horMov)) % line.Length);
                    if (element == emptyField)
                    {
                        Interlocked.Increment(ref empty);
                    }
                    else if (element == treeField)
                    {
                        Interlocked.Increment(ref tree);
                    }
                    else
                    {
                        Interlocked.Increment(ref other);
                    }
                }
            });

            return tree;
        }
    }

}
