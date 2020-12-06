using AdventOfCode.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{

    class Day4 : DayExample
    {
        public Day4() : base("InputDay4.txt")
        {
        }

        public override void Run()
        {
            Part2();
        }

        private static Regex pattern = new Regex(@"(?:(?:\S+:\S+\s)+(?:\S+:\S+))");
        private static Regex pattern2 = new Regex(@"(\S+):(\S+)");

        string[] fields = new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", "cid" };
        byte notReqFields = 0b_10000000;

        private void Part1()
        {
            string input = readInputFileSingleString();
            int OK = 0, NOK = 0;

            MatchCollection matches = pattern.Matches(input);
            foreach (Match match in matches)
            {
                MatchCollection matches2 = pattern2.Matches(match.Value);
                byte reqCheck = 0;

                foreach (Match match2 in matches2)
                {
                    int index = Array.IndexOf(fields, match2.Groups[1].Value);
                    if (index >= 0)
                    {
                        reqCheck = (byte)(reqCheck ^ (1 << index));
                    }
                }

                if ((reqCheck | notReqFields) == 0b_11111111)
                {
                    OK++;
                }
                else
                {
                    NOK++;
                }
            }
            Console.WriteLine("OK:  " + OK);
            Console.WriteLine("NOK: " + NOK);
            Console.ReadKey();
        }

        private void Part2()
        {
            
            string input = readInputFileSingleString();
            int OK = 0, NOK = 0;
            DateTime starttime = System.DateTime.Now;

            MatchCollection matches = pattern.Matches(input);
            //foreach (Match match in matches)
            Parallel.ForEach(matches.OfType<Match>(), (match) => {
                MatchCollection matches2 = pattern2.Matches(match.Value);
                byte reqCheck = 0;

                foreach (Match match2 in matches2)
                {
                    int index = Array.IndexOf(fields, match2.Groups[1].Value);
                    if (index >= 0 && Validator.isValid(match2.Groups[1].Value, match2.Groups[2].Value))
                    {
                        reqCheck = (byte)(reqCheck ^ (1 << index));
                    }
                }

                if ((reqCheck | notReqFields) == 0b_11111111)
                {
                        Interlocked.Increment(ref OK);
                }
                /*else
                {
                    NOK++;
                }*/
            });
            double ms = (DateTime.Now - starttime).TotalMilliseconds;
            Console.WriteLine(ms);
            Console.WriteLine("OK:  " + OK);
            Console.WriteLine("NOK: " + NOK);
            Console.ReadKey();
        }

        class Validator
        {
            private static readonly string[] validEyeColors = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
            private static readonly Regex colorPattern = new Regex(@"^#[0-9|a-f]{6}$");
            public static bool isValid(string type, string data)
            {
                bool isValid = false;
                int value;

                switch (type)
                {
                    case "byr":
                    case "iyr":
                    case "eyr":
                        if (data.Length == 4 && int.TryParse(data, out value))
                        {
                            if ("byr".Equals(type) && value >= 1920 && value <= 2002)
                            {
                                isValid = true;
                            }
                            else if ("iyr".Equals(type) && value >= 2010 && value <= 2020)
                            {
                                isValid = true;
                            }
                            else if ("eyr".Equals(type) && value >= 2020 && value <= 2030)
                            {
                                isValid = true;
                            }
                        }
                        break;
                    case "hgt":
                        if (int.TryParse(data.Substring(0, data.Length - 2), out value))
                        {
                            string unit = data.Substring(data.Length - 2);
                            if ("cm".Equals(unit) && value >= 150 && value <= 193)
                            {
                                isValid = true;
                            }
                            else if ("in".Equals(unit) && value >= 59 && value <= 76)
                            {
                                isValid = true;
                            }
                        }
                        
                        break;
                    case "hcl":
                        if (colorPattern.Match(data).Success) {
                            isValid = true;
                        }
                        break;
                    case "ecl":
                        if (Array.IndexOf(validEyeColors, data) >= 0) {
                            isValid = true;
                        }
                        break;
                    case "pid":
                            if (data.Length == 9 && int.TryParse(data, out value))
                            {
                                isValid = true;
                            }
                            break;
                    case "cid":
                        isValid = true;
                        break;

                }
                return isValid;
            }
        }

    }

}
