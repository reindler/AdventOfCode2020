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

    class Day8 : DayExample
    {
        public Day8() : base("InputDay8.txt")
        {
        }

        public override void Run()
        {
            Part2();
        }


        /**
         * Input:
         *  operation argument
         *   acc, jmp,nop
         *   signed number
         */

        //private static Regex pattern = new Regex(@"([a-z]{3}) [+]{0,1}([-]{0,1}\d+)");
        private void Part1()
        {

            string[] lines = readInputFile();
            int acc = 0;
            HashSet<int> executedLines = new HashSet<int>();
            int curOp;
            bool success = true;
            for (curOp=0; curOp<lines.Length; curOp++) {
                if (!executedLines.Add(curOp)) {
                    success = false;
                    break;
                }
                int index = lines[curOp].IndexOf(" ");
                string operation = lines[curOp].Substring(0, index);
                if (operation == "jmp") {
                    curOp += int.Parse(lines[curOp].Substring(index)) -1; //-1 to counter the curOp++
                } else if (operation == "acc") {
                    acc += int.Parse(lines[curOp].Substring(index));
                } else if (operation == "nop") {
                    // do nothing
                } else {
                    Console.WriteLine("Unknown operation \""+operation+"\"");
                }
            }
            if (!success) {
                Console.WriteLine("Visited " + (curOp+1) + " twice");
            }
            Console.WriteLine("Acc: "+acc);
            Console.ReadKey();
        }

        private void Part2()
        {
            string[] input = readInputFile();
            string[] lines;

            int acc;
            HashSet<int> changedLines = new HashSet<int>();
            LinkedList<int> executedLines = new LinkedList<int>();
            int curOp;
            bool success = true, changed;

            do
            {
                lines = (string[])input.Clone();
                acc = 0;

                if (executedLines.Count <= 0 && !success)
                {
                    Console.WriteLine("FUCK");
                    break;
                }
                if (!success)
                {
                    changed = false;
                    for (int i = executedLines.Count - 1; i >= 0 && !changed; i--)
                    {
                        if (changedLines.Add(executedLines.ElementAt(i)))
                        {
                            if (lines[executedLines.ElementAt(i)].StartsWith("nop"))
                            {
                                lines[executedLines.ElementAt(i)] = lines[executedLines.ElementAt(i)].Replace("nop", "jmp");
                                changed = true;
                            }
                            else if (lines[executedLines.ElementAt(i)].StartsWith("jmp"))
                            {
                                lines[executedLines.ElementAt(i)]=lines[executedLines.ElementAt(i)].Replace("jmp", "nop");
                                changed = true;
                            }
                            else { }
                        }
                    }
                    executedLines.Clear();
                    if (!changed)
                    {
                        Console.WriteLine("FUCK");
                        break;
                    }
                }
                success = true;

                for (curOp = 0; curOp < lines.Length; curOp++)
                {
                    if (executedLines.Contains(curOp))
                    {
                        success = false;
                        break;
                    }
                    else
                    {
                        executedLines.AddLast(curOp);
                    }

                    int index = lines[curOp].IndexOf(" ");
                    string operation = lines[curOp].Substring(0, index);
                    if (operation == "jmp")
                    {
                        curOp += int.Parse(lines[curOp].Substring(index)) - 1; //-1 to counter the curOp++
                    }
                    else if (operation == "acc")
                    {
                        acc += int.Parse(lines[curOp].Substring(index));
                    }
                    else if (operation == "nop")
                    {
                        // do nothing
                    }
                    else
                    {
                        Console.WriteLine("Unknown operation \"" + operation + "\"");
                    }
                }
            } while (!success);
            Console.WriteLine("Acc: " + acc);
            Console.ReadKey();
        }
    }

}
