using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace AdventOfCode.Days
{
    class Day9 : DayExample
    {
        public Day9() : base("InputDay9.txt")
        {
        }

        public override void Run()
        {
            Part2();
        }

        private void Part1()
        {
            string input = readInputFileSingleString();
            long[] array = input.Split('\n').Select(long.Parse).ToArray();
            int curIndex;
            bool success = true;
            for (curIndex = 25; curIndex < array.Length && success; curIndex++) {
                success = false;
                for (int i = curIndex - 25; i < curIndex-1 && !success; i++) {
                    for (int j = i + 1; j < curIndex && !success; j++) {
                        if (array[i]+array[j]==array[curIndex]) {
                            success = true;
                        }
                    }
                }
            }
            Console.WriteLine("Weakness at array["+(curIndex-1)+"]: "+ array[curIndex-1]);
            Console.ReadKey();
        }

        private void Part2()
        {
            string input = readInputFileSingleString();
            long[] array = input.Split('\n').Select(long.Parse).ToArray();
            int curIndex;
            bool success = true;
            for (curIndex = 25; curIndex < array.Length && success; curIndex++)
            {
                success = false;
                for (int i = curIndex - 25; i < curIndex - 1 && !success; i++)
                {
                    for (int j = i + 1; j < curIndex && !success; j++)
                    {
                        if (array[i] + array[j] == array[curIndex])
                        {
                            success = true;
                        }
                    }
                }
            }

            long weaknessValue = array[curIndex - 1];
            Console.WriteLine("Weakness at array[" + (curIndex - 1) + "]: " + weaknessValue);

            long sum = array[0];
            int lowerIndex = 0, upperIndex = 0;
            success = true;

            while (sum != weaknessValue && success) {
                if (sum < weaknessValue) {
                    upperIndex++;
                    if (upperIndex >= array.Length)
                    {
                        Console.WriteLine("Reached end unsuccessful");
                        success = false;
                    }
                    else {
                        sum += array[upperIndex];
                    }
                }
                if (sum > weaknessValue) {
                    sum -= array[lowerIndex];
                    lowerIndex++;

                    if (lowerIndex >= array.Length)
                    {
                        Console.WriteLine("Reached end unsuccessful (with lowerIndex?)");
                        success = false;
                    }
                }
            }

            if (success)
            {
                long smallest = long.MaxValue, largest = long.MinValue;
                for (int i = lowerIndex; i <= upperIndex && i < array.Length; i++)
                {
                    if (i != lowerIndex) {
                        Console.Write(" + ");
                    }
                    Console.Write(array[i]);
                    if (smallest > array[i]) { smallest = array[i]; }
                    if (largest < array[i]) { largest = array[i]; }
                }
                Console.WriteLine(" = " + weaknessValue);
                Console.Write(smallest + " + " + largest + " = " + (smallest + largest));
            }
            Console.ReadKey();
        }
    }

}
