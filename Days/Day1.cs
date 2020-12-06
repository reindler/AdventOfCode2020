using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    
    class Day1 : DayExample
    {

        private const int findValue = 2020;

        public Day1() : base("InputDay1.txt") {
        }

        public override void Run()
        {
            Part2();
        }

        private void Part1() {
            string[] input = readInputFile();
            int val1 = 0, val2 = 0;
            bool run = true;

            for (int i = 0; i < input.Length && run; i++)
            {
                if (int.TryParse(input[i], out val1))
                {
                    for (int j = i + 1; j < input.Length && run; j++)
                    {
                        if (int.TryParse(input[j], out val2))
                        {
                            if (val1 + val2 == findValue)
                            {
                                run = false;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(val1 + " * " + val2 + " = " + (val1 * val2));
            Console.ReadKey();
        }

        private void Part2() {
            string[] input = readInputFile();
            int val1 = 0, val2 = 0, val3 = 0;
            bool run = true;

            for (int i = 0; i < input.Length && run; i++)
            {
                if (int.TryParse(input[i], out val1))
                {
                    for (int j = i + 1; j < input.Length && run; j++)
                    {
                        if (int.TryParse(input[j], out val2))
                        {
                            for (int k = j + 1; k < input.Length && run; k++)
                            {
                                if (int.TryParse(input[k], out val3))
                                {
                                    if (val1 + val2 + val3 == findValue)
                                    {
                                        run = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(val1 + " * " + val2 + " * " + val3 + " = " + (val1 * val2 * val3));
            Console.ReadKey();
        }
    }

}
