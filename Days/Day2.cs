using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    
    class Day2 : DayExample
    {

        private static Regex pattern = new Regex(@"(\d*)-(\d*) (\D): (\D*)");

        public Day2() : base("InputDay2.txt") {
        }

        public override void Run()
        {
            Part2();
        }

        private void Part1() {
            int OK=0, NOK=0, parseNOK=0;

            string[] lines = readInputFile();
            Parallel.ForEach(lines, line =>
            {
                Match match = pattern.Match(line);
                if (match.Success)
                {
                    //Console.WriteLine(match.Groups[1] + " / " + match.Groups[2] + " / " + match.Groups[3] + " / " + match.Groups[4]);
                    int lowerT, upperT;
                    if (int.TryParse(match.Groups[1].Value, out lowerT) && int.TryParse(match.Groups[2].Value, out upperT))
                    {
                        int freq = match.Groups[4].Value.Count(f => (f == match.Groups[3].Value.First()));
                        if (freq >= lowerT && freq <= upperT)
                        {
                            OK++;
                        }
                        else {
                            NOK++;
                        }
                    }
                    else {
                        parseNOK++;
                    }
                    
                }
                else {
                    Console.WriteLine(line + " not matched");
                }
            });
            Console.WriteLine("OK: " + OK);
            Console.WriteLine("NOK: " + NOK);
            Console.WriteLine("parseNOK: " + parseNOK);
            Console.ReadKey();
        }

        private void Part2() {
            int OK = 0, NOK = 0, parseNOK = 0;

            string[] lines = readInputFile();
            Parallel.ForEach(lines, line =>
            {
                Match match = pattern.Match(line);
                if (match.Success)
                {
                    //Console.WriteLine(match.Groups[1] + " / " + match.Groups[2] + " / " + match.Groups[3] + " / " + match.Groups[4]);
                    int lowerT, upperT;
                    if (int.TryParse(match.Groups[1].Value, out lowerT) && int.TryParse(match.Groups[2].Value, out upperT))
                    {
                        lowerT--;
                        upperT--;
                        try
                        {
                            if ((match.Groups[4].Value.ElementAt(lowerT) == match.Groups[3].Value.First() && match.Groups[4].Value.ElementAt(upperT) != match.Groups[3].Value.First()) ||
                               (match.Groups[4].Value.ElementAt(lowerT) != match.Groups[3].Value.First() && match.Groups[4].Value.ElementAt(upperT) == match.Groups[3].Value.First()))
                            {
                                OK++;
                            }
                            else
                            {
                                NOK++;
                            }
                        }
                        catch (Exception ex)
                        {
                            parseNOK++;
                            Console.WriteLine(line);
                        }
                    }
                    else
                    {
                        parseNOK++;
                    }

                }
                else
                {
                    Console.WriteLine(line + " not matched");
                }
            });
            Console.WriteLine("OK: " + OK);
            Console.WriteLine("NOK: " + NOK);
            Console.WriteLine("parseNOK: " + parseNOK);
            Console.ReadKey();
        }
    }

}
