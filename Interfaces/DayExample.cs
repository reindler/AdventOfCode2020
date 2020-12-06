using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Interfaces
{
    abstract class DayExample
    {
        protected readonly string inputFile;

        public DayExample() { }

        protected DayExample(string inputFile) {
            this.inputFile = inputFile;
        }
        public abstract void Run();

        protected string[] readInputFile()
        {
            return File.ReadAllLines("Input/" + inputFile);
        }

        protected string readInputFileSingleString()
        {
            return File.ReadAllText("Input/" + inputFile);
        }
    }
}
